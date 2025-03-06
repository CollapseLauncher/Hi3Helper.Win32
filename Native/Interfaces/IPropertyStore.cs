using Hi3Helper.Win32.Native.ClassIds;
using Hi3Helper.Win32.ShellLinkCOM;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces
{
    [Guid(ShellLinkClsId.Id_IPropertyStoreIGuid)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface]
    public partial interface IPropertyStore
    {
        [PreserveSig]
        int GetCount(out uint cProps);
        [PreserveSig]
        int GetAt(in uint iProp, out PropertyKey pkey);
        [PreserveSig]
        int GetValue(ref PropertyKey key, out PropVariant pv);
        [PreserveSig]
        int SetValue(ref PropertyKey key, ref PropVariant pv);
        [PreserveSig]
        int Commit();
    }
}
