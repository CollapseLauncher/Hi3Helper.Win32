using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Enums.DXGI;
using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface]
[Guid("db6f6ddb-ac77-4e88-8253-819df9bbf140")]
public partial interface ID3D11Device
{
    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createbuffer
    void CreateBuffer(in D3D11_BUFFER_DESC pDesc, nint /* optional D3D11_SUBRESOURCE_DATA* */ pInitialData, nint /* optional ID3D11Buffer* */ ppBuffer);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createtexture1d
    void CreateTexture1D(in D3D11_TEXTURE1D_DESC pDesc, nint /* optional D3D11_SUBRESOURCE_DATA* */ pInitialData, nint /* optional ID3D11Texture1D* */ ppTexture1D);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createtexture2d
    void CreateTexture2D(in D3D11_TEXTURE2D_DESC pDesc, nint /* optional D3D11_SUBRESOURCE_DATA* */ pInitialData, out nint /* optional ID3D11Texture2D* */ ppTexture2D);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createtexture3d
    void CreateTexture3D(in D3D11_TEXTURE3D_DESC pDesc, nint /* optional D3D11_SUBRESOURCE_DATA* */ pInitialData, nint /* optional ID3D11Texture3D* */ ppTexture3D);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createshaderresourceview
    void CreateShaderResourceView([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Resource>))] ID3D11Resource pResource, nint /* optional D3D11_SHADER_RESOURCE_VIEW_DESC* */ pDesc, nint /* optional ID3D11ShaderResourceView* */ ppSRView);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createunorderedaccessview
    void CreateUnorderedAccessView([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Resource>))] ID3D11Resource pResource, nint /* optional D3D11_UNORDERED_ACCESS_VIEW_DESC* */ pDesc, nint /* optional ID3D11UnorderedAccessView* */ ppUAView);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createrendertargetview
    void CreateRenderTargetView([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Resource>))] ID3D11Resource pResource, nint /* optional D3D11_RENDER_TARGET_VIEW_DESC* */ pDesc, nint /* optional ID3D11RenderTargetView* */ ppRTView);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdepthstencilview
    void CreateDepthStencilView([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Resource>))] ID3D11Resource pResource, nint /* optional D3D11_DEPTH_STENCIL_VIEW_DESC* */ pDesc, nint /* optional ID3D11DepthStencilView* */ ppDepthStencilView);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createinputlayout
    void CreateInputLayout([In][MarshalUsing(CountElementName = nameof(NumElements))] D3D11_INPUT_ELEMENT_DESC[] pInputElementDescs, uint NumElements, nint pShaderBytecodeWithInputSignature, nuint BytecodeLength, nint /* optional ID3D11InputLayout* */ ppInputLayout);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createvertexshader
    void CreateVertexShader(nint pShaderBytecode, nuint BytecodeLength, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11ClassLinkage?>))] ID3D11ClassLinkage? pClassLinkage, nint /* optional ID3D11VertexShader* */ ppVertexShader);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-creategeometryshader
    void CreateGeometryShader(nint pShaderBytecode, nuint BytecodeLength, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11ClassLinkage?>))] ID3D11ClassLinkage? pClassLinkage, nint /* optional ID3D11GeometryShader* */ ppGeometryShader);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-creategeometryshaderwithstreamoutput
    void CreateGeometryShaderWithStreamOutput(nint pShaderBytecode, nuint BytecodeLength, nint /* optional D3D11_SO_DECLARATION_ENTRY* */ pSODeclaration, uint NumEntries, nint /* optional uint* */ pBufferStrides, uint NumStrides, uint RasterizedStream, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11ClassLinkage?>))] ID3D11ClassLinkage? pClassLinkage, nint /* optional ID3D11GeometryShader* */ ppGeometryShader);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createpixelshader
    void CreatePixelShader(nint pShaderBytecode, nuint BytecodeLength, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11ClassLinkage?>))] ID3D11ClassLinkage? pClassLinkage, nint /* optional ID3D11PixelShader* */ ppPixelShader);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createhullshader
    void CreateHullShader(nint pShaderBytecode, nuint BytecodeLength, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11ClassLinkage?>))] ID3D11ClassLinkage? pClassLinkage, nint /* optional ID3D11HullShader* */ ppHullShader);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdomainshader
    void CreateDomainShader(nint pShaderBytecode, nuint BytecodeLength, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11ClassLinkage?>))] ID3D11ClassLinkage? pClassLinkage, nint /* optional ID3D11DomainShader* */ ppDomainShader);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createcomputeshader
    void CreateComputeShader(nint pShaderBytecode, nuint BytecodeLength, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11ClassLinkage?>))] ID3D11ClassLinkage? pClassLinkage, nint /* optional ID3D11ComputeShader* */ ppComputeShader);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createclasslinkage
    void CreateClassLinkage([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11ClassLinkage>))] out ID3D11ClassLinkage ppLinkage);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createblendstate
    void CreateBlendState(in D3D11_BLEND_DESC pBlendStateDesc, nint /* optional ID3D11BlendState* */ ppBlendState);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdepthstencilstate
    void CreateDepthStencilState(in D3D11_DEPTH_STENCIL_DESC pDepthStencilDesc, nint /* optional ID3D11DepthStencilState* */ ppDepthStencilState);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createrasterizerstate
    void CreateRasterizerState(in D3D11_RASTERIZER_DESC pRasterizerDesc, nint /* optional ID3D11RasterizerState* */ ppRasterizerState);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createsamplerstate
    void CreateSamplerState(in D3D11_SAMPLER_DESC pSamplerDesc, nint /* optional ID3D11SamplerState* */ ppSamplerState);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createquery
    void CreateQuery(in D3D11_QUERY_DESC pQueryDesc, nint /* optional ID3D11Query* */ ppQuery);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createpredicate
    void CreatePredicate(in D3D11_QUERY_DESC pPredicateDesc, nint /* optional ID3D11Predicate* */ ppPredicate);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createcounter
    void CreateCounter(in D3D11_COUNTER_DESC pCounterDesc, nint /* optional ID3D11Counter* */ ppCounter);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdeferredcontext
    void CreateDeferredContext(uint ContextFlags, nint /* optional ID3D11DeviceContext* */ ppDeferredContext);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-opensharedresource
    void OpenSharedResource(nint hResource, in Guid ReturnedInterface, out nint /* void */ ppResource);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkformatsupport
    void CheckFormatSupport(DXGI_FORMAT Format, out uint pFormatSupport);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkmultisamplequalitylevels
    void CheckMultisampleQualityLevels(DXGI_FORMAT Format, uint SampleCount, out uint pNumQualityLevels);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkcounterinfo
    [PreserveSig]
    void CheckCounterInfo(out D3D11_COUNTER_INFO pCounterInfo);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkcounter
    void CheckCounter(in D3D11_COUNTER_DESC pDesc, out D3D11_COUNTER_TYPE pType, out uint pActiveCounters, [MarshalUsing(typeof(Utf8StringMarshaller), CountElementName = nameof(pNameLength))] string? szName, nint /* optional uint* */ pNameLength, [MarshalUsing(typeof(Utf8StringMarshaller), CountElementName = nameof(pUnitsLength))] string? szUnits, nint /* optional uint* */ pUnitsLength, [MarshalUsing(typeof(Utf8StringMarshaller), CountElementName = nameof(pDescriptionLength))] string szDescription, nint /* optional uint* */ pDescriptionLength);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkfeaturesupport
    void CheckFeatureSupport(D3D11_FEATURE Feature, nint pFeatureSupportData, uint FeatureSupportDataSize);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-getprivatedata
    void GetPrivateData(in Guid guid, ref uint pDataSize, nint /* optional void* */ pData);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-setprivatedata
    void SetPrivateData(in Guid guid, uint DataSize, nint /* optional void* */ pData);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-setprivatedatainterface
    void SetPrivateDataInterface(in Guid guid, nint pData);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-getfeaturelevel
    [PreserveSig]
    D3D_FEATURE_LEVEL GetFeatureLevel();

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-getcreationflags
    [PreserveSig]
    uint GetCreationFlags();

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-getdeviceremovedreason
    void GetDeviceRemovedReason();

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-getimmediatecontext
    [PreserveSig]
    void GetImmediateContext([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11DeviceContext>))] out ID3D11DeviceContext ppImmediateContext);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-setexceptionmode
    void SetExceptionMode(uint RaiseFlags);

    // https://learn.microsoft.com/windows/win32/api/d3d11/nf-d3d11-id3d11device-getexceptionmode
    [PreserveSig]
    uint GetExceptionMode();
}
