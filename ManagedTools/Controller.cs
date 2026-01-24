using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using Microsoft.Extensions.Logging;
using System;

namespace Hi3Helper.Win32.ManagedTools;

public static class Controller
{
    private static ILogger? _logger;
    
    [Flags]
    public enum XInputButtons : ushort
    {
        DPadUp        = 0x0001,
        DPadDown      = 0x0002,
        DPadLeft      = 0x0004,
        DPadRight     = 0x0008,
        Start         = 0x0010,
        Back          = 0x0020,
        LeftThumb     = 0x0040,
        RightThumb    = 0x0080,
        LeftShoulder  = 0x0100,
        RightShoulder = 0x0200,
        A             = 0x1000,
        B             = 0x2000,
        X             = 0x4000,
        Y             = 0x8000
    }

    public static (int status, XINPUT_STATE? state) GetControllerState(
        int controllerIndex = 0,
        ILogger? logger = null)
    {
        try
        {
            _logger ??= logger;
            var result = PInvoke.XInputGetState(controllerIndex, out var state);

            if (result == 0) // Controller connected
            {
                return (result, state);
            }

            return (result, null);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Error when getting controller state!");
            return (-1, null);
        }
    }

    public static XInputButtons? GetButtonState(ILogger? logger = null)
    {
        _logger ??= logger;

        var r = GetControllerState();
        if (r.status == 1 || r.state == null) return null;

        return (XInputButtons)r.state.Value.Gamepad.wButtons;
    }
}