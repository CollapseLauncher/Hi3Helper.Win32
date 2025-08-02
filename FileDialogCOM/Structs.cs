using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.FileDialogCOM
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct PROPERTYKEY
    {
        internal Guid fmtid;
        internal uint pid;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
    
    internal struct COMDLG_FILTERSPEC
    {
        internal nint pszName;
        internal nint pszSpec;
    }
}
