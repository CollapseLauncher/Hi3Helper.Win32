using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("a04bfb29-08ef-43d6-a49c-a9bdbdcbe686")]
public partial interface ID3D11Device1 : ID3D11Device
{
    // https://learn.microsoft.com/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-getimmediatecontext1
    [PreserveSig]
    void GetImmediateContext1([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11DeviceContext1>))] out ID3D11DeviceContext1 ppImmediateContext);

    // https://learn.microsoft.com/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-createdeferredcontext1
    void CreateDeferredContext1(uint ContextFlags, nint /* optional ID3D11DeviceContext1* */ ppDeferredContext);

    // https://learn.microsoft.com/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-createblendstate1
    void CreateBlendState1(in D3D11_BLEND_DESC1 pBlendStateDesc, nint /* optional ID3D11BlendState1* */ ppBlendState);

    // https://learn.microsoft.com/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-createrasterizerstate1
    void CreateRasterizerState1(in D3D11_RASTERIZER_DESC1 pRasterizerDesc, nint /* optional ID3D11RasterizerState1* */ ppRasterizerState);

    // https://learn.microsoft.com/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-createdevicecontextstate
    void CreateDeviceContextState(uint Flags, [In][MarshalUsing(CountElementName = nameof(FeatureLevels))] D3D_FEATURE_LEVEL[] pFeatureLevels, uint FeatureLevels, uint SDKVersion, in Guid EmulatedInterface, nint /* optional D3D_FEATURE_LEVEL* */ pChosenFeatureLevel, nint /* optional ID3DDeviceContextState* */ ppContextState);

    // https://learn.microsoft.com/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-opensharedresource1
    void OpenSharedResource1(nint hResource, in Guid returnedInterface, out nint /* void */ ppResource);

    // https://learn.microsoft.com/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-opensharedresourcebyname
    void OpenSharedResourceByName(string? lpName, uint dwDesiredAccess, in Guid returnedInterface, out nint /* void */ ppResource);
}
