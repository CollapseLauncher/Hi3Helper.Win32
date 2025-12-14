using System;

namespace Hi3Helper.Win32.Native.Structs.D3D;

public struct D3D11_TEX1D_RTV : IEquatable<D3D11_TEX1D_RTV>
{
    public static readonly D3D11_TEX1D_RTV Null = new();

    public uint MipSlice;

    public D3D11_TEX1D_RTV(uint value) => MipSlice = value;
    public override readonly string ToString() => $"0x{MipSlice:x}";

    public override readonly bool Equals(object? obj) => obj is D3D11_TEX1D_RTV value && Equals(value);
    public readonly bool Equals(D3D11_TEX1D_RTV other) => other.MipSlice == MipSlice;
    public override readonly int GetHashCode() => MipSlice.GetHashCode();
    public static bool operator ==(D3D11_TEX1D_RTV left, D3D11_TEX1D_RTV right) => left.Equals(right);
    public static bool operator !=(D3D11_TEX1D_RTV left, D3D11_TEX1D_RTV right) => !left.Equals(right);
    public static implicit operator uint(D3D11_TEX1D_RTV value) => value.MipSlice;
    public static implicit operator D3D11_TEX1D_RTV(uint value) => new(value);
}
