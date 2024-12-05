﻿using Hi3Helper.Win32.ToastCOM.Notification;
using System;
using System.Runtime.InteropServices;
using System.Xml;

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
}
