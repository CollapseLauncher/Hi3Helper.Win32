using Hi3Helper.Win32.ManagedTools;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ITaskNamedValueCollection)]
public unsafe partial interface ITaskNamedValueCollection : IDispatch
{
    void Count(out int count);

    void Item([MarshalUsing(typeof(TypedComVariantMarshaller<int>))]                  int                  index,
              [MarshalUsing(typeof(ComInterfaceMarshaller<ITaskNamedValuePair>))] out ITaskNamedValuePair? pair);

    void _NewEnum([MarshalUsing(typeof(TypedComVariantMarshaller<int>))] int   index,
                  out                                                    void* pEnum);

    void Create([MarshalUsing(typeof(Utf16StringMarshaller))]                           string?              name,
                [MarshalUsing(typeof(Utf16StringMarshaller))]                           string?              value,
                [MarshalUsing(typeof(ComInterfaceMarshaller<ITaskNamedValuePair>))] out ITaskNamedValuePair? pair);

    void Remove(int index);

    void Clear();
}
