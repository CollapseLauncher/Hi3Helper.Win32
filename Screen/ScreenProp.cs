using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Screen
{
    public class ScreenProp
    {
        public List<Size>? ScreenResolutions { get; private set; }
        public Size CurrentResolution { get => GetScreenSize(); }

        public ScreenProp()
        {
            int sizeOfDevMode = Marshal.SizeOf<DEVMODEW>();
            nint devModeHandle = Marshal.AllocCoTaskMem(sizeOfDevMode);

            try
            {
                ScreenResolutions = new List<Size>();
                for (int i = 0; PInvoke.EnumDisplaySettings(null, i, devModeHandle); i++)
                {
                    DEVMODEW localDevMode = Marshal.PtrToStructure<DEVMODEW>(devModeHandle);
                    if (ScreenResolutions.Count == 0)
                        ScreenResolutions.Add(new Size { Width = (int)localDevMode.dmPelsWidth, Height = (int)localDevMode.dmPelsHeight });
                    else if (!(ScreenResolutions[^1].Width == localDevMode.dmPelsWidth && ScreenResolutions[^1].Height == localDevMode.dmPelsHeight))
                        ScreenResolutions.Add(new Size { Width = (int)localDevMode.dmPelsWidth, Height = (int)localDevMode.dmPelsHeight });

                    Marshal.DestroyStructure<DEVMODEW>(devModeHandle);
                }
            }
            finally
            {
                Marshal.FreeCoTaskMem(devModeHandle);
            }

            // Some corner case
            if (ScreenResolutions.Count == 0)
            {
                ScreenResolutions.Add(GetScreenSize());
            }
        }

        public Size GetScreenSize() => new Size
        {
            Width = PInvoke.GetSystemMetrics(SystemMetric.SM_CXSCREEN),
            Height = PInvoke.GetSystemMetrics(SystemMetric.SM_CYSCREEN)
        };

        public int GetMaxHeight() => ScreenResolutions?.Max(x => x.Height) ?? 0;
    }
}
