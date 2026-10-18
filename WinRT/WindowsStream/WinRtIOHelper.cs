using System;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;

namespace Hi3Helper.Win32.WinRT.WindowsStream;

internal static class WinRtIoHelper
{
    internal static ExceptionDispatchInfo NativeExceptionToIoExceptionInfo(Exception nativeException)
    {
        if (!(nativeException.GetType() == typeof(Exception)))
            return ExceptionDispatchInfo.Capture(nativeException);
        string message = nativeException.Message;
        if (string.IsNullOrWhiteSpace(message))
            message = "SR.IO_General";

        return ExceptionDispatchInfo.Capture(new IOException(message, nativeException));
    }

    internal static void EnsureResultsInUserBuffer(IBuffer userBuffer, IBuffer resultBuffer)
    {
        if (resultBuffer.IsSameData(userBuffer))
            return;

        resultBuffer.CopyTo(userBuffer);
        userBuffer.Length = resultBuffer.Length;
    }
}
