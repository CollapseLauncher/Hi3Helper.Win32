using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("1841e5c8-16b0-489b-bcc8-44cfb0d5deae")]
public partial interface ID3D11DeviceChild
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice
    [PreserveSig]
    void GetDevice(out nint ppDevice);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata
    void GetPrivateData(in Guid guid, ref uint pDataSize, nint /* optional void* */ pData);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata
    void SetPrivateData(in Guid guid, uint DataSize, nint /* optional void* */ pData);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface
    void SetPrivateDataInterface(in Guid guid, nint pData);
}
