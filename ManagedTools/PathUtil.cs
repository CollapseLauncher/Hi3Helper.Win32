using Hi3Helper.Win32.Native.ClassIds;
using Hi3Helper.Win32.Native.LibraryImport;
using System;
using System.Runtime.CompilerServices;

namespace Hi3Helper.Win32.ManagedTools;

public static class PathUtil
{
    /// Reference:
    /// https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/Interop/Windows/Shell32/Interop.SHGetKnownFolderPath.cs#L269
    public static string GetFolderPath(Environment.SpecialFolder folder, Environment.SpecialFolderOption option = Environment.SpecialFolderOption.None)
    {
        // We're using SHGetKnownFolderPath instead of SHGetFolderPath as SHGetFolderPath is
        // capped at MAX_PATH.
        //
        // Because we validate both of the input enums we shouldn't have to care about CSIDL and flag
        // definitions we haven't mapped. If we remove or loosen the checks we'd have to account
        // for mapping here (this includes tweaking as SHGetFolderPath would do).
        //
        // The only SpecialFolderOption defines we have are equivalent to KnownFolderFlags.

        ref readonly Guid folderGuid = ref Unsafe.NullRef<Guid>();
        string? fallbackEnv = null;
        switch (folder)
        {
            // Special-cased values to not use SHGetFolderPath when we have a more direct option available.
            case Environment.SpecialFolder.System:
                // This assumes the system directory always exists and thus we don't need to do anything special for any SpecialFolderOption.
                return Environment.SystemDirectory;
            default:
                return string.Empty;

            // Map the SpecialFolder to the appropriate Guid
            case Environment.SpecialFolder.ApplicationData:
                folderGuid = ref KnownFoldersGuid.RoamingAppData;
                fallbackEnv = "APPDATA";
                break;
            case Environment.SpecialFolder.CommonApplicationData:
                folderGuid = ref KnownFoldersGuid.ProgramData;
                fallbackEnv = "ProgramData";
                break;
            case Environment.SpecialFolder.LocalApplicationData:
                folderGuid = ref KnownFoldersGuid.LocalAppData;
                fallbackEnv = "LOCALAPPDATA";
                break;
            case Environment.SpecialFolder.Cookies:
                folderGuid = ref KnownFoldersGuid.Cookies;
                break;
            case Environment.SpecialFolder.Desktop:
                folderGuid = ref KnownFoldersGuid.Desktop;
                break;
            case Environment.SpecialFolder.Favorites:
                folderGuid = ref KnownFoldersGuid.Favorites;
                break;
            case Environment.SpecialFolder.History:
                folderGuid = ref KnownFoldersGuid.History;
                break;
            case Environment.SpecialFolder.InternetCache:
                folderGuid = ref KnownFoldersGuid.InternetCache;
                break;
            case Environment.SpecialFolder.Programs:
                folderGuid = ref KnownFoldersGuid.Programs;
                break;
            case Environment.SpecialFolder.MyComputer:
                folderGuid = ref KnownFoldersGuid.ComputerFolder;
                break;
            case Environment.SpecialFolder.MyMusic:
                folderGuid = ref KnownFoldersGuid.Music;
                break;
            case Environment.SpecialFolder.MyPictures:
                folderGuid = ref KnownFoldersGuid.Pictures;
                break;
            case Environment.SpecialFolder.MyVideos:
                folderGuid = ref KnownFoldersGuid.Videos;
                break;
            case Environment.SpecialFolder.Recent:
                folderGuid = ref KnownFoldersGuid.Recent;
                break;
            case Environment.SpecialFolder.SendTo:
                folderGuid = ref KnownFoldersGuid.SendTo;
                break;
            case Environment.SpecialFolder.StartMenu:
                folderGuid = ref KnownFoldersGuid.StartMenu;
                break;
            case Environment.SpecialFolder.Startup:
                folderGuid = ref KnownFoldersGuid.Startup;
                break;
            case Environment.SpecialFolder.Templates:
                folderGuid = ref KnownFoldersGuid.Templates;
                break;
            case Environment.SpecialFolder.DesktopDirectory:
                folderGuid = ref KnownFoldersGuid.Desktop;
                break;
            case Environment.SpecialFolder.Personal:
                // Same as Personal
                // case Environment.SpecialFolder.MyDocuments:
                folderGuid = ref KnownFoldersGuid.Documents;
                break;
            case Environment.SpecialFolder.ProgramFiles:
                folderGuid = ref KnownFoldersGuid.ProgramFiles;
                fallbackEnv = "ProgramFiles";
                break;
            case Environment.SpecialFolder.CommonProgramFiles:
                folderGuid = ref KnownFoldersGuid.ProgramFilesCommon;
                fallbackEnv = "CommonProgramFiles";
                break;
            case Environment.SpecialFolder.AdminTools:
                folderGuid = ref KnownFoldersGuid.AdminTools;
                break;
            case Environment.SpecialFolder.CDBurning:
                folderGuid = ref KnownFoldersGuid.CDBurning;
                break;
            case Environment.SpecialFolder.CommonAdminTools:
                folderGuid = ref KnownFoldersGuid.CommonAdminTools;
                break;
            case Environment.SpecialFolder.CommonDocuments:
                folderGuid = ref KnownFoldersGuid.PublicDocuments;
                break;
            case Environment.SpecialFolder.CommonMusic:
                folderGuid = ref KnownFoldersGuid.PublicMusic;
                break;
            case Environment.SpecialFolder.CommonOemLinks:
                folderGuid = ref KnownFoldersGuid.CommonOEMLinks;
                break;
            case Environment.SpecialFolder.CommonPictures:
                folderGuid = ref KnownFoldersGuid.PublicPictures;
                break;
            case Environment.SpecialFolder.CommonStartMenu:
                folderGuid = ref KnownFoldersGuid.CommonStartMenu;
                break;
            case Environment.SpecialFolder.CommonPrograms:
                folderGuid = ref KnownFoldersGuid.CommonPrograms;
                break;
            case Environment.SpecialFolder.CommonStartup:
                folderGuid = ref KnownFoldersGuid.CommonStartup;
                break;
            case Environment.SpecialFolder.CommonDesktopDirectory:
                folderGuid = ref KnownFoldersGuid.PublicDesktop;
                break;
            case Environment.SpecialFolder.CommonTemplates:
                folderGuid = ref KnownFoldersGuid.CommonTemplates;
                break;
            case Environment.SpecialFolder.CommonVideos:
                folderGuid = ref KnownFoldersGuid.PublicVideos;
                break;
            case Environment.SpecialFolder.Fonts:
                folderGuid = ref KnownFoldersGuid.Fonts;
                break;
            case Environment.SpecialFolder.NetworkShortcuts:
                folderGuid = ref KnownFoldersGuid.NetHood;
                break;
            case Environment.SpecialFolder.PrinterShortcuts:
                folderGuid = ref KnownFoldersGuid.PrintersFolder;
                break;
            case Environment.SpecialFolder.UserProfile:
                folderGuid = ref KnownFoldersGuid.Profile;
                fallbackEnv = "USERPROFILE";
                break;
            case Environment.SpecialFolder.CommonProgramFilesX86:
                folderGuid = ref KnownFoldersGuid.ProgramFilesCommonX86;
                fallbackEnv = "CommonProgramFiles(x86)";
                break;
            case Environment.SpecialFolder.ProgramFilesX86:
                folderGuid = ref KnownFoldersGuid.ProgramFilesX86;
                fallbackEnv = "ProgramFiles(x86)";
                break;
            case Environment.SpecialFolder.Resources:
                folderGuid = ref KnownFoldersGuid.ResourceDir;
                break;
            case Environment.SpecialFolder.LocalizedResources:
                folderGuid = ref KnownFoldersGuid.LocalizedResourcesDir;
                break;
            case Environment.SpecialFolder.SystemX86:
                folderGuid = ref KnownFoldersGuid.SystemX86;
                break;
            case Environment.SpecialFolder.Windows:
                folderGuid = ref KnownFoldersGuid.Windows;
                // ReSharper disable once StringLiteralTypo
                fallbackEnv = "windir";
                break;
        }

        int hr = PInvoke.SHGetKnownFolderPath(in folderGuid, (uint)option, nint.Zero, out string? path);
        if (hr == 0 && !string.IsNullOrEmpty(path))
            return path;

        // Fallback logic if SHGetKnownFolderPath failed (nanoserver)
        return fallbackEnv != null ? Environment.GetEnvironmentVariable(fallbackEnv) ?? string.Empty : string.Empty;
    }
}
