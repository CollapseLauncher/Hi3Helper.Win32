using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces.TaskScheduler;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(TaskSchedulerIIDConst.IID_IRegistrationInfo)]
public unsafe partial interface IRegistrationInfo : IDispatch
{
    void GetDescription([MarshalUsing(typeof(Utf16StringMarshaller))] out string? description);

    void SetDescription([MarshalUsing(typeof(Utf16StringMarshaller))] string? description);

    void GetAuthor([MarshalUsing(typeof(Utf16StringMarshaller))] out string? author);

    void SetAuthor([MarshalUsing(typeof(Utf16StringMarshaller))] string? author);

    void GetVersion([MarshalUsing(typeof(Utf16StringMarshaller))] out string? version);

    void SetVersion([MarshalUsing(typeof(Utf16StringMarshaller))] string? version);

    void GetDate([MarshalUsing(typeof(Utf16StringMarshaller))] out string? date);

    void SetDate([MarshalUsing(typeof(Utf16StringMarshaller))] string? date);

    void GetDocumentation([MarshalUsing(typeof(Utf16StringMarshaller))] out string? doc);

    void SetDocumentation([MarshalUsing(typeof(Utf16StringMarshaller))] string? doc);

    void GetXmlText([MarshalUsing(typeof(Utf16StringMarshaller))] out string? xml);

    void SetXmlText([MarshalUsing(typeof(Utf16StringMarshaller))] string? xml);

    void GetURI([MarshalUsing(typeof(Utf16StringMarshaller))] out string? uri);

    void SetURI([MarshalUsing(typeof(Utf16StringMarshaller))] string? uri);

    void GetSecurityDescriptor(out ComVariant sddl);

    void SetSecurityDescriptor(ComVariant sddl);

    void GetSource([MarshalUsing(typeof(Utf16StringMarshaller))] out string? source);

    void SetSource([MarshalUsing(typeof(Utf16StringMarshaller))] string? source);
}
