using Hi3Helper.Win32.ManagedTools;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ILogonTrigger)]
public unsafe partial interface ILogonTrigger : ITrigger
{
    void GetDelay([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? pDelay);

    void SetDelay([MarshalUsing(typeof(Utf16StringMarshaller))] string? delay);

    void GetUserId([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? pUser);

    void SetUserId([MarshalUsing(typeof(Utf16StringMarshaller))] string? user);
}
