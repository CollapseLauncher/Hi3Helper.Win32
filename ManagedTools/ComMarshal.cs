using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using static Hi3Helper.Win32.Native.LibraryImport.PInvoke;

namespace Hi3Helper.Win32.ManagedTools
{
    // ReSharper disable once PartialTypeWithSinglePart
    public static class ComMarshal
    {
        public static unsafe HResult CreateInstance<T>(Guid rClsId, nint pUnkOuter, CLSCTX dwClsContext, out T? ppv)
        {
            Guid    refTGuid = typeof(T).GUID;
            HResult hr       = CoCreateInstance(in rClsId, pUnkOuter, dwClsContext, in refTGuid, out void* o);
            ppv = ComInterfaceMarshaller<T>.ConvertToManaged(o);
            return hr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe TInterfaceTo? CastComInterfaceAs<TInterfaceFrom, TInterfaceTo>(this TInterfaceFrom interfaceFrom, in Guid interfaceToGuid)
            where TInterfaceFrom : class
            where TInterfaceTo : class
        {
            void* interfaceFromPtr = ComInterfaceMarshaller<TInterfaceFrom>.ConvertToUnmanaged(interfaceFrom);
            ((HResult)Marshal.QueryInterface((nint)interfaceFromPtr, in interfaceToGuid, out nint interfaceToPtr)).ThrowOnFailure();

            TInterfaceTo? interfaceTo = ComInterfaceMarshaller<TInterfaceTo>.ConvertToManaged((void*)interfaceToPtr);
            return interfaceTo;
        }

        public static unsafe void FreeInstance<T>(T? obj)
            where T : class
        {
            void* objPtr = ComInterfaceMarshaller<T>.ConvertToUnmanaged(obj);
            ComInterfaceMarshaller<T>.Free(objPtr);
        }
    }
}
