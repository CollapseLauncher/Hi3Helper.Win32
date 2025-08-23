using Hi3Helper.Win32.Native.Enums;
using static Hi3Helper.Win32.Native.LibraryImport.PInvoke;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.ManagedTools
{
    public static class Windowing
    {
        public static void ShowWindow(nint windowPtr) => ShowWindowAsync(windowPtr, HandleEnum.SW_SHOWNORMAL);
        public static void ShowWindowMaximized(nint windowPtr) => ShowWindowAsync(windowPtr, HandleEnum.SW_SHOWMAXIMIZED);
        public static void HideWindow(nint windowPtr) => ShowWindowAsync(windowPtr, HandleEnum.SW_SHOWMINIMIZED);

        public static void SetWindowIcon(nint windowHandle, nint hIconLarge, nint hIconSmall)
        {
            const uint  WM_SETICON = 0x0080;
            const nuint ICON_BIG   = 1;
            const nuint ICON_SMALL = 0;
            SendMessage(windowHandle, WM_SETICON, ICON_BIG, hIconLarge);
            SendMessage(windowHandle, WM_SETICON, ICON_SMALL, hIconSmall);
        }
    }
}
