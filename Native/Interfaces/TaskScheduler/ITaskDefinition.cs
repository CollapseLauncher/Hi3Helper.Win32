using Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ITaskDefinition)]
public unsafe partial interface ITaskDefinition : IDispatch
{
    void GetRegistrationInfo([MarshalUsing(typeof(ComInterfaceMarshaller<IRegistrationInfo>))] out IRegistrationInfo? info);

    void SetRegistrationInfo([MarshalUsing(typeof(ComInterfaceMarshaller<IRegistrationInfo>))] IRegistrationInfo? info);

    void GetTriggers([MarshalUsing(typeof(ComInterfaceMarshaller<ITriggerCollection>))] out ITriggerCollection? triggers);

    void SetTriggers([MarshalUsing(typeof(ComInterfaceMarshaller<ITriggerCollection>))] ITriggerCollection? triggers);

    void GetSettings([MarshalUsing(typeof(ComInterfaceMarshaller<ITaskSettings>))] out ITaskSettings? settings);

    void SetSettings([MarshalUsing(typeof(ComInterfaceMarshaller<ITaskSettings>))] ITaskSettings? settings);

    void GetData([MarshalUsing(typeof(Utf16StringMarshaller))] out string? data);

    void SetData([MarshalUsing(typeof(Utf16StringMarshaller))] string? data);

    void GetPrincipal([MarshalUsing(typeof(ComInterfaceMarshaller<IPrincipal>))] out IPrincipal? principal);

    void SetPrincipal([MarshalUsing(typeof(ComInterfaceMarshaller<IPrincipal>))] IPrincipal? principal);

    void GetActions([MarshalUsing(typeof(ComInterfaceMarshaller<IActionCollection>))] out IActionCollection? actions);

    void SetActions([MarshalUsing(typeof(ComInterfaceMarshaller<IActionCollection>))] IActionCollection? actions);

    void GetXmlText([MarshalUsing(typeof(Utf16StringMarshaller))] out string? xml);

    void SetXmlText([MarshalUsing(typeof(Utf16StringMarshaller))] string? xml);
}
