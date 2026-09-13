using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_ITrigger)]
public unsafe partial interface ITrigger : IDispatch
{
    void Type(out TASK_TRIGGER_TYPE2 type);

    void GetId([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? id);

    void SetId([MarshalUsing(typeof(Utf16StringMarshaller))] string? id);

    void GetRepetition([MarshalUsing(typeof(ComInterfaceMarshaller<IRepetitionPattern>))] out IRepetitionPattern? repeat);

    void SetRepetition([MarshalUsing(typeof(ComInterfaceMarshaller<IRepetitionPattern>))] IRepetitionPattern repeat);

    void GetExecutionTimeLimit([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? limit);

    void SetExecutionTimeLimit([MarshalUsing(typeof(Utf16StringMarshaller))] string? limit);

    void GetStartBoundary([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? start);

    void SetStartBoundary([MarshalUsing(typeof(Utf16StringMarshaller))] string? start);

    void GetEndBoundary([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? end);

    void SetEndBoundary([MarshalUsing(typeof(Utf16StringMarshaller))] string? end);

    void GetEnabled([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool enabled);

    void SetEnabled([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool enabled);
}
