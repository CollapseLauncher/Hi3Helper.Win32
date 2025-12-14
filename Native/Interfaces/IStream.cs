using Hi3Helper.Win32.Native.Structs;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces;

[GeneratedComInterface]
[Guid("0000000c-0000-0000-c000-000000000046")]
public partial interface IStream : ISequentialStream
{
    // https://learn.microsoft.com/windows/win32/api/objidl/nf-objidl-istream-seek
    void Seek(long dlibMove, SeekOrigin dwOrigin, nint /* optional ulong* */ plibNewPosition);

    // https://learn.microsoft.com/windows/win32/api/objidl/nf-objidl-istream-setsize
    void SetSize(ulong libNewSize);

    // https://learn.microsoft.com/windows/win32/api/objidl/nf-objidl-istream-copyto
    void CopyTo([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IStream>))] IStream pstm, ulong cb, nint /* optional ulong* */ pcbRead, nint /* optional ulong* */ pcbWritten);

    // https://learn.microsoft.com/windows/win32/api/objidl/nf-objidl-istream-commit
    void Commit(uint grfCommitFlags);

    // https://learn.microsoft.com/windows/win32/api/objidl/nf-objidl-istream-revert
    void Revert();

    // https://learn.microsoft.com/windows/win32/api/objidl/nf-objidl-istream-lockregion
    void LockRegion(ulong libOffset, ulong cb, uint dwLockType);

    // https://learn.microsoft.com/windows/win32/api/objidl/nf-objidl-istream-unlockregion
    void UnlockRegion(ulong libOffset, ulong cb, uint dwLockType);

    // https://learn.microsoft.com/windows/win32/api/objidl/nf-objidl-istream-stat
    void Stat(out STATSTG pstatstg, uint grfStatFlag);

    // https://learn.microsoft.com/windows/win32/api/objidl/nf-objidl-istream-clone
    void Clone([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IStream>))] out IStream ppstm);
}
