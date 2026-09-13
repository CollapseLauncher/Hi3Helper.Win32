using Hi3Helper.Win32.ManagedTools;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Action;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IExecAction)]
public unsafe partial interface IExecAction : IAction
{
    void GetPath([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? path);

    void SetPath([MarshalUsing(typeof(Utf16StringMarshaller))] string? path);

    void GetArguments([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? argument);

    void SetArguments([MarshalUsing(typeof(Utf16StringMarshaller))] string? argument);

    void GetWorkingDirectory([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? directory);

    void SetWorkingDirectory([MarshalUsing(typeof(Utf16StringMarshaller))] string? directory);
}
