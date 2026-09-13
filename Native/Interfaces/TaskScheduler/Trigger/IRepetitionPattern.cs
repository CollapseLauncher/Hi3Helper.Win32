using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IRepetitionPattern)]
public unsafe partial interface IRepetitionPattern : IDispatch
{
    void GetInterval([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? interval);

    void SetInterval([MarshalUsing(typeof(Utf16StringMarshaller))] string? interval);

    void GetDuration([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? duration);

    void SetDuration([MarshalUsing(typeof(Utf16StringMarshaller))] string? duration);

    void GetStopAtDurationEnd(out VARIANT_BOOL stop);

    void SetStopAtDurationEnd(VARIANT_BOOL sop);
}
