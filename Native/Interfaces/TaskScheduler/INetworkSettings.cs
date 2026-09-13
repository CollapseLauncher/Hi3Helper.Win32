using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_INetworkSettings)]
public unsafe partial interface INetworkSettings : IDispatch
{
    void Name([MarshalUsing(typeof(Utf16StringMarshaller))] out string? name);

    void Name([MarshalUsing(typeof(Utf16StringMarshaller))] string? name);

    void Id([MarshalUsing(typeof(Utf16StringMarshaller))] out string? id);

    void Id([MarshalUsing(typeof(Utf16StringMarshaller))] string? id);
}
