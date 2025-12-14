using Hi3Helper.Win32.Native.Enums.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("3c613a02-34b2-44ea-9a7c-45aea9c6fd6d")]
public partial interface IWICColorContext
{
    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-initializefromfilename
    void InitializeFromFilename(string? wzFilename);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-initializefrommemory
    void InitializeFromMemory(nint /* byte array */ pbBuffer, uint cbBufferSize);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-initializefromexifcolorspace
    void InitializeFromExifColorSpace(uint value);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-gettype
    void GetType(out WICColorContextType pType);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-getprofilebytes
    void GetProfileBytes(uint cbBuffer, nint /* byte array */ pbBuffer, out uint pcbActual);

    // https://learn.microsoft.com/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-getexifcolorspace
    void GetExifColorSpace(out uint pValue);
}
