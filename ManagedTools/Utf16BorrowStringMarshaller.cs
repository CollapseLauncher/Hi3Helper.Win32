using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.ManagedTools;

[CustomMarshaller(typeof(string), MarshalMode.Default, typeof(Utf16BorrowStringMarshaller))]
public static class Utf16BorrowStringMarshaller
{
    public static ushort* ConvertToUnmanaged(string? managed)
        => throw new NotSupportedException("This marshaller can only read the borrowed string and not marshalling it to native");

    public static string? ConvertToManaged(ushort* unmanaged)
        => Marshal.PtrToStringUni((IntPtr)unmanaged);

    public static void Free(ushort* unmanaged) { }
}
