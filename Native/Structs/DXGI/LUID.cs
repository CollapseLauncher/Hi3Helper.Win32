// ReSharper disable CommentTypo
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
#pragma warning disable IDE0051
namespace Hi3Helper.Win32.Native.Structs.DXGI;

/// <summary>The LUID structure is an opaque structure that specifies an identifier that is guaranteed to be unique on the local machine. For more information, see the reference page for LUID in the Microsoft Windows SDK documentation.</summary>
/// <remarks>
/// <para><see href="https://learn.microsoft.com/windows/win32/api/ntdef/ns-ntdef-luid">Learn more about this API from learn.microsoft.com</see>.</para>
/// </remarks>
public struct LUID
{
    public uint LowPart;

    public int HighPart;
}
