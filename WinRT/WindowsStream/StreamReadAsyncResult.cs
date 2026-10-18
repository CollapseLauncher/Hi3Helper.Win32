using System;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Hi3Helper.Win32.WinRT.WindowsStream;

internal sealed class StreamReadAsyncResult : StreamOperationAsyncResult
{
    private readonly IBuffer _userBuffer;

    internal StreamReadAsyncResult(
        IAsyncOperationWithProgress<IBuffer, uint> asyncStreamReadOperation,
        IBuffer                                    buffer,
        AsyncCallback                              userCompletionCallback,
        object                                     userAsyncStateInfo,
        bool                                       processCompletedOperationInCallback)
        : base(asyncStreamReadOperation, userCompletionCallback, userAsyncStateInfo, processCompletedOperationInCallback)
    {
        _userBuffer = buffer != null ? buffer : throw new ArgumentNullException(nameof(buffer));
        asyncStreamReadOperation.Completed = StreamOperationCompletedCallback;
    }

    internal override void ProcessConcreteCompletedOperation(
        IAsyncInfo? completedOperation,
        out long   bytesCompleted)
    {
        ProcessConcreteCompletedOperation((IAsyncOperationWithProgress<IBuffer, uint>)completedOperation!, out bytesCompleted);
    }

    private void ProcessConcreteCompletedOperation(
        IAsyncOperationWithProgress<IBuffer, uint> completedOperation,
        out long                                   bytesCompleted)
    {
        WinRtIoHelper.EnsureResultsInUserBuffer(_userBuffer, completedOperation.GetResults());
        bytesCompleted = _userBuffer.Length;
    }
}
