using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.ClassIds;
using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Interfaces;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable NotAccessedField.Local
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable CommentTypo

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
namespace Hi3Helper.Win32.ShellLinkCOM
{
    internal unsafe delegate void ToDelegateInvoke(char* buffer, int length);

    internal unsafe delegate void ToDelegateWithW32FindDataInvoke(char* buffer, nint findDataPtr, int length);

    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
    public partial class ShellLink : IDisposable
    {
        // Use Unicode (W) under NT, otherwise use ANSI      
        readonly IShellLinkW?    _linkW;
        readonly IPropertyStore? _propertyStoreW;
        readonly IPersistFile?   _persistFileW;
        readonly IPersist?       _persistW;
        string                   _shortcutFile = "";

        /// <summary>
        /// Creates an instance of the Shell Link object.
        /// </summary>
        public ShellLink()
        {
            ComMarshal.CreateInstance(
                ShellLinkClsId.ClsId_ShellLink,
                nint.Zero,
                CLSCTX.CLSCTX_INPROC_SERVER,
                out IShellLinkW? shellLink
                ).ThrowOnFailure();

            _linkW = shellLink;
            _persistFileW = shellLink?.CastComInterfaceAs<IShellLinkW, IPersistFile>(in ShellLinkClsId.IGuid_IPersistFile);
            _persistW = shellLink?.CastComInterfaceAs<IShellLinkW, IPersist>(in ShellLinkClsId.IGuid_IPersist);
            _propertyStoreW = shellLink?.CastComInterfaceAs<IShellLinkW, IPropertyStore>(in ShellLinkClsId.IGuid_IPropertyStore);
        }

        /// <summary>
        /// Creates an instance of a Shell Link object
        /// from the specified link file
        /// </summary>
        /// <param name="linkFile">The Shortcut file to open</param>
        public ShellLink(string linkFile) : this() => Open(linkFile);

        /// <summary>
        /// Call dispose just in case it hasn't happened yet
        /// </summary>
        ~ShellLink() => Dispose();

        /// <summary>
        /// Dispose the object, releasing the COM ShellLink object
        /// </summary>
        public void Dispose()
        {
            ComMarshal.FreeInstance(_linkW);
            GC.SuppressFinalize(this);
        }

        public string? ShortcutFile { get; set; }

        /// <summary>
        /// This pointer must be destroyed with DestroyIcon when you are done with it.
        /// </summary>
        /// <param name="large">Whether to return the small or large icon</param>
        public nint GetIcon(bool large)
        {
            // Get icon index and path:
            string iconFile = IconPath;
            int iconIndex = IconIndex ?? 0;

            // If there are no details set for the icon, then we must use
            // the shell to get the icon for the target:
            if (iconFile.Length == 0)
            {
                // Use the FileIcon object to get the icon:
                SHGetFileInfoConstants flags =
                    SHGetFileInfoConstants.SHGFI_ICON |
                        SHGetFileInfoConstants.SHGFI_ATTRIBUTES;

                flags |= large ? SHGetFileInfoConstants.SHGFI_LARGEICON : SHGetFileInfoConstants.SHGFI_SMALLICON;

                FileIcon fileIcon = new(Target, flags);
                return fileIcon.ShellIcon;
            }

            // Use ExtractIconEx to get the icon:
            nint[] hIconEx  = [nint.Zero];
            nint   hIconExP = Marshal.UnsafeAddrOfPinnedArrayElement(hIconEx, 0);
            if (large)
            {
                PInvoke.ExtractIconEx(
                                      iconFile,
                                      iconIndex,
                                      hIconExP,
                                      nint.Zero,
                                      1);
            }
            else
            {
                PInvoke.ExtractIconEx(
                                      iconFile,
                                      iconIndex,
                                      nint.Zero,
                                      hIconExP,
                                      1);
            }

            return hIconEx[0];
        }

        /// <summary>
        /// Gets the path to the file containing the icon for this shortcut.
        /// </summary>
        [field: AllowNull, MaybeNull]
        public unsafe string IconPath
        {
            get => field ??= GetStringFromIMethod(260, (ptr, len) => _linkW?.GetIconLocation(ptr, len, out _));
            set => _linkW?.SetIconLocation(field = value, IconIndex ?? 0);
        }

        /// <summary>
        /// Gets the index of this icon within the icon path's resources
        /// </summary>
        public unsafe int? IconIndex
        {
            get
            {
                if (field != null)
                {
                    return field ?? 0;
                }

                int iconIndex = 0;
                _     = GetStringFromIMethod(260, (ptr, len) => _linkW?.GetIconLocation(ptr, len, out iconIndex));
                field = iconIndex;
                return field ?? 0;
            }
            set => _linkW?.SetIconLocation(IconPath, (field = value) ?? 0);
        }

