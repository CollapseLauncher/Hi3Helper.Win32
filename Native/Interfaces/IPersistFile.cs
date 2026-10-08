using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.ClassIds;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces;

[Guid(ShellLinkClsId.Id_IPersistFileIGuid)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IPersistFile : IPersist

{
    /// <summary>
    /// Checks for changes since last file write
    /// </summary>
    void IsDirty();

    /// <summary>
    /// Opens the specified file and initializes the object from its contents
    /// </summary>
    void Load(
        string pszFileName,
        uint   dwMode);

    /// <summary>
    /// Saves the object into the specified file
    /// </summary>
    void Save(
        string                               pszFileName,
        [MarshalAs(UnmanagedType.Bool)] bool fRemember);

    /// <summary>
    /// Notifies the object that save is completed
    /// </summary>
    void SaveCompleted(string pszFileName);

    /// <summary>
    /// Gets the current name of the file associated with the object
    /// </summary>
    void GetCurFile(out string ppszFileName);
}