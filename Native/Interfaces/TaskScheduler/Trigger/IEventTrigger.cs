using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.ManagedTools;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IEventTrigger)]
public unsafe partial interface IEventTrigger : ITrigger
{
    void GetSubscription([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? pQuery);

    void SetSubscription([MarshalUsing(typeof(Utf16StringMarshaller))] string? query);

    void GetDelay([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? pDelay);

    void SetDelay([MarshalUsing(typeof(Utf16StringMarshaller))] string? delay);

    void GetValueQueries([MarshalUsing(typeof(ComInterfaceMarshaller<ITaskNamedValueCollection>))] out ITaskNamedValueCollection? ppNamedXPaths);

    void SetValueQueries([MarshalUsing(typeof(ComInterfaceMarshaller<ITaskNamedValueCollection>))] ITaskNamedValueCollection? pNamedXPaths);
}
