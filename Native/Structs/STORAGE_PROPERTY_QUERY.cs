using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct STORAGE_PROPERTY_QUERY
    {
        public              uint PropertyId;   // Use uint if documented as unsigned.
        public              uint QueryType;
        public unsafe fixed byte AdditionalParameters[1]; // Fixed-size array.
    }
}