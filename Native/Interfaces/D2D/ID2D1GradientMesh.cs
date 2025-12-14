using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("f292e401-c050-4cde-83d7-04962d3b23c2")]
public partial interface ID2D1GradientMesh : ID2D1Resource
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1gradientmesh-getpatchcount
    [PreserveSig]
    uint GetPatchCount();

    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1gradientmesh-getpatches
    void GetPatches(uint startIndex, [In][Out][MarshalUsing(CountElementName = nameof(patchesCount))] D2D1_GRADIENT_MESH_PATCH[] patches, uint patchesCount);
}