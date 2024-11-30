using Hi3Helper.Win32.Native.Structs;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Runtime.InteropServices;
// ReSharper disable UnusedMember.Local

namespace Hi3Helper.Win32.Native;

public static partial class PInvoke
{
    private const uint IOCTL_STORAGE_QUERY_PROPERTY = 0x2D1400;
    private const uint FILE_DEVICE_MASS_STORAGE     = 0x0000002D;
    private const uint FILE_ANY_ACCESS              = 0x0000;
    private const uint METHOD_BUFFERED              = 0x0000;

    public static bool IsDriveSsd(FileInfo fileInfo, ILogger? logger = null)
    {
        return IsDriveSsd(fileInfo.FullName);
    }
    
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
        IntPtr hDevice    = CreateFileW(devicePath, 0, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
        if (hDevice == IntPtr.Zero || hDevice == new IntPtr(-1))
        {
            logger?.LogError(new IOException($"Unable to open drive: {pathRoot}. Error: {Marshal.GetLastWin32Error()}").ToString());
            return true; // Assume SSD
        }

        try
        {
            // Allocate unmanaged memory for STORAGE_PROPERTY_QUERY
            int    querySize = Marshal.SizeOf<STORAGE_PROPERTY_QUERY>();
            IntPtr queryPtr  = Marshal.AllocHGlobal(querySize);
            try
            {
                var query = new STORAGE_PROPERTY_QUERY
                {
                    PropertyId = 7, // StorageDeviceTrimProperty
                    QueryType  = 0
                };
                Marshal.StructureToPtr(query, queryPtr, false);

                // Allocate unmanaged memory for DEVICE_TRIM_DESCRIPTOR
                int    trimDescSize = Marshal.SizeOf<DEVICE_TRIM_DESCRIPTOR>();
                IntPtr trimDescPtr  = Marshal.AllocHGlobal(trimDescSize);
                try
                {
                    if (DeviceIoControl(
                                        hDevice,
                                        IOCTL_STORAGE_QUERY_PROPERTY,
                                        queryPtr,
                                        (uint)querySize,
                                        trimDescPtr,
                                        (uint)trimDescSize,
                                        out _,
                                        IntPtr.Zero))
                    {
                        var trimDescriptor = Marshal.PtrToStructure<DEVICE_TRIM_DESCRIPTOR>(trimDescPtr);
                        return trimDescriptor.TrimEnabled != 0; // Convert byte to bool
                    }
                    else
                    {
                        logger?.LogError(new IOException($"DeviceIoControl failed. Error: {Marshal.GetLastWin32Error()}").ToString());
                        return true; // Assume SSD
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(trimDescPtr);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(queryPtr);
            }
        }
        finally
        {
            CloseHandle(hDevice);
        }
    }
}