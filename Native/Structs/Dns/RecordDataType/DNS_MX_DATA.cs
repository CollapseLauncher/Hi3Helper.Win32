using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682070(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_MX_DATA
    {
        public char*  pNameExchange;
        public ushort wPreference;
        public ushort Pad;

        public ReadOnlySpan<char> GetNameExchange() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pNameExchange);

        public override string ToString() => GetNameExchange().ToString();
    }
}
