/*
 * This code was decompiled from Microsoft.Windows.SDK.NET library
 * with some changes included.
 */

using Hi3Helper.Win32.WinRT.IBufferCOM;
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Hi3Helper.Win32.WinRT.WindowsStream;

[SupportedOSPlatform("windows10.0.10240.0")]
internal static class StreamOperationsImplementation
{
    static StreamOperationsImplementation()
    {
        _ = StreamTaskAdaptersImplementation.Initialized;
    }

    internal static IAsyncOperationWithProgress<IBuffer, uint> ReadAsync_MemoryStream(
        Stream  stream,
        IBuffer buffer,
        uint    count)
    {
        buffer.Length = 0u;

        if (stream is not MemoryStream memoryStream)
        {
            throw new InvalidOperationException("Stream must be a MemoryStream");
        }

        try
        {
            IBuffer windowsRuntimeBuffer = memoryStream
               .GetWindowsRuntimeBuffer((int)memoryStream.Position,
                                        (int)count);
            if (windowsRuntimeBuffer.Length != 0)
            {
                memoryStream.Seek(windowsRuntimeBuffer.Length, SeekOrigin.Current);
            }

            return AsyncInfo.FromResultWithProgress<IBuffer, uint>(windowsRuntimeBuffer);
        }
        catch (Exception error)
        {
            return AsyncInfo.FromExceptionWithProgress<IBuffer, uint>(error);
        }
    }

    internal static IAsyncOperationWithProgress<IBuffer, uint> ReadAsync_AbstractStream(
        Stream             stream,
        IBuffer            buffer,
        uint               count,
        InputStreamOptions options)
    {
        int      bytesRequested = (int)count;
        IBuffer? dataBuffer     = buffer as WindowsRuntimeBuffer;
        dataBuffer ??= WindowsRuntimeBuffer.Create((int)Math.Min(int.MaxValue, buffer.Capacity));

        return AsyncInfo.Run<IBuffer, uint>(TaskProvider);

        async Task<IBuffer> TaskProvider(CancellationToken cancelToken, IProgress<uint> progressListener)
        {
            dataBuffer.Length = 0u;
            dataBuffer.TryGetUnderlyingData(out Memory<byte> data);
            bool flag           = cancelToken.IsCancellationRequested;
            int  bytesCompleted = 0;
            while (!flag)
            {
                int bytesRead = 0;
                try
                {
                    bytesRead = await stream
                                     .ReadAsync(data.Slice(bytesCompleted, bytesRequested - bytesCompleted),
                                                cancelToken)
                                     .ConfigureAwait(false);
                    bytesCompleted += bytesRead;
                }
                catch (OperationCanceledException)
                {
                    if (bytesCompleted == 0 && bytesRead == 0)
                    {
                        throw;
                    }
                }

                dataBuffer.Length = (uint)bytesCompleted;
                flag = options == InputStreamOptions.Partial ||
                       bytesRead == 0 ||
                       bytesCompleted == bytesRequested ||
                       cancelToken.IsCancellationRequested;
                progressListener?.Report(dataBuffer.Length);
            }

            return dataBuffer;
        }
    }

    internal static IAsyncOperationWithProgress<uint, uint> WriteAsync_AbstractStream(Stream stream, IBuffer buffer)
    {
        Func<CancellationToken, IProgress<uint>, Task<uint>> taskProvider =
            !buffer.TryGetUnderlyingData(out Memory<byte> data)
                ? TaskProviderNonWindowsRuntime
                : TaskProvider;

        return AsyncInfo.Run(taskProvider);

        async Task<uint> TaskProviderNonWindowsRuntime(CancellationToken cancelToken, IProgress<uint> progressListener)
        {
            if (cancelToken.IsCancellationRequested)
            {
                return 0u;
            }

            uint bytesToWrite = buffer.Length;
            Stream stream2 = buffer.AsStream();
            int num = 16384;
            if (bytesToWrite < num)
            {
                num = (int)bytesToWrite;
            }

            if (num > 0)
            {
                await stream2.CopyToAsync(stream, num, cancelToken)
                    .ConfigureAwait(false);
            }

            progressListener.Report(bytesToWrite);
            return bytesToWrite;
        }

        async Task<uint> TaskProvider(CancellationToken cancelToken, IProgress<uint> progressListener)
        {
            if (cancelToken.IsCancellationRequested)
            {
                return 0u;
            }

            int bytesToWrite = (int)buffer.Length;
            await stream.WriteAsync(data[..bytesToWrite], cancelToken)
                        .ConfigureAwait(false);
            progressListener.Report((uint)bytesToWrite);
            return (uint)bytesToWrite;
        }
    }

    internal static IAsyncOperation<bool> FlushAsync_AbstractStream(Stream stream)
    {
        return AsyncInfo.Run(TaskProvider);

        async Task<bool> TaskProvider(CancellationToken cancelToken)
        {
            if (cancelToken.IsCancellationRequested)
            {
                return false;
            }

            await stream.FlushAsync(cancelToken)
                .ConfigureAwait(false);
            return true;
        }
    }
}
