﻿using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable UnassignedReadonlyField

namespace Hi3Helper.Win32.Native.Structs.Dns
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682082(v=vs.85).aspx
    /// These field offsets could be different depending on endianness and bitness
    /// </summary>
    public readonly unsafe struct DNS_RECORD
    {
        public readonly DNS_RECORD*   pNext;
        public readonly char*         pName;
        public readonly ushort        wType;
        public readonly ushort        wDataLength;
        public readonly DnsFlagsUnion Flags;
        public readonly uint          dwTtl;
        public readonly uint          dwReserved;
        public readonly DnsDataUnion  Data;

        public ReadOnlySpan<char> GetRecordName() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pName);

        public override string ToString() => GetRecordName().ToString();
    }
}
