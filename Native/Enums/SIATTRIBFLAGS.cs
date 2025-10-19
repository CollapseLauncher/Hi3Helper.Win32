// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.Native.Enums
{
    public enum SIATTRIBFLAGS : uint
    {
        SIATTRIBFLAGS_AND       = 0x00000001, // if multiple items and the attributes together.
        SIATTRIBFLAGS_OR        = 0x00000002, // if multiple items or the attributes together.
        SIATTRIBFLAGS_APPCOMPAT = 0x00000003  // Call GetAttributes directly on the ShellFolder for multiple attributes 
    }
}
