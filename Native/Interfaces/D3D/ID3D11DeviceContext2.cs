using Hi3Helper.Win32.Native.Interfaces.DXGI;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.D3D;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D3D;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("420d5b32-b90c-4da4-bef0-359f6a24a83a")]
public partial interface ID3D11DeviceContext2 : ID3D11DeviceContext1
{
    // https://learn.microsoft.com/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-updatetilemappings
    void UpdateTileMappings([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Resource>))] ID3D11Resource pTiledResource, uint NumTiledResourceRegions, nint /* optional D3D11_TILED_RESOURCE_COORDINATE* */ pTiledResourceRegionStartCoordinates, nint /* optional D3D11_TILE_REGION_SIZE* */ pTiledResourceRegionSizes, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Buffer?>))] ID3D11Buffer? pTilePool, uint NumRanges, nint /* optional uint* */ pRangeFlags, nint /* optional uint* */ pTilePoolStartOffsets, nint /* optional uint* */ pRangeTileCounts, uint Flags);

    // https://learn.microsoft.com/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-copytilemappings
    void CopyTileMappings([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Resource>))] ID3D11Resource pDestTiledResource, in D3D11_TILED_RESOURCE_COORDINATE pDestRegionStartCoordinate, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Resource>))] ID3D11Resource pSourceTiledResource, in D3D11_TILED_RESOURCE_COORDINATE pSourceRegionStartCoordinate, in D3D11_TILE_REGION_SIZE pTileRegionSize, uint Flags);

    // https://learn.microsoft.com/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-copytiles
    [PreserveSig]
    void CopyTiles([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Resource>))] ID3D11Resource pTiledResource, in D3D11_TILED_RESOURCE_COORDINATE pTileRegionStartCoordinate, in D3D11_TILE_REGION_SIZE pTileRegionSize, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Buffer>))] ID3D11Buffer pBuffer, ulong BufferStartOffsetInBytes, uint Flags);

    // https://learn.microsoft.com/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-updatetiles
    [PreserveSig]
    void UpdateTiles([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Resource>))] ID3D11Resource pDestTiledResource, in D3D11_TILED_RESOURCE_COORDINATE pDestTileRegionStartCoordinate, in D3D11_TILE_REGION_SIZE pDestTileRegionSize, nint pSourceTileData, uint Flags);

    // https://learn.microsoft.com/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-resizetilepool
    void ResizeTilePool([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11Buffer>))] ID3D11Buffer pTilePool, ulong NewSizeInBytes);

    // https://learn.microsoft.com/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-tiledresourcebarrier
    [PreserveSig]
    void TiledResourceBarrier([MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11DeviceChild?>))] ID3D11DeviceChild? pTiledResourceOrViewAccessBeforeBarrier, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<ID3D11DeviceChild?>))] ID3D11DeviceChild? pTiledResourceOrViewAccessAfterBarrier);

    // https://learn.microsoft.com/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-isannotationenabled
    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    BOOL IsAnnotationEnabled();

    // https://learn.microsoft.com/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-setmarkerint
    [PreserveSig]
    void SetMarkerInt(string? pLabel, int Data);

    // https://learn.microsoft.com/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-begineventint
    [PreserveSig]
    void BeginEventInt(string? pLabel, int Data);

    // https://learn.microsoft.com/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-endevent
    [PreserveSig]
    void EndEvent();
}