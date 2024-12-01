using Hi3Helper.Win32.Native.Enums;
using System.Buffers;
using System.Runtime.InteropServices;
using NativePInvoke = Hi3Helper.Win32.Native.PInvoke;

namespace Hi3Helper.Win32.Native.ManagedTools
{
    public static partial class PInvoke
    {
        public static string GetLastWin32ErrorMessage()
        {
            const FORMAT_MESSAGE FormatMessageFlag = FORMAT_MESSAGE.FROM_SYSTEM | FORMAT_MESSAGE.IGNORE_INSERTS;
            const int BufferSize = 256;

            int lastError = Marshal.GetLastWin32Error();
            int hresult = Marshal.GetHRForLastWin32Error();

            // Set buffer length to 256 chars (512 KB)
            char[] buffer = ArrayPool<char>.Shared.Rent(BufferSize);
            try
            {
                // Get the message
                int messageSize = NativePInvoke.FormatMessage(
                    FormatMessageFlag,
                    nint.Zero,
                    lastError,
                    0,
                    buffer,
                    BufferSize,
                    nint.Zero);

                // Store as managed string
                string message = new string(buffer, 0, messageSize) + $" (Err: {lastError:x8} | HRESULT: {hresult:x8})";
                return message;
            }
            finally
            {
                ArrayPool<char>.Shared.Return(buffer);
            }
        }
    }
}
