using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Hi3Helper.Win32.Native.ClassIds;
using Hi3Helper.Win32.Native.Structs;
using Hi3Helper.Win32.ShellLinkCOM;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces;


[Guid(ShellLinkClsId.Id_ShellLinkIGuid)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IShellLinkW
{
    /// <summary>
    /// Retrieves the path and filename of a shell link object
    /// </summary>
    unsafe void GetPath(
        ref char     pszFile,
        int          cchMaxPath,
        nint         pfd,
        EShellLinkGP fFlags);

    /// <summary>
    /// Retrieves the list of shell link item identifiers
    /// </summary>
    void GetIDList(out ITEMIDLIST* ppidl);

    /// <summary>
    /// Sets the list of shell link item identifiers
    /// </summary>
    void SetIDList(ITEMIDLIST* pidl);

    /// <summary>
    /// Retrieves the shell link description string
    /// </summary>
    unsafe void GetDescription(
        ref char pszFile,
        int      cchMaxName);

    /// <summary>
    /// Sets the shell link description string
    /// </summary>
    void SetDescription(string? pszName);

    /// <summary>
    /// Retrieves the name of the shell link working directory
    /// </summary>
    unsafe void GetWorkingDirectory(
        ref char pszDir,
        int      cchMaxPath);

    /// <summary>
    /// Sets the name of the shell link working directory
    /// </summary>
    void SetWorkingDirectory(string? pszDir);

    /// <summary>
    /// Retrieves the shell link command-line arguments
    /// </summary>
    unsafe void GetArguments(
        ref char pszArgs,
        int      cchMaxPath);

    /// <summary>
    /// Sets the shell link command-line arguments
    /// </summary>
    void SetArguments(string? pszArgs);

    /// <summary>
    /// Retrieves or sets the shell link hot key
    /// </summary>
    void GetHotkey(out short pwHotkey);

    /// <summary>
    /// Retrieves or sets the shell link hot key
    /// </summary>
    void SetHotkey(short pwHotkey);

    /// <summary>
    /// Retrieves or sets the shell link show command
    /// </summary>
    void GetShowCmd(out uint piShowCmd);

    /// <summary>
    /// Retrieves or sets the shell link show command
    /// </summary>
    void SetShowCmd(uint piShowCmd);

    /// <summary>
    /// Retrieves the location (path and index) of the shell link icon
    /// </summary>
    unsafe void GetIconLocation(
        ref char pszIconPath,
        int      cchIconPath,
        out int  piIcon);

    /// <summary>
    /// Sets the location (path and index) of the shell link icon
    /// </summary>
    void SetIconLocation(
        string? pszIconPath,
        int     iIcon);

    /// <summary>
    /// Sets the shell link relative path
    /// </summary>
    void SetRelativePath(
        string? pszPathRel,
        uint    dwReserved);

    /// <summary>
    /// Resolves a shell link. The system searches for the shell link object and updates the shell link path and its list of identifiers (if necessary)
    /// </summary>
    void Resolve(
        nint windowHandle,
        uint fFlags);

    /// <summary>
    /// Sets the shell link path and filename
    /// </summary>
    void SetPath(string? pszFile);
}