using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.Enums;

namespace Hi3Helper.Win32.Native.Interfaces;

[GeneratedComInterface]
[Guid("af86e2e0-b12d-4c6a-9c5a-d7aa65101e90")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public partial interface IInspectable
{
    // https://learn.microsoft.com/windows/win32/api/inspectable/nf-inspectable-iinspectable-getiids
    void GetIids(out uint iidCount, out nint iids);

    // https://learn.microsoft.com/windows/win32/api/inspectable/nf-inspectable-iinspectable-getruntimeclassname
    void GetRuntimeClassName(out nint className);

    // https://learn.microsoft.com/windows/win32/api/inspectable/nf-inspectable-iinspectable-gettrustlevel
    void GetTrustLevel(out TrustLevel trustLevel);
}
