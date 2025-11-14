using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable MemberCanBePrivate.Global

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682067(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_MINFO_DATA
    {
        public char* pNameMailbox;
        public char* pNameErrorsMailbox;

        public ReadOnlySpan<char> GetNameMailbox() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pNameMailbox);
        public ReadOnlySpan<char> GetNameErrorsMailbox() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pNameErrorsMailbox);

        public override string ToString() => $"Mailbox: {GetNameMailbox()} | ErrorMailbox: {GetNameErrorsMailbox()}";
    }
}
