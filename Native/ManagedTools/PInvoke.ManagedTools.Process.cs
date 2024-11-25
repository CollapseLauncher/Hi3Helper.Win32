using Hi3Helper.Win32.Native.Structs;
using Microsoft.Extensions.Logging;
using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
// ReSharper disable RedundantUnsafeContext

namespace Hi3Helper.Win32.Native
{
    public static partial class PInvoke
    {
        // https://github.com/dotnet/runtime/blob/f4d39134b8daefb5ab0db6750a203f980eecb4f0/src/libraries/System.Diagnostics.Process/src/System/Diagnostics/ProcessManager.Win32.cs#L299
        // https://github.com/dotnet/runtime/blob/f4d39134b8daefb5ab0db6750a203f980eecb4f0/src/libraries/System.Diagnostics.Process/src/System/Diagnostics/ProcessManager.Win32.cs#L346
        // https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/Interop/Windows/NtDll/Interop.NtQuerySystemInformation.cs#L11

        private const int SystemProcessInformation = 5;
        private const int QueryLimitedInformation = 0x1000;

        private const int DefaultNtQueryChangedLen = 4 << 17;
        private static int DynamicNtQueryChangedBufferLen = DefaultNtQueryChangedLen;

        public static unsafe bool IsProcessExist(int processId) => OpenProcess(QueryLimitedInformation, false, processId) != nint.Zero;

        public static unsafe bool IsProcessExist(ReadOnlySpan<char> processName, out int processId, out nint windowHandle, string checkForOriginPath = "", ILogger? logger = null)
            => IsProcessExist(processName, out processId, out windowHandle, checkForOriginPath, false, logger);

