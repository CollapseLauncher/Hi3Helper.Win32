using Hi3Helper.Win32.ManagedTools;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IRegisteredTaskCollection)]
public unsafe partial interface IRegisteredTaskCollection : IDispatch
{
    void Count(out int count);

    void Item([MarshalUsing(typeof(TypedComVariantMarshaller<int>))]              int              index,
              [MarshalUsing(typeof(ComInterfaceMarshaller<IRegisteredTask>))] out IRegisteredTask? task);

    void _NewEnum([MarshalUsing(typeof(TypedComVariantMarshaller<int>))] int   index,
                  out                                                    void* pEnum);
}
