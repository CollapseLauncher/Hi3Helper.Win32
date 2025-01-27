using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using Microsoft.Extensions.Logging;
using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
// ReSharper disable RedundantUnsafeContext

namespace Hi3Helper.Win32.Native.ManagedTools
{
    public static class ProcessChecker
    {
        // https://github.com/dotnet/runtime/blob/f4d39134b8daefb5ab0db6750a203f980eecb4f0/src/libraries/System.Diagnostics.Process/src/System/Diagnostics/ProcessManager.Win32.cs#L299
        // https://github.com/dotnet/runtime/blob/f4d39134b8daefb5ab0db6750a203f980eecb4f0/src/libraries/System.Diagnostics.Process/src/System/Diagnostics/ProcessManager.Win32.cs#L346
        // https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/Interop/Windows/NtDll/Interop.NtQuerySystemInformation.cs#L11

        private const int SystemProcessInformation = 5;
        private const int QueryLimitedInformation = 0x1000;

        private const int  DefaultNtQueryChangedLen = 4 << 17;
        private const nint InvalidHandleValue = -1;
        private const int  ProcessSetInformation = 0x0200;
        private static int _dynamicNtQueryChangedBufferLen = DefaultNtQueryChangedLen;

        public static unsafe bool IsProcessExist(int processId)
        {
            // Get the handler and return true if procHandler is not null
            nint procHandler = PInvoke.OpenProcess(QueryLimitedInformation, false, processId);
            if (procHandler != nint.Zero)
            {
                PInvoke.CloseHandle(procHandler);
                return true;
            }

            // Otherwise, return false
            return false;
        }

        public static unsafe bool IsProcessExist(ReadOnlySpan<char> processName, out int processId, out nint windowHandle, string checkForOriginPath = "", ILogger? logger = null)
            => IsProcessExist(processName, out processId, out windowHandle, checkForOriginPath, false, logger);

