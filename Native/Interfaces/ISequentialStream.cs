using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces;

[GeneratedComInterface]
[Guid("0c733a30-2a1c-11ce-ade5-00aa0044773d")]
public partial interface ISequentialStream
{
    // https://learn.microsoft.com/windows/win32/api/objidl/nf-objidl-isequentialstream-read
    void Read(nint pv, uint cb, nint /* optional uint* */ pcbRead);

    // https://learn.microsoft.com/windows/win32/api/objidl/nf-objidl-isequentialstream-write
    void Write(nint pv, uint cb, nint /* optional uint* */ pcbWritten);
}