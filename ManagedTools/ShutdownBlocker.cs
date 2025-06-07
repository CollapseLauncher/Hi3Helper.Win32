using Hi3Helper.Win32.Native.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using static Hi3Helper.Win32.Native.LibraryImport.PInvoke;

namespace Hi3Helper.Win32.ManagedTools
{
    public static class ShutdownBlocker
    {
        private static ILogger? _logger;
        
        public static void StartBlocking(nint hWnd, string reason, ILogger? logger)
        {
            try
            {
                // Set the logger
                _logger = logger;
                
                // Log the blocking reason
                _logger?.LogInformation($"Starting shutdown block for reason: {reason}");

                // Call the Windows API to block shutdown
                if (!ShutdownBlockReasonCreate(hWnd, reason))
                {
                    throw new Win32Exception("Failed to block shutdown. Error code: " + Marshal.GetLastWin32Error());
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error while blocking shutdown!\r\n{ex.Message}");
            }
        }
        
        public static void StopBlocking(nint hWnd, ILogger? logger)
        {
            try
            {
                // Set the logger
                _logger = logger;

                // Log the unblocking action
                _logger?.LogInformation("Stopping shutdown block");

                // Call the Windows API to remove the shutdown block
                if (!ShutdownBlockReasonDestroy(hWnd))
                {
                    throw new Win32Exception("Failed to remove shutdown block. Error code: " + Marshal.GetLastWin32Error());
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error while stopping shutdown block!\r\n{ex.Message}");
            }
        }
    }
}