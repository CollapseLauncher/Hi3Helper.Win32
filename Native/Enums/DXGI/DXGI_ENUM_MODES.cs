using System;
// ReSharper disable CommentTypo
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Enums.DXGI;

/// <summary>Options for enumerating display modes.</summary>
/// <remarks>
/// <para>These flag options are used in [**IDXGIOutput::GetDisplayModeList**](/windows/desktop/api/DXGI/nf-dxgi-idxgioutput-getdisplaymodelist) to enumerate display modes. These flag options are also used in [**IDXGIOutput1::GetDisplayModeList1**](/windows/desktop/api/DXGI1_2/nf-dxgi1_2-idxgioutput1-getdisplaymodelist1) to enumerate display modes.</para>
/// <para><see href="https://learn.microsoft.com/windows/win32/direct3ddxgi/dxgi-enum-modes#">Read more on learn.microsoft.com</see>.</para>
/// </remarks>
[Flags]
public enum DXGI_ENUM_MODES : uint
{
    DXGI_ENUM_MODES_INTERLACED      = 0x00000001,
    DXGI_ENUM_MODES_SCALING         = 0x00000002,
    DXGI_ENUM_MODES_STEREO          = 0x00000004,
    DXGI_ENUM_MODES_DISABLED_STEREO = 0x00000008,
}
