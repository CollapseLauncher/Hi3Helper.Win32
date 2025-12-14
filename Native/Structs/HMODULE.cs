using System;

namespace Hi3Helper.Win32.Native.Structs;

public struct HMODULE : IEquatable<HMODULE>
{
    public static readonly HMODULE Null = new();

    public nint Value;

    public HMODULE(nint value) => Value = value;
    public override readonly string ToString() => $"0x{Value:x}";

    public override readonly bool Equals(object? obj) => obj is HMODULE value && Equals(value);
    public readonly bool Equals(HMODULE other) => other.Value == Value;
    public override readonly int GetHashCode() => Value.GetHashCode();
    public static bool operator ==(HMODULE left, HMODULE right) => left.Equals(right);
    public static bool operator !=(HMODULE left, HMODULE right) => !left.Equals(right);
    public static implicit operator nint(HMODULE value) => value.Value;
    public static implicit operator HMODULE(nint value) => new(value);
}
