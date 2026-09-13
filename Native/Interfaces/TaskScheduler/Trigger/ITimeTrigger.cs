using Hi3Helper.Win32.ManagedTools;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ITimeTrigger)]
public unsafe partial interface ITimeTrigger : ITrigger
{
    void RandomDelay([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? delay);

    void RandomDelay([MarshalUsing(typeof(Utf16StringMarshaller))] string? delay);
}
