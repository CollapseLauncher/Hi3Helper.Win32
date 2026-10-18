using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Hi3Helper.Win32.WinRT.WindowsStream;

public sealed class WinRtToNetFxStreamAdapter : Stream, IDisposable
{
    private readonly bool _leaveOpen;

    private object? _winRtStream;

    private readonly bool _canRead;

    private readonly bool _canWrite;

    private readonly bool _canSeek;

    [field: AllowNull, MaybeNull]
    private byte[] OneByteBuffer
    {
        get => field ??= [];
    }

    public override bool CanRead
    {
        get
        {
            if (_canRead)
            {
                return _winRtStream != null;
            }

            return false;
        }
    }

    public override bool CanWrite
    {
        get
        {
            if (_canWrite)
            {
                return _winRtStream != null;
            }

            return false;
        }
    }

    public override bool CanSeek
    {
        get
        {
            if (_canSeek)
            {
                return _winRtStream != null;
            }

            return false;
        }
    }

    public override long Length
    {
        get
        {
            IRandomAccessStream randomAccessStream = EnsureNotDisposed<IRandomAccessStream>();
            if (!_canSeek)
            {
                throw new NotSupportedException();
            }

            ulong size = randomAccessStream.Size;
            if (size > long.MaxValue)
            {
                throw new IOException();
            }

            return (long)size;
        }
    }

