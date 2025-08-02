using Hi3Helper.Win32.Native.ClassIds;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable PartialTypeWithSinglePart

namespace Hi3Helper.Win32.Native.Interfaces
{
    [Guid(ShellLinkClsId.Id_IPersistIGuid)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface IPersist
    {
        /// <summary>
        /// Returns the class identifier for the component object
        /// </summary>
        [PreserveSig]
        void GetClassID(out Guid pClassID);
    }
}
