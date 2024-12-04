using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.ToastCOM
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NOTIFICATION_USER_INPUT_DATA
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Key;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string Value;
    }

    public struct ToastCommands
    {
        #region Properties
        public string Argument;

        public string Content;
        #endregion

        #region Constructors
        public ToastCommands(string arg, string content)
        {
            Argument = arg;
            Content = content;
        }
        #endregion
    }
}