        public static unsafe bool IsProcessExist(ReadOnlySpan<char> processName, out int processId, out nint windowHandle, string checkForOriginPath = "", bool useStartsWithMatch = true, ILogger? logger = null)
        {
            // Set default process id number to 0
            processId = 0;
            windowHandle = nint.Zero;

            // If the buffer length is more than 2 MiB, then reset the length to default
            if (_dynamicNtQueryChangedBufferLen > 2 << 20)
            {
                _dynamicNtQueryChangedBufferLen = DefaultNtQueryChangedLen;
            }

            // Initialize the first buffer to 512 KiB
            ArrayPool<byte> arrayPool = ArrayPool<byte>.Shared;
            byte[] ntQueryCachedBuffer = arrayPool.Rent(_dynamicNtQueryChangedBufferLen);
            bool isReallocate = false;
            // ReSharper disable once RedundantAssignment

            // Get size of UNICODE_STRING struct
            int sizeOfUnicodeString = sizeof(UNICODE_STRING);

        StartOver:
            try
            {
                // If the buffer request is more than 2 MiB, then return false
                if (_dynamicNtQueryChangedBufferLen > 2 << 20)
                    return false;

                // If buffer reallocation is requested, then re-rent the buffer
                // from ArrayPool<T>.Shared
                if (isReallocate)
                    ntQueryCachedBuffer = arrayPool.Rent(_dynamicNtQueryChangedBufferLen);

                // Get the pointer of the buffer
                byte* dataBufferPtr = (byte*)Marshal.UnsafeAddrOfPinnedArrayElement(ntQueryCachedBuffer, 0);
                {
                    // Get the query of the current running process and store it to the buffer
                    uint hNtQuerySystemInformationResult = PInvoke.NtQuerySystemInformation(SystemProcessInformation, dataBufferPtr, (uint)ntQueryCachedBuffer.Length, out uint length);

                    // If the required length of the data is exceeded than the current buffer,
                    // then try to reallocate and start over to the top.
                    const uint statusInfoLengthMismatch = 0xC0000004;
                    if (hNtQuerySystemInformationResult == statusInfoLengthMismatch || length > ntQueryCachedBuffer.Length)
                    {
                        // Round up length
                        _dynamicNtQueryChangedBufferLen = (int)BitOperations.RoundUpToPowerOf2(length);
                        logger?.LogWarning($"Buffer requested is insufficient! Requested: {length} > Capacity: {ntQueryCachedBuffer.Length}, Resizing the buffer...");
                        isReallocate = true;
                        goto StartOver;
                    }

                    // If other error has occurred, then return false as failed.
                    if (hNtQuerySystemInformationResult != 0)
                    {
                        logger?.LogError($"Error happened while operating NtQuerySystemInformation(): {Win32Error.GetLastWin32ErrorMessage()}");
                        return false;
                    }

                    // Start reading data from the buffer
                    int currentOffset = 0;
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
                    ReadOnlySpan<char> imageNameSpan = new(unicodeString->Buffer, unicodeString->Length / 2);
                    bool isMatchedExecutable = !useStartsWithMatch ? 
                        imageNameSpan.Equals(processName, StringComparison.OrdinalIgnoreCase) :
                        imageNameSpan.StartsWith(processName, StringComparison.OrdinalIgnoreCase);

                    if (isMatchedExecutable)
                    {
                        // Move the offset of the current pointer and get the processId value
                        processId = *(int*)(curPosPtr + 56 + sizeOfUnicodeString + 8);

                        // Try find the window id and assign it to windowHandle
                        windowHandle = MainWindowFinder.FindMainWindow(processId);

                        // If the origin path argument is null, then return as true.
                        if (string.IsNullOrEmpty(checkForOriginPath))
                            return true;

                        // Try open the process and get the handle
                        nint processHandle = PInvoke.OpenProcess(QueryLimitedInformation, false, processId);

                        // If failed, then log the Win32 error and return false.
                        if (processHandle == InvalidHandleValue
                         || processHandle == nint.Zero)
                        {
                            logger?.LogError($"Error happened while operating OpenProcess(): {Win32Error.GetLastWin32ErrorMessage()}");
                            return false;
                        }

                        // If the string is not null, then check if the file path is exactly the same.
                        // START!!

                        // Try rent the new buffer to get the command line
                        const int bufferProcessCmdLen       = 1 << 10;
                        int       bufferProcessCmdLenReturn = bufferProcessCmdLen;
                        char[]    bufferProcessCmd          = ArrayPool<char>.Shared.Rent(bufferProcessCmdLen);
                        try
                        {
                            // Cast processCmd buffer as pointer
                            char* bufferProcessCmdPtr = (char*)Marshal.UnsafeAddrOfPinnedArrayElement(bufferProcessCmd, 0);
                            {
                                // Get the command line query of the process
                                bool hQueryFullProcessImageNameResult = PInvoke.QueryFullProcessImageName(processHandle, 0, bufferProcessCmdPtr, ref bufferProcessCmdLenReturn);
                                // If the query is unsuccessful, then log the Win32 error and return false.
                                if (!hQueryFullProcessImageNameResult)
                                {
                                    logger?.LogError($"Error happened while operating QueryFullProcessImageName(): {Win32Error.GetLastWin32ErrorMessage()}");
                                    return false;
                                }

                                // If the requested return length is more than capacity (-2 for null terminator), then return false.
                                if (bufferProcessCmdLenReturn > bufferProcessCmdLen - 2)
                                {
                                    logger?.LogError($"The process command line length is more than requested length: {bufferProcessCmdLen - 2} < return {bufferProcessCmdLenReturn}");
                                    return false;
                                }

                                // Get the command line query
                                ReadOnlySpan<char> processCmdLineSpan = new(bufferProcessCmdPtr, bufferProcessCmdLenReturn);

                                // Get the span of origin path to compare
                                ReadOnlySpan<char> checkForOriginPathDir = checkForOriginPath;

                                // Compare and return if any of result is equal
                                bool isCommandPathEqual = !useStartsWithMatch ? 
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

                            // Close the OpenProcess handle
                            PInvoke.CloseHandle(processHandle);
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
                arrayPool.Return(ntQueryCachedBuffer);
            }

            return false;
        }

        public static unsafe string? GetProcessPathByProcessId(int processId, ILogger? logger = null)
        {
            // Try open the process and get the handle
            nint processHandle = PInvoke.OpenProcess(QueryLimitedInformation, false, processId);

            // If failed, then log the Win32 error and return null.
            if (processHandle == nint.Zero)
            {
                logger?.LogError($"Error happened while operating OpenProcess(): {Win32Error.GetLastWin32ErrorMessage()}");
                return null;
            }

            // Try rent the new buffer to get the command line
            int bufferProcessCmdLen = 1 << 10;
            int bufferProcessCmdLenReturn = bufferProcessCmdLen;
            char[] bufferProcessCmd = ArrayPool<char>.Shared.Rent(bufferProcessCmdLen);

            try
            {
                // Cast processCmd buffer as pointer
                char* bufferProcessCmdPtr = (char*)Marshal.UnsafeAddrOfPinnedArrayElement(bufferProcessCmd, 0);
                {
                    // Get the command line query of the process
                    bool hQueryFullProcessImageNameResult = PInvoke.QueryFullProcessImageName(processHandle, 0, bufferProcessCmdPtr, ref bufferProcessCmdLenReturn);
                    // If the query is unsuccessful, then log the Win32 error and return false.
                    if (!hQueryFullProcessImageNameResult)
                    {
                        logger?.LogError($"Error happened while operating QueryFullProcessImageName(): {Win32Error.GetLastWin32ErrorMessage()}");
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
                // Return the buffer
                ArrayPool<char>.Shared.Return(bufferProcessCmd);

                // Close the process handle
                PInvoke.CloseHandle(processHandle);
            }
        }

        public static nint GetProcessWindowHandle(string procName) => Process.GetProcessesByName(Path.GetFileNameWithoutExtension(procName), ".")[0].MainWindowHandle;

        public static Process[] GetInstanceProcesses()
        {
            Process   currentProcess = Process.GetCurrentProcess();
            Process[] processes      = Process.GetProcessesByName(currentProcess.ProcessName);

            return processes;
        }

        public static int EnumerateInstances(ILogger? logger = null)
        {
            Process[] instanceProc = GetInstanceProcesses();
            int instanceCount = instanceProc.Length;

            int finalInstanceCount = 0;

            if (instanceCount > 1)
            {
                int curPId = Environment.ProcessId;
                logger?.LogTrace($"Detected {instanceCount} instances! Current PID: {curPId}");
                logger?.LogTrace("Enumerating instances...");
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
                        logger?.LogError("Failed when trying to fetch an instance information! " +
                                     $"InstanceCount is not incremented.\r\n{ex}");
                        throw;
                    }
                }

                logger?.LogTrace($"Multiple instances found! This is instance #{finalInstanceCount}");
            }
            else finalInstanceCount = 1;

            return finalInstanceCount;
        }

        public static bool TryGetProcessIdWithActiveWindow(string processName,              out int processId,                 out nint windowHandle,
                                                           string checkFromOriginPath = "", bool    useStartsWithMatch = true, ILogger? logger       = null)
        {
            // Try get the process id and window handle
            if (!IsProcessExist(processName, out processId, out windowHandle, checkFromOriginPath, useStartsWithMatch, logger))
            {
                return false;
            }

            // Determine whether the process has window handle initialized.
            return windowHandle != nint.Zero;
        }

        public static bool TrySetProcessPriority(string   processName,              PriorityClass priority,
                                                 string   checkFromOriginPath = "", bool          useStartsWithMatch = true,
                                                 ILogger? logger              = null)
        {
            // Try get the process id
            if (!IsProcessExist(processName, out int processId, out _, checkFromOriginPath, useStartsWithMatch, logger))
            {
                logger?.LogError("Cannot find process for such name: {} at: {}", processName, string.IsNullOrEmpty(checkFromOriginPath) ? "[default]" : checkFromOriginPath);
                return false;
            }

            // Try set the process priority
            return TrySetProcessPriority(processId, priority, logger);
        }

        public static bool TrySetProcessPriority(int processId, PriorityClass priority, ILogger? logger = null)
        {
            // Open the process handle to set the process information
            nint openProcHandle = PInvoke.OpenProcess(ProcessSetInformation, true, processId);
            // Return false if it handles INVALID_HANDLE_VALUE due to permissions (for example: Process protection)
            if (openProcHandle == InvalidHandleValue
             || openProcHandle == nint.Zero)
            {
                PrintErrMessage("Cannot open process handle as it returns INVALID_HANDLE_VALUE or null");
                return false;
            }

            try
            {
                // Try set the priority class of the process
                if (!PInvoke.SetPriorityClass(openProcHandle, priority))
                {
                    // If not, return false
                    PrintErrMessage("Cannot set process priority");
                    return false;
                }

                // Return true as successful
                logger?.LogInformation("Process Id: {} priority has been set to: {}", processId, priority);
                return true;
            }
            finally
            {
                // Close the process handle
                PInvoke.CloseHandle(openProcHandle);
            }

            void PrintErrMessage(string message)
            {
                logger?.LogError("{} for ProccessId: {} to Priority: {}", message, processId, priority);
                logger?.LogError("Error: {}", Win32Error.GetLastWin32ErrorMessage());
            }
        }
    }
}
