using Hi3Helper.Win32.Native.Enums.DXGI;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.DXGI;

[GeneratedComInterface]
[Guid("05008617-fbfd-4051-a790-144884b4f6a9")]
public partial interface IDXGIDevice2 : IDXGIDevice1
{
    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgidevice2-offerresources
    void OfferResources(uint NumResources, [In][MarshalUsing(CountElementName = nameof(NumResources))] IDXGIResource[] ppResources, DXGI_OFFER_RESOURCE_PRIORITY Priority);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgidevice2-reclaimresources
    void ReclaimResources(uint NumResources, [In][MarshalUsing(CountElementName = nameof(NumResources))] IDXGIResource[] ppResources, nint /* optional BOOL* */ pDiscarded);

    // https://learn.microsoft.com/windows/win32/api/dxgi1_2/nf-dxgi1_2-idxgidevice2-enqueuesetevent
    void EnqueueSetEvent(nint hEvent);
}