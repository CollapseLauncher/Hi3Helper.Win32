using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IRegisteredTask)]
public unsafe partial interface IRegisteredTask : IDispatch
{
    void Name([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? name);

    void Path([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? path);

    void State(out TASK_STATE state);

    void GetEnabled([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool enabled);

    void SetEnabled([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool enabled);

    void Run(ComVariant parameters, out IRunningTask? task);

    void RunEx(ComVariant parameters, int flags, int sessionID, string? user, out IRunningTask? task);

    void GetInstances(int flags,
                      [MarshalUsing(typeof(ComInterfaceMarshaller<IRunningTaskCollection>))] out IRunningTaskCollection? tasks);

    void LastRunTime(out double date);

    void LastTaskResult(out int result);

    void NumberOfMissedRuns(out int runs);

    void NextRunTime(out double date);

    void Definition(out ITaskDefinition? task);

    void Xml([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? xml);

    void GetSecurityDescriptor(int info, [MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? sddl);

    void SetSecurityDescriptor([MarshalUsing(typeof(Utf16StringMarshaller))] string? sddl, int flags);

    void Stop(int flags);

    void GetRunTimes(LPSYSTEMTIME     start,
                     LPSYSTEMTIME     end,
                     ref int          count,
                     out LPSYSTEMTIME time);
}
