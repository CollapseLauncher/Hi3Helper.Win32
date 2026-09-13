using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ITaskSettings)]
public unsafe partial interface ITaskSettings : IDispatch
{
    void GetAllowDemandStart([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool allow);
    
    void SetAllowDemandStart([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool allow);

    void GetRestartInterval([MarshalUsing(typeof(Utf16StringMarshaller))] out string? interval);

    void SetRestartInterval([MarshalUsing(typeof(Utf16StringMarshaller))] string? interval);

    void GetRestartCount(out int count);

    void SetRestartCount(int count);

    void GetMultipleInstances(out TASK_INSTANCES_POLICY policy);

    void SetMultipleInstances(TASK_INSTANCES_POLICY policy);

    void GetStopIfGoingOnBatteries([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool stop);

    void SetStopIfGoingOnBatteries([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool stop);

    void GetDisallowStartIfOnBatteries([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool disallow);

    void SetDisallowStartIfOnBatteries([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool disallow);

    void GetAllowHardTerminate([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool allow);

    void SetAllowHardTerminate([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool allow);

    void GetStartWhenAvailable([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool start);

    void SetStartWhenAvailable([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool start);

    void GetXmlText([MarshalUsing(typeof(Utf16StringMarshaller))] out string? xml);

    void SetXmlText([MarshalUsing(typeof(Utf16StringMarshaller))] string? xml);

    void GetRunOnlyIfNetworkAvailable([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool run);

    void SetRunOnlyIfNetworkAvailable([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool run);

    void GetExecutionTimeLimit([MarshalUsing(typeof(Utf16StringMarshaller))] out string? limit);

    void SetExecutionTimeLimit([MarshalUsing(typeof(Utf16StringMarshaller))] string? limit);

    void GetEnabled([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool enabled);

    void SetEnabled([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool enabled);

    void GetDeleteExpiredTaskAfter([MarshalUsing(typeof(Utf16StringMarshaller))] out string? delay);

    void SetDeleteExpiredTaskAfter([MarshalUsing(typeof(Utf16StringMarshaller))] string? delay);

    void GetPriority(out int priority);

    void SetPriority(int priority);

    void GetCompatibility(out TASK_COMPATIBILITY level);

    void SetCompatibility(TASK_COMPATIBILITY level);

    void GetHidden([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool hidden);

    void SetHidden([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool hidden);

    void GetIdleSettings([MarshalUsing(typeof(ComInterfaceMarshaller<IIdleSettings>))] out IIdleSettings? settings);

    void SetIdleSettings([MarshalUsing(typeof(ComInterfaceMarshaller<IIdleSettings>))] IIdleSettings? settings);

    void GetRunOnlyIfIdle([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool run);

    void SetRunOnlyIfIdle([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool run);

    void GetWakeToRun([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool wake);

    void SetWakeToRun([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool wake);

    void GetNetworkSettings([MarshalUsing(typeof(ComInterfaceMarshaller<INetworkSettings>))] out INetworkSettings? settings);

    void SetNetworkSettings([MarshalUsing(typeof(ComInterfaceMarshaller<INetworkSettings>))] INetworkSettings? settings);
}
