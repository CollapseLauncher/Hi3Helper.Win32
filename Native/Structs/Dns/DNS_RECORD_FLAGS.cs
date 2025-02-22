using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs.Dns
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682084(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_RECORD_FLAGS
    {
        internal uint data;

        // DWORD Section :2;
        public uint Section
        {
            get { return data & 0x3u; }
            set { data = data & ~0x3u | value & 0x3u; }
        }

        // DWORD Delete :1;
        public uint Delete
        {
            get { return data >> 2 & 0x1u; }
            set { data = data & ~(0x1u << 2) | (value & 0x1u) << 2; }
        }

        // DWORD CharSet :2;
        public uint CharSet
        {
            get { return data >> 3 & 0x3u; }
            set { data = data & ~(0x3u << 3) | (value & 0x3u) << 3; }
        }

        // DWORD Unused :3;
        public uint Unused
        {
            get { return data >> 5 & 0x7u; }
            set { data = data & ~(0x7u << 5) | (value & 0x7u) << 5; }
        }

        // DWORD Reserved :24;
        public uint Reserved
        {
            get { return data >> 8 & 0xFFFFFFu; }
            set { data = data & ~(0xFFFFFFu << 8) | (value & 0xFFFFFFu) << 8; }
        }
    }
}
