using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.ClassIds;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.ShellLinkCOM;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(ShellLinkClsId.Id_IPropertyStoreIGuid)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface]
public partial interface IPropertyStore
{
    void GetCount(out uint cProps);

    void GetAt(ref readonly uint iProp, out PropertyKey pkey);

    void GetValue(ref readonly PropertyKey key, out PropVariant pv);

    void SetValue(ref readonly PropertyKey key, ref readonly PropVariant pv);

    void Commit();
}