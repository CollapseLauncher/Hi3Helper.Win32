using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_BUFFER_RTV
{
    [StructLayout(LayoutKind.Explicit)]
    public struct _Anonymous1_e__Union
    {
        [FieldOffset(0)]
        public uint FirstElement;

        [FieldOffset(0)]
        public uint ElementOffset;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct _Anonymous2_e__Union
    {
        [FieldOffset(0)]
        public uint NumElements;

        [FieldOffset(0)]
        public uint ElementWidth;
    }

    public _Anonymous1_e__Union Anonymous1;
    public _Anonymous2_e__Union Anonymous2;
}