        /// <summary>
        /// Gets/sets the fully qualified path to the link's target
        /// </summary>
        [field: AllowNull, MaybeNull]
        public unsafe string Target
        {
            get => field ??= GetStringFromIMethod(260, (ptr, len) => _linkW?.GetPath(ptr, len, nint.Zero, EShellLinkGP.SLGP_UNCPRIORITY));
            set => _linkW?.SetPath(field = value);
        }

        /// <summary>
        /// Gets/sets the Working Directory for the Link
        /// </summary>
        [field: AllowNull, MaybeNull]
        public unsafe string WorkingDirectory
        {
            get => field ??= GetStringFromIMethod(260, (ptr, len) => _linkW?.GetWorkingDirectory(ptr, len));
            set => _linkW?.SetWorkingDirectory(field = value);
        }

        /// <summary>
        /// Gets/sets the description of the link
        /// </summary>
        [field: AllowNull, MaybeNull]
        public unsafe string Description
        {
            get => field ??= GetStringFromIMethod(1024, (ptr, len) => _linkW?.GetDescription(ptr, len));
            set => _linkW?.SetDescription(field = value);
        }

        /// <summary>
        /// Gets/sets any command line arguments associated with the link
        /// </summary>
        [field: AllowNull, MaybeNull]
        public unsafe string Arguments
        {
            get => field ??= GetStringFromIMethod(260, (ptr, len) => _linkW?.GetArguments(ptr, len));
            set => _linkW?.SetArguments(field = value);
        }

        /// <summary>
        /// Gets/sets the initial display mode when the shortcut is
        /// run
        /// </summary>
        public LinkDisplayMode DisplayMode
        {
            get
            {
                uint cmd = 0;
                _linkW?.GetShowCmd(out cmd);
                return (LinkDisplayMode)cmd;
            }
            set => _linkW?.SetShowCmd((uint)value);
        }

        /// <summary>
        /// Gets/sets the HotKey to start the shortcut (if any)
        /// </summary>
        public short HotKey
        {
            get
            {
                short key = 0;
                _linkW?.GetHotkey(out key);
                return key;
            }
            set => _linkW?.SetHotkey(value);
        }

        private static unsafe string GetStringFromIMethod(int length, ToDelegateInvoke toInvokeDelegate)
        {
            Span<char> buffer = stackalloc char[length];
            fixed (char* bufferP = &MemoryMarshal.GetReference(buffer))
            {
                toInvokeDelegate(bufferP, length);
                ReadOnlySpan<char> bufferSliced = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(bufferP);
                return bufferSliced.IsEmpty ? string.Empty : new string(bufferSliced);
            }
        }

        /// <summary>
        /// Sets the appUserModelId
        /// </summary>
        public void SetAppUserModelId(string appId)
        {
            PropertyKey pkey = PropertyKey.PkeyAppUserModelID;
            PropVariant str = PropVariant.FromString(appId);
            _propertyStoreW?.SetValue(ref pkey, ref str);
        }

        /// <summary>
        /// Sets the ToastActivatorCLSID
        /// </summary>
        public void SetToastActivatorClsid(string clsid)
        {
            Guid guid = Guid.Parse(clsid);
            SetToastActivatorClsid(guid);
        }

        /// <summary>
        /// Sets the ToastActivatorCLSID
        /// </summary>
        public void SetToastActivatorClsid(Guid clsid)
        {
            PropertyKey pkey = PropertyKey.PkeyAppUserModelToastActivatorClsid;
            PropVariant varGuid = PropVariant.FromGuid(clsid);
            try
            {
                int errCode = _propertyStoreW?.SetValue(ref pkey, ref varGuid) ?? unchecked((int)0x80004003);
                Marshal.ThrowExceptionForHR(errCode);

                errCode = _propertyStoreW?.Commit() ?? unchecked((int)0x80004003);
                Marshal.ThrowExceptionForHR(errCode);
            }
            finally
            {
                varGuid.Clear();
            }
        }

        /// <summary>
        /// Saves the shortcut to ShortCutFile.
        /// </summary>
        public void Save()
        {
            Save(_shortcutFile);
        }

        /// <summary>
        /// Saves the shortcut to the specified file
        /// </summary>
        /// <param name="linkFile">The shortcut file (.lnk)</param>
        public void Save(string linkFile) => _persistFileW?.Save(linkFile, true);

        /// <summary>
        /// Loads a shortcut from the specified file
        /// </summary>
        /// <param name="linkFile">The shortcut file (.lnk) to load</param>
        public void Open(string linkFile) => Open(linkFile, nint.Zero, EShellLinkResolveFlags.SLR_ANY_MATCH | EShellLinkResolveFlags.SLR_NO_UI, 1);

