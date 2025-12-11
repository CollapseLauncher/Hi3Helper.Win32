/*
 * This code was decompiled from Microsoft.Windows.SDK.NET library
 * with some changes included.
 */

using ABI.Windows.Foundation;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Storage.Streams;
using WinRT;

namespace Hi3Helper.Win32.WinRT.WindowsStream;

internal static class StreamTaskAdaptersImplementation
{
    private static class AsyncOperationWithProgressUintUint
    {
        internal static bool ThisInitialized { get; } = InitSelf();

        private static unsafe bool InitSelf()
        {
            return IAsyncOperationWithProgressMethods<uint, uint, uint, uint>.InitCcw(&Do_Abi_put_Progress_0, &Do_Abi_get_Progress_1, &Do_Abi_put_Completed_2, &Do_Abi_get_Completed_3, &Do_Abi_GetResults_4);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static unsafe int Do_Abi_GetResults_4(IntPtr thisPtr, uint* returnValue)
        {
            *returnValue = 0u;
            try
            {
                uint num = IAsyncOperationWithProgressMethods<uint, uint>.Do_Abi_GetResults_4(thisPtr);
                *returnValue = num;
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Do_Abi_put_Progress_0(IntPtr thisPtr, IntPtr handler)
        {
            _ = AsyncOperationProgressHandlerUintUint.ThisInitialized;
            try
            {
                IAsyncOperationWithProgressMethods<uint, uint>.Do_Abi_put_Progress_0(thisPtr, ABI.Windows.Foundation.AsyncOperationProgressHandler<uint, uint>.FromAbi(handler));
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static unsafe int Do_Abi_get_Progress_1(IntPtr thisPtr, IntPtr* returnValue)
        {
            _            = AsyncOperationProgressHandlerUintUint.ThisInitialized;
            *returnValue = 0;
            try
            {
                Windows.Foundation.AsyncOperationProgressHandler<uint, uint> asyncOperationProgressHandler = IAsyncOperationWithProgressMethods<uint, uint>.Do_Abi_get_Progress_1(thisPtr);
                *returnValue = ABI.Windows.Foundation.AsyncOperationProgressHandler<uint, uint>.FromManaged(asyncOperationProgressHandler);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Do_Abi_put_Completed_2(IntPtr thisPtr, IntPtr handler)
        {
            _ = AsyncOperationWithProgressCompletedHandlerUintUint.ThisInitialized;
            try
            {
                IAsyncOperationWithProgressMethods<uint, uint>.Do_Abi_put_Completed_2(thisPtr, ABI.Windows.Foundation.AsyncOperationWithProgressCompletedHandler<uint, uint>.FromAbi(handler));
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static unsafe int Do_Abi_get_Completed_3(IntPtr thisPtr, IntPtr* returnValue)
        {
            _            = AsyncOperationWithProgressCompletedHandlerUintUint.ThisInitialized;
            *returnValue = 0;
            try
            {
                Windows.Foundation.AsyncOperationWithProgressCompletedHandler<uint, uint> asyncOperationWithProgressCompletedHandler = IAsyncOperationWithProgressMethods<uint, uint>.Do_Abi_get_Completed_3(thisPtr);
                *returnValue = ABI.Windows.Foundation.AsyncOperationWithProgressCompletedHandler<uint, uint>.FromManaged(asyncOperationWithProgressCompletedHandler);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }
    }

    private static class AsyncOperationProgressHandlerUintUint
    {
        internal static bool ThisInitialized { get; } = InitSelf();

        private static unsafe bool InitSelf()
        {
            AsyncOperationProgressHandlerMethods<uint, uint, uint, uint>.InitCcw(&Do_Abi_Invoke);
            AsyncOperationProgressHandlerMethods<uint, uint, uint, uint>.InitRcwHelper(&Invoke);
            return true;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Do_Abi_Invoke(IntPtr thisPtr, IntPtr asyncInfo, uint progressInfo)
        {
            try
            {
                AsyncOperationProgressHandlerMethods<uint, uint, uint, uint>.Abi_Invoke(thisPtr, MarshalInterface<IAsyncOperationWithProgress<uint, uint>>.FromAbi(asyncInfo), progressInfo);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        private static unsafe void Invoke(IObjectReference objRef, IAsyncOperationWithProgress<uint, uint> asyncInfo, uint progressInfo)
        {
            IntPtr thisPtr = objRef.ThisPtr;
            ObjectReferenceValue value = default;
            try
            {
                value = MarshalInterface<IAsyncOperationWithProgress<uint, uint>>.CreateMarshaler2(asyncInfo, IAsyncOperationWithProgressMethods<uint, uint>.IID);
                IntPtr abi = MarshalInspectable<object>.GetAbi(value);
                ExceptionHelpers.ThrowExceptionForHR(((delegate* unmanaged[Stdcall]<IntPtr, IntPtr, uint, int>)(*(IntPtr*)(*(IntPtr*)thisPtr + 3 * (nint)sizeof(delegate* unmanaged[Stdcall]<IntPtr, IntPtr, uint, int>))))(thisPtr, abi, progressInfo));
                GC.KeepAlive(objRef);
            }
            finally
            {
                MarshalInterface<IAsyncOperationWithProgress<uint, uint>>.DisposeMarshaler(value);
            }
        }
    }

    private static class AsyncOperationWithProgressCompletedHandlerUintUint
    {
        internal static bool ThisInitialized { get; } = InitSelf();

        private static unsafe bool InitSelf()
        {
            return AsyncOperationWithProgressCompletedHandlerMethods<uint, uint, uint, uint>.InitCcw(&Do_Abi_Invoke);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Do_Abi_Invoke(IntPtr thisPtr, IntPtr asyncInfo, AsyncStatus asyncStatus)
        {
            try
            {
                AsyncOperationWithProgressCompletedHandlerMethods<uint, uint, uint, uint>.Abi_Invoke(thisPtr, MarshalInterface<IAsyncOperationWithProgress<uint, uint>>.FromAbi(asyncInfo), asyncStatus);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }
    }

    private static class AsyncOperationWithProgressIBufferUint
    {
        internal static bool ThisInitialized { get; } = InitSelf();

        private static unsafe bool InitSelf()
        {
            return IAsyncOperationWithProgressMethods<IBuffer, IntPtr, uint, uint>.InitCcw(&Do_Abi_put_Progress_0, &Do_Abi_get_Progress_1, &Do_Abi_put_Completed_2, &Do_Abi_get_Completed_3, &Do_Abi_GetResults_4);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static unsafe int Do_Abi_GetResults_4(IntPtr thisPtr, IntPtr* returnValue)
        {
            *returnValue = 0;
            try
            {
                IBuffer buffer = IAsyncOperationWithProgressMethods<IBuffer, uint>.Do_Abi_GetResults_4(thisPtr);
                *returnValue = MarshalInterface<IBuffer>.FromManaged(buffer);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Do_Abi_put_Progress_0(IntPtr thisPtr, IntPtr handler)
        {
            _ = AsyncOperationProgressHandlerIBufferUint.ThisInitialized;
            try
            {
                IAsyncOperationWithProgressMethods<IBuffer, uint>.Do_Abi_put_Progress_0(thisPtr, ABI.Windows.Foundation.AsyncOperationProgressHandler<IBuffer, uint>.FromAbi(handler));
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static unsafe int Do_Abi_get_Progress_1(IntPtr thisPtr, IntPtr* returnValue)
        {
            _            = AsyncOperationProgressHandlerIBufferUint.ThisInitialized;
            *returnValue = 0;
            try
            {
                Windows.Foundation.AsyncOperationProgressHandler<IBuffer, uint> asyncOperationProgressHandler = IAsyncOperationWithProgressMethods<IBuffer, uint>.Do_Abi_get_Progress_1(thisPtr);
                *returnValue = ABI.Windows.Foundation.AsyncOperationProgressHandler<IBuffer, uint>.FromManaged(asyncOperationProgressHandler);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Do_Abi_put_Completed_2(IntPtr thisPtr, IntPtr handler)
        {
            _ = AsyncOperationWithProgressCompletedHandlerIBufferUint.ThisInitialized;
            try
            {
                IAsyncOperationWithProgressMethods<IBuffer, uint>.Do_Abi_put_Completed_2(thisPtr, ABI.Windows.Foundation.AsyncOperationWithProgressCompletedHandler<IBuffer, uint>.FromAbi(handler));
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static unsafe int Do_Abi_get_Completed_3(IntPtr thisPtr, IntPtr* returnValue)
        {
            _            = AsyncOperationWithProgressCompletedHandlerIBufferUint.ThisInitialized;
            *returnValue = 0;
            try
            {
                Windows.Foundation.AsyncOperationWithProgressCompletedHandler<IBuffer, uint> asyncOperationWithProgressCompletedHandler = IAsyncOperationWithProgressMethods<IBuffer, uint>.Do_Abi_get_Completed_3(thisPtr);
                *returnValue = ABI.Windows.Foundation.AsyncOperationWithProgressCompletedHandler<IBuffer, uint>.FromManaged(asyncOperationWithProgressCompletedHandler);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }
    }

    private static class AsyncOperationProgressHandlerIBufferUint
    {
        internal static bool ThisInitialized { get; } = InitSelf();

        private static unsafe bool InitSelf()
        {
            AsyncOperationProgressHandlerMethods<IBuffer, IntPtr, uint, uint>.InitCcw(&Do_Abi_Invoke);
            AsyncOperationProgressHandlerMethods<IBuffer, IntPtr, uint, uint>.InitRcwHelper(&Invoke);
            return true;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Do_Abi_Invoke(IntPtr thisPtr, IntPtr asyncInfo, uint progressInfo)
        {
            try
            {
                AsyncOperationProgressHandlerMethods<IBuffer, IntPtr, uint, uint>.Abi_Invoke(thisPtr, MarshalInterface<IAsyncOperationWithProgress<IBuffer, uint>>.FromAbi(asyncInfo), progressInfo);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        private static unsafe void Invoke(IObjectReference objRef, IAsyncOperationWithProgress<IBuffer, uint> asyncInfo, uint progressInfo)
        {
            IntPtr thisPtr = objRef.ThisPtr;
            ObjectReferenceValue value = default;
            try
            {
                value = MarshalInterface<IAsyncOperationWithProgress<IBuffer, uint>>.CreateMarshaler2(asyncInfo, IAsyncOperationWithProgressMethods<IBuffer, uint>.IID);
                IntPtr abi = MarshalInspectable<object>.GetAbi(value);
                ExceptionHelpers.ThrowExceptionForHR(((delegate* unmanaged[Stdcall]<IntPtr, IntPtr, uint, int>)(*(IntPtr*)(*(IntPtr*)thisPtr + 3 * (nint)sizeof(delegate* unmanaged[Stdcall]<IntPtr, IntPtr, uint, int>))))(thisPtr, abi, progressInfo));
                GC.KeepAlive(objRef);
            }
            finally
            {
                MarshalInterface<IAsyncOperationWithProgress<IBuffer, uint>>.DisposeMarshaler(value);
            }
        }
    }

    private static class AsyncOperationWithProgressCompletedHandlerIBufferUint
    {
        internal static bool ThisInitialized { get; } = InitSelf();

        private static unsafe bool InitSelf()
        {
            return AsyncOperationWithProgressCompletedHandlerMethods<IBuffer, IntPtr, uint, uint>.InitCcw(&Do_Abi_Invoke);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Do_Abi_Invoke(IntPtr thisPtr, IntPtr asyncInfo, AsyncStatus asyncStatus)
        {
            try
            {
                AsyncOperationWithProgressCompletedHandlerMethods<IBuffer, IntPtr, uint, uint>.Abi_Invoke(thisPtr, MarshalInterface<IAsyncOperationWithProgress<IBuffer, uint>>.FromAbi(asyncInfo), asyncStatus);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }
    }

    private static class AsyncOperationBool
    {
        internal static bool ThisInitialized { get; } = InitSelf();

        private static unsafe bool InitSelf()
        {
            return IAsyncOperationMethods<bool, byte>.InitCcw(&Do_Abi_put_Completed_0, &Do_Abi_get_Completed_1, &Do_Abi_GetResults_2);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static unsafe int Do_Abi_GetResults_2(IntPtr thisPtr, byte* returnValue)
        {
            *returnValue = 0;
            try
            {
                bool flag = IAsyncOperationMethods<bool>.Do_Abi_GetResults_2(thisPtr);
                *returnValue = flag ? (byte)1 : (byte)0;
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Do_Abi_put_Completed_0(IntPtr thisPtr, IntPtr handler)
        {
            _ = AsyncOperationCompletedHandlerBool.ThisInitialized;
            try
            {
                IAsyncOperationMethods<bool>.Do_Abi_put_Completed_0(thisPtr, ABI.Windows.Foundation.AsyncOperationCompletedHandler<bool>.FromAbi(handler));
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static unsafe int Do_Abi_get_Completed_1(IntPtr thisPtr, IntPtr* returnValue)
        {
            _            = AsyncOperationCompletedHandlerBool.ThisInitialized;
            *returnValue = 0;
            try
            {
                Windows.Foundation.AsyncOperationCompletedHandler<bool> asyncOperationCompletedHandler = IAsyncOperationMethods<bool>.Do_Abi_get_Completed_1(thisPtr);
                *returnValue = ABI.Windows.Foundation.AsyncOperationCompletedHandler<bool>.FromManaged(asyncOperationCompletedHandler);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }
    }

    private static class AsyncOperationCompletedHandlerBool
    {
        internal static bool ThisInitialized { get; } = InitSelf();

        private static unsafe bool InitSelf()
        {
            return AsyncOperationCompletedHandlerMethods<bool, byte>.InitCcw(&Do_Abi_Invoke);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Do_Abi_Invoke(IntPtr thisPtr, IntPtr asyncInfo, AsyncStatus asyncStatus)
        {
            try
            {
                AsyncOperationCompletedHandlerMethods<bool, byte>.Abi_Invoke(thisPtr, MarshalInterface<IAsyncOperation<bool>>.FromAbi(asyncInfo), asyncStatus);
            }
            catch (Exception ex)
            {
                ExceptionHelpers.SetErrorInfo(ex);
                return ExceptionHelpers.GetHRForException(ex);
            }

            return 0;
        }
    }

    internal static bool Initialized { get; } = Init();

    private static bool Init()
    {
        ComWrappersSupport.RegisterTypeComInterfaceEntriesLookup(LookupVtableEntries);
        ComWrappersSupport.RegisterTypeRuntimeClassNameLookup(LookupRuntimeClassName);
        return true;
    }

    private static ComWrappers.ComInterfaceEntry[]? LookupVtableEntries(Type type)
    {
        switch (type.ToString())
        {
            case "System.Threading.Tasks.TaskToAsyncOperationWithProgressAdapter`2[Windows.Storage.Streams.IBuffer,System.UInt32]":
                _ = AsyncOperationWithProgressIBufferUint.ThisInitialized;
                return
                [
                    new ComWrappers.ComInterfaceEntry
                {
                    IID = IAsyncOperationWithProgressMethods<IBuffer, uint>.IID,
                    Vtable = IAsyncOperationWithProgressMethods<IBuffer, uint>.AbiToProjectionVftablePtr
                },
                new ComWrappers.ComInterfaceEntry
                {
                    IID = IAsyncInfoMethods.IID,
                    Vtable = IAsyncInfoMethods.AbiToProjectionVftablePtr
                }
                ];
            case "System.Threading.Tasks.TaskToAsyncOperationWithProgressAdapter`2[System.UInt32,System.UInt32]":
                _ = AsyncOperationWithProgressUintUint.ThisInitialized;
                return
                [
                    new ComWrappers.ComInterfaceEntry
                {
                    IID = IAsyncOperationWithProgressMethods<uint, uint>.IID,
                    Vtable = IAsyncOperationWithProgressMethods<uint, uint>.AbiToProjectionVftablePtr
                },
                new ComWrappers.ComInterfaceEntry
                {
                    IID = IAsyncInfoMethods.IID,
                    Vtable = IAsyncInfoMethods.AbiToProjectionVftablePtr
                }
                ];
            case "System.Threading.Tasks.TaskToAsyncOperationAdapter`1[System.Boolean]":
                _ = AsyncOperationBool.ThisInitialized;
                return
                [
                    new ComWrappers.ComInterfaceEntry
                {
                    IID = IAsyncOperationMethods<bool>.IID,
                    Vtable = IAsyncOperationMethods<bool>.AbiToProjectionVftablePtr
                },
                new ComWrappers.ComInterfaceEntry
                {
                    IID = IAsyncInfoMethods.IID,
                    Vtable = IAsyncInfoMethods.AbiToProjectionVftablePtr
                }
                ];
            default:
                return null;
        }
    }

    private static string? LookupRuntimeClassName(Type type)
    {
        return type.ToString() switch
        {
            "System.Threading.Tasks.TaskToAsyncOperationWithProgressAdapter`2[Windows.Storage.Streams.IBuffer,System.UInt32]" => "Windows.Foundation.IAsyncOperationWithProgress`2<Windows.Storage.Streams.IBuffer, UInt32>",
            "System.Threading.Tasks.TaskToAsyncOperationWithProgressAdapter`2[System.UInt32,System.UInt32]" => "Windows.Foundation.IAsyncOperationWithProgress`2<Double, Double>",
            "System.Threading.Tasks.TaskToAsyncOperationAdapter`1[System.Boolean]" => "Windows.Foundation.IAsyncOperation`1<Boolean>",
            _ => null,
        };
    }
}
