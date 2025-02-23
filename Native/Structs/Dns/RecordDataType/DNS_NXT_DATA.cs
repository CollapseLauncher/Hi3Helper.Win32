using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682076(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_NXT_DATA
    {
        public IntPtr pNameNext;    // string
        public ushort wNumTypes;
        public IntPtr wTypes;       // WORD  wTypes[1];
    }
}
