using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using Windows.Foundation;

namespace Hi3Helper.Win32.WinRT.WindowsStream;

internal abstract partial class StreamOperationAsyncResult : IAsyncResult
{
    private readonly AsyncCallback? _userCompletionCallback;
    private readonly object?        _userAsyncStateInfo;

    private IAsyncInfo? _asyncStreamOperation;

    private volatile bool              _completed;
    private volatile bool              _callbackInvoked;
    private volatile ManualResetEvent? _waitHandle;

    private long _bytesCompleted;

    private ExceptionDispatchInfo? _errorInfo;

    private readonly bool        _processCompletedOperationInCallback;
    private          IAsyncInfo? _completedOperation;


    protected internal StreamOperationAsyncResult(IAsyncInfo asyncStreamOperation,
                                                  AsyncCallback userCompletionCallback, object userAsyncStateInfo,
                                                  bool processCompletedOperationInCallback)
    {
        _userCompletionCallback = userCompletionCallback;
        _userAsyncStateInfo = userAsyncStateInfo;

        _asyncStreamOperation = asyncStreamOperation ?? throw new ArgumentNullException(nameof(asyncStreamOperation));

        _completed = false;
        _callbackInvoked = false;

        _bytesCompleted = 0;

        _errorInfo = null;

        _processCompletedOperationInCallback = processCompletedOperationInCallback;
    }


    public object? AsyncState
    {
        get { return _userAsyncStateInfo; }
    }


    internal bool ProcessCompletedOperationInCallback
    {
        get { return _processCompletedOperationInCallback; }
    }


    public WaitHandle AsyncWaitHandle
    {
        get
        {
            ManualResetEvent? wh = _waitHandle;
            if (wh != null)
                return wh;

            // What if someone calls this public property and decides to wait on it?
            // > Use 'completed' in the ctor - this way the handle wait will return as appropriate.
            wh = new ManualResetEvent(_completed);

            ManualResetEvent? otherHandle = Interlocked.CompareExchange(ref _waitHandle, wh, null);

            // We lost the race. Dispose OUR handle and return OTHER handle:
            if (otherHandle == null)
            {
                return wh;
            }

            wh.Dispose();
            return otherHandle;

            // We won the race. Return OUR new handle:
        }
    }

    public bool CompletedSynchronously
    {
        get { return false; }
    }


    public bool IsCompleted
    {
        get { return _completed; }
    }


    internal void Wait()
    {
        if (_completed)
            return;

        WaitHandle wh = AsyncWaitHandle;

        while (!_completed)
            wh.WaitOne();
    }


    internal long BytesCompleted
    {
        get { return _bytesCompleted; }
    }


    internal bool HasError
    {
        get { return _errorInfo != null; }
    }


    internal void ThrowCachedError()
    {
        _errorInfo?.Throw();
    }


    internal bool CancelStreamOperation()
    {
        if (_callbackInvoked)
            return false;

        if (_asyncStreamOperation == null)
        {
            return true;
        }

        _asyncStreamOperation.Cancel();
        _asyncStreamOperation = null;

        return true;
    }

    internal void CloseStreamOperation()
    {
        try
        {
            _asyncStreamOperation?.Close();
        }
        catch
        {
            // ignored
        }
        _asyncStreamOperation = null;
    }


    ~StreamOperationAsyncResult()
    {
        // This finalisation is not critical, but we can still make an effort to notify the underlying WinRT stream
        // that we are not any longer interested in the results:
        CancelStreamOperation();
    }


    internal abstract void ProcessConcreteCompletedOperation(IAsyncInfo? completedOperation, out long bytesCompleted);


    private static void ProcessCompletedOperation_InvalidOperationThrowHelper(ExceptionDispatchInfo? errInfo, string? errMsg = null)
    {
        Exception? errInfoSrc = errInfo == null! ? null : errInfo.SourceException;
        if (errInfoSrc == null)
            throw new InvalidOperationException(errMsg);

        throw new InvalidOperationException(errMsg, errInfoSrc);
    }


    internal void ProcessCompletedOperation()
    {
        // The error handling is slightly tricky here:
        // Before processing the IO results, we are verifying some basic assumptions and if they do not hold, we are
        // throwing InvalidOperation. However, by the time this method is called, we might have already stored something
        // into errorInfo, e.g. if an error occurred in StreamOperationCompletedCallback. If that is the case, then that
        // previous exception might include some important info relevant for detecting the problem. So, we take that
        // previous exception and attach it as the inner exception to the InvalidOperationException being thrown.
        // In cases where we have a good understanding of the previously saved errorInfo, and we know for sure that it
        // the immediate reason for the state validation to fail, we can avoid throwing InvalidOperation altogether
        // and only rethrow the errorInfo.

        if (!_callbackInvoked)
            ProcessCompletedOperation_InvalidOperationThrowHelper(_errorInfo);

        if (!_processCompletedOperationInCallback && !_completed)
            ProcessCompletedOperation_InvalidOperationThrowHelper(_errorInfo);

        if (_completedOperation == null!)
        {
            ExceptionDispatchInfo? errInfo = _errorInfo;
            Exception? errInfoSrc = errInfo == null! ? null : errInfo.SourceException;

            // See if errorInfo is set because we observed completedOperation == null previously (being slow is Ok on error path):
            if (errInfoSrc is NullReferenceException)
            {
                errInfo?.Throw();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        if (_completedOperation?.Id != _asyncStreamOperation?.Id)
            ProcessCompletedOperation_InvalidOperationThrowHelper(_errorInfo);

        if (_completedOperation?.Status == AsyncStatus.Error)
        {
            _bytesCompleted = 0;
            ThrowWithIoExceptionDispatchInfo(_completedOperation.ErrorCode);
        }

        ProcessConcreteCompletedOperation(_completedOperation, out _bytesCompleted);
    }


    internal void StreamOperationCompletedCallback(IAsyncInfo completedOperation, AsyncStatus unusedCompletionStatus)
    {
        try
        {
            if (_callbackInvoked)
                throw new InvalidOperationException();

            _callbackInvoked = true;

            // This happens in rare stress cases in Console mode and the WinRT folks said they are unlikely to fix this in Dev11.
            // Moreover, this can happen if the underlying WinRT stream has a faulty user implementation.
            // If we did not do this check, we would either get the same exception without the explaining message when dereferencing
            // completedOperation later, or we will get an InvalidOperation when processing the Op. With the check, they will be
            // aggregated and the user will know what went wrong.
            _completedOperation = completedOperation ?? throw new NullReferenceException();

            // processCompletedOperationInCallback == false indicates that the stream is doing a blocking wait on the waitHandle of this IAsyncResult.
            // In that case calls on completedOperation may deadlock if completedOperation is not free threaded.
            // By setting processCompletedOperationInCallback to false the stream that created this IAsyncResult indicated that it
            // will call ProcessCompletedOperation after the waitHandle is signalled to fetch the results.

            if (_processCompletedOperationInCallback)
                ProcessCompletedOperation();
        }
        catch (Exception ex)
        {
            _bytesCompleted = 0;
            _errorInfo      = ExceptionDispatchInfo.Capture(ex);
        }
        finally
        {
            _completed = true;
            Interlocked.MemoryBarrier();
            // From this point on, AsyncWaitHandle would create a handle that is readily set,
            // so we do not need to check if it is being produced asynchronously.
            _waitHandle?.Set();
        }

        _userCompletionCallback?.Invoke(this);
    }

    private static void ThrowWithIoExceptionDispatchInfo(Exception e)
    {
        WinRtIoHelper.NativeExceptionToIoExceptionInfo(e).Throw();
    }
}
