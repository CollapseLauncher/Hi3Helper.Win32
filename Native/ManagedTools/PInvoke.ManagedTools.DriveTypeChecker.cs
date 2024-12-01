using Hi3Helper.Win32.Native.Structs;
using Microsoft.Extensions.Logging;
using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// ReSharper disable UnusedMember.Local

namespace Hi3Helper.Win32.Native;

public static partial class PInvoke
{
    // For CreateFile to get handle to drive
    private const uint GENERIC_READ             = 0x80000000;
    private const uint GENERIC_WRITE            = 0x40000000;
    private const uint FILE_SHARE_READ          = 0x00000001;
    private const uint FILE_SHARE_WRITE         = 0x00000002;
    private const uint OPEN_EXISTING            = 0x00000003;
    private const uint FILE_ATTRIBUTE_NORMAL    = 0x00000080;

    private const uint FILE_DEVICE_MASS_STORAGE     = 0x0000002D;
    private const uint FILE_ANY_ACCESS              = 0x00000000;
    private const uint METHOD_BUFFERED              = 0x00000000;
    private const uint IOCTL_STORAGE_BASE           = FILE_DEVICE_MASS_STORAGE;
    private const uint FILE_DEVICE_CONTROLLER       = 0x00000004;
    private const uint IOCTL_SCSI_BASE              = FILE_DEVICE_CONTROLLER;
    private const uint FILE_READ_ACCESS             = 0x00000001;
    private const uint FILE_WRITE_ACCESS            = 0x00000002;
    private const uint IOCTL_STORAGE_QUERY_PROPERTY = (IOCTL_STORAGE_BASE << 16) | (FILE_ANY_ACCESS << 14) | (0x500 << 2) | METHOD_BUFFERED;

    public static bool IsDriveSsd(FileInfo fileInfo, ILogger? logger = null) =>
        IsDriveSsd(fileInfo.FullName, logger);
    
