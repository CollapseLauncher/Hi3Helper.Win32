using Hi3Helper.Win32.Native.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;
using static Hi3Helper.Win32.Native.LibraryImport.PInvoke;
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.ManagedTools
{
    public static class MiniDump
    {
        /// <summary>
        /// Try to create a minidump of the specified process.
        /// </summary>
        /// <typeparam name="TSafeHandle">A safe handle type of <see cref="SafeHandle"/></typeparam>
        /// <param name="processToDump">The target instance of <see cref="Process"/> to dump.</param>
        /// <param name="fileHandle">A pointer to the handle of FILE.</param>
        /// <param name="error">The exception output if an error occur.</param>
        /// <param name="includeFullMemory">Whether to include a full memory dump or just a minimal dump.</param>
        /// <param name="logger">Logger, set null to ignore logging</param>
        /// <returns>
        /// This returns <c>true</c> if the dump is created successfully; otherwise, <c>false</c>.
        /// </returns>
        public static bool TryCreateMiniDump<TSafeHandle>(
            Process        processToDump,
            TSafeHandle    fileHandle,
            out Exception? error,
            bool           includeFullMemory = false,
            ILogger?       logger            = null)
            where TSafeHandle : SafeHandle
        {
            error = null;
            MiniDumpType dumpType = MiniDumpType.Normal;

            if (includeFullMemory)
            {
                dumpType |= MiniDumpType.WithFullMemory |
                            MiniDumpType.WithHandleData |
                            MiniDumpType.WithThreadInfo |
                            MiniDumpType.WithUnloadedModules;
            }
            else
            {
                dumpType |= MiniDumpType.WithPrivateReadWriteMemory |
                            MiniDumpType.FilterMemory |
                            MiniDumpType.WithDataSegs |
                            MiniDumpType.WithIndirectlyReferencedMemory;
            }


            SafeHandleMarshaller<TSafeHandle>.ManagedToUnmanagedIn marshalIn = new();
            marshalIn.FromManaged(fileHandle);
            try
            {
                nint hFile = marshalIn.ToUnmanaged();

                logger?.LogTrace("[MiniDump::TryCreateMiniDump()] Writing to handle: {handle}", hFile);
                bool result = MiniDumpWriteDump(processToDump.Handle,
                                                processToDump.Id,
                                                hFile,
                                                dumpType,
                                                nint.Zero,
                                                nint.Zero,
                                                nint.Zero);

                if (result)
                {
                    return true;
                }

                error = Marshal.GetExceptionForHR(Marshal.GetLastPInvokeError());
                return false;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
            finally
            {
                marshalIn.Free();
                if (error != null)
                {
                    logger?.LogError(error, "[MiniDump::TryCreateMiniDump()] Failed to create minidump! Error: {err}", error);
                }
            }
        }

        /// <summary>
        /// Create a minidump of the specified process.
        /// </summary>
        /// <param name="filePath">Full path to write the file to</param>
        /// <param name="processToDump">Target process</param>
        /// <param name="includeFullMemory">Whether to include the entire memory file</param>
        /// <param name="logger">Logger, set null to ignore logging</param>
        /// <returns>True if debug file is created successfully</returns>
        public static Task<bool> CreateMiniDumpAsync(
            string   filePath,
            Process  processToDump,
            bool     includeFullMemory = false,
            ILogger? logger            = null)
        {
            return Task.Factory.StartNew(() =>
            {
                using FileStream fs = File.Create(filePath);

                try
                {
                    if (!TryCreateMiniDump(processToDump,
                                           fs.SafeFileHandle,
                                           out Exception? error,
                                           includeFullMemory,
                                           logger)) return error != null ? throw error : false;

                    logger?.LogInformation("""
                                           [MiniDump::CreateMiniDumpAsync()] Minidump created successfully at {filePath}
                                           ID: {processToDump.Id}
                                           Process Name: {processToDump.ProcessName}
                                           Include Full Memory: {includeFullMemory}
                                           Dump File Size: {fs.Length} bytes
                                           """,
                                           filePath,
                                           processToDump.Id,
                                           processToDump.ProcessName,
                                           includeFullMemory,
                                           fs.Length);
                    return true;
                }
                catch (Exception ex)
                {
                    logger?.LogError(ex, "[MiniDump::CreateMiniDumpAsync()] Failed to create minidump! Error: {ex}", ex);
                    return false;
                }
            });
        }

        /// <inheritdoc cref="CreateMiniDumpAsync"/>
        public static bool CreateMiniDump(
            string   filePath,
            Process  processToDump,
            bool     includeFullMemory = false,
            ILogger? logger            = null)
            => CreateMiniDumpAsync(filePath, processToDump, includeFullMemory, logger).Result;
    }
}