using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs;

[StructLayout(LayoutKind.Sequential, Size = 2)]
public readonly struct VARIANT_BOOL
{
    private readonly short _value;

    private VARIANT_BOOL(short value)
    {
        _value = value;
    }

    public static implicit operator bool(VARIANT_BOOL value) => value._value == unchecked((short)0xFFFF);

    public static implicit operator VARIANT_BOOL(bool value) => new(value ? unchecked((short)0xFFFF) : (short)0);

    public static bool operator ==(VARIANT_BOOL from, bool to) => (bool)from == to;

    public static bool operator !=(VARIANT_BOOL from, bool to) => !(from == to);

    public static bool operator ==(VARIANT_BOOL from, VARIANT_BOOL to) => (bool)from == (bool)to;

    public static bool operator !=(VARIANT_BOOL from, VARIANT_BOOL to) => (bool)from != (bool)to;

    public override int GetHashCode() => _value.GetHashCode();

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is VARIANT_BOOL asVariantBool &&
               this == asVariantBool;
    }
}
