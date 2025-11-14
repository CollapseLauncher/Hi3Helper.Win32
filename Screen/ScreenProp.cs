using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using System.Buffers;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
// ReSharper disable ClassNeverInstantiated.Global

namespace Hi3Helper.Win32.Screen
{
    public class ScreenProp
    {
        public static Size CurrentResolution { get => GetScreenSize(); }

        private static unsafe int GetSizeOf<T>() where T : unmanaged => sizeof(T);

        public static IEnumerable<Size> EnumerateScreenSizes()
        {
            int index = 0;
            int found = 0;
            int sizeOfDevMode = GetSizeOf<DEVMODEW>();

            byte[] buffer = ArrayPool<byte>.Shared.Rent(sizeOfDevMode);
            nint bufferPtr = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
            try
            {
                int lastWidth = 0;
                int lastHeight = 0;
                while (PInvoke.EnumDisplaySettings(null, index, bufferPtr))
                {
                    ++index;
                    Size currentSize = GetSizeFromPtr(bufferPtr);
                    if (lastWidth == currentSize.Width && lastHeight == currentSize.Height)
                    {
                        continue;
                    }

                    ++found;
                    lastWidth  = currentSize.Width;
                    lastHeight = currentSize.Height;
                    yield return currentSize;
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }

            if (found == 0)
            {
                yield return GetScreenSize();
            }
        }

        public static int GetMaxHeight() => EnumerateScreenSizes().Max(x => x.Height);

        private static unsafe Size GetSizeFromPtr(nint ptr)
        {
            DEVMODEW* localDevMode = (DEVMODEW*)ptr;
            return new Size { Width = (int)localDevMode->dmPelsWidth, Height = (int)localDevMode->dmPelsHeight };
        }

        private static Size GetScreenSize() =>
            new Size
        {
            Width = PInvoke.GetSystemMetrics(SystemMetric.SM_CXSCREEN),
            Height = PInvoke.GetSystemMetrics(SystemMetric.SM_CYSCREEN)
        };
    }
}
