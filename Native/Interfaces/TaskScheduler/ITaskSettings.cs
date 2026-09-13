using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ITaskSettings)]
public unsafe partial interface ITaskSettings : IDispatch
{
    void GetAllowDemandStart(out VARIANT_BOOL allow);
    
    void SetAllowDemandStart(VARIANT_BOOL allow);

    void GetRestartInterval([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? interval);

    void SetRestartInterval([MarshalUsing(typeof(Utf16StringMarshaller))] string? interval);

    void GetRestartCount(out int count);

    void SetRestartCount(int count);

    void GetMultipleInstances(out TASK_INSTANCES_POLICY policy);

    void SetMultipleInstances(TASK_INSTANCES_POLICY policy);

    void GetStopIfGoingOnBatteries(out VARIANT_BOOL stop);

    void SetStopIfGoingOnBatteries(VARIANT_BOOL stop);

    void GetDisallowStartIfOnBatteries(out VARIANT_BOOL disallow);

    void SetDisallowStartIfOnBatteries(VARIANT_BOOL disallow);

    void GetAllowHardTerminate(out VARIANT_BOOL allow);

    void SetAllowHardTerminate(VARIANT_BOOL allow);

    void GetStartWhenAvailable(out VARIANT_BOOL start);

    void SetStartWhenAvailable(VARIANT_BOOL start);

    void GetXmlText([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? xml);

    void SetXmlText([MarshalUsing(typeof(Utf16StringMarshaller))] string? xml);

    void GetRunOnlyIfNetworkAvailable(out VARIANT_BOOL run);

    void SetRunOnlyIfNetworkAvailable(VARIANT_BOOL run);

    void GetExecutionTimeLimit([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? limit);

    void SetExecutionTimeLimit([MarshalUsing(typeof(Utf16StringMarshaller))] string? limit);

    void GetEnabled(out VARIANT_BOOL enabled);

    void SetEnabled(VARIANT_BOOL enabled);

    void GetDeleteExpiredTaskAfter([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? delay);

    void SetDeleteExpiredTaskAfter([MarshalUsing(typeof(Utf16StringMarshaller))] string? delay);

    void GetPriority(out int priority);

    void SetPriority(int priority);

    void GetCompatibility(out TASK_COMPATIBILITY level);

    void SetCompatibility(TASK_COMPATIBILITY level);

    void GetHidden(out VARIANT_BOOL hidden);

    void SetHidden(VARIANT_BOOL hidden);

    void GetIdleSettings([MarshalUsing(typeof(ComInterfaceMarshaller<IIdleSettings>))] out IIdleSettings? settings);

    void SetIdleSettings([MarshalUsing(typeof(ComInterfaceMarshaller<IIdleSettings>))] IIdleSettings? settings);

    void GetRunOnlyIfIdle(out VARIANT_BOOL run);

    void SetRunOnlyIfIdle(VARIANT_BOOL run);

    void GetWakeToRun(out VARIANT_BOOL wake);

    void SetWakeToRun(VARIANT_BOOL wake);

    void GetNetworkSettings([MarshalUsing(typeof(ComInterfaceMarshaller<INetworkSettings>))] out INetworkSettings? settings);

    void SetNetworkSettings([MarshalUsing(typeof(ComInterfaceMarshaller<INetworkSettings>))] INetworkSettings? settings);
}
