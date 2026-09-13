using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.Native.Interfaces;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("00020400-0000-0000-C000-000000000046")]
public unsafe partial interface IDispatch
{
    void GetTypeInfoCount(out int pctInfo);

    void GetTypeInfo(int   iTInfo,
                     int   lcid,
                     void* ppTInfo);

    void GetIDsOfNames(Guid*     riid,
                       out char* rgszNames,
                       int       cNames,
                       int       lcid,
                       int*      rgDispId);

    void Invoke(int*        dispIdMember,
                Guid*       riid,
                int         lcid,
                short       wFlags,
                void*       pDispParams,
                ComVariant* pVarResult,
                void*       pExcepInfo,
                int*        puArgErr);
}
