using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IDailyTrigger)]
public unsafe partial interface IDailyTrigger : ITrigger
{
    void GetDaysInterval(out short pDays);

    void SetDaysInterval(short days);

    void GetRandomDelay([MarshalUsing(typeof(Utf16StringMarshaller))] out string? pRandomDelay);

    void SetRandomDelay([MarshalUsing(typeof(Utf16StringMarshaller))] string? randomDelay);
}