    public static bool IsDriveSsd(string path, ILogger? logger = null)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            logger?.LogError(new ArgumentException("Path cannot be null or empty", nameof(path)).ToString());
            return true; // Assume SSD
        }

        var pathRoot = Path.GetPathRoot(path);
        if (string.IsNullOrWhiteSpace(pathRoot))
        {
            logger?.LogError(new ArgumentException("Invalid path", nameof(path)).ToString());
            return true; // Assume SSD
        }
        
        var    devicePath = $@"\\.\{pathRoot[..^1]}";
        nint   hDevice    = CreateFile(devicePath, 0, 3, nint.Zero, 3, 0, nint.Zero);
        if (hDevice == nint.Zero || hDevice == new nint(-1))
        {
            logger?.LogError(new IOException($"Unable to open drive: {pathRoot}. Error: {Marshal.GetLastWin32Error()}").ToString());
            return true; // Assume SSD
        }

        try
        {
            // Get status if drive is trim-enabled, So check for another parameter (seek penalty).
            bool isDriveHasTrimEnabled = IsDriveHasTrimEnabled(logger, hDevice);

            // Check if drive has seek penalty. A non-solid state drive must have this
            // return as true (like HDD or Disc-drive). Otherwise, false as SSD.
            bool isDriveHasSeekPenalty = IsDriveHasSeekPenalty(logger, hDevice);
            return isDriveHasTrimEnabled && !isDriveHasSeekPenalty;
        }
        finally
        {
            CloseHandle(hDevice);
        }
    }

    private static unsafe bool IsDriveHasTrimEnabled(ILogger? logger, nint hDevice)
    {
        // Get query and descriptor size
        int querySize       = Marshal.SizeOf<STORAGE_PROPERTY_QUERY>();
        int trimDescSize    = Marshal.SizeOf<DEVICE_TRIM_DESCRIPTOR>();
        int bufferSize      = querySize + trimDescSize;

        // Allocate buffer
        byte[] buffer = ArrayPool<byte>.Shared.Rent(bufferSize);

        // Assign buffer for STORAGE_PROPERTY_QUERY
        ReadOnlySpan<byte>  queryBuffer = buffer.AsSpan(0);
        nint                queryPtr    = GetArrayReference(queryBuffer);
        try
        {
            STORAGE_PROPERTY_QUERY* query   = (STORAGE_PROPERTY_QUERY*)queryPtr;
            query->PropertyId               = 8; // StorageDeviceTrimProperty
            query->QueryType                = 0;

            // Assign buffer for DEVICE_TRIM_DESCRIPTOR
            ReadOnlySpan<byte>  trimDescBuffer  = buffer.AsSpan(querySize); // Set offset, move forward from query buffer
            nint                trimDescPtr     = GetArrayReference(trimDescBuffer);
            if (DeviceIoControl(
                hDevice,
                IOCTL_STORAGE_QUERY_PROPERTY,
                queryPtr,
                (uint)querySize,
                trimDescPtr,
                (uint)trimDescSize,
                out _,
                nint.Zero))
            {
                DEVICE_TRIM_DESCRIPTOR* trimDescriptor  = (DEVICE_TRIM_DESCRIPTOR*)trimDescPtr;
                bool                    isTrimEnabled   = trimDescriptor->TrimEnabled != 0; // Convert byte to bool
                return isTrimEnabled;
            }
            else
            {
                logger?.LogError(new IOException($"DeviceIoControl failed. Error: {Marshal.GetLastWin32Error()}").ToString());
                return false; // Assume SSD
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    private static unsafe bool IsDriveHasSeekPenalty(ILogger? logger, nint hDevice)
    {
        // Get query and descriptor size
        int querySize           = Marshal.SizeOf<STORAGE_PROPERTY_QUERY>();
        int seekPenaltyDescSize = Marshal.SizeOf<DEVICE_SEEK_PENALTY_DESCRIPTOR>();
        int bufferSize          = querySize + seekPenaltyDescSize;

        // Allocate buffer
        byte[] buffer = ArrayPool<byte>.Shared.Rent(bufferSize);

        // Assign buffer for STORAGE_PROPERTY_QUERY
        ReadOnlySpan<byte> queryBuffer = buffer.AsSpan(0);
        nint queryPtr = GetArrayReference(queryBuffer);
        try
        {
            STORAGE_PROPERTY_QUERY* query   = (STORAGE_PROPERTY_QUERY*)queryPtr;
            query->PropertyId               = 7; // StorageDeviceSeekPenaltyProperty
            query->QueryType                = 0;

            // Assign buffer for DEVICE_SEEK_PENALTY_DESCRIPTOR
            ReadOnlySpan<byte>  seekPenaltyDescBuffer  = buffer.AsSpan(querySize); // Set offset, move forward from query buffer
            nint                seekPenaltyDescPtr     = GetArrayReference(seekPenaltyDescBuffer);
            if (DeviceIoControl(
                hDevice,
                IOCTL_STORAGE_QUERY_PROPERTY,
                queryPtr,
                (uint)querySize,
                seekPenaltyDescPtr,
                (uint)seekPenaltyDescSize,
                out _,
                nint.Zero))
            {
                DEVICE_SEEK_PENALTY_DESCRIPTOR* trimDescriptor      = (DEVICE_SEEK_PENALTY_DESCRIPTOR*)seekPenaltyDescPtr;
                bool                            isHasSeekPenalty    = trimDescriptor->IncursSeekPenalty != 0; // Convert byte to bool
                return isHasSeekPenalty;
            }
            else
            {
                logger?.LogError(new IOException($"DeviceIoControl failed. Error: {Marshal.GetLastWin32Error()}").ToString());
                return true; // Assume SSD
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe nint GetArrayReference<T>(ReadOnlySpan<T> buffer)
    {
        fixed (T* bufferPtr = &buffer[0])
        {
            return (nint)bufferPtr;
        }
    }
#pragma warning restore CS8500
}