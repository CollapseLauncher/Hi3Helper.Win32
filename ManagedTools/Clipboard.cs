using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.LibraryImport;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.ManagedTools
{
    public static class Clipboard
    {
        public static unsafe void CopyDataToClipboard(scoped ReadOnlySpan<byte> data,
                                                      StandardClipboardFormats  format,
                                                      ILogger?                  logger)
        {
            // Flag constant
            const GLOBAL_ALLOC_FLAGS allocFlags = GLOBAL_ALLOC_FLAGS.GMEM_MOVEABLE | GLOBAL_ALLOC_FLAGS.GMEM_ZEROINIT;

            uint bufferSize = (uint)data.Length;

            // Initialize the memory pointer
            nint hGlobalAllocPtr = nint.Zero;
            nint sourceBufferPtr = (nint)Unsafe.AsPointer(in MemoryMarshal.AsRef<byte>(data));
            try
            {

                // Allocate the Global-Movable buffer to the kernel with given size
                hGlobalAllocPtr = PInvoke.GlobalAlloc(allocFlags, bufferSize);
                if (hGlobalAllocPtr == nint.Zero)
                {
                    logger?.LogError("[Clipboard::CopyDataToClipboard] Cannot allocate global buffer using GlobalAlloc! Error: {ex}", Win32Error.GetLastWin32ErrorMessage());
                    return;
                }

                // Lock the Global for writing
                IntPtr hGlobalAllocPtrPinned = PInvoke.GlobalLock(hGlobalAllocPtr);
                if (hGlobalAllocPtrPinned == nint.Zero)
                {
                    logger?.LogError("[Clipboard::CopyDataToClipboard] Cannot lock global buffer for writing! Error: {ex}", Win32Error.GetLastWin32ErrorMessage());
                    return;
                }

                // Write the sourceBufferPtr into the hGlobalAlloc pointer
                PInvoke.RtlCopyMemory(hGlobalAllocPtrPinned, sourceBufferPtr, bufferSize);

                // Unlock the buffer pinned pointer. Ignoring the return value
                // as it will always return for NO_ERROR.
                _ = PInvoke.GlobalUnlock(hGlobalAllocPtr);

                // Set the clipboard data to the new GlobalAlloc pointer
                if (PInvoke.SetClipboardData(format, hGlobalAllocPtr) == nint.Zero)
                {
                    logger?.LogError("[Clipboard::CopyDataToClipboard] Cannot set the clipboard data from hGlobalAllocPtr! Error: {ex}", Win32Error.GetLastWin32ErrorMessage());
                    return;
                }

                logger?.LogDebug("[Clipboard::CopyDataToClipboard] Content has been set to Clipboard buffer with size: {bufferSize} bytes", bufferSize);
            }
            finally
            {
                // Free Global memory
                if (hGlobalAllocPtr != nint.Zero)
                {
                    PInvoke.GlobalFree(hGlobalAllocPtr);
                }
            }
        }

        public static void CopyStringToClipboard(string? inputString, ILogger? logger = null)
        {
            const StandardClipboardFormats clipboardFlags = StandardClipboardFormats.CF_UNICODETEXT;

            // Try open the Clipboard
            if (!PInvoke.OpenClipboard(nint.Zero))
            {
                logger?.LogError("[Clipboard::CopyStringToClipboard] Cannot open the clipboard! Error: {ex}", Win32Error.GetLastWin32ErrorMessage());
                return;
            }

            try
            {
                // Make sure to empty the clipboard before setting and allocate the content
                if (!PInvoke.EmptyClipboard())
                {
                    logger?.LogError("[Clipboard::CopyStringToClipboard] Cannot clear the previous clipboard! Error: {ex}",
                                     Win32Error.GetLastWin32ErrorMessage());
                    return;
                }

                ReadOnlySpan<char> span        = inputString;
                Span<char>         stackBuffer = stackalloc char[span.Length + 1]; // Adds null terminator since it needs that.
                stackBuffer.Clear();
                span.CopyTo(stackBuffer);

                ReadOnlySpan<byte> byteSpan = MemoryMarshal.AsBytes(stackBuffer);
                CopyDataToClipboard(byteSpan, clipboardFlags, logger);
            }
            finally
            {
                // Close the clipboard
                PInvoke.CloseClipboard();
            }
        }
    }
}
