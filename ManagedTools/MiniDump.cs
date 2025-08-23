using Hi3Helper.Win32.Native.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Hi3Helper.Win32.Native.LibraryImport.PInvoke;
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.ManagedTools
{
    public static class MiniDump
    {
        private static ILogger? _logger;

        /// <summary>
        /// Create a minidump of the specified process.
        /// </summary>
        /// <param name="filePath">Full path to write the file to</param>
        /// <param name="processToDump">Target process</param>
        /// <param name="includeFullMemory">Whether to include the entire memory file</param>
        /// <param name="logger">Logger, set null to ignore logging</param>
        /// <returns>True if debug file is created successfully</returns>
        public static async Task<bool> CreateMiniDumpAsync(
            string   filePath,
            Process  processToDump,
            bool     includeFullMemory = false,
            ILogger? logger            = null)
        {
            try
            {
                _logger ??= logger;

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

                await using FileStream fs =
                    new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                bool result = MiniDumpWriteDump(
                                                processToDump.Handle,
                                                processToDump.Id,
                                                fs.SafeFileHandle,
                                                (int)dumpType,
                                                IntPtr.Zero,
                                                IntPtr.Zero,
                                                IntPtr.Zero);

                if (!result)
                {
                    int err = Marshal.GetLastWin32Error();
                    _logger?.LogError("[MiniDump::CreateMiniDumpAsync()] Failed to create minidump! Error: {err}", err);
                    return false;
                }

                await fs.FlushAsync();
                _logger?.LogInformation($"[MiniDump::CreateMiniDumpAsync()] Minidump created successfully at {filePath}\r\n" +
                                        $"Dump Type: {dumpType}\r\n" +
                                        $"Process ID: {processToDump.Id}\r\n" +
                                        $"Process Name: {processToDump.ProcessName}\r\n" +
                                        $"Include Full Memory: {includeFullMemory}" +
                                        $"Dump File Size: {fs.Length} bytes");
                return true;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "[MiniDump::CreateMiniDumpAsync()] Failed to create minidump!");
                return false;
            }
            finally
            {
                _logger = null;
            }
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