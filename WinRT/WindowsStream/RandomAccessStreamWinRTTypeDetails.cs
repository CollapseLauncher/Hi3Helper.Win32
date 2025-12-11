/*
 * This code was decompiled from Microsoft.Windows.SDK.NET library
 * with some changes included.
 */

using ABI.System;
using ABI.Windows.Storage.Streams;
using System.Runtime.InteropServices;
using WinRT;
// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.WinRT.WindowsStream;

internal sealed class RandomAccessStreamWinRTTypeDetails : IWinRTExposedTypeDetails
{
    public ComWrappers.ComInterfaceEntry[] GetExposedInterfaces()
    {
        return
        [
            new ComWrappers.ComInterfaceEntry
            {
                IID = IRandomAccessStreamMethods.IID,
                Vtable = IRandomAccessStreamMethods.AbiToProjectionVftablePtr
            },
            new ComWrappers.ComInterfaceEntry
            {
                IID = IInputStreamMethods.IID,
                Vtable = IInputStreamMethods.AbiToProjectionVftablePtr
            },
            new ComWrappers.ComInterfaceEntry
            {
                IID = IOutputStreamMethods.IID,
                Vtable = IOutputStreamMethods.AbiToProjectionVftablePtr
            },
            new ComWrappers.ComInterfaceEntry
            {
                IID = IDisposableMethods.IID,
                Vtable = IDisposableMethods.AbiToProjectionVftablePtr
            }
        ];
    }
}
