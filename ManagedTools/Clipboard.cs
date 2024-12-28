using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.LibraryImport;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.ManagedTools
{
    public static class Clipboard
    {
        public static unsafe void CopyStringToClipboard(string? inputString, ILogger? logger = null)
        {
            // Flag constants
            const GLOBAL_ALLOC_FLAGS AllocFlags = GLOBAL_ALLOC_FLAGS.GMEM_MOVEABLE | GLOBAL_ALLOC_FLAGS.GMEM_ZEROINIT;
            const StandardClipboardFormats ClipboardFlags = StandardClipboardFormats.CF_UNICODETEXT;

            // Initialize the memory pointer
            nint hGlobalAllocPtrPinned = nint.Zero;
            nint hGlobalAllocPtr = nint.Zero;
            nint mStrToHGlobalPtr = nint.Zero;

            // Get the inputString length and allocate the buffer size
            uint inputLen = string.IsNullOrEmpty(inputString) ? 0 : (uint)inputString.Length;
            uint bufferSize = (inputLen + 1) * 2;
            try
            {
                // Try open the Clipboard
                if (!PInvoke.OpenClipboard(nint.Zero))
                {
                    logger?.LogError($"[InvokeProp::CopyStringToClipboard()] Cannot open the clipboard! Error: {Win32Error.GetLastWin32ErrorMessage()}");
                    return;
                }

                // Make sure to empty the clipboard before setting and allocate the content
                if (!PInvoke.EmptyClipboard())
                {
                    logger?.LogError($"[InvokeProp::CopyStringToClipboard()] Cannot clear the previous clipboard! Error: {Win32Error.GetLastWin32ErrorMessage()}");
                    return;
                }

                // Allocate string to HGlobal since the pointer of the managed string will always be movable
                // by the GC when it tries to compact the memory.
                mStrToHGlobalPtr = Marshal.StringToHGlobalUni(inputString);
                if (mStrToHGlobalPtr == nint.Zero)
                {
                    logger?.LogError($"[InvokeProp::CopyStringToClipboard()] Cannot allocate string to HGlobal");
                    return;
                }

                // Allocate the Global-Movable buffer to the kernel with given size
                hGlobalAllocPtr = PInvoke.GlobalAlloc(AllocFlags, bufferSize);
                if (hGlobalAllocPtr == nint.Zero)
                {
                    logger?.LogError($"[InvokeProp::CopyStringToClipboard()] Cannot allocate global buffer using GlobalAlloc! Error: {Win32Error.GetLastWin32ErrorMessage()}");
                    return;
                }

                // Lock the Global for writing
                hGlobalAllocPtrPinned = PInvoke.GlobalLock(hGlobalAllocPtr);
                if (hGlobalAllocPtrPinned == nint.Zero)
                {
                    logger?.LogError($"[InvokeProp::CopyStringToClipboard()] Cannot lock global buffer for writing! Error: {Win32Error.GetLastWin32ErrorMessage()}");
                    return;
                }

                // Write the mStrToHGlobalPtr into the hGlobalAlloc pointer
                PInvoke.RtlCopyMemory(hGlobalAllocPtrPinned, mStrToHGlobalPtr, bufferSize);

                // Unlock the buffer pinned pointer. Ignoring the return value
                // as it will always returns for NO_ERROR.
                _ = PInvoke.GlobalUnlock(hGlobalAllocPtr);

                // Set the clipboard data to the new GlobalAlloc pointer
                if (PInvoke.SetClipboardData(ClipboardFlags, hGlobalAllocPtr) == nint.Zero)
                {
                    logger?.LogError($"[InvokeProp::CopyStringToClipboard()] Cannot set the clipboard data from hGlobalAllocPtr! Error: {Win32Error.GetLastWin32ErrorMessage()}");
                    return;
                }

                logger?.LogDebug($"[InvokeProp::CopyStringToClipboard()] Content has been set to Clipboard buffer with size: {bufferSize} bytes");
            }
            finally
            {
                // Free Global memory
                if (hGlobalAllocPtr != nint.Zero)
                {
                    PInvoke.GlobalFree(hGlobalAllocPtr);
                }

                // Free the HGlobal memory
                if (mStrToHGlobalPtr != nint.Zero)
                {
                    Marshal.FreeHGlobal(mStrToHGlobalPtr);
                }

                // Close the clipboard
                PInvoke.CloseClipboard();
            }
        }
    }
}
