using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682109(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_TXT_DATA
    {
        public uint  dwStringCount;
        public char* pStringArray;

        public ReadOnlySpan<char> GetStringArray() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pStringArray);

        public override string ToString() => GetStringArray().ToString();
    }
}
