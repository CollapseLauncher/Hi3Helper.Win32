/*
 * This code was decompiled from Microsoft.Windows.SDK.NET library
 * with some changes included.
 */

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Windows.Foundation;
using Windows.Storage.Streams;
using WinRT;
using static Hi3Helper.Win32.WinRT.WindowsStream.NetFxToWinRtStreamAdapter;
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.WinRT.WindowsStream;

public static class RandomStreamExtension
{
    extension(Stream stream)
    {
        [OverloadResolutionPriority(1)]
        public IRandomAccessStream AsRandomAccessStream(bool bypassChecks)
        {
            if (!bypassChecks)
            {
                return stream.AsRandomAccessStream();
            }

            StreamReadOperationOptimization opt = stream.GetOptimization();

            NetFxToWinRtStreamAdapter.RandomAccessStream streamAdapter = new(stream, opt);
            streamAdapter.SetWonInitializationRace();
            return streamAdapter;
        }

        [OverloadResolutionPriority(1)]
        public IInputStream AsInputStream(bool bypassChecks)
        {
            if (!bypassChecks)
            {
                return stream.AsInputStream();
            }

            StreamReadOperationOptimization opt = stream.GetOptimization();

            if (stream.CanWrite)
            {
                InputOutputStream stream1Adapter = new(stream, opt);
                stream1Adapter.SetWonInitializationRace();
                return stream1Adapter;
            }

            InputStream streamAdapter = new(stream, opt);
            streamAdapter.SetWonInitializationRace();
            return streamAdapter;
        }

        [OverloadResolutionPriority(1)]
        public IOutputStream AsOutputStream(bool bypassChecks)
        {
            if (!bypassChecks)
            {
                return stream.AsOutputStream();
            }

            if (stream.CanRead)
            {
                return (IOutputStream)stream.AsInputStream(bypassChecks);
            }

            StreamReadOperationOptimization opt = stream.GetOptimization();

            OutputStream streamAdapter = new(stream, opt);
            streamAdapter.SetWonInitializationRace();
            return streamAdapter;
        }

        private StreamReadOperationOptimization GetOptimization()
            => stream is MemoryStream
                ? StreamReadOperationOptimization.MemoryStream
                : StreamReadOperationOptimization.AbstractStream;
    }
}

public abstract class NetFxToWinRtStreamAdapter : IDisposable
{
    [WinRTRuntimeClassName("Windows.Storage.Streams.IInputStream")]
    [WinRTExposedType(typeof(InputStreamWinRTTypeDetails))]
    public sealed class InputStream(Stream stream, StreamReadOperationOptimization readOptimization)
        : NetFxToWinRtStreamAdapter(stream, readOptimization), IInputStream;

    [WinRTRuntimeClassName("Windows.Storage.Streams.IOutputStream")]
    [WinRTExposedType(typeof(OutputStreamWinRTTypeDetails))]
    public sealed class OutputStream(Stream stream, StreamReadOperationOptimization readOptimization)
        : NetFxToWinRtStreamAdapter(stream, readOptimization), IOutputStream;

    [WinRTRuntimeClassName("Windows.Storage.Streams.IRandomAccessStream")]
    [WinRTExposedType(typeof(RandomAccessStreamWinRTTypeDetails))]
    public sealed class RandomAccessStream(Stream stream, StreamReadOperationOptimization readOptimization)
        : NetFxToWinRtStreamAdapter(stream, readOptimization), IRandomAccessStream;

    [WinRTRuntimeClassName("Windows.Storage.Streams.IInputStream")]
    [WinRTExposedType(typeof(InputOutputStreamWinRTTypeDetails))]
    public sealed class InputOutputStream(Stream stream, StreamReadOperationOptimization readOptimization)
        : NetFxToWinRtStreamAdapter(stream, readOptimization), IInputStream, IOutputStream;

    public enum StreamReadOperationOptimization
    {
        AbstractStream,
        MemoryStream
    }

    private Stream? _managedStream;

    private bool _leaveUnderlyingStreamOpen = true;

    private readonly StreamReadOperationOptimization _readOptimization;

    public bool CanRead
    {
        get
        {
            Stream stream = EnsureNotDisposed();
            return stream.CanRead;
        }
    }

    public bool CanWrite
    {
        get
        {
            Stream stream = EnsureNotDisposed();
            return stream.CanWrite;
        }
    }

    public ulong Position
    {
        get
        {
            Stream stream = EnsureNotDisposed();
            return (ulong)stream.Position;
        }
    }

