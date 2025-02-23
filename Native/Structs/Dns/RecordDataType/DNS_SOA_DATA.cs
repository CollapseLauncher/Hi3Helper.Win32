using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682096(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_SOA_DATA
    {
        public char* pNamePrimaryServer;
        public char* pNameAdministrator;
        public uint dwSerialNo;
        public uint dwRefresh;
        public uint dwRetry;
        public uint dwExpire;
        public uint dwDefaultTtl;

        public ReadOnlySpan<char> GetNamePrimaryServer() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pNamePrimaryServer);

        public ReadOnlySpan<char> GetNameAdministrator() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pNameAdministrator);

        public override string ToString() =>
            $"NamePrimaryServer: {GetNamePrimaryServer()} | " +
            $"NameAdministrator: {GetNameAdministrator()} | " +
            $"SerialNo: {dwSerialNo} | " +
            $"Refresh: {dwRefresh} | " +
            $"Retry: {dwRetry} | " +
            $"Expire: {dwExpire} | " +
            $"DefaultTtl: {dwDefaultTtl}";
    }
}
