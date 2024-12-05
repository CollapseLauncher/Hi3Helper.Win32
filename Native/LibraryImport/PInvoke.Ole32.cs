﻿using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.ShellLinkCOM;
using Hi3Helper.Win32.ToastCOM;
using System;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native.LibraryImport
{
    public static partial class PInvoke
    {
        [LibraryImport("ole32.dll", EntryPoint = "CoCreateInstance")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial HResult CoCreateInstance(in Guid rclsid, nint pUnkOuter, CLSCTX dwClsContext, in Guid riid, out void* ppObj);

        /// <summary>
        /// Called to properly clean up the memory referenced by a PropVariant instance.
        /// </summary>
        [LibraryImport("ole32.dll", EntryPoint = "PropVariantClear")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static unsafe partial HResult PropVariantClear(PropVariant* pvar);

        [LibraryImport("ole32.dll", EntryPoint = "CoRegisterClassObject")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static partial HResult CoRegisterClassObject(
            in Guid rclsid,
            [MarshalAs(UnmanagedType.Interface)] IClassFactory pUnk,
            uint dwClsContext,
            uint flags,
            out uint lpdwRegister);
    }
}
