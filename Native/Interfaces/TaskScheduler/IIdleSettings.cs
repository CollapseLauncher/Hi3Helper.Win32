using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IIdleSettings)]
public unsafe partial interface IIdleSettings : IDispatch
{
    void GetIdleDuration([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? delay);

    void SetIdleDuration([MarshalUsing(typeof(Utf16StringMarshaller))] string? delay);

    void GetWaitTimeout([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? timeout);

    void SetWaitTimeout([MarshalUsing(typeof(Utf16StringMarshaller))] string? timeout);

    void GetStopOnIdleEnd(out VARIANT_BOOL stop);

    void SetStopOnIdleEnd(VARIANT_BOOL stop);

    void GetRestartOnIdle(out VARIANT_BOOL restart);

    void SetRestartOnIdle(VARIANT_BOOL restart);
}
