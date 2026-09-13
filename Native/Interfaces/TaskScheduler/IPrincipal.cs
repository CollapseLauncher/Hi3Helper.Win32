using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IPrincipal)]
public unsafe partial interface IPrincipal : IDispatch
{
    void Id(out string? id);

    void Id(string? id);

    void DisplayName(out string? name);

    void DisplayName(string? name);

    void UserId(out string? user);

    void UserId(string? user);

    void LogonType(out TASK_LOGON_TYPE logon);

    void LogonType(TASK_LOGON_TYPE logon);

    void GroupId(out string? group);

    void GroupId(string? group);

    void RunLevel(out TASK_RUNLEVEL_TYPE level);

    void RunLevel(TASK_RUNLEVEL_TYPE level);
}
