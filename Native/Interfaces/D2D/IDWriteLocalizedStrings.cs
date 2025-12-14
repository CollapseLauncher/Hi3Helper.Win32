using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("08256209-099a-4b34-b86d-c22b110e7771")]
public partial interface IDWriteLocalizedStrings
{
    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-getcount
    [PreserveSig]
    uint GetCount();

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-findlocalename
    void FindLocaleName(string? localeName, out uint index, out BOOL exists);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-getlocalenamelength
    void GetLocaleNameLength(uint index, out uint length);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-getlocalename
    void GetLocaleName(uint index, [MarshalUsing(CountElementName = nameof(size))] string? localeName, uint size);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-getstringlength
    void GetStringLength(uint index, out uint length);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-getstring
    void GetString(uint index, [MarshalUsing(CountElementName = nameof(size))] string? stringBuffer, uint size);
}