        public static unsafe bool IsProcessExist(ReadOnlySpan<char> processName, out int processId, out nint windowHandle, string checkForOriginPath = "", bool useStartsWithMatch = false, ILogger? logger = null)
        {
            // Set default process id number to 0
            processId = 0;
            windowHandle = nint.Zero;

            // If the buffer length is more than 2 MiB, then reset the length to default
            if (DynamicNtQueryChangedBufferLen > (2 << 20))
            {
                DynamicNtQueryChangedBufferLen = DefaultNtQueryChangedLen;
            }

            // Initialize the first buffer to 512 KiB
            ArrayPool<byte> arrayPool = ArrayPool<byte>.Shared;
            byte[] NtQueryCachedBuffer = arrayPool.Rent(DynamicNtQueryChangedBufferLen);
            bool isReallocate = false;
            // ReSharper disable once RedundantAssignment
            uint length = 0;

            // Get size of UNICODE_STRING struct
            int sizeOfUnicodeString = Marshal.SizeOf<UNICODE_STRING>();

        StartOver:
            try
            {
                // If the buffer request is more than 2 MiB, then return false
                if (DynamicNtQueryChangedBufferLen > (2 << 20))
                    return false;

                // If buffer reallocation is requested, then re-rent the buffer
                // from ArrayPool<T>.Shared
                if (isReallocate)
                    NtQueryCachedBuffer = arrayPool.Rent(DynamicNtQueryChangedBufferLen);

                // Get the pointer of the buffer
                fixed (byte* dataBufferPtr = &NtQueryCachedBuffer[0])
                {
                    // Get the query of the current running process and store it to the buffer
                    uint hNtQuerySystemInformationResult = NtQuerySystemInformation(SystemProcessInformation, dataBufferPtr, (uint)NtQueryCachedBuffer.Length, out length);

                    // If the required length of the data is exceeded than the current buffer,
                    // then try to reallocate and start over to the top.
                    const uint STATUS_INFO_LENGTH_MISMATCH = 0xC0000004;
                    if (hNtQuerySystemInformationResult == STATUS_INFO_LENGTH_MISMATCH || length > NtQueryCachedBuffer.Length)
                    {
                        // Round up length
                        DynamicNtQueryChangedBufferLen = (int)BitOperations.RoundUpToPowerOf2(length);
                        logger?.LogWarning($"Buffer requested is insufficient! Requested: {length} > Capacity: {NtQueryCachedBuffer.Length}, Resizing the buffer...");
                        isReallocate = true;
                        goto StartOver;
                    }

                    // If other error has occurred, then return false as failed.
                    if (hNtQuerySystemInformationResult != 0)
                    {
                        logger?.LogError($"Error happened while operating NtQuerySystemInformation(): {Marshal.GetLastWin32Error()}");
                        return false;
                    }

                    // Start reading data from the buffer
                    int currentOffset = 0;
                    bool isCommandPathEqual;
                ReadQueryData:
                    // Get the current position of the pointer based on its offset
                    byte* curPosPtr = dataBufferPtr + currentOffset;

                    // Get the increment of the next entry offset
                    // and get the struct from the given pointer offset + 56 bytes ahead
                    // to obtain the process name.
                    int nextEntryOffset = *(int*)curPosPtr;
                    UNICODE_STRING* unicodeString = (UNICODE_STRING*)(curPosPtr + 56);

                    // Use the struct buffer into the ReadOnlySpan<char> to be compared with
                    // the input from "processName" argument.
                    ReadOnlySpan<char> imageNameSpan = new ReadOnlySpan<char>(unicodeString->Buffer, unicodeString->Length / 2);
                    bool isMatchedExecutable = !useStartsWithMatch ? 
                        imageNameSpan.Equals(processName, StringComparison.OrdinalIgnoreCase) :
                        imageNameSpan.StartsWith(processName, StringComparison.OrdinalIgnoreCase);

                    if (isMatchedExecutable)
                    {
                        // If the origin path argument is null, then return as true.
                        if (string.IsNullOrEmpty(checkForOriginPath))
                            return true;

                        // If the string is not null, then check if the file path is exactly the same.
                        // START!!

                        // Move the offset of the current pointer and get the processId value
                        processId = *(int*)(curPosPtr + 56 + sizeOfUnicodeString + 8);

                        // Try find the window id and assign it to windowHandle
                        windowHandle = MainWindowFinder.FindMainWindow(processId);

                        // Try open the process and get the handle
                        nint processHandle = OpenProcess(QueryLimitedInformation, false, processId);

                        // If failed, then log the Win32 error and return false.
                        if (processHandle == nint.Zero)
                        {
                            logger?.LogError($"Error happened while operating OpenProcess(): {Marshal.GetLastWin32Error()}");
                            return false;
                        }

                        // Try rent the new buffer to get the command line
                        int bufferProcessCmdLen = 1 << 10;
                        int bufferProcessCmdLenReturn = bufferProcessCmdLen;
                        char[] bufferProcessCmd = ArrayPool<char>.Shared.Rent(bufferProcessCmdLen);
                        try
                        {
                            // Cast processCmd buffer as pointer
                            fixed (char* bufferProcessCmdPtr = &bufferProcessCmd[0])
                            {
                                // Get the command line query of the process
                                bool hQueryFullProcessImageNameResult = QueryFullProcessImageName(processHandle, 0, bufferProcessCmdPtr, ref bufferProcessCmdLenReturn);
                                // If the query is unsuccessful, then log the Win32 error and return false.
                                if (!hQueryFullProcessImageNameResult)
                                {
                                    logger?.LogError($"Error happened while operating QueryFullProcessImageName(): {Marshal.GetLastWin32Error()}");
                                    return false;
                                }

                                // If the requested return length is more than capacity (-2 for null terminator), then return false.
                                if (bufferProcessCmdLenReturn > bufferProcessCmdLen - 2)
                                {
                                    logger?.LogError($"The process command line length is more than requested length: {bufferProcessCmdLen - 2} < return {bufferProcessCmdLenReturn}");
                                    return false;
                                }

                                // Get the command line query
                                ReadOnlySpan<char> processCmdLineSpan = new ReadOnlySpan<char>(bufferProcessCmdPtr, bufferProcessCmdLenReturn);

                                // Get the span of origin path to compare
                                ReadOnlySpan<char> checkForOriginPathDir = checkForOriginPath;

                                // Compare and return if any of result is equal
                                isCommandPathEqual = !useStartsWithMatch ? 
                                    processCmdLineSpan.Equals(checkForOriginPathDir, StringComparison.OrdinalIgnoreCase) :
                                    processCmdLineSpan.StartsWith(checkForOriginPathDir, StringComparison.OrdinalIgnoreCase);

                                if (isCommandPathEqual)
                                    return true;
                            }
                        }
                        finally
                        {
                            // Return the buffer
                            ArrayPool<char>.Shared.Return(bufferProcessCmd);
                        }
                    }

                    // Otherwise, if the next entry offset is not 0 (not ended), then read
                    // the next data and move forward based on the given offset.
                    currentOffset += nextEntryOffset;
                    if (nextEntryOffset != 0)
                        goto ReadQueryData;
                }
            }
            finally
            {
                // Return the buffer to the ArrayPool<T>.Shared
                arrayPool.Return(NtQueryCachedBuffer);
            }

            return false;
        }

