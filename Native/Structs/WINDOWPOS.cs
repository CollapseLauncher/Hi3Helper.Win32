// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable UnassignedField.Global
namespace Hi3Helper.Win32.Native.Structs
{
    public struct WINDOWPOS
    {
        public nint windowHandle;
        public nint windowHandleInsertAfter;
        public int  x;
        public int  y;
        public int  cx;
        public int  cy;
        public uint flags;
    }
}
