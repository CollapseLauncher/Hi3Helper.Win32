using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IMonthlyTrigger)]
public unsafe partial interface IMonthlyTrigger : ITrigger
{
    void GetDaysOfMonth(out short pDays);

    void SetDaysOfMonth(short days);

    void GetMonthsOfYear(out short pMonths);

    void SetMonthsOfYear(short months);

    void GetRunOnLastDayOfMonth(out VARIANT_BOOL pLastDay);

    void SetRunOnLastDayOfMonth(VARIANT_BOOL lastDay);

    void GetRandomDelay([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? pRandomDelay);

    void SetRandomDelay([MarshalUsing(typeof(Utf16StringMarshaller))] string? randomDelay);
}
