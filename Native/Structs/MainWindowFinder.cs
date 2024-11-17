using Hi3Helper.Win32.Native.Enums;
using System;

namespace Hi3Helper.Win32.Native.Structs
{
    public struct MainWindowFinder
    {
        private nint _bestHandle;
        private int _processId;

        public static unsafe nint FindMainWindow(int processId)
        {
            MainWindowFinder instance;

            instance._bestHandle = nint.Zero;
            instance._processId = processId;

            EnumWindowsProc enumWindowCallback = EnumWindowsCallback;
            PInvoke.EnumWindows(enumWindowCallback, (nint)(void*)&instance);

            return instance._bestHandle;
        }

        private static unsafe bool EnumWindowsCallback(nint handle, nint extraParameter)
        {
            MainWindowFinder* instance = (MainWindowFinder*)extraParameter;

            int processId = 0; // Avoid uninitialized variable if the window got closed in the meantime
            PInvoke.GetWindowThreadProcessId(handle, &processId);

            if ((processId == instance->_processId) && IsMainWindow(handle))
            {
                instance->_bestHandle = handle;
                return false;
            }
            return true;
        }

        private static bool IsMainWindow(nint handle) => (PInvoke.GetWindow(handle, GetWindowType.GW_OWNER) == nint.Zero) && PInvoke.IsWindowVisible(handle);
    }
}
