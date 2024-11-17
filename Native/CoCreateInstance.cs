﻿using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native
{
    public static partial class CoCreateInstance
    {
        public static unsafe HResult CreateInstance<T>(Guid rclsid, nint pUnkOuter, CLSCTX dwClsContext, out T? ppv)
        {
            Guid refTGuid = typeof(T).GUID;
            HResult hr = PInvoke.CoCreateInstance(in rclsid, pUnkOuter, dwClsContext, in refTGuid, out void* o);
            ppv = ComInterfaceMarshaller<T>.ConvertToManaged(o);
            return hr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe TInterfaceTo? CastComInterfaceAs<TInterfaceFrom, TInterfaceTo>(this TInterfaceFrom interfaceFrom, in Guid interfaceToGuid)
            where TInterfaceFrom : class
            where TInterfaceTo : class
        {
            void* interfaceFromPtr = ComInterfaceMarshaller<TInterfaceFrom>.ConvertToUnmanaged(interfaceFrom);

            Marshal.QueryInterface((nint)interfaceFromPtr, in interfaceToGuid, out nint ppv);
            void* interfaceToPtr = (void*)ppv;

            TInterfaceTo? interfaceTo = ComInterfaceMarshaller<TInterfaceTo>.ConvertToManaged(interfaceToPtr);
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
