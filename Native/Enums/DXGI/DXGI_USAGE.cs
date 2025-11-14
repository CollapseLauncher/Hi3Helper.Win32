// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
using System;

namespace Hi3Helper.Win32.Native.Enums.DXGI;

/// <summary>Flags for surface and resource creation options.</summary>
/// <remarks>
/// <para>Each flag is defined as an unsigned integer. </para>
/// <para>This doc was truncated.</para>
/// <para><see href="https://learn.microsoft.com/windows/win32/direct3ddxgi/dxgi-usage#">Read more on learn.microsoft.com</see>.</para>
/// </remarks>
[Flags]
public enum DXGI_USAGE : uint
{
    DXGI_USAGE_SHADER_INPUT         = 0x00000010,
    DXGI_USAGE_RENDER_TARGET_OUTPUT = 0x00000020,
    DXGI_USAGE_BACK_BUFFER          = 0x00000040,
    DXGI_USAGE_SHARED               = 0x00000080,
    DXGI_USAGE_READ_ONLY            = 0x00000100,
    DXGI_USAGE_DISCARD_ON_PRESENT   = 0x00000200,
    DXGI_USAGE_UNORDERED_ACCESS     = 0x00000400
}
