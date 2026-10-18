using Windows.Foundation;

namespace Hi3Helper.Win32.WinRT.WindowsStream;

internal class StreamFlushAsyncResult : StreamOperationAsyncResult
{
    internal StreamFlushAsyncResult(IAsyncOperation<bool> asyncStreamFlushOperation, bool processCompletedOperationInCallback)

        : base(asyncStreamFlushOperation, null!, null!, processCompletedOperationInCallback)
    {
        asyncStreamFlushOperation.Completed = StreamOperationCompletedCallback;
    }

    internal override void ProcessConcreteCompletedOperation(IAsyncInfo? completedOperation, out long bytesCompleted)
    {
        ProcessConcreteCompletedOperation((IAsyncOperation<bool>)completedOperation!, out bytesCompleted);
    }

    private static void ProcessConcreteCompletedOperation(IAsyncOperation<bool> completedOperation, out long bytesCompleted)
    {
        bool success = completedOperation.GetResults();
        bytesCompleted = success ? 0 : -1;
    }
}
