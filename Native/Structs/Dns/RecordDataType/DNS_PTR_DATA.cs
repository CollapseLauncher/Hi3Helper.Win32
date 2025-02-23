using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682080(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_PTR_DATA
    {
        public char* pNameHost;

        public ReadOnlySpan<char> GetNameHost() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pNameHost);

        public override string ToString() => GetNameHost().ToString();
    }
}
