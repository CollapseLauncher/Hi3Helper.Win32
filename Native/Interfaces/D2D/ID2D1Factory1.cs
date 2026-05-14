using Hi3Helper.Win32.Native.Interfaces.D3D;
using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
public delegate nint PD2D1_EFFECT_FACTORY(nint effectImpl);

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("bb12d362-daee-4b9a-aa1d-14ba401cfa1f")]
public partial interface ID2D1Factory1 : ID2D1Factory
{
    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdevice
    void CreateDevice([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDXGIDevice>))] IDXGIDevice dxgiDevice, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Device>))] out ID2D1Device d2dDevice);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createstrokestyle(constd2d1_stroke_style_properties1_constfloat_uint32_id2d1strokestyle1)
    void CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES1 strokeStyleProperties, nint /* optional float* */ dashes, uint dashesCount, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1StrokeStyle1>))] out ID2D1StrokeStyle1 strokeStyle);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createpathgeometry
    void CreatePathGeometry([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1PathGeometry1>))] out ID2D1PathGeometry1 pathGeometry);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdrawingstateblock(constd2d1_drawing_state_description1_idwriterenderingparams_id2d1drawingstateblock1)
    void CreateDrawingStateBlock(nint /* optional D2D1_DRAWING_STATE_DESCRIPTION1* */ drawingStateDescription, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteRenderingParams?>))] IDWriteRenderingParams? textRenderingParams, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1DrawingStateBlock1>))] out ID2D1DrawingStateBlock1 drawingStateBlock);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-creategdimetafile
    void CreateGdiMetafile([MarshalUsing(typeof(UniqueComInterfaceMarshaller<IStream>))] IStream metafileStream, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1GdiMetafile>))] out ID2D1GdiMetafile metafile);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstream
    void RegisterEffectFromStream(in Guid classId, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IStream>))] IStream propertyXml, nint /* optional D2D1_PROPERTY_BINDING* */ bindings, uint bindingsCount, PD2D1_EFFECT_FACTORY effectFactory);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstring
    void RegisterEffectFromString(in Guid classId, string? propertyXml, nint /* optional D2D1_PROPERTY_BINDING* */ bindings, uint bindingsCount, PD2D1_EFFECT_FACTORY effectFactory);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-unregistereffect
    void UnregisterEffect(in Guid classId);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-getregisteredeffects
    void GetRegisteredEffects(nint /* optional Guid* */ effects, uint effectsCount, nint /* optional uint* */ effectsReturned, nint /* optional uint* */ effectsRegistered);

    // https://learn.microsoft.com/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-geteffectproperties
    void GetEffectProperties(in Guid effectId, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID2D1Properties>))] out ID2D1Properties properties);
}