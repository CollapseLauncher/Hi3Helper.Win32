using Hi3Helper.Win32.ManagedTools;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ITaskService)]
public unsafe partial interface ITaskService : IDispatch
{
    void GetFolder([MarshalUsing(typeof(Utf16StringMarshaller))]                   string?      path,
                   [MarshalUsing(typeof(ComInterfaceMarshaller<ITaskFolder>))] out ITaskFolder? taskFolder);

    void GetRunningTasks(int flags,
                         [MarshalUsing(typeof(ComInterfaceMarshaller<IRunningTaskCollection>))] out IRunningTaskCollection? runningTaskCollection);

    void NewTask(uint                                                                                 flags,
                 [MarshalUsing(typeof(ComInterfaceMarshaller<ITaskDefinition>))] out ITaskDefinition? taskDefinition);

    void Connect([MarshalUsing(typeof(TypedComVariantMarshaller<string>))] string? serverName,
                 [MarshalUsing(typeof(TypedComVariantMarshaller<string>))] string? user,
                 [MarshalUsing(typeof(TypedComVariantMarshaller<string>))] string? domain,
                 [MarshalUsing(typeof(TypedComVariantMarshaller<string>))] string? password);

    void get_Connected(out ComVariant connected);

    void get_TargetServer([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? server);

    void get_ConnectedUser([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? user);

    void get_ConnectedDomain([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? domain);

    void get_HighestVersion(out int version);
}