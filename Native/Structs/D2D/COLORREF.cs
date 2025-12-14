using System;

namespace Hi3Helper.Win32.Native.Structs.D2D;

public struct COLORREF : IEquatable<COLORREF>
{
    public static readonly COLORREF Null = new();

    public uint Value;

    public COLORREF(uint value) => Value = value;
    public override readonly string ToString() => $"0x{Value:x}";

    public override readonly bool Equals(object? obj) => obj is COLORREF value && Equals(value);
    public readonly bool Equals(COLORREF other) => other.Value == Value;
    public override readonly int GetHashCode() => Value.GetHashCode();
    public static bool operator ==(COLORREF left, COLORREF right) => left.Equals(right);
    public static bool operator !=(COLORREF left, COLORREF right) => !left.Equals(right);
    public static implicit operator uint(COLORREF value) => value.Value;
    public static implicit operator COLORREF(uint value) => new(value);
}