        /// <summary>
        /// Loads a shortcut from the specified file, and allows flags controlling
        /// the UI behaviour if the shortcut's target isn't found to be set.
        /// </summary>
        /// <param name="linkFile">The shortcut file (.lnk) to load</param>
        /// <param name="windowHandle">The window handle of the application's UI, if any</param>
        /// <param name="resolveFlags">Flags controlling resolution behaviour</param>
        public void Open(string linkFile, nint windowHandle, EShellLinkResolveFlags resolveFlags) => Open(linkFile, windowHandle, resolveFlags, 1);

        /// <summary>
        /// Loads a shortcut from the specified file, and allows flags controlling
        /// the UI behaviour if the shortcut's target isn't found to be set.  If
        /// no SLR_NO_UI is specified, you can also specify a timeout.
        /// </summary>
        /// <param name="linkFile">The shortcut file (.lnk) to load</param>
        /// <param name="windowHandle">The window handle of the application's UI, if any</param>
        /// <param name="resolveFlags">Flags controlling resolution behaviour</param>
        /// <param name="timeOut">Timeout if SLR_NO_UI is specified, in ms.</param>
        public void Open(string linkFile, nint windowHandle, EShellLinkResolveFlags resolveFlags, ushort timeOut)
        {
            _persistFileW?.Load(linkFile, 0);
            _shortcutFile = linkFile;
        }
    }

    /// <summary>
    /// Enables extraction of icons for any file type from
    /// the Shell.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SupportedOSPlatform("windows")]
    public class FileIcon
    {
        /// <summary>
        /// Gets/sets the flags used to extract the icon
        /// </summary>
        public SHGetFileInfoConstants Flags { get; set; }

        /// <summary>
        /// Gets/sets the filename to get the icon for
        /// </summary>
        public string? FileName { get; set; }

        /// <summary>
        /// Gets the icon for the chosen file
        /// </summary>
        public nint ShellIcon { get; private set; }

        /// <summary>
        /// Gets the display name for the selected file
        /// if the SHGFI_DISPLAYNAME flag was set.
        /// </summary>
        public string? DisplayName { get; private set; }

        /// <summary>
        /// Gets the type name for the selected file
        /// if the SHGFI_TYPENAME flag was set.
        /// </summary>
        public string? TypeName { get; private set; }

        /// <summary>
        ///  Gets the information for the specified 
        ///  file name and flags.
        /// </summary>
        private unsafe void GetInfo()
        {
            ShellIcon   = nint.Zero;
            TypeName    = "";
            DisplayName = "";

            int  shfiSize   = sizeof(SHFILEINFOW);
            nint shfiHandle = Marshal.AllocCoTaskMem(shfiSize);

            try
            {
                nint ret = PInvoke.SHGetFileInfo(FileName ?? string.Empty, 0, shfiHandle, (uint)shfiSize, (uint)Flags);
                ref SHFILEINFOW shfi = ref Unsafe.AsRef<SHFILEINFOW>((void*)shfiHandle);

                if (ret != nint.Zero)
                {
                    if (shfi.hIcon != nint.Zero)
                    {
                        ShellIcon = shfi.hIcon; // need to dispose this
                    }

                    fixed (char* typeName = shfi.szTypeName)
                    {
                        fixed (char* displayName = shfi.szDisplayName)
                        {
                            TypeName    = new string(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(typeName));
                            DisplayName = new string(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(displayName));
                        }
                    }
                }
                else
                {
                    Console.WriteLine(Win32Error.GetLastWin32ErrorMessage());
                }
            }
            finally
            {
                Marshal.FreeCoTaskMem(shfiHandle);
            }
        }

        /// <summary>
        /// Constructs a new, default instance of the FileIcon
        /// class.  Specify the filename and call GetInfo()
        /// to retrieve an icon.
        /// </summary>
        public FileIcon()
        {
            Flags = SHGetFileInfoConstants.SHGFI_ICON |
                    SHGetFileInfoConstants.SHGFI_DISPLAYNAME |
                    SHGetFileInfoConstants.SHGFI_TYPENAME |
                    SHGetFileInfoConstants.SHGFI_ATTRIBUTES |
                    SHGetFileInfoConstants.SHGFI_EXETYPE;
        }

        /// <summary>
        /// Constructs a new instance of the FileIcon class
        /// and retrieves the icon, display name and type name
        /// for the specified file.
        /// </summary>
        /// <param name="fileName">The filename to get the icon, 
        /// display name and type name for</param>
        public FileIcon(string fileName)
            : this()
        {
            FileName = fileName;
            GetInfo();
        }

        /// <summary>
        /// Constructs a new instance of the FileIcon class
        /// and retrieves the information specified in the 
        /// flags.
        /// </summary>
        /// <param name="fileName">The filename to get information
        /// for</param>
        /// <param name="flags">The flags to use when extracting the
        /// icon and other shell information.</param>
        public FileIcon(string fileName, SHGetFileInfoConstants flags)
        {
            FileName = fileName;
            Flags    = flags;
            GetInfo();
        }
    }
}
