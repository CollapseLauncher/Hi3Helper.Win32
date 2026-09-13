using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IRunningTask)]
public unsafe partial interface IRunningTask : IDispatch
{
    void Name([MarshalUsing(typeof(Utf16StringMarshaller))] out string? name);

    void InstanceGuid([MarshalUsing(typeof(Utf16StringMarshaller))] out string? guid);

    void Path([MarshalUsing(typeof(Utf16StringMarshaller))] out string? path);

    void State(out TASK_STATE state);

    void CurrentAction([MarshalUsing(typeof(Utf16StringMarshaller))] out string? name);

    void Stop(void* p);

    void Refresh(void* p);

    void EnginePID(out int pid);
}
