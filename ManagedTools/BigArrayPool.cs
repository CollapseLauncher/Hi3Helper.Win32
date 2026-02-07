using System.Buffers;

namespace Hi3Helper.Win32.ManagedTools;

/// <summary>
/// This is an extension for ArrayPool with bigger size limit, up to 64 MiB of buffer size (compared to 1 MiB on usual ArrayPool).
/// </summary>
/// <typeparam name="T">Type of the buffer.</typeparam>
public static class BigArrayPool<T>
    where T : unmanaged
{
    public static readonly ArrayPool<T> Shared;

    static unsafe BigArrayPool()
    {
        const int sharedByteMaxSize   = 64 << 20; // 64 MiB
        const int sharedBucketMaxSize = 27;       // 27 buckets

        int sizeOfT = sizeof(T);

        // Scale the bucket and buffer size based on size of the struct.
        int sizeOfBufferMax = sharedByteMaxSize / sizeOfT;
        int bucketMaxSize   = sharedBucketMaxSize * sizeOfT;

        Shared = ArrayPool<T>.Create(sizeOfBufferMax, bucketMaxSize);
    }
}
