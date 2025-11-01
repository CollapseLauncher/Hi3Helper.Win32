using System;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Hi3Helper.Win32.Native.ClassIds;

public class ShellLinkClsId
{
    public const string Id_ShellLinkClsId      = "00021401-0000-0000-C000-000000000046";
    public const string Id_ShellLinkIGuid      = "000214F9-0000-0000-C000-000000000046";
    public const string Id_IPersistFileIGuid   = "0000010B-0000-0000-C000-000000000046";
    public const string Id_IPersistIGuid       = "0000010C-0000-0000-C000-000000000046";
    public const string Id_IPropertyStoreIGuid = "886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99";

    public static readonly Guid ClsId_ShellLink      = new Guid(Id_ShellLinkClsId);
    public static readonly Guid IGuid_ShellLink      = new Guid(Id_ShellLinkIGuid);
    public static readonly Guid IGuid_IPersistFile   = new Guid(Id_IPersistFileIGuid);
    public static readonly Guid IGuid_IPersist       = new Guid(Id_IPersistIGuid);
    public static readonly Guid IGuid_IPropertyStore = new Guid(Id_IPropertyStoreIGuid);
}
