using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.ManagedTools;

public class Keyboard
{
    private const uint KEYEVENTF_KEYUP = 0x0002;
    private const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
    private const uint KEYEVENTF_SCANCODE    = 0x0008;

    [Flags]
    public enum KeyboardButtons : ushort
    {
        Up = 0x26,
        Down = 0x28,
        Left = 0x25,
        Right = 0x27,
        
        Enter = 0x0D,
        Esc = 0x1B,
        Tab = 0x09
    }

    [Flags]
    public enum ScanCodes : ushort
    {
        ScanUp    = 0x48,
        ScanDown  = 0x50,
        ScanLeft  = 0x4B,
        ScanRight = 0x4D
    }
    
    public static void KeyboardDown(KeyboardButtons vk) => Send(vk, 0);
    public static void KeyboardUp(KeyboardButtons   vk) => Send(vk, KEYEVENTF_KEYUP);

    private static void Send(KeyboardButtons vk, uint flags)
    {
        INPUT[] input =
        [
            new INPUT
            {
                type = 1, // INPUT_KEYBOARD
                ki = new KEYBDINPUT
                {
                    wVk         = (ushort)vk,
                    wScan       = 0,
                    dwFlags     = flags,
                    time        = 0,
                    dwExtraInfo = 0
                }
            }
        ];

        PInvoke.SendInput(1, input, Marshal.SizeOf<INPUT>());
    }
    
    private static void SendArrow(ushort scanCode, bool down)
    {
        INPUT[] input =
        [
            new INPUT
            {
                type = 1, // INPUT_KEYBOARD
                ki = new KEYBDINPUT
                {
                    wVk   = 0,
                    wScan = scanCode,
                    dwFlags = KEYEVENTF_SCANCODE |
                              KEYEVENTF_EXTENDEDKEY |
                              (down ? 0 : KEYEVENTF_KEYUP),
                    time        = 0,
                    dwExtraInfo = 0
                }
            }
        ];

        PInvoke.SendInput(1, input, Marshal.SizeOf<INPUT>());
    }

}