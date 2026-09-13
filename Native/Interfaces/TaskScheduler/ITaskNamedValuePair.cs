using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ITaskNamedValuePair)]
public unsafe partial interface ITaskNamedValuePair : IDispatch
{
    void GetName([MarshalUsing(typeof(Utf16StringMarshaller))] out string? pName);

    void SetName([MarshalUsing(typeof(Utf16StringMarshaller))] string? name);

    void GetValue([MarshalUsing(typeof(Utf16StringMarshaller))] out string? pValue);

    void SetValue([MarshalUsing(typeof(Utf16StringMarshaller))] string? value);
}
