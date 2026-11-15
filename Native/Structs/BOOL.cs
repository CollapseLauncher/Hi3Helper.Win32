using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct BOOL : IEquatable<BOOL>
{
    public static BOOL Null => default;

    public int Value;

    public BOOL(int value) => Value = value;

    public readonly override bool Equals(object? obj) => obj is BOOL value && Equals(value);

    public readonly bool Equals(BOOL other) => other.Value == Value;

    public readonly override int GetHashCode() => Value.GetHashCode();

    public static bool operator ==(BOOL left, BOOL right) => left.Equals(right);

    public static bool operator !=(BOOL left, BOOL right) => !left.Equals(right);

    public static implicit operator bool(BOOL value) => value.Value == 1;

    public static implicit operator BOOL(bool value) => new(value ? 1 : 0);

    public static implicit operator int(BOOL value) => value.Value;

    public static implicit operator BOOL(int value) => new(value);
}
