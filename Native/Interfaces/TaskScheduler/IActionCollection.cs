using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IActionCollection)]
public unsafe partial interface IActionCollection : IDispatch
{
    void Count(out int count);
    void Item(int                                                                  index,
              [MarshalUsing(typeof(ComInterfaceMarshaller<IAction>))] out IAction? action);

    void _NewEnum(out void* pEnum);

    void GetXmlText([MarshalUsing(typeof(Utf16StringMarshaller))] out string? xml);

    void SetXmlText([MarshalUsing(typeof(Utf16StringMarshaller))] string? xml);

    void Create(TASK_ACTION_TYPE                                                     type,
                [MarshalUsing(typeof(ComInterfaceMarshaller<IAction>))] out IAction? action);

    void Remove([MarshalUsing(typeof(TypedComVariantMarshaller<int>))] int index);

    void Clear();

    void GetContext([MarshalUsing(typeof(Utf16StringMarshaller))] out string? ctx);

    void SetContext([MarshalUsing(typeof(Utf16StringMarshaller))] string? ctx);
}
