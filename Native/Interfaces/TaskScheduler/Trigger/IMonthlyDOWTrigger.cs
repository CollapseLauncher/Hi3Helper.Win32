using Hi3Helper.Win32.ManagedTools;
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

    void GetRunOnLastDayOfMonth([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] out bool pLastDay);

    void SetRunOnLastDayOfMonth([MarshalUsing(typeof(TypedComVariantMarshaller<bool>))] bool lastDay);

    void GetRandomDelay([MarshalUsing(typeof(Utf16StringMarshaller))] out string? pRandomDelay);

    void SetRandomDelay([MarshalUsing(typeof(Utf16StringMarshaller))] string? randomDelay);
}
