using System;
using System.Buffers;
using System.Security.Cryptography;
using System.Text;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.ToastCOM
{
    internal class IidGuid
    {
        internal const  string NotificationActivationCallback = "53e31837-6600-4a81-9395-75cffe746f94";
        internal const  string IClassFactory                  = "00000001-0000-0000-c000-000000000046";
        internal static Guid   GuidIClassFactory              = new(IClassFactory);
    }

    internal class ClsidGuid
    {
        internal static Guid GetGuidFromString(string fromString)
        {
            int bufferLen = fromString.Length + 16;
            byte[] buffer = ArrayPool<byte>.Shared.Rent(bufferLen);
            Span<byte> hashBuffer = buffer.AsSpan(buffer.Length - 16);

            try
            {
                if (!Encoding.UTF8.TryGetBytes(fromString, buffer, out int bytesWritten))
                    throw new InvalidOperationException();

                int written = MD5.HashData(buffer.AsSpan(0, bytesWritten), hashBuffer);
                if (written == 0)
                    throw new InvalidOperationException();

                return new Guid(hashBuffer);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}
