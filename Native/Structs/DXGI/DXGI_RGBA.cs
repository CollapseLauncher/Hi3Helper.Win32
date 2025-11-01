// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

// ReSharper disable CommentTypo
namespace Hi3Helper.Win32.Native.Structs.DXGI;

/// <summary>DXGI_RGBA structure - Represents a color value with alpha, which is used for transparency.</summary>
/// <remarks>
/// <para>You can set the members of this structure to values outside the range of 0 through 1 to implement some unusual effects. Values greater than 1 produce strong lights that tend to wash out a scene. Negative values produce dark lights that actually remove light from a scene. The DXGItype.h header type-defines **DXGI\_RGBA** as an alias of [**D3DCOLORVALUE**](d3dcolorvalue.md), as follows:</para>
/// <para></para>
/// <para>This doc was truncated.</para>
/// <para><see href="https://learn.microsoft.com/windows/win32/direct3ddxgi/dxgi-rgba#">Read more on learn.microsoft.com</see>.</para>
/// </remarks>
public struct DXGI_RGBA
{
    /// <summary>Floating-point value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.</summary>
    public float r;

    /// <summary>Floating-point value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.</summary>
    public float g;

    /// <summary>Floating-point value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.</summary>
    public float b;

    /// <summary>Floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.</summary>
    public float a;
}
