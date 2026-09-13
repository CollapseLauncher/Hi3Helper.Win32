using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ITriggerCollection)]
public unsafe partial interface ITriggerCollection : IDispatch
{
    void Count(out int count);

    void Item(int                                                                    index,
              [MarshalUsing(typeof(ComInterfaceMarshaller<ITrigger>))] out ITrigger? trigger);

    void _NewEnum(out void* pEnum);

    void Create(TASK_TRIGGER_TYPE2                                                     type,
                [MarshalUsing(typeof(ComInterfaceMarshaller<ITrigger>))] out ITrigger? trigger);

    void Remove([MarshalUsing(typeof(TypedComVariantMarshaller<int>))] int index);

    void Clear();
}
