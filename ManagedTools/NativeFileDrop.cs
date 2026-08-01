using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Buffers;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.ManagedTools;

public static class NativeFileDrop
{
    public static bool TryHandleFileDrop(nint dropHandle,
                                         [NotNullWhen(true)]
                                         out string[]? files,
                                         out POINTL dropPoint,
                                         [NotNullWhen(false)]
                                         out Exception? exception)
    {
        const uint getFileCount = uint.MaxValue;

        Unsafe.SkipInit(out files);
        Unsafe.SkipInit(out dropPoint);
        Unsafe.SkipInit(out exception);
        try
        {
            uint fileCount = PInvoke.DragQueryFile(dropHandle,
                                                   getFileCount,
                                                   nint.Zero,
                                                   0);
            files = new string[fileCount];
            for (uint i = 0; i < fileCount; i++)
            {
                if (!TryCreateString(i,
                                     dropHandle,
                                     out string? filePath,
                                     out exception))
                {
                    return false;
                }
                files[i] = filePath;
            }

            PInvoke.DragQueryPoint(dropHandle, out dropPoint);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
        finally
        {
            PInvoke.DragFinish(dropHandle);
        }

        [SkipLocalsInit]
        static unsafe bool TryCreateString(uint index,
                                           nint dropHandle,
                                           [NotNullWhen(true)]
                                           out string?    result,
                                           [NotNullWhen(false)]
                                           out Exception? exception)
        {
            Unsafe.SkipInit(out result);
            Unsafe.SkipInit(out exception);

            uint filePathLength = PInvoke.DragQueryFile(dropHandle, index, nint.Zero, 0);
            uint filePathBufferLen = filePathLength + 1;

            char[]? filePathBufferRent =
                filePathBufferLen <= 512
                    ? null
                    : ArrayPool<char>.Shared.Rent((int)filePathBufferLen);
            Span<char> filePathBuffer    = filePathBufferRent ?? stackalloc char[(int)filePathBufferLen];
            ref char   filePathBufferRef = ref MemoryMarshal.GetReference(filePathBuffer);

            try
            {
                uint lengthOrError = PInvoke.DragQueryFile(dropHandle,
                                                           index,
                                                           (nint)Unsafe.AsPointer(ref filePathBufferRef),
                                                           (uint)filePathBuffer.Length);
                if (lengthOrError == 0)
                {
                    int win32Error = Marshal.GetLastWin32Error();
                    if (win32Error != 0)
                    {
                        throw new Win32Exception(win32Error);
                    }
                }

                result = new string(filePathBuffer[..(int)lengthOrError]);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
            finally
            {
                if (filePathBufferRent != null) ArrayPool<char>.Shared.Return(filePathBufferRent);
            }
        }
    }
}
