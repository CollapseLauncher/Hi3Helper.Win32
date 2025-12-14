using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("c9b664e5-74a1-4378-9ac2-eefc37a3f4d8")]
public partial interface ID2D1ImageSource : ID2D1Image
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1imagesource-offerresources
    void OfferResources();

    // https://learn.microsoft.com/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1imagesource-tryreclaimresources
    void TryReclaimResources(out BOOL resourcesDiscarded);
}