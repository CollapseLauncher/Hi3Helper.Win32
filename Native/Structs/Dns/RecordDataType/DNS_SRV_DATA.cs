using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682097(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_SRV_DATA
    {
        public IntPtr pNameTarget;      // string
        public ushort uPriority;
        public ushort wWeight;
        public ushort wPort;
        public ushort Pad;
    }
}
