using System;
using Windows.Foundation;

namespace Hi3Helper.Win32.WinRT.WindowsStream;

internal class StreamWriteAsyncResult : StreamOperationAsyncResult
{
    internal StreamWriteAsyncResult(IAsyncOperationWithProgress<uint, uint> asyncStreamWriteOperation,
                                    AsyncCallback userCompletionCallback, object userAsyncStateInfo,
                                    bool processCompletedOperationInCallback)

        : base(asyncStreamWriteOperation, userCompletionCallback, userAsyncStateInfo, processCompletedOperationInCallback)
    {
        asyncStreamWriteOperation.Completed = StreamOperationCompletedCallback;
    }


    internal override void ProcessConcreteCompletedOperation(IAsyncInfo? completedOperation, out long bytesCompleted)
    {
        ProcessConcreteCompletedOperation((IAsyncOperationWithProgress<uint, uint>)completedOperation!, out bytesCompleted);
    }


    private static void ProcessConcreteCompletedOperation(IAsyncOperationWithProgress<uint, uint> completedOperation, out long bytesCompleted)
    {
        uint bytesWritten = completedOperation.GetResults();
        bytesCompleted = bytesWritten;
    }
}