using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Interfaces;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;

namespace Hi3Helper.Win32.WinRT.IBufferCOM;

public static class BufferExtensions
{
    /// <param name="buffer">The source of <see cref="IBuffer"/> instance to cast into.</param>
    extension(IBuffer buffer)
    {
        /// <summary>
        /// Cast <see cref="IBuffer"/> to <see cref="IBufferByteAccess"/>.
        /// </summary>
        /// <param name="isKeepAlive">Whether to keep the source <see cref="IBuffer"/> COM instance alive or not.</param>
        /// <returns>An <see cref="IBufferByteAccess"/> instance.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IBufferByteAccess AsBufferByteAccess(bool isKeepAlive = true)
        {
            return !ComMarshal<IBuffer>
               .TryCastComObjectAs(buffer,
                                   out IBufferByteAccess? asByteAccess,
                                   out Exception? ex,
                                   isKeepAlive)
                ? throw ex
                : asByteAccess;
        }

        /// <summary>
        /// Try to get underlying data buffer of .NET's <see cref="WindowsRuntimeBuffer"/> instance.
        /// </summary>
        /// <param name="data">Underlying buffer array of the instance.</param>
        /// <param name="offset">The offset of where the data can be written.</param>
        /// <returns><see langword="true"/> if the <see cref="IBuffer"/> instance is <see cref="WindowsRuntimeBuffer"/>. Otherwise, <see langword="false"/> and an empty array will be given.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetUnderlyingData(out byte[] data, out int offset)
        {
            if (buffer is WindowsRuntimeBuffer winRtBuffer)
            {
                winRtBuffer.GetUnderlyingData(out data, out offset);
                return true;
            }

            data   = null!;
            offset = 0;
            return false;
        }

        /// <summary>
        /// Try to get underlying data buffer of .NET's <see cref="WindowsRuntimeBuffer"/> instance.
        /// </summary>
        /// <param name="memory">Underlying buffer memory of the instance.</param>
        /// <returns><see langword="true"/> if the <see cref="IBuffer"/> instance is <see cref="WindowsRuntimeBuffer"/>. Otherwise, <see langword="false"/> and an empty <see cref="Memory{T}"/> will be given.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetUnderlyingData(out Memory<byte> memory)
        {
            if (buffer.TryGetUnderlyingData(out byte[] data, out int offset))
            {
                memory = data.AsMemory(offset);
                return true;
            }

            memory = Memory<byte>.Empty;
            return false;
        }
    }

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "GetUnderlyingData")]
    private static extern void GetUnderlyingData(this WindowsRuntimeBuffer buffer, out byte[] data, out int offset);
}
