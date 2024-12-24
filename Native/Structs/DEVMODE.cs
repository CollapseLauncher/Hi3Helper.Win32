using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.Structs
{
    // Reference:
    // http://www.codeproject.com/KB/dotnet/changing-display-settings.aspx
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DEVMODEW
    {
        public fixed char dmDeviceName[32];
        public ushort dmSpecVersion;
        public ushort dmDriverVersion;
        public ushort dmSize;
        public ushort dmDriverExtra;
        public uint dmFields;
        public POINTL dmPosition;
        public uint dmDisplayOrientation;
        public uint dmDisplayFixedOutput;
        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;
        public fixed char dmFormName[32];
        public ushort dmLogPixels;
        public uint dmBitsPerPel;
        public uint dmPelsWidth;
        public uint dmPelsHeight;
        public uint dmDisplayFlags;
        public uint dmDisplayFrequency;
        public uint dmICMMethod;
        public uint dmICMIntent;
        public uint dmMediaType;
        public uint dmDitherType;
        public uint dmReserved1;
        public uint dmReserved2;
        public uint dmPanningWidth;
        public uint dmPanningHeight;

        public ReadOnlySpan<char> GetDeviceNameSpan
        {
            get
            {
                fixed (char* charPtr = &dmDeviceName[0])
                {
                    return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(charPtr);
                }
            }
        }

        public ReadOnlySpan<char> GetFormName
        {
            get
            {
                fixed (char* charPtr = &dmFormName[0])
                {
                    return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(charPtr);
                }
            }
        }
    }
}
