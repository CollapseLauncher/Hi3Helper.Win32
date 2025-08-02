using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace Hi3Helper.Win32.Native.Structs.Dns.RecordDataType
{
    /// <summary>
    /// See http://msdn.microsoft.com/en-us/library/windows/desktop/ms682094(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_SIG_DATA
    {
        public char*  pNameSigner;
        public ushort wTypeCovered;
        public byte   chAlgorithm;
        public byte   chLabelCount;
        public uint   dwOriginalTtl;
        public uint   dwExpiration;
        public uint   dwTimeSigned;
        public ushort wKeyTag;
        public ushort Pad;
        public IntPtr Signature; // BYTE  Signature[1];

        public ReadOnlySpan<char> GetNameSigner() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pNameSigner);

        public override string ToString() =>
            $"Signer: {GetNameSigner()} | " +
            $"TypeCovered: {wTypeCovered} | " +
            $"Algorithm: {chAlgorithm} | " +
            $"LabelCount: {chLabelCount} | " +
            $"OriginalTtl: {dwOriginalTtl} | " +
            $"Expiration: {dwExpiration} | " +
            $"TimeSigned: {dwTimeSigned} | " +
            $"KeyTag: {wKeyTag}";
    }
}
