using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IAction)]
public unsafe partial interface IAction : IDispatch
{
    void GetId([MarshalUsing(typeof(Utf16StringMarshaller))] out string? id);

    void SetId([MarshalUsing(typeof(Utf16StringMarshaller))] string? id);

    void Type(out TASK_ACTION_TYPE type);
}
