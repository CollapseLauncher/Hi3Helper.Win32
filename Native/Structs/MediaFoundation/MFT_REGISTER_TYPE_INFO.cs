using System;
using System.Runtime.InteropServices;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Structs.MediaFoundation;

[StructLayout(LayoutKind.Sequential)]
public struct MFT_REGISTER_TYPE_INFO
{
    public Guid GuidMajorType;
    public Guid GuidSubtype;
}
