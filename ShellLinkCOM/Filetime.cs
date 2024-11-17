﻿using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.ShellLinkCOM
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 0)]
    public partial struct Filetime
    {
        public uint dwLowDateTime;
        public uint dwHighDateTime;
    }
}
