﻿using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682097(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_SRV_DATA
    {
        public char* pNameTarget;
        public ushort uPriority;
        public ushort wWeight;
        public ushort wPort;
        public ushort Pad;

        public ReadOnlySpan<char> GetNameTarget() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pNameTarget);

        public override string ToString() => GetNameTarget().ToString();
    }
}
