using Hi3Helper.Win32.ManagedTools;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ITaskFolderCollection)]
public unsafe partial interface ITaskFolderCollection : IDispatch
{
    void Count(out int count);

    void Item([MarshalUsing(typeof(TypedComVariantMarshaller<int>))]          int          index,
              [MarshalUsing(typeof(ComInterfaceMarshaller<ITaskFolder>))] out ITaskFolder? folder);

    void _NewEnum([MarshalUsing(typeof(TypedComVariantMarshaller<int>))] int   index,
                  out                                                    void* pEnum);
}