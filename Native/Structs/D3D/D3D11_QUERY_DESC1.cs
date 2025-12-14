using Hi3Helper.Win32.Native.Enums.D3D;

namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_QUERY_DESC1
{
    public D3D11_QUERY Query;
    public uint MiscFlags;
    public D3D11_CONTEXT_TYPE ContextType;
}
