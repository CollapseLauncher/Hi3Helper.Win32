using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("9B7E4E00-342C-4106-A19F-4F2704F689F0")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface ID3D11Multithread
{
    [PreserveSig]
    void Enter();

    [PreserveSig]
    void Leave();

    // Native BOOLs; the result is the previous state, not an HRESULT.
    [PreserveSig]
    int SetMultithreadProtected(int enabled);

    [PreserveSig]
    int GetMultithreadProtected();
}
