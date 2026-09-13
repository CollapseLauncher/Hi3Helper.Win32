using Hi3Helper.Win32.ManagedTools;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IIdleSettings)]
public unsafe partial interface IIdleSettings : IDispatch
{
    void GetIdleDuration([MarshalUsing(typeof(Utf16StringMarshaller))] out string? delay);

    void SetIdleDuration([MarshalUsing(typeof(Utf16StringMarshaller))] string? delay);

    void GetWaitTimeout([MarshalUsing(typeof(Utf16StringMarshaller))] out string? timeout);

    void SetWaitTimeout([MarshalUsing(typeof(Utf16StringMarshaller))] string? timeout);

    void GetStopOnIdleEnd([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool stop);

    void SetStopOnIdleEnd([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool stop);

    void GetRestartOnIdle([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool restart);

    void SetRestartOnIdle([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool restart);
}
