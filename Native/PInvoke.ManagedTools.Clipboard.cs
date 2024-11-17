using Hi3Helper.Win32.Native.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Hi3Helper.Win32.Native
{
    public static partial class PInvoke
    {
        public static unsafe void CopyStringToClipboard(string inputString, ILogger? logger = null)
        {
            // Initialize the memory pointer
            // ReSharper disable RedundantAssignment
            nint stringBufferPtr = nint.Zero;
            // ReSharper restore RedundantAssignment
            nint hMem = nint.Zero;

            // Set the Clipboard bool status
            bool isOpenClipboardSuccess = false;

            try
            {
                // If inputString is null or empty, then return
                if (string.IsNullOrEmpty(inputString))
                {
                    logger?.LogWarning($"[InvokeProp::CopyStringToClipboard()] inputString cannot be empty! Clipboard will not be set!");
                    return;
                }

                // Try open the Clipboard
                if (!(isOpenClipboardSuccess = OpenClipboard(nint.Zero)))
                    logger?.LogError($"[InvokeProp::CopyStringToClipboard()] Error has occurred while opening clipboard buffer! Error: {Marshal.GetLastPInvokeErrorMessage()}");

                // Set the bufferSize + 1, the additional 1 byte will be used to interpret the null byte
                int bufferSize = inputString.Length + 1;

                // Allocate the Global-Movable buffer to the kernel with given size and lock the buffer
                hMem = GlobalAlloc(GLOBAL_ALLOC_FLAGS.GMEM_MOVEABLE, (nuint)bufferSize);
                stringBufferPtr = GlobalLock(hMem);

                // Write the inputString as a UTF-8 bytes into the string buffer
                if (!Encoding.UTF8.TryGetBytes(inputString, new Span<byte>((byte*)stringBufferPtr, inputString.Length), out int bufferWritten))
                    logger?.LogError($"[InvokeProp::CopyStringToClipboard()] Loading inputString into buffer has failed! Clipboard will not be set!");

                // Always set the null byte at the end of the buffer
                ((byte*)stringBufferPtr!)![bufferWritten] = 0x00; // Write the null (terminator) byte

                // Unlock the buffer
                GlobalUnlock(hMem);

                // Empty the previous Clipboard and set to the new one from this buffer. If
                // the clearance is failed, then clear the buffer at "finally" block
                if (EmptyClipboard() || SetClipboardData(1, hMem) == nint.Zero)
                {
                    logger?.LogError($"[InvokeProp::CopyStringToClipboard()] Error has occurred while clearing and set clipboard buffer! Error: {Marshal.GetLastPInvokeErrorMessage()}");
                    return;
                }

                logger?.LogDebug($"[InvokeProp::CopyStringToClipboard()] Content has been set to Clipboard buffer with size: {bufferSize} bytes");
            }
            finally
            {
                // If the buffer is allocated (not zero), then free it.
                if (hMem != nint.Zero) GlobalFree(hMem);

                // Close the buffer if the clipboard is successfully opened.
                if (isOpenClipboardSuccess) CloseClipboard();
            }
        }
    }
}
