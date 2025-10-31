// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable GrammarMistakeInComment
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
namespace Hi3Helper.Win32.Native.Enums.DXGI;

/// <summary>Resource data formats, including fully-typed and typeless formats. A list of modifiers at the bottom of the page more fully describes each format type.</summary>
/// <remarks>
/// <para><h3><a id="Byte_Order__LSB_MSB_"></a><a id="byte_order__lsb_msb_"></a><a id="BYTE_ORDER__LSB_MSB_"></a>Byte Order (LSB/MSB)</h3> Most formats have byte-aligned components, and the components are in C-array order (the least address comes first). For those formats that don't have power-of-2-aligned components, the first named component is in the least-significant bits.</para>
/// <para><h3><a id="Portable_Coding_for_Endian-Independence"></a><a id="portable_coding_for_endian-independence"></a><a id="PORTABLE_CODING_FOR_ENDIAN-INDEPENDENCE"></a>Portable Coding for Endian-Independence</h3> Rather than adjusting for whether a system uses big-endian or little-endian byte ordering, you should write portable code, as follows.</para>
/// <para></para>
/// <para>This doc was truncated.</para>
/// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#">Read more on learn.microsoft.com</see>.</para>
/// </remarks>
public enum DXGI_FORMAT
{
    /// <summary>The format is not known.</summary>
    DXGI_FORMAT_UNKNOWN = 0,
    /// <summary>A four-component, 128-bit typeless format that supports 32 bits per channel including alpha. ¹</summary>
    DXGI_FORMAT_R32G32B32A32_TYPELESS = 1,
    /// <summary>A four-component, 128-bit floating-point format that supports 32 bits per channel including alpha. <sup>1,5,8</sup></summary>
    DXGI_FORMAT_R32G32B32A32_FLOAT = 2,
    /// <summary>A four-component, 128-bit unsigned-integer format that supports 32 bits per channel including alpha. ¹</summary>
    DXGI_FORMAT_R32G32B32A32_UINT = 3,
    /// <summary>A four-component, 128-bit signed-integer format that supports 32 bits per channel including alpha. ¹</summary>
    DXGI_FORMAT_R32G32B32A32_SINT = 4,
    /// <summary>A three-component, 96-bit typeless format that supports 32 bits per color channel.</summary>
    DXGI_FORMAT_R32G32B32_TYPELESS = 5,
    /// <summary>A three-component, 96-bit floating-point format that supports 32 bits per color channel.<sup>5,8</sup></summary>
    DXGI_FORMAT_R32G32B32_FLOAT = 6,
    /// <summary>A three-component, 96-bit unsigned-integer format that supports 32 bits per color channel.</summary>
    DXGI_FORMAT_R32G32B32_UINT = 7,
    /// <summary>A three-component, 96-bit signed-integer format that supports 32 bits per color channel.</summary>
    DXGI_FORMAT_R32G32B32_SINT = 8,
    /// <summary>A four-component, 64-bit typeless format that supports 16 bits per channel including alpha.</summary>
    DXGI_FORMAT_R16G16B16A16_TYPELESS = 9,
    /// <summary>A four-component, 64-bit floating-point format that supports 16 bits per channel including alpha.<sup>5,7</sup></summary>
    DXGI_FORMAT_R16G16B16A16_FLOAT = 10,
    /// <summary>A four-component, 64-bit unsigned-normalized-integer format that supports 16 bits per channel including alpha.</summary>
    DXGI_FORMAT_R16G16B16A16_UNORM = 11,
    /// <summary>A four-component, 64-bit unsigned-integer format that supports 16 bits per channel including alpha.</summary>
    DXGI_FORMAT_R16G16B16A16_UINT = 12,
    /// <summary>A four-component, 64-bit signed-normalized-integer format that supports 16 bits per channel including alpha.</summary>
    DXGI_FORMAT_R16G16B16A16_SNORM = 13,
    /// <summary>A four-component, 64-bit signed-integer format that supports 16 bits per channel including alpha.</summary>
    DXGI_FORMAT_R16G16B16A16_SINT = 14,
    /// <summary>A two-component, 64-bit typeless format that supports 32 bits for the red channel and 32 bits for the green channel.</summary>
    DXGI_FORMAT_R32G32_TYPELESS = 15,
    /// <summary>A two-component, 64-bit floating-point format that supports 32 bits for the red channel and 32 bits for the green channel.<sup>5,8</sup></summary>
    DXGI_FORMAT_R32G32_FLOAT = 16,
    /// <summary>A two-component, 64-bit unsigned-integer format that supports 32 bits for the red channel and 32 bits for the green channel.</summary>
    DXGI_FORMAT_R32G32_UINT = 17,
    /// <summary>A two-component, 64-bit signed-integer format that supports 32 bits for the red channel and 32 bits for the green channel.</summary>
    DXGI_FORMAT_R32G32_SINT = 18,
    /// <summary>A two-component, 64-bit typeless format that supports 32 bits for the red channel, 8 bits for the green channel, and 24 bits are unused.</summary>
    DXGI_FORMAT_R32G8X24_TYPELESS = 19,
    /// <summary>A 32-bit floating-point component, and two unsigned-integer components (with an additional 32 bits). This format supports 32-bit depth, 8-bit stencil, and 24 bits are unused.⁵</summary>
    DXGI_FORMAT_D32_FLOAT_S8X24_UINT = 20,
    /// <summary>A 32-bit floating-point component, and two typeless components (with an additional 32 bits). This format supports 32-bit red channel, 8 bits are unused, and 24 bits are unused.⁵</summary>
    DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS = 21,
    /// <summary>A 32-bit typeless component, and two unsigned-integer components (with an additional 32 bits). This format has 32 bits unused, 8 bits for green channel, and 24 bits are unused.</summary>
    DXGI_FORMAT_X32_TYPELESS_G8X24_UINT = 22,
    /// <summary>A four-component, 32-bit typeless format that supports 10 bits for each color and 2 bits for alpha.</summary>
    DXGI_FORMAT_R10G10B10A2_TYPELESS = 23,
    /// <summary>A four-component, 32-bit unsigned-normalized-integer format that supports 10 bits for each color and 2 bits for alpha.</summary>
    DXGI_FORMAT_R10G10B10A2_UNORM = 24,
    /// <summary>A four-component, 32-bit unsigned-integer format that supports 10 bits for each color and 2 bits for alpha.</summary>
    DXGI_FORMAT_R10G10B10A2_UINT = 25,
    /// <summary>
    /// <para>Three partial-precision floating-point numbers encoded into a single 32-bit value (a variant of s10e5, which is sign bit, 10-bit mantissa, and 5-bit biased (15) exponent). There are no sign bits, and there is a 5-bit biased (15) exponent for each channel, 6-bit mantissa  for R and G, and a 5-bit mantissa for B, as shown in the following illustration.<sup>5,7</sup> </para>
    /// <para>This doc was truncated.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_R11G11B10_FLOAT = 26,
    /// <summary>A four-component, 32-bit typeless format that supports 8 bits per channel including alpha.</summary>
    DXGI_FORMAT_R8G8B8A8_TYPELESS = 27,
    /// <summary>A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits per channel including alpha.</summary>
    DXGI_FORMAT_R8G8B8A8_UNORM = 28,
    /// <summary>A four-component, 32-bit unsigned-normalized integer sRGB format that supports 8 bits per channel including alpha.</summary>
    DXGI_FORMAT_R8G8B8A8_UNORM_SRGB = 29,
    /// <summary>A four-component, 32-bit unsigned-integer format that supports 8 bits per channel including alpha.</summary>
    DXGI_FORMAT_R8G8B8A8_UINT = 30,
    /// <summary>A four-component, 32-bit signed-normalized-integer format that supports 8 bits per channel including alpha.</summary>
    DXGI_FORMAT_R8G8B8A8_SNORM = 31,
    /// <summary>A four-component, 32-bit signed-integer format that supports 8 bits per channel including alpha.</summary>
    DXGI_FORMAT_R8G8B8A8_SINT = 32,
    /// <summary>A two-component, 32-bit typeless format that supports 16 bits for the red channel and 16 bits for the green channel.</summary>
    DXGI_FORMAT_R16G16_TYPELESS = 33,
    /// <summary>A two-component, 32-bit floating-point format that supports 16 bits for the red channel and 16 bits for the green channel.<sup>5,7</sup></summary>
    DXGI_FORMAT_R16G16_FLOAT = 34,
    /// <summary>A two-component, 32-bit unsigned-normalized-integer format that supports 16 bits each for the green and red channels.</summary>
    DXGI_FORMAT_R16G16_UNORM = 35,
    /// <summary>A two-component, 32-bit unsigned-integer format that supports 16 bits for the red channel and 16 bits for the green channel.</summary>
    DXGI_FORMAT_R16G16_UINT = 36,
    /// <summary>A two-component, 32-bit signed-normalized-integer format that supports 16 bits for the red channel and 16 bits for the green channel.</summary>
    DXGI_FORMAT_R16G16_SNORM = 37,
    /// <summary>A two-component, 32-bit signed-integer format that supports 16 bits for the red channel and 16 bits for the green channel.</summary>
    DXGI_FORMAT_R16G16_SINT = 38,
    /// <summary>A single-component, 32-bit typeless format that supports 32 bits for the red channel.</summary>
    DXGI_FORMAT_R32_TYPELESS = 39,
    /// <summary>A single-component, 32-bit floating-point format that supports 32 bits for depth.<sup>5,8</sup></summary>
    DXGI_FORMAT_D32_FLOAT = 40,
    /// <summary>A single-component, 32-bit floating-point format that supports 32 bits for the red channel.<sup>5,8</sup></summary>
    DXGI_FORMAT_R32_FLOAT = 41,
    /// <summary>A single-component, 32-bit unsigned-integer format that supports 32 bits for the red channel.</summary>
    DXGI_FORMAT_R32_UINT = 42,
    /// <summary>A single-component, 32-bit signed-integer format that supports 32 bits for the red channel.</summary>
    DXGI_FORMAT_R32_SINT = 43,
    /// <summary>A two-component, 32-bit typeless format that supports 24 bits for the red channel and 8 bits for the green channel.</summary>
    DXGI_FORMAT_R24G8_TYPELESS = 44,
    /// <summary>A 32-bit z-buffer format that supports 24 bits for depth and 8 bits for stencil.</summary>
    DXGI_FORMAT_D24_UNORM_S8_UINT = 45,
    /// <summary>A 32-bit format, that contains a 24 bit, single-component, unsigned-normalized integer, with an additional typeless 8 bits. This format has 24 bits red channel and 8 bits unused.</summary>
    DXGI_FORMAT_R24_UNORM_X8_TYPELESS = 46,
    /// <summary>A 32-bit format, that contains a 24 bit, single-component, typeless format,  with an additional 8 bit unsigned integer component. This format has 24 bits unused and 8 bits green channel.</summary>
    DXGI_FORMAT_X24_TYPELESS_G8_UINT = 47,
    /// <summary>A two-component, 16-bit typeless format that supports 8 bits for the red channel and 8 bits for the green channel.</summary>
    DXGI_FORMAT_R8G8_TYPELESS = 48,
    /// <summary>A two-component, 16-bit unsigned-normalized-integer format that supports 8 bits for the red channel and 8 bits for the green channel.</summary>
    DXGI_FORMAT_R8G8_UNORM = 49,
    /// <summary>A two-component, 16-bit unsigned-integer format that supports 8 bits for the red channel and 8 bits for the green channel.</summary>
    DXGI_FORMAT_R8G8_UINT = 50,
    /// <summary>A two-component, 16-bit signed-normalized-integer format that supports 8 bits for the red channel and 8 bits for the green channel.</summary>
    DXGI_FORMAT_R8G8_SNORM = 51,
    /// <summary>A two-component, 16-bit signed-integer format that supports 8 bits for the red channel and 8 bits for the green channel.</summary>
    DXGI_FORMAT_R8G8_SINT = 52,
    /// <summary>A single-component, 16-bit typeless format that supports 16 bits for the red channel.</summary>
    DXGI_FORMAT_R16_TYPELESS = 53,
    /// <summary>A single-component, 16-bit floating-point format that supports 16 bits for the red channel.<sup>5,7</sup></summary>
    DXGI_FORMAT_R16_FLOAT = 54,
    /// <summary>A single-component, 16-bit unsigned-normalized-integer format that supports 16 bits for depth.</summary>
    DXGI_FORMAT_D16_UNORM = 55,
    /// <summary>A single-component, 16-bit unsigned-normalized-integer format that supports 16 bits for the red channel.</summary>
    DXGI_FORMAT_R16_UNORM = 56,
    /// <summary>A single-component, 16-bit unsigned-integer format that supports 16 bits for the red channel.</summary>
    DXGI_FORMAT_R16_UINT = 57,
    /// <summary>A single-component, 16-bit signed-normalized-integer format that supports 16 bits for the red channel.</summary>
    DXGI_FORMAT_R16_SNORM = 58,
    /// <summary>A single-component, 16-bit signed-integer format that supports 16 bits for the red channel.</summary>
    DXGI_FORMAT_R16_SINT = 59,
    /// <summary>A single-component, 8-bit typeless format that supports 8 bits for the red channel.</summary>
    DXGI_FORMAT_R8_TYPELESS = 60,
    /// <summary>A single-component, 8-bit unsigned-normalized-integer format that supports 8 bits for the red channel.</summary>
    DXGI_FORMAT_R8_UNORM = 61,
    /// <summary>A single-component, 8-bit unsigned-integer format that supports 8 bits for the red channel.</summary>
    DXGI_FORMAT_R8_UINT = 62,
    /// <summary>A single-component, 8-bit signed-normalized-integer format that supports 8 bits for the red channel.</summary>
    DXGI_FORMAT_R8_SNORM = 63,
    /// <summary>A single-component, 8-bit signed-integer format that supports 8 bits for the red channel.</summary>
    DXGI_FORMAT_R8_SINT = 64,
    /// <summary>A single-component, 8-bit unsigned-normalized-integer format for alpha only.</summary>
    DXGI_FORMAT_A8_UNORM = 65,
    /// <summary>A single-component, 1-bit unsigned-normalized integer format that supports 1 bit for the red channel. ².</summary>
    DXGI_FORMAT_R1_UNORM = 66,
    /// <summary>
    /// <para>Three partial-precision floating-point numbers encoded into a single 32-bit value all sharing the same 5-bit exponent (variant of s10e5, which is sign bit, 10-bit mantissa, and 5-bit biased (15) exponent). There is no sign bit, and there is a shared 5-bit biased (15) exponent and a 9-bit mantissa for each channel, as shown in the following illustration. <sup>6,7</sup>. </para>
    /// <para>This doc was truncated.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_R9G9B9E5_SHAREDEXP = 67,
    /// <summary>
    /// <para>A four-component, 32-bit unsigned-normalized-integer format. This packed RGB format is analogous to the UYVY format. Each 32-bit block describes a pair of pixels: (R8, G8, B8) and (R8, G8, B8) where the R8/B8 values are repeated, and the G8 values are unique to each pixel. ³ Width must be even.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_R8G8_B8G8_UNORM = 68,
    /// <summary>
    /// <para>A four-component, 32-bit unsigned-normalized-integer format. This packed RGB format is analogous to the YUY2 format. Each 32-bit block describes a pair of pixels: (R8, G8, B8) and (R8, G8, B8) where the R8/B8 values are repeated, and the G8 values are unique to each pixel. ³ Width must be even.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_G8R8_G8B8_UNORM = 69,
    /// <summary>Four-component typeless block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC1_TYPELESS = 70,
    /// <summary>Four-component block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC1_UNORM = 71,
    /// <summary>Four-component block-compression format for sRGB data. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC1_UNORM_SRGB = 72,
    /// <summary>Four-component typeless block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC2_TYPELESS = 73,
    /// <summary>Four-component block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC2_UNORM = 74,
    /// <summary>Four-component block-compression format for sRGB data. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC2_UNORM_SRGB = 75,
    /// <summary>Four-component typeless block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC3_TYPELESS = 76,
    /// <summary>Four-component block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC3_UNORM = 77,
    /// <summary>Four-component block-compression format for sRGB data. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC3_UNORM_SRGB = 78,
    /// <summary>One-component typeless block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC4_TYPELESS = 79,
    /// <summary>One-component block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC4_UNORM = 80,
    /// <summary>One-component block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC4_SNORM = 81,
    /// <summary>Two-component typeless block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC5_TYPELESS = 82,
    /// <summary>Two-component block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC5_UNORM = 83,
    /// <summary>Two-component block-compression format. For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC5_SNORM = 84,
    /// <summary>
    /// <para>A three-component, 16-bit unsigned-normalized-integer format that supports 5 bits for blue, 6 bits for green, and 5 bits for red. <b>Direct3D 10 through Direct3D 11:  </b>This value is defined for DXGI. However, Direct3D 10, 10.1, or 11 devices do not support this format. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_B5G6R5_UNORM = 85,
    /// <summary>
    /// <para>A four-component, 16-bit unsigned-normalized-integer format that supports 5 bits for each color channel and 1-bit alpha. <b>Direct3D 10 through Direct3D 11:  </b>This value is defined for DXGI. However, Direct3D 10, 10.1, or 11 devices do not support this format. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_B5G5R5A1_UNORM = 86,
    /// <summary>A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits for each color channel and 8-bit alpha.</summary>
    DXGI_FORMAT_B8G8R8A8_UNORM = 87,
    /// <summary>A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits for each color channel and 8 bits unused.</summary>
    DXGI_FORMAT_B8G8R8X8_UNORM = 88,
    /// <summary>A four-component, 32-bit 2.8-biased fixed-point format that supports 10 bits for each color channel and 2-bit alpha.</summary>
    DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM = 89,
    /// <summary>A four-component, 32-bit typeless format that supports 8 bits for each channel including alpha. ⁴</summary>
    DXGI_FORMAT_B8G8R8A8_TYPELESS = 90,
    /// <summary>A four-component, 32-bit unsigned-normalized standard RGB format that supports 8 bits for each channel including alpha. ⁴</summary>
    DXGI_FORMAT_B8G8R8A8_UNORM_SRGB = 91,
    /// <summary>A four-component, 32-bit typeless format that supports 8 bits for each color channel, and 8 bits are unused. ⁴</summary>
    DXGI_FORMAT_B8G8R8X8_TYPELESS = 92,
    /// <summary>A four-component, 32-bit unsigned-normalized standard RGB format that supports 8 bits for each color channel, and 8 bits are unused. ⁴</summary>
    DXGI_FORMAT_B8G8R8X8_UNORM_SRGB = 93,
    /// <summary>A typeless block-compression format. ⁴ For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC6H_TYPELESS = 94,
    /// <summary>A block-compression format. ⁴ For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.⁵</summary>
    DXGI_FORMAT_BC6H_UF16 = 95,
    /// <summary>A block-compression format. ⁴ For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.⁵</summary>
    DXGI_FORMAT_BC6H_SF16 = 96,
    /// <summary>A typeless block-compression format. ⁴ For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC7_TYPELESS = 97,
    /// <summary>A block-compression format. ⁴ For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC7_UNORM = 98,
    /// <summary>A block-compression format. ⁴ For information about block-compression formats, see <a href="https://docs.microsoft.com/windows/desktop/direct3d11/texture-block-compression-in-direct3d-11">Texture Block Compression in Direct3D 11</a>.</summary>
    DXGI_FORMAT_BC7_UNORM_SRGB = 99,
    /// <summary>
    /// <para>Most common YUV 4:4:4 video resource format. Valid view formats for this video resource format are DXGI_FORMAT_R8G8B8A8_UNORM and DXGI_FORMAT_R8G8B8A8_UINT. For UAVs, an additional valid view format is DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as opposed to just write for DXGI_FORMAT_R8G8B8A8_UNORM and DXGI_FORMAT_R8G8B8A8_UINT. Supported view types are SRV, RTV, and UAV. One view provides a straightforward mapping of the entire surface. The mapping to the view channel is V-&gt;R8, U-&gt;G8, Y-&gt;B8, and A-&gt;A8. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_AYUV = 100,
    /// <summary>
    /// <para>10-bit per channel packed YUV 4:4:4 video resource format. Valid view formats for this video resource format are DXGI_FORMAT_R10G10B10A2_UNORM and DXGI_FORMAT_R10G10B10A2_UINT. For UAVs, an additional valid view format is DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as opposed to just write for DXGI_FORMAT_R10G10B10A2_UNORM and DXGI_FORMAT_R10G10B10A2_UINT. Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface. The mapping to the view channel is U-&gt;R10, Y-&gt;G10, V-&gt;B10, and A-&gt;A2. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_Y410 = 101,
    /// <summary>
    /// <para>16-bit per channel packed YUV 4:4:4 video resource format. Valid view formats for this video resource format are DXGI_FORMAT_R16G16B16A16_UNORM and DXGI_FORMAT_R16G16B16A16_UINT. Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface. The mapping to the view channel is U-&gt;R16, Y-&gt;G16, V-&gt;B16, and A-&gt;A16. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_Y416 = 102,
    /// <summary>
    /// <para>Most common YUV 4:2:0 video resource format. Valid luminance data view formats for this video resource format are DXGI_FORMAT_R8_UNORM and DXGI_FORMAT_R8_UINT. Valid chrominance data view formats (width and height are each 1/2 of luminance view) for this video resource format are DXGI_FORMAT_R8G8_UNORM and DXGI_FORMAT_R8G8_UINT. Supported view types are SRV, RTV, and UAV. For luminance data view, the mapping to the view channel is Y-&gt;R8. For chrominance data view, the mapping to the view channel is U-&gt;R8 and V-&gt;G8. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. Width and height must be even. Direct3D 11 staging resources and initData parameters for this format use (rowPitch * (height + (height / 2))) bytes. The first (SysMemPitch * height) bytes are the Y plane, the remaining (SysMemPitch * (height / 2)) bytes are the UV plane. An app using the YUY 4:2:0 formats  must map the luma (Y) plane separately from the chroma (UV) planes. Developers do this by calling <a href="https://docs.microsoft.com/windows/desktop/api/d3d12/nf-d3d12-id3d12device-createshaderresourceview">ID3D12Device::CreateShaderResourceView</a> twice for the same texture and passing in 1-channel and 2-channel formats. Passing in a 1-channel format compatible with the Y plane maps only the Y plane. Passing in a 2-channel format compatible with the UV planes (together) maps only the U and V planes as a single resource view. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_NV12 = 103,
    /// <summary>
    /// <para>10-bit per channel planar YUV 4:2:0 video resource format. Valid luminance data view formats for this video resource format are DXGI_FORMAT_R16_UNORM and DXGI_FORMAT_R16_UINT. The runtime does not enforce whether the lowest 6 bits are 0 (given that this video resource format is a 10-bit format that uses 16 bits). If required, application shader code would have to enforce this manually.  From the runtime's point of view, DXGI_FORMAT_P010 is no different than DXGI_FORMAT_P016. Valid chrominance data view formats (width and height are each 1/2 of luminance view) for this video resource format are DXGI_FORMAT_R16G16_UNORM and DXGI_FORMAT_R16G16_UINT. For UAVs, an additional valid chrominance data view format is DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as opposed to just write for DXGI_FORMAT_R16G16_UNORM and DXGI_FORMAT_R16G16_UINT. Supported view types are SRV, RTV, and UAV. For luminance data view, the mapping to the view channel is Y-&gt;R16. For chrominance data view, the mapping to the view channel is U-&gt;R16 and V-&gt;G16. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. Width and height must be even. Direct3D 11 staging resources and initData parameters for this format use (rowPitch * (height + (height / 2))) bytes. The first (SysMemPitch * height) bytes are the Y plane, the remaining (SysMemPitch * (height / 2)) bytes are the UV plane. An app using the YUY 4:2:0 formats  must map the luma (Y) plane separately from the chroma (UV) planes. Developers do this by calling <a href="https://docs.microsoft.com/windows/desktop/api/d3d12/nf-d3d12-id3d12device-createshaderresourceview">ID3D12Device::CreateShaderResourceView</a> twice for the same texture and passing in 1-channel and 2-channel formats. Passing in a 1-channel format compatible with the Y plane maps only the Y plane. Passing in a 2-channel format compatible with the UV planes (together) maps only the U and V planes as a single resource view. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_P010 = 104,
    /// <summary>
    /// <para>16-bit per channel planar YUV 4:2:0 video resource format. Valid luminance data view formats for this video resource format are DXGI_FORMAT_R16_UNORM and DXGI_FORMAT_R16_UINT. Valid chrominance data view formats (width and height are each 1/2 of luminance view) for this video resource format are DXGI_FORMAT_R16G16_UNORM and DXGI_FORMAT_R16G16_UINT. For UAVs, an additional valid chrominance data view format is DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as opposed to just write for DXGI_FORMAT_R16G16_UNORM and DXGI_FORMAT_R16G16_UINT. Supported view types are SRV, RTV, and UAV. For luminance data view, the mapping to the view channel is Y-&gt;R16. For chrominance data view, the mapping to the view channel is U-&gt;R16 and V-&gt;G16. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. Width and height must be even. Direct3D 11 staging resources and initData parameters for this format use (rowPitch * (height + (height / 2))) bytes. The first (SysMemPitch * height) bytes are the Y plane, the remaining (SysMemPitch * (height / 2)) bytes are the UV plane. An app using the YUY 4:2:0 formats  must map the luma (Y) plane separately from the chroma (UV) planes. Developers do this by calling <a href="https://docs.microsoft.com/windows/desktop/api/d3d12/nf-d3d12-id3d12device-createshaderresourceview">ID3D12Device::CreateShaderResourceView</a> twice for the same texture and passing in 1-channel and 2-channel formats. Passing in a 1-channel format compatible with the Y plane maps only the Y plane. Passing in a 2-channel format compatible with the UV planes (together) maps only the U and V planes as a single resource view. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_P016 = 105,
    /// <summary>
    /// <para>8-bit per channel planar YUV 4:2:0 video resource format. This format is subsampled where each pixel has its own Y value, but each 2x2 pixel block shares a single U and V value. The runtime requires that the width and height of all resources that are created with this format are multiples of 2. The runtime also requires that the left, right, top, and bottom members of any RECT that are used for this format are multiples of 2. This format differs from DXGI_FORMAT_NV12 in that the layout of the data within the resource is completely opaque to applications. Applications cannot use the CPU to map the resource and then access the data within the resource. You cannot use shaders with this format. Because of this behavior, legacy hardware that supports a non-NV12 4:2:0 layout (for example, YV12, and so on) can be used. Also, new hardware that has a 4:2:0 implementation better than NV12 can be used when the application does not need the data to be in a standard layout. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. Width and height must be even. Direct3D 11 staging resources and initData parameters for this format use (rowPitch * (height + (height / 2))) bytes. An app using the YUY 4:2:0 formats  must map the luma (Y) plane separately from the chroma (UV) planes. Developers do this by calling <a href="https://docs.microsoft.com/windows/desktop/api/d3d12/nf-d3d12-id3d12device-createshaderresourceview">ID3D12Device::CreateShaderResourceView</a> twice for the same texture and passing in 1-channel and 2-channel formats. Passing in a 1-channel format compatible with the Y plane maps only the Y plane. Passing in a 2-channel format compatible with the UV planes (together) maps only the U and V planes as a single resource view. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_420_OPAQUE = 106,
    /// <summary>
    /// <para>Most common YUV 4:2:2 video resource format. Valid view formats for this video resource format are DXGI_FORMAT_R8G8B8A8_UNORM and DXGI_FORMAT_R8G8B8A8_UINT. For UAVs, an additional valid view format is DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as opposed to just write for DXGI_FORMAT_R8G8B8A8_UNORM and DXGI_FORMAT_R8G8B8A8_UINT. Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface. The mapping to the view channel is Y0-&gt;R8, U0-&gt;G8, Y1-&gt;B8, and V0-&gt;A8. A unique valid view format for this video resource format is DXGI_FORMAT_R8G8_B8G8_UNORM. With this view format, the width of the view appears to be twice what the DXGI_FORMAT_R8G8B8A8_UNORM or DXGI_FORMAT_R8G8B8A8_UINT view would be when hardware reconstructs RGBA automatically on read and before filtering.  This Direct3D hardware behavior is legacy and is likely not useful any more. With this view format, the mapping to the view channel is Y0-&gt;R8, U0-&gt; G8[0], Y1-&gt;B8, and V0-&gt; G8[1]. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. Width must be even. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_YUY2 = 107,
    /// <summary>
    /// <para>10-bit per channel packed YUV 4:2:2 video resource format. Valid view formats for this video resource format are DXGI_FORMAT_R16G16B16A16_UNORM and DXGI_FORMAT_R16G16B16A16_UINT. The runtime does not enforce whether the lowest 6 bits are 0 (given that this video resource format is a 10-bit format that uses 16 bits). If required, application shader code would have to enforce this manually.  From the runtime's point of view, DXGI_FORMAT_Y210 is no different than DXGI_FORMAT_Y216. Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface. The mapping to the view channel is Y0-&gt;R16, U-&gt;G16, Y1-&gt;B16, and V-&gt;A16. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. Width must be even. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_Y210 = 108,
    /// <summary>
    /// <para>16-bit per channel packed YUV 4:2:2 video resource format. Valid view formats for this video resource format are DXGI_FORMAT_R16G16B16A16_UNORM and DXGI_FORMAT_R16G16B16A16_UINT. Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface. The mapping to the view channel is Y0-&gt;R16, U-&gt;G16, Y1-&gt;B16, and V-&gt;A16. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. Width must be even. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_Y216 = 109,
    /// <summary>
    /// <para>Most common planar YUV 4:1:1 video resource format. Valid luminance data view formats for this video resource format are DXGI_FORMAT_R8_UNORM and DXGI_FORMAT_R8_UINT. Valid chrominance data view formats (width and height are each 1/4 of luminance view) for this video resource format are DXGI_FORMAT_R8G8_UNORM and DXGI_FORMAT_R8G8_UINT. Supported view types are SRV, RTV, and UAV. For luminance data view, the mapping to the view channel is Y-&gt;R8. For chrominance data view, the mapping to the view channel is U-&gt;R8 and V-&gt;G8. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. Width must be a multiple of 4. Direct3D11 staging resources and initData parameters for this format use (rowPitch * height * 2) bytes. The first (SysMemPitch * height) bytes are the Y plane, the next ((SysMemPitch / 2) * height) bytes are the UV plane, and the remainder is padding. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_NV11 = 110,
    /// <summary>
    /// <para>4-bit palletized YUV format that is commonly used for DVD subpicture. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_AI44 = 111,
    /// <summary>
    /// <para>4-bit palletized YUV format that is commonly used for DVD subpicture. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_IA44 = 112,
    /// <summary>
    /// <para>8-bit palletized format that is used for palletized RGB data when the processor processes ISDB-T data and for palletized YUV data when the processor processes BluRay data. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_P8 = 113,
    /// <summary>
    /// <para>8-bit palletized format with 8 bits of alpha that is used for palletized YUV data when the processor processes BluRay data. For more info about YUV formats for video rendering, see <a href="https://docs.microsoft.com/windows/desktop/medfound/recommended-8-bit-yuv-formats-for-video-rendering">Recommended 8-Bit YUV Formats for Video Rendering</a>. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_A8P8 = 114,
    /// <summary>
    /// <para>A four-component, 16-bit unsigned-normalized integer format that supports 4 bits for each channel including alpha. <b>Direct3D 11.1:  </b>This value is not supported until Windows 8.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    DXGI_FORMAT_B4G4R4A4_UNORM = 115,
    /// <summary>A video format; an 8-bit version of a hybrid planar 4:2:2 format.</summary>
    DXGI_FORMAT_P208 = 130,
    /// <summary>An 8 bit YCbCrA 4:4 rendering format.</summary>
    DXGI_FORMAT_V208 = 131,
    /// <summary>An 8 bit YCbCrA 4:4:4:4 rendering format.</summary>
    DXGI_FORMAT_V408 = 132,
    DXGI_FORMAT_SAMPLER_FEEDBACK_MIN_MIP_OPAQUE = 189,
    DXGI_FORMAT_SAMPLER_FEEDBACK_MIP_REGION_USED_OPAQUE = 190,
    DXGI_FORMAT_A4B4G4R4_UNORM = 191,
}