        public static unsafe string? GetProcessPathByProcessId(int processId, ILogger? logger = null)
        {
            // Try open the process and get the handle
            nint processHandle = OpenProcess(QueryLimitedInformation, false, processId);

            // If failed, then log the Win32 error and return null.
            if (processHandle == nint.Zero)
            {
                logger?.LogError($"Error happened while operating OpenProcess(): {Marshal.GetLastWin32Error()}");
                return null;
            }

            // Try rent the new buffer to get the command line
            int bufferProcessCmdLen = 1 << 10;
            int bufferProcessCmdLenReturn = bufferProcessCmdLen;
            char[] bufferProcessCmd = ArrayPool<char>.Shared.Rent(bufferProcessCmdLen);

            try
            {
                // Cast processCmd buffer as pointer
                fixed (char* bufferProcessCmdPtr = &bufferProcessCmd[0])
                {
                    // Get the command line query of the process
                    bool hQueryFullProcessImageNameResult = QueryFullProcessImageName(processHandle, 0, bufferProcessCmdPtr, ref bufferProcessCmdLenReturn);
                    // If the query is unsuccessful, then log the Win32 error and return false.
                    if (!hQueryFullProcessImageNameResult)
                    {
                        logger?.LogError($"Error happened while operating QueryFullProcessImageName(): {Marshal.GetLastWin32Error()}");
                        return null;
                    }

                    // If the requested return length is more than capacity (-2 for null terminator), then return false.
                    if (bufferProcessCmdLenReturn > bufferProcessCmdLen - 2)
                    {
                        logger?.LogError($"The process command line length is more than requested length: {bufferProcessCmdLen - 2} < return {bufferProcessCmdLenReturn}");
                        return null;
                    }

                    // Return string
                    return new string(bufferProcessCmdPtr, 0, bufferProcessCmdLenReturn);
                }
            }
            finally
            {
                ArrayPool<char>.Shared.Return(bufferProcessCmd);
            }
        }

        public static nint GetProcessWindowHandle(string ProcName) => Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ProcName), ".")[0].MainWindowHandle;

        public static Process[] GetInstanceProcesses()
        {
            var currentProcess = Process.GetCurrentProcess();
            var processes = Process.GetProcessesByName(currentProcess.ProcessName);

            return processes;
        }

        public static int EnumerateInstances(ILogger? logger = null)
        {
            var instanceProc = GetInstanceProcesses();
            var instanceCount = instanceProc.Length;

            var finalInstanceCount = 0;

            if (instanceCount > 1)
            {
                var curPId = Process.GetCurrentProcess().Id;
                logger?.LogTrace($"Detected {instanceCount} instances! Current PID: {curPId}");
                logger?.LogTrace($"Enumerating instances...");
                foreach (Process p in instanceProc)
                {
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
                    if (p == null) continue;
                    try
                    {
                        if (p.MainWindowHandle == nint.Zero)
                        {
                            logger?.LogTrace("Process does not have window, skipping...");
                            continue;
                        }

                        logger?.LogTrace($"Name: {p.ProcessName}");
                        logger?.LogTrace($"MainModule: {p.MainModule?.FileName}");
                        logger?.LogTrace($"PID: {p.Id}");

                        finalInstanceCount++;
                    }
                    catch (Exception ex)
                    {
                        logger?.LogError($"Failed when trying to fetch an instance information! " +
                                     $"InstanceCount is not incremented.\r\n{ex}");
                        throw;
                    }
                }

                logger?.LogTrace($"Multiple instances found! This is instance #{finalInstanceCount}");
            }
            else finalInstanceCount = 1;

            return finalInstanceCount;
        }
    }
}
