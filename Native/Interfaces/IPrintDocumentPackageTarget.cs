using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces;

[GeneratedComInterface]
[Guid("1b8efec4-3019-4c27-964e-367202156906")]
public partial interface IPrintDocumentPackageTarget
{
    // https://learn.microsoft.com/windows/win32/api/documenttarget/nf-documenttarget-iprintdocumentpackagetarget-getpackagetargettypes
    void GetPackageTargetTypes(out uint targetCount, [MarshalUsing(CountElementName = nameof(targetCount))] out Guid[] targetTypes);

    // https://learn.microsoft.com/windows/win32/api/documenttarget/nf-documenttarget-iprintdocumentpackagetarget-getpackagetarget
    void GetPackageTarget(in Guid guidTargetType, in Guid riid, out nint /* void */ ppvTarget);

    // https://learn.microsoft.com/windows/win32/api/documenttarget/nf-documenttarget-iprintdocumentpackagetarget-cancel
    void Cancel();
}