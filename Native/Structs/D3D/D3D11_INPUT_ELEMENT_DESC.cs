using Hi3Helper.Win32.Native.Enums.D3D;
using Hi3Helper.Win32.Native.Enums.DXGI;

namespace Hi3Helper.Win32.Native.Structs.D3D;

public unsafe struct D3D11_INPUT_ELEMENT_DESC
{
    public byte* SemanticName;
    public uint SemanticIndex;
    public DXGI_FORMAT Format;
    public uint InputSlot;
    public uint AlignedByteOffset;
    public D3D11_INPUT_CLASSIFICATION InputSlotClass;
    public uint InstanceDataStepRate;
}
