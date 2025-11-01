using System;
using System.Buffers;
using System.Security.Cryptography;
using System.Text;
// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global

#pragma warning disable CA2211

namespace Hi3Helper.Win32.Native.ClassIds;

public class ClassFactoryClsId
{
    public const  string IClassFactory     = "00000001-0000-0000-c000-000000000046";
    public static Guid   GuidIClassFactory = new Guid(IClassFactory);

    public static Guid GetGuidFromString(string fromString)
    {
        int        bufferLen  = fromString.Length + 16;
        byte[]     buffer     = ArrayPool<byte>.Shared.Rent(bufferLen);
        Span<byte> hashBuffer = buffer.AsSpan(buffer.Length - 16);

        try
        {
            if (!Encoding.UTF8.TryGetBytes(fromString, buffer, out int bytesWritten))
                throw new InvalidOperationException();

            int written = MD5.HashData(buffer.AsSpan(0, bytesWritten), hashBuffer);
            return written == 0 ? throw new InvalidOperationException() : new Guid(hashBuffer);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}
