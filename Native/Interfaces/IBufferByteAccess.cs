using Hi3Helper.Win32.Native.ClassIds;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces
{
    [Guid(BufferClsId.IBufferByteAccess)]
    [GeneratedComInterface]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IBufferByteAccess
    {
        void Buffer(out nint pByte);
    }
}
