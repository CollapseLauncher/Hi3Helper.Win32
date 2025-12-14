using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("82237326-8111-4f7c-bcf4-b5c1175564fe")]
public partial interface ID2D1GdiMetafileSink
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gdimetafilesink-processrecord
    void ProcessRecord(uint recordType, nint /* optional void* */ recordData, uint recordDataSize);
}