    public override long Position
    {
        get
        {
            IRandomAccessStream randomAccessStream = EnsureNotDisposed<IRandomAccessStream>();
            if (!_canSeek)
            {
                throw new NotSupportedException();
            }

            ulong position = randomAccessStream.Position;
            if (position > long.MaxValue)
            {
                throw new IOException();
            }

            return (long)position;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Position));
            }

            IRandomAccessStream randomAccessStream = EnsureNotDisposed<IRandomAccessStream>();
            if (!_canSeek)
            {
                throw new NotSupportedException();
            }

            randomAccessStream.Seek((ulong)value);
        }
    }

    public static WinRtToNetFxStreamAdapter Create(object windowsRuntimeStream, bool leaveOpen = false)
    {
        ArgumentNullException.ThrowIfNull(windowsRuntimeStream);

        bool flag  = windowsRuntimeStream is IInputStream;
        bool flag2 = windowsRuntimeStream is IOutputStream;
        bool flag3 = windowsRuntimeStream is IRandomAccessStream;
        if (!flag && !flag2 && !flag3)
        {
            throw new ArgumentException(nameof(windowsRuntimeStream));
        }

        if (flag3)
        {
            IRandomAccessStream randomAccessStream = (IRandomAccessStream)windowsRuntimeStream;
            if (!flag && randomAccessStream.CanRead)
            {
                throw new ArgumentException();
            }

            if (!flag2 && randomAccessStream.CanWrite)
            {
                throw new ArgumentException();
            }

            if (!randomAccessStream.CanRead)
            {
                flag = false;
            }

            if (!randomAccessStream.CanWrite)
            {
                flag2 = false;
            }
        }

        if (!flag && !flag2)
        {
            throw new ArgumentException();
        }

        return new WinRtToNetFxStreamAdapter(windowsRuntimeStream, flag, flag2, flag3, leaveOpen);
    }

    private WinRtToNetFxStreamAdapter(object winRtStream, bool canRead, bool canWrite, bool canSeek, bool leaveOpen = false)
    {
        _winRtStream = winRtStream;
        _canRead     = canRead;
        _canWrite    = canWrite;
        _canSeek     = canSeek;
        _leaveOpen   = leaveOpen;
    }

    private TWinRtStream EnsureNotDisposed<TWinRtStream>() where TWinRtStream : class
    {
        return _winRtStream as TWinRtStream ?? throw new ObjectDisposedException(nameof(_winRtStream));
    }

    private void EnsureNotDisposed()
    {
        if (_winRtStream == null)
        {
            throw new ObjectDisposedException(nameof(_winRtStream));
        }
    }

    private void EnsureCanRead()
    {
        if (!_canRead)
        {
            throw new NotSupportedException();
        }
    }

    private void EnsureCanWrite()
    {
        if (!_canWrite)
        {
            throw new NotSupportedException();
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && _winRtStream != null && !_leaveOpen && _winRtStream is IDisposable disposable)
        {
            disposable.Dispose();
        }

        _winRtStream = null;
        base.Dispose(disposing);
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        IRandomAccessStream randomAccessStream = EnsureNotDisposed<IRandomAccessStream>();
        if (!_canSeek)
        {
            throw new NotSupportedException();
        }

        switch (origin)
        {
            case SeekOrigin.Begin:
                Position = offset;
                return offset;
            case SeekOrigin.Current:
                {
                    long position = Position;
                    if (long.MaxValue - position < offset)
                    {
                        throw new IOException();
                    }

                    long num5 = position + offset;
                    if (num5 < 0)
                    {
                        throw new IOException();
                    }

                    Position = num5;
                    return num5;
                }
            case SeekOrigin.End:
                {
                    ulong size = randomAccessStream.Size;
                    long num3;
                    if (size > long.MaxValue)
                    {
                        if (offset >= 0)
                        {
                            throw new IOException();
                        }

                        ulong num  = offset == long.MinValue ? 9223372036854775808uL : (ulong)-offset;
                        ulong num2 = size - num;
                        if (num2 > long.MaxValue)
                        {
                            throw new IOException();
                        }

                        num3 = (long)num2;
                    }
                    else
                    {
                        long num4 = (long)size;
                        if (long.MaxValue - num4 < offset)
                        {
                            throw new IOException();
                        }

                        num3 = num4 + offset;
                        if (num3 < 0)
                        {
                            throw new IOException();
                        }
                    }

                    Position = num3;
                    return num3;
                }
            default:
                throw new ArgumentException(nameof(origin));
        }
    }

    public override void SetLength(long value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
        IRandomAccessStream randomAccessStream = EnsureNotDisposed<IRandomAccessStream>();
        if (!_canSeek)
        {
            throw new NotSupportedException();
        }

        EnsureCanWrite();
        randomAccessStream.Size = (ulong)value;
        if (randomAccessStream.Size < randomAccessStream.Position)
        {
            randomAccessStream.Seek((ulong)value);
        }
    }

    [SupportedOSPlatform("windows10.0.10240.0")]
    private IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state, bool usedByBlockingWrapper)
    {
        ArgumentNullException.ThrowIfNull(buffer);
        ArgumentOutOfRangeException.ThrowIfLessThan(offset,                 0);
        ArgumentOutOfRangeException.ThrowIfLessThan(count,                  0);
        ArgumentOutOfRangeException.ThrowIfLessThan(buffer.Length - offset, count);

        IInputStream inputStream = EnsureNotDisposed<IInputStream>();
        EnsureCanRead();
        IBuffer buffer2 = buffer.AsBuffer(offset, count);
        IAsyncOperationWithProgress<IBuffer, uint> asyncStreamReadOperation = inputStream.ReadAsync(buffer2, (uint)count, InputStreamOptions.Partial);
        return new StreamReadAsyncResult(asyncStreamReadOperation, buffer2, callback, state, !usedByBlockingWrapper);
    }

    public override int EndRead(IAsyncResult asyncResult)
    {
        if (asyncResult is not StreamOperationAsyncResult streamOperationAsyncResult)
        {
            throw new ArgumentException(nameof(asyncResult));
        }

        EnsureNotDisposed();
        EnsureCanRead();

        streamOperationAsyncResult.Wait();
        try
        {
            if (!streamOperationAsyncResult.ProcessCompletedOperationInCallback)
            {
                streamOperationAsyncResult.ProcessCompletedOperation();
            }

            if (streamOperationAsyncResult.HasError)
            {
                streamOperationAsyncResult.CloseStreamOperation();
                streamOperationAsyncResult.ThrowCachedError();
            }

            long bytesCompleted = streamOperationAsyncResult.BytesCompleted;
            return (int)bytesCompleted;
        }
        finally
        {
            streamOperationAsyncResult.CloseStreamOperation();
        }
    }

    [SupportedOSPlatform("windows10.0.10240.0")]
    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(buffer);
        ArgumentOutOfRangeException.ThrowIfLessThan(offset,                 0);
        ArgumentOutOfRangeException.ThrowIfLessThan(count,                  0);
        ArgumentOutOfRangeException.ThrowIfLessThan(buffer.Length - offset, count);

        EnsureNotDisposed();
        EnsureCanRead();
        cancellationToken.ThrowIfCancellationRequested();
        return ReadAsyncInternal(buffer, offset, count, cancellationToken);
    }

    [SupportedOSPlatform("windows10.0.10240.0")]
    public override int Read(byte[] buffer, int offset, int count)
    {
        IAsyncResult asyncResult = BeginRead(buffer, offset, count, null!, null!, usedByBlockingWrapper: true);
        return EndRead(asyncResult);
    }

    [SupportedOSPlatform("windows10.0.10240.0")]
    public override int ReadByte()
    {
        byte[] oneByteBuffer = OneByteBuffer;
        if (Read(oneByteBuffer, 0, 1) == 0)
        {
            return -1;
        }

        return oneByteBuffer[0];
    }

    public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state)
    {
        return BeginWrite(buffer, offset, count, callback, state, usedByBlockingWrapper: false);
    }

    private IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state, bool usedByBlockingWrapper)
    {
        ArgumentNullException.ThrowIfNull(buffer);
        ArgumentOutOfRangeException.ThrowIfLessThan(offset,                 0);
        ArgumentOutOfRangeException.ThrowIfLessThan(count,                  0);
        ArgumentOutOfRangeException.ThrowIfLessThan(buffer.Length - offset, count);

        IOutputStream outputStream = EnsureNotDisposed<IOutputStream>();
        EnsureCanWrite();
        IBuffer buffer2 = buffer.AsBuffer(offset, count);
        IAsyncOperationWithProgress<uint, uint> asyncStreamWriteOperation = outputStream.WriteAsync(buffer2);
        return new StreamWriteAsyncResult(asyncStreamWriteOperation, callback!, state!, !usedByBlockingWrapper);
    }

    public override void EndWrite(IAsyncResult asyncResult)
    {
        if (asyncResult is not StreamOperationAsyncResult streamOperationAsyncResult)
        {
            throw new ArgumentException(nameof(asyncResult));
        }

        EnsureNotDisposed();
        EnsureCanWrite();

        streamOperationAsyncResult.Wait();
        try
        {
            if (!streamOperationAsyncResult.ProcessCompletedOperationInCallback)
            {
                streamOperationAsyncResult.ProcessCompletedOperation();
            }

            if (streamOperationAsyncResult.HasError)
            {
                streamOperationAsyncResult.CloseStreamOperation();
                streamOperationAsyncResult.ThrowCachedError();
            }
        }
        finally
        {
            streamOperationAsyncResult.CloseStreamOperation();
        }
    }

    [SupportedOSPlatform("windows10.0.10240.0")]
    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(buffer);
        ArgumentOutOfRangeException.ThrowIfLessThan(offset,                 0);
        ArgumentOutOfRangeException.ThrowIfLessThan(count,                  0);
        ArgumentOutOfRangeException.ThrowIfLessThan(buffer.Length - offset, count);

        IOutputStream outputStream = EnsureNotDisposed<IOutputStream>();
        EnsureCanWrite();
        cancellationToken.ThrowIfCancellationRequested();
        IBuffer buffer2 = buffer.AsBuffer(offset, count);
        IAsyncOperationWithProgress<uint, uint> source = outputStream.WriteAsync(buffer2);
        return source.AsTask(cancellationToken);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        IAsyncResult asyncResult = BeginWrite(buffer, offset, count, null, null, usedByBlockingWrapper: true);
        EndWrite(asyncResult);
    }

    public override void WriteByte(byte value)
    {
        byte[] oneByteBuffer = OneByteBuffer;
        oneByteBuffer[0] = value;
        Write(oneByteBuffer, 0, 1);
    }

    public override void Flush()
    {
        IOutputStream outputStream = EnsureNotDisposed<IOutputStream>();
        if (!_canWrite)
        {
            return;
        }

        IAsyncOperation<bool> asyncStreamFlushOperation = outputStream.FlushAsync();
        StreamFlushAsyncResult streamFlushAsyncResult = new StreamFlushAsyncResult(asyncStreamFlushOperation, processCompletedOperationInCallback: false);
        streamFlushAsyncResult.Wait();
        try
        {
            streamFlushAsyncResult.ProcessCompletedOperation();
            if (streamFlushAsyncResult.HasError)
            {
                streamFlushAsyncResult.CloseStreamOperation();
                streamFlushAsyncResult.ThrowCachedError();
            }
        }
        finally
        {
            streamFlushAsyncResult.CloseStreamOperation();
        }
    }

    [SupportedOSPlatform("windows10.0.10240.0")]
    public override Task FlushAsync(CancellationToken cancellationToken)
    {
        IOutputStream outputStream = EnsureNotDisposed<IOutputStream>();
        if (!_canWrite)
        {
            return Task.CompletedTask;
        }

        cancellationToken.ThrowIfCancellationRequested();
        IAsyncOperation<bool> source = outputStream.FlushAsync();
        return source.AsTask(cancellationToken);
    }

    [SupportedOSPlatform("windows10.0.10240.0")]
    private async Task<int> ReadAsyncInternal(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        IInputStream inputStream = EnsureNotDisposed<IInputStream>();
        try
        {
            IBuffer userBuffer = buffer.AsBuffer(offset, count);
            IAsyncOperationWithProgress<IBuffer, uint> source = inputStream.ReadAsync(userBuffer, (uint)count, InputStreamOptions.Partial);
            IBuffer buffer2 = await source.AsTask(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
            if (buffer2 == null)
            {
                return 0;
            }

            WinRtIoHelper.EnsureResultsInUserBuffer(userBuffer, buffer2);
            return (int)buffer2.Length;
        }
        catch (Exception nativeException)
        {
            WinRtIoHelper.NativeExceptionToIoExceptionInfo(nativeException).Throw();
            return 0;
        }
    }
}
