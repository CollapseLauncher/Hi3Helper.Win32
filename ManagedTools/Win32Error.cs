using Hi3Helper.Win32.Native.Enums;
using System;
using System.Buffers;
using System.Runtime.InteropServices;
using static Hi3Helper.Win32.Native.LibraryImport.PInvoke;

namespace Hi3Helper.Win32.Native.ManagedTools
{
    public static class Win32Error
    {
        public static string GetLastWin32ErrorMessage()
        {
            // Get last errors
            int lastError = Marshal.GetLastWin32Error();
            int hResult   = Marshal.GetHRForLastWin32Error();

            // Store as managed string
            string message = GetWin32ErrorMessage(lastError) + $" (Err: {lastError:x8} | HRESULT: {hResult:x8})";
            return message;
        }

        public static string GetWin32ErrorMessage(int errCode)
        {
            const FORMAT_MESSAGE FormatMessageFlag = FORMAT_MESSAGE.FROM_SYSTEM | FORMAT_MESSAGE.IGNORE_INSERTS;
            const int            BufferSize        = 256;

            // Set buffer length to 256 chars (512 KB)
            char[] buffer = ArrayPool<char>.Shared.Rent(BufferSize);
            try
            {
                // Get the message
                int messageSize = FormatMessage(
                                                FormatMessageFlag,
                                                nint.Zero,
                                                errCode,
                                                0,
                                                buffer,
                                                BufferSize,
                                                nint.Zero);

                // Return message string
                return new string(buffer.AsSpan(0, messageSize).TrimEnd("\r\n"));
            }
            finally
            {
                // Free the buffer
                ArrayPool<char>.Shared.Return(buffer);
            }
        }
    }
}