    public ulong Size
    {
        get
        {
            Stream stream = EnsureNotDisposed();
            return (ulong)stream.Length;
        }
        set
        {
            if (value > long.MaxValue)
            {
                IndexOutOfRangeException ex = new("Value has been set which exceeds long.MaxValue");
                ex.SetHResult(-2147024809);
                throw ex;
            }

            Stream stream = EnsureNotDisposed();
            if (!stream.CanWrite)
            {
                InvalidOperationException ex2 = new();
                ex2.SetHResult(-2147483634);
                throw ex2;
            }

            stream.SetLength((long)value);
        }
    }

    private NetFxToWinRtStreamAdapter(Stream stream, StreamReadOperationOptimization readOptimization)
    {
        _readOptimization = readOptimization;
        _managedStream = stream;
    }

    internal void SetWonInitializationRace()
    {
        _leaveUnderlyingStreamOpen = false;
    }

    private Stream EnsureNotDisposed()
    {
        if (_managedStream is { } managedStream)
        {
            return managedStream;
        }

        ObjectDisposedException ex = new(nameof(_managedStream));
        ex.SetHResult(-2147483629);
        throw ex;
    }

    void IDisposable.Dispose()
    {
        if (_managedStream is { } managedStream)
        {
            _managedStream = null;
            if (!_leaveUnderlyingStreamOpen)
            {
                managedStream.Dispose();
            }
        }

        GC.SuppressFinalize(this);
    }

    [SupportedOSPlatform("windows10.0.10240.0")]
    public IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
    {
        ArgumentNullException.ThrowIfNull(buffer);

        if (count > int.MaxValue)
        {
            ArgumentOutOfRangeException ex = new(nameof(count));
            ex.SetHResult(-2147024809);
            throw ex;
        }

        if (buffer.Capacity < count)
        {
            ThrowCapacityInsufficient();
        }

        if (options != InputStreamOptions.None && options != InputStreamOptions.Partial && options != InputStreamOptions.ReadAhead)
        {
            ArgumentOutOfRangeException ex3 = new(nameof(options));
            ex3.SetHResult(-2147024809);
            throw ex3;
        }

        Stream stream = EnsureNotDisposed();
        return _readOptimization switch
        {
            StreamReadOperationOptimization.MemoryStream => StreamOperationsImplementation.ReadAsync_MemoryStream(stream, buffer, count),
            StreamReadOperationOptimization.AbstractStream => StreamOperationsImplementation.ReadAsync_AbstractStream(stream, buffer, count, options),
            _ => null!
        };
    }

    [SupportedOSPlatform("windows10.0.10240.0")]
    public IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer)
    {
        ArgumentNullException.ThrowIfNull(buffer);

        if (buffer.Capacity < buffer.Length)
        {
            ThrowCapacityInsufficient();
        }

        Stream stream = EnsureNotDisposed();
        return StreamOperationsImplementation.WriteAsync_AbstractStream(stream, buffer);
    }

    [SupportedOSPlatform("windows10.0.10240.0")]
    public IAsyncOperation<bool> FlushAsync()
    {
        Stream stream = EnsureNotDisposed();
        return StreamOperationsImplementation.FlushAsync_AbstractStream(stream);
    }

    public void Seek(ulong position)
    {
        if (position > long.MaxValue)
        {
            IndexOutOfRangeException ex = new("Position has a value which exceeds long.MaxValue");
            ex.SetHResult(-2147024809);
            throw ex;
        }

        Stream stream = EnsureNotDisposed();
        stream.Seek((long)position, SeekOrigin.Begin);
    }

    private static void ThrowCloningNotSupported(string methodName)
    {
        NotSupportedException ex = new(methodName);
        ex.SetHResult(-2147467263);
        throw ex;
    }

#pragma warning disable CA1822 // Mark members as static
    public IRandomAccessStream CloneStream()
    {
        ThrowCloningNotSupported("CloneStream");
        return null!;
    }

    public IInputStream GetInputStreamAt(ulong position)
    {
        ThrowCloningNotSupported("GetInputStreamAt");
        return null!;
    }

    public IOutputStream GetOutputStreamAt(ulong position)
    {
        ThrowCloningNotSupported("GetOutputStreamAt");
        return null!;
    }
#pragma warning restore CA1822 // Mark members as static

    private static void ThrowCapacityInsufficient()
    {
        IndexOutOfRangeException ex = new("The buffer has insufficient capacity");
        ex.SetHResult(-2147024809);
        throw ex;
    }
}
