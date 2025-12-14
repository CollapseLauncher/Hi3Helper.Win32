namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_CLASS_INSTANCE_DESC
{
    public uint InstanceId;
    public uint InstanceIndex;
    public uint TypeId;
    public uint ConstantBuffer;
    public uint BaseConstantBufferOffset;
    public uint BaseTexture;
    public uint BaseSampler;
    public BOOL Created;
}