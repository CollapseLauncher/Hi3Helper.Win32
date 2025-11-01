using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/cc982164(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_NAPTR_DATA
    {
        public ushort wOrder;
        public ushort wPreference;
        public char*  pFlags;
        public char*  pService;
        public char*  pRegularExpression;
        public char*  pReplacement;

        public ReadOnlySpan<char> GetFlags() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pFlags);
        public ReadOnlySpan<char> GetService() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pService);
        public ReadOnlySpan<char> GetRegularExpression() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pRegularExpression);
        public ReadOnlySpan<char> GetReplacement() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pReplacement);

        public override string ToString() => $"Flags: {GetFlags()} | Service: {GetService()} | RegularExpression: {GetRegularExpression()} | Replacement: {GetReplacement()}"; 
    }
}
