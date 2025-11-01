using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682113(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_WINSR_DATA
    {
        public uint  dwMappingFlag;
        public uint  dwLookupTimeout;
        public uint  dwCacheTimeout;
        public char* pNameResultDomain;

        public ReadOnlySpan<char> GetNameResultDomain() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pNameResultDomain);

        public override string ToString() => GetNameResultDomain().ToString();
    }
}
