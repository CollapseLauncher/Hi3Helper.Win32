// ReSharper disable InconsistentNaming
// ReSharper disable GrammarMistakeInComment
// ReSharper disable UnusedMember.Global
#pragma warning disable IDE0051
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

namespace Hi3Helper.Win32.Native.Structs.DXGI;

/// <summary>Describes multi-sampling parameters for a resource.</summary>
/// <remarks>
/// <para>This structure is a member of the <a href="https://docs.microsoft.com/windows/desktop/api/dxgi1_2/ns-dxgi1_2-dxgi_swap_chain_desc1">DXGI_SWAP_CHAIN_DESC1</a> structure. The default sampler mode, with no anti-aliasing, has a count of 1 and a quality level of 0. If multi-sample antialiasing is being used, all bound render targets and depth buffers must have the same sample counts and quality levels. </para>
/// <para>This doc was truncated.</para>
/// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc#">Read more on learn.microsoft.com</see>.</para>
/// </remarks>
public struct DXGI_SAMPLE_DESC
{
    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> The number of multisamples per pixel.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint Count;

    /// <summary>
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types">UINT</a></b> The image quality level. The higher the quality, the lower the performance. The valid range is between zero and one less than the level returned by <a href="https://docs.microsoft.com/windows/desktop/api/d3d10/nf-d3d10-id3d10device-checkmultisamplequalitylevels">ID3D10Device::CheckMultisampleQualityLevels</a> for Direct3D 10 or <a href="https://docs.microsoft.com/windows/desktop/api/d3d11/nf-d3d11-id3d11device-checkmultisamplequalitylevels">ID3D11Device::CheckMultisampleQualityLevels</a> for Direct3D 11. For Direct3D 10.1 and Direct3D 11, you can use two special quality level values. For more information about these quality level values, see Remarks.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc#members">Read more on learn.microsoft.com</see>.</para>
    /// </summary>
    public uint Quality;
}
