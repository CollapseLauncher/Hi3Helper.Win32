using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Structs;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

// ReSharper disable InconsistentNaming

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler.Trigger;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IMonthlyDOWTrigger)]
public unsafe partial interface IMonthlyDOWTrigger : ITrigger
{
    void GetDaysOfWeek(out short pDays);

    void SetDaysOfWeek(short days);

    void GetWeeksOfMonth(out short pWeeks);

    void SetWeeksOfMonth(short weeks);

    void GetMonthsOfYear(out short pMonths);

    void SetMonthsOfYear(short months);

    void GetRunOnLastDayOfMonth(out VARIANT_BOOL pLastDay);

    void SetRunOnLastDayOfMonth(VARIANT_BOOL lastDay);

    void GetRandomDelay([MarshalUsing(typeof(Utf16BorrowStringMarshaller))] out string? pRandomDelay);

    void SetRandomDelay([MarshalUsing(typeof(Utf16StringMarshaller))] string? randomDelay);
}
