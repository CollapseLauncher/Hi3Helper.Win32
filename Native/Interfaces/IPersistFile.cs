using Hi3Helper.Win32.Native.ClassIds;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Interfaces
{
    [Guid(ShellLinkClsId.Id_IPersistFileIGuid)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
    public partial interface IPersistFile
    {
        // can't get this to go if I extend IPersist, so put it here:
        [PreserveSig]
        void GetClassID(out Guid pClassID);

        /// <summary>
        /// Checks for changes since last file write
        /// </summary>
        void IsDirty();

        /// <summary>
        /// Opens the specified file and initializes the object from its contents
        /// </summary>
        void Load(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            uint dwMode);

        /// <summary>
        /// Saves the object into the specified file
        /// </summary>
        void Save(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            [MarshalAs(UnmanagedType.Bool)] bool fRemember);

        /// <summary>
        /// Notifies the object that save is completed
        /// </summary>
        void SaveCompleted(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFileName);

        /// <summary>
        /// Gets the current name of the file associated with the object
        /// </summary>
        void GetCurFile(
            [MarshalAs(UnmanagedType.LPWStr)] out string ppszFileName);
    }
}
