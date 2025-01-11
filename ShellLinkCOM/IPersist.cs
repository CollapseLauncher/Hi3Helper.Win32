using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable PartialTypeWithSinglePart

namespace Hi3Helper.Win32.ShellLinkCOM
{
    [Guid(CLSIDGuid.Id_IPersistIGuid)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    internal partial interface IPersist
    {
        [PreserveSig]
        //[helpstring("Returns the class identifier for the component object")]
        void GetClassID(out Guid pClassID);
    }
}
