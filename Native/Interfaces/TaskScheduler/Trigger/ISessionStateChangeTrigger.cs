using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ISessionStateChangeTrigger)]
public unsafe partial interface ISessionStateChangeTrigger : ITrigger
{
    void GetDelay([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? pDelay);

    void SetDelay([MarshalUsing(typeof(Utf16StringMarshaller))] string? delay);

    void GetUserId([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? pUser);

    void SetUserId([MarshalUsing(typeof(Utf16StringMarshaller))] string? user);

    void GetStateChange(out TASK_SESSION_STATE_CHANGE_TYPE pType);

    void SetStateChange(TASK_SESSION_STATE_CHANGE_TYPE type);
}
