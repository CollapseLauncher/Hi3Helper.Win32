using Hi3Helper.Win32.Native.Interfaces.MediaFoundation;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.Native.Structs.MediaFoundation;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable StringLiteralTypo
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
#pragma warning disable CA1401

namespace Hi3Helper.Win32.Native.LibraryImport;

public static partial class PInvoke
{
    [LibraryImport("Mfplat.dll", EntryPoint = "MFStartup")]
    public static partial HResult MFStartup(uint version, uint dwFlags);

    [LibraryImport("Mfplat.dll", EntryPoint = "MFShutdown")]
    public static partial HResult MFShutdown();

    [LibraryImport("Mfplat.dll", EntryPoint = "MFCreateAttributes")]
    public static partial HResult MFCreateAttributes([In][MarshalUsing(CountElementName = nameof(cInitialSize))] nint[] ppMFAttributes, int cInitialSize);

    [LibraryImport("Mfplat.dll", EntryPoint = "MFTEnumEx")]
    public static partial HResult MFTEnumEx(
        in Guid                    guidCategory,
        uint                       flags,
        in  MFT_REGISTER_TYPE_INFO pInputType,
        in  MFT_REGISTER_TYPE_INFO pOutputType,

        [MarshalUsing(CountElementName = nameof(pnumMFTActivate))]
        out IMFActivate[] pppMFTActivate,
        out int           pnumMFTActivate);
}
