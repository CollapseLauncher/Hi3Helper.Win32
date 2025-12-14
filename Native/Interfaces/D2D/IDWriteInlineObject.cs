using Hi3Helper.Win32.Native.Enums.D2D;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.D2D;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.D2D;

[GeneratedComInterface]
[Guid("8339fde3-106f-47ab-8373-1c6295eb10b3")]
public partial interface IDWriteInlineObject
{
    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwriteinlineobject-draw
    void Draw(nint /* optional void* */ clientDrawingContext, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IDWriteTextRenderer>))] IDWriteTextRenderer renderer, float originX, float originY, BOOL isSideways, BOOL isRightToLeft, nint clientDrawingEffect);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwriteinlineobject-getmetrics
    void GetMetrics(out DWRITE_INLINE_OBJECT_METRICS metrics);

    // https://learn.microsoft.com/windows/win32/DirectWrite/idwriteinlineobject-getoverhangmetrics
    void GetOverhangMetrics(out DWRITE_OVERHANG_METRICS overhangs);

    // https://learn.microsoft.com/windows/win32/api/dwrite/nf-dwrite-idwriteinlineobject-getbreakconditions
    void GetBreakConditions(out DWRITE_BREAK_CONDITION breakConditionBefore, out DWRITE_BREAK_CONDITION breakConditionAfter);
}