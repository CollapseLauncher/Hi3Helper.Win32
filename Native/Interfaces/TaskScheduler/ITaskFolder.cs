using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ITaskFolder)]
public unsafe partial interface ITaskFolder : IDispatch
{
    void Name([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? name);

    void Path([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? path);

    void GetFolder(string?                                                                      path,
                   [MarshalUsing(typeof(ComInterfaceMarshaller<ITaskFolder>))] out ITaskFolder? folder);

    void GetFolders(int flags,
                    [MarshalUsing(typeof(ComInterfaceMarshaller<ITaskFolderCollection>))] out ITaskFolderCollection? folders);

    void CreateFolder(string?                                                                      name,
                      ComVariant                                                                   sddl,
                      [MarshalUsing(typeof(ComInterfaceMarshaller<ITaskFolder>))] out ITaskFolder? folder);

    void DeleteFolder([MarshalUsing(typeof(Utf16StringMarshaller))] string? name,
                       int flags);

    void GetTask([MarshalUsing(typeof(Utf16StringMarshaller))]                       string?          name,
                 [MarshalUsing(typeof(ComInterfaceMarshaller<IRegisteredTask>))] out IRegisteredTask? task);

    void GetTasks(int flags,
                  [MarshalUsing(typeof(ComInterfaceMarshaller<IRegisteredTaskCollection>))] out IRegisteredTaskCollection? tasks);

    void DeleteTask([MarshalUsing(typeof(Utf16StringMarshaller))] string? name,
                    int                                                   flags);

    void RegisterTask([MarshalUsing(typeof(Utf16StringMarshaller))] string?                               path,
                      [MarshalUsing(typeof(Utf16StringMarshaller))] string?                               xml,
                      int                                                                                 flags,
                      [MarshalUsing(typeof(TypedComVariantMarshaller<string>))] string?                   user,
                      [MarshalUsing(typeof(TypedComVariantMarshaller<string>))] string?                   password,
                      TASK_LOGON_TYPE                                                                     logonType,
                      ComVariant                                                                          sddl,
                      [MarshalUsing(typeof(ComInterfaceMarshaller<IRegisteredTask>))] out IRegisteredTask task);

    void RegisterTaskDefinition([MarshalUsing(typeof(Utf16StringMarshaller))] string? path,
                                ITaskDefinition? definition,
                                int flags,
                                [MarshalUsing(typeof(TypedComVariantMarshaller<string>))] string? user,
                                [MarshalUsing(typeof(TypedComVariantMarshaller<string>))] string? password,
                                TASK_LOGON_TYPE logon,
                                [MarshalUsing(typeof(TypedComVariantMarshaller<string>))] string? sddl,
                                [MarshalUsing(typeof(ComInterfaceMarshaller<IRegisteredTask>))] out IRegisteredTask task);

    void GetSecurityDescriptor(int                                                       info,
                               [MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? sddl);

    void SetSecurityDescriptor([MarshalUsing(typeof(Utf16StringMarshaller))] string? sddl,
                               int                                                   flags);
}