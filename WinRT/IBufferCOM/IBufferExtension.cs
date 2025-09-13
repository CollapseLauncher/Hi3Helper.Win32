using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Interfaces;
using System;
using Windows.Storage.Streams;

namespace Hi3Helper.Win32.WinRT.IBufferCOM
{
    public static class IBufferExtension
    {
        /// <summary>
        /// Cast <see cref="IBuffer"/> to <see cref="IBufferByteAccess"/>.
        /// </summary>
        /// <param name="buffer">The source of <see cref="IBuffer"/> instance to cast into.</param>
        /// <param name="isIBufferKeepAlive">Whether to keep the source <see cref="IBuffer"/> COM instance alive or not.</param>
        /// <returns>An <see cref="IBufferByteAccess"/> instance.</returns>
        public static IBufferByteAccess AsBufferByteAccess(this IBuffer buffer, bool isIBufferKeepAlive = true)
        {
            return !ComMarshal<IBuffer>.TryCastComObjectAs(buffer,
                                                           out IBufferByteAccess? asByteAccess,
                                                           out Exception? ex,
                                                           isIBufferKeepAlive) ? throw ex : asByteAccess;
        }
    }
}
