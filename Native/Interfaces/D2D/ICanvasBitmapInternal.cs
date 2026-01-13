using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[Guid("4684FA78-C721-4531-8CCE-BEA927F95E5D")]
[GeneratedComInterface]
public partial interface ICanvasBitmapInternal
{
    void GetD2DBitmap(out nint ppv);
}
