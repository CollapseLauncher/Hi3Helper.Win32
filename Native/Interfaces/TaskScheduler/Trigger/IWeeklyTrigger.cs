using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IWeeklyTrigger)]
public unsafe partial interface IWeeklyTrigger : ITrigger
{
    void GetDaysOfWeek(out short pDays);

    void SetDaysOfWeek(short days);

    void GetWeeksInterval(out short pWeeks);

    void SetWeeksInterval(short weeks);

    void GetRandomDelay([MarshalUsing(typeof(Utf16StringMarshaller))] out string? pRandomDelay);

    void SetRandomDelay([MarshalUsing(typeof(Utf16StringMarshaller))] string? randomDelay);
}
