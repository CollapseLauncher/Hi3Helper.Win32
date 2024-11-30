using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DEVICE_TRIM_DESCRIPTOR
    {
        public uint Version;
        public uint Size;
        public byte TrimEnabled; // Represent bool as a byte for blittability.
    }
}