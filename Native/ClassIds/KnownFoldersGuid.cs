﻿// Reference:
// https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/Interop/Windows/Shell32/Interop.SHGetKnownFolderPath.cs#L269
// https://msdn.microsoft.com/en-us/library/windows/desktop/dd378457.aspx

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

using System;

namespace Hi3Helper.Win32.Native.ClassIds;

public static class KnownFoldersGuid
{
    /// <summary>
    /// (CSIDL_ADMINTOOLS) Per user Administrative Tools
    /// "%APPDATA%\Microsoft\Windows\Start Menu\Programs\Administrative Tools"
    /// </summary>
    public static readonly Guid AdminTools = new("{724EF170-A42D-4FEF-9F26-B60E846FBA4F}");

    /// <summary>
    /// (CSIDL_CDBURN_AREA) Temporary Burn folder
    /// "%LOCALAPPDATA%\Microsoft\Windows\Burn\Burn"
    /// </summary>
    public static readonly Guid CDBurning = new("{9E52AB10-F80D-49DF-ACB8-4330F5687855}");

    /// <summary>
    /// (CSIDL_COMMON_ADMINTOOLS) Common Administrative Tools
    /// "%ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\Administrative Tools"
    /// </summary>
    public static readonly Guid CommonAdminTools = new("{D0384E7D-BAC3-4797-8F14-CBA229B392B5}");

    /// <summary>
    /// (CSIDL_COMMON_OEM_LINKS) OEM Links folder
    /// "%ALLUSERSPROFILE%\OEM Links"
    /// </summary>
    public static readonly Guid CommonOEMLinks = new("{C1BAE2D0-10DF-4334-BEDD-7AA20B227A9D}");

    /// <summary>
    /// (CSIDL_COMMON_PROGRAMS) Common Programs folder
    /// "%ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs"
    /// </summary>
    public static readonly Guid CommonPrograms = new("{0139D44E-6AFE-49F2-8690-3DAFCAE6FFB8}");

    /// <summary>
    /// (CSIDL_COMMON_STARTMENU) Common Start Menu folder
    /// "%ALLUSERSPROFILE%\Microsoft\Windows\Start Menu"
    /// </summary>
    public static readonly Guid CommonStartMenu = new("{A4115719-D62E-491D-AA7C-E74B8BE3B067}");

    /// <summary>
    /// (CSIDL_COMMON_STARTUP, CSIDL_COMMON_ALTSTARTUP) Common Startup folder
    /// "%ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\StartUp"
    /// </summary>
    public static readonly Guid CommonStartup = new("{82A5EA35-D9CD-47C5-9629-E15D2F714E6E}");

    /// <summary>
    /// (CSIDL_COMMON_TEMPLATES) Common Templates folder
    /// "%ALLUSERSPROFILE%\Microsoft\Windows\Templates"
    /// </summary>
    public static readonly Guid CommonTemplates = new("{B94237E7-57AC-4347-9151-B08C6C32D1F7}");

    /// <summary>
    /// (CSIDL_DRIVES) Computer virtual folder
    /// </summary>
    public static readonly Guid ComputerFolder = new("{0AC0837C-BBF8-452A-850D-79D08E667CA7}");

    /// <summary>
    /// (CSIDL_CONNECTIONS) Network Connections virtual folder
    /// </summary>
    public static readonly Guid ConnectionsFolder = new("{6F0CD92B-2E97-45D1-88FF-B0D186B8DEDD}");

    /// <summary>
    /// (CSIDL_CONTROLS) Control Panel virtual folder
    /// </summary>
    public static readonly Guid ControlPanelFolder = new("{82A74AEB-AEB4-465C-A014-D097EE346D63}");

    /// <summary>
    /// (CSIDL_COOKIES) Cookies folder
    /// "%APPDATA%\Microsoft\Windows\Cookies"
    /// </summary>
    public static readonly Guid Cookies = new("{2B0F765D-C0E9-4171-908E-08A611B84FF6}");

    /// <summary>
    /// (CSIDL_DESKTOP, CSIDL_DESKTOPDIRECTORY) Desktop folder
    /// "%USERPROFILE%\Desktop"
    /// </summary>
    public static readonly Guid Desktop = new("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");

    /// <summary>
    /// (CSIDL_MYDOCUMENTS, CSIDL_PERSONAL) Documents (My Documents) folder
    /// "%USERPROFILE%\Documents"
    /// </summary>
    public static readonly Guid Documents = new("{FDD39AD0-238F-46AF-ADB4-6C85480369C7}");

    /// <summary>
    /// (CSIDL_FAVORITES, CSIDL_COMMON_FAVORITES) Favorites folder
    /// "%USERPROFILE%\Favorites"
    /// </summary>
    public static readonly Guid Favorites = new("{1777F761-68AD-4D8A-87BD-30B759FA33DD}");

    /// <summary>
    /// (CSIDL_FONTS) Fonts folder
    /// "%windir%\Fonts"
    /// </summary>
    public static readonly Guid Fonts = new("{FD228CB7-AE11-4AE3-864C-16F3910AB8FE}");

    /// <summary>
    /// (CSIDL_HISTORY) History folder
    /// "%LOCALAPPDATA%\Microsoft\Windows\History"
    /// </summary>
    public static readonly Guid History = new("{D9DC8A3B-B784-432E-A781-5A1130A75963}");

    /// <summary>
    /// (CSIDL_INTERNET_CACHE) Temporary Internet Files folder
    /// "%LOCALAPPDATA%\Microsoft\Windows\Temporary Internet Files"
    /// </summary>
    public static readonly Guid InternetCache = new("{352481E8-33BE-4251-BA85-6007CAEDCF9D}");

    /// <summary>
    /// (CSIDL_INTERNET) The Internet virtual folder
    /// </summary>
    public static readonly Guid InternetFolder = new("{4D9F7874-4E0C-4904-967B-40B0D20C3E4B}");

    /// <summary>
    /// (CSIDL_LOCAL_APPDATA) Local folder
    /// "%LOCALAPPDATA%" ("%USERPROFILE%\AppData\Local")
    /// </summary>
    public static readonly Guid LocalAppData = new("{F1B32785-6FBA-4FCF-9D55-7B8E7F157091}");

    /// <summary>
    /// (CSIDL_RESOURCES_LOCALIZED) Fixed localized resources folder
    /// "%windir%\resources\0409" (per active codepage)
    /// </summary>
    public static readonly Guid LocalizedResourcesDir = new("{2A00375E-224C-49DE-B8D1-440DF7EF3DDC}");

    /// <summary>
    /// (CSIDL_MYMUSIC) Music folder
    /// "%USERPROFILE%\Music"
    /// </summary>
    public static readonly Guid Music = new("{4BD8D571-6D19-48D3-BE97-422220080E43}");

    /// <summary>
    /// (CSIDL_NETHOOD) Network shortcuts folder "%APPDATA%\Microsoft\Windows\Network Shortcuts"
    /// </summary>
    public static readonly Guid NetHood = new("{C5ABBF53-E17F-4121-8900-86626FC2C973}");

    /// <summary>
    /// (CSIDL_NETWORK, CSIDL_COMPUTERSNEARME) Network virtual folder
    /// </summary>
    public static readonly Guid NetworkFolder = new("{D20BEEC4-5CA8-4905-AE3B-BF251EA09B53}");

    /// <summary>
    /// (CSIDL_MYPICTURES) Pictures folder "%USERPROFILE%\Pictures"
    /// </summary>
    public static readonly Guid Pictures = new("{33E28130-4E1E-4676-835A-98395C3BC3BB}");

    /// <summary>
    /// (CSIDL_PRINTERS) Printers virtual folder
    /// </summary>
    public static readonly Guid PrintersFolder = new("{76FC4E2D-D6AD-4519-A663-37BD56068185}");

    /// <summary>
    /// (CSIDL_PRINTHOOD) Printer Shortcuts folder
    /// "%APPDATA%\Microsoft\Windows\Printer Shortcuts"
    /// </summary>
    public static readonly Guid PrintHood = new("{9274BD8D-CFD1-41C3-B35E-B13F55A758F4}");

    /// <summary>
    /// (CSIDL_PROFILE) The root users profile folder "%USERPROFILE%"
    /// ("%SystemDrive%\Users\%USERNAME%")
    /// </summary>
    public static readonly Guid Profile = new("{5E6C858F-0E22-4760-9AFE-EA3317B67173}");

    /// <summary>
    /// (CSIDL_COMMON_APPDATA) ProgramData folder
    /// "%ALLUSERSPROFILE%" ("%ProgramData%", "%SystemDrive%\ProgramData")
    /// </summary>
    public static readonly Guid ProgramData = new("{62AB5D82-FDC1-4DC3-A9DD-070D1D495D97}");

    /// <summary>
    /// (CSIDL_PROGRAM_FILES) Program Files folder for the current process architecture
    /// "%ProgramFiles%" ("%SystemDrive%\Program Files")
    /// </summary>
    public static readonly Guid ProgramFiles = new("{905e63b6-c1bf-494e-b29c-65b732d3d21a}");

    /// <summary>
    /// (CSIDL_PROGRAM_FILESX86) 32 bit Program Files folder (available to both 32/64 bit processes)
    /// </summary>
    public static readonly Guid ProgramFilesX86 = new("{7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E}");

    /// <summary>
    /// (CSIDL_PROGRAM_FILES_COMMON) Common Program Files folder for the current process architecture
    /// "%ProgramFiles%\Common Files"
    /// </summary>
    public static readonly Guid ProgramFilesCommon = new("{F7F1ED05-9F6D-47A2-AAAE-29D317C6F066}");

    /// <summary>
    /// (CSIDL_PROGRAM_FILES_COMMONX86) Common 32 bit Program Files folder (available to both 32/64 bit processes)
    /// </summary>
    public static readonly Guid ProgramFilesCommonX86 = new("{DE974D24-D9C6-4D3E-BF91-F4455120B917}");

    /// <summary>
    /// (CSIDL_PROGRAMS) Start menu Programs folder
    /// "%APPDATA%\Microsoft\Windows\Start Menu\Programs"
    /// </summary>
    public static readonly Guid Programs = new("{A77F5D77-2E2B-44C3-A6A2-ABA601054A51}");

    /// <summary>
    /// (CSIDL_COMMON_DESKTOPDIRECTORY) Public Desktop folder
    /// "%PUBLIC%\Desktop"
    /// </summary>
    public static readonly Guid PublicDesktop = new("{C4AA340D-F20F-4863-AFEF-F87EF2E6BA25}");

    /// <summary>
    /// (CSIDL_COMMON_DOCUMENTS) Public Documents folder
    /// "%PUBLIC%\Documents"
    /// </summary>
    public static readonly Guid PublicDocuments = new("{ED4824AF-DCE4-45A8-81E2-FC7965083634}");

    /// <summary>
    /// (CSIDL_COMMON_MUSIC) Public Music folder
    /// "%PUBLIC%\Music"
    /// </summary>
    public static readonly Guid PublicMusic = new("{3214FAB5-9757-4298-BB61-92A9DEAA44FF}");

    /// <summary>
    /// (CSIDL_COMMON_PICTURES) Public Pictures folder
    /// "%PUBLIC%\Pictures"
    /// </summary>
    public static readonly Guid PublicPictures = new("{B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5}");

    /// <summary>
    /// (CSIDL_COMMON_VIDEO) Public Videos folder
    /// "%PUBLIC%\Videos"
    /// </summary>
    public static readonly Guid PublicVideos = new("{2400183A-6185-49FB-A2D8-4A392A602BA3}");

    /// <summary>
    /// (CSIDL_RECENT) Recent Items folder
    /// "%APPDATA%\Microsoft\Windows\Recent"
    /// </summary>
    public static readonly Guid Recent = new("{AE50C081-EBD2-438A-8655-8A092E34987A}");

    /// <summary>
    /// (CSIDL_BITBUCKET) Recycle Bin virtual folder
    /// </summary>
    public static readonly Guid RecycleBinFolder = new("{B7534046-3ECB-4C18-BE4E-64CD4CB7D6AC}");

    /// <summary>
    /// (CSIDL_RESOURCES) Resources fixed folder
    /// "%windir%\Resources"
    /// </summary>
    public static readonly Guid ResourceDir = new("{8AD10C31-2ADB-4296-A8F7-E4701232C972}");

    /// <summary>
    /// (CSIDL_APPDATA) Roaming user application data folder
    /// "%APPDATA%" ("%USERPROFILE%\AppData\Roaming")
    /// </summary>
    public static readonly Guid RoamingAppData = new("{3EB685DB-65F9-4CF6-A03A-E3EF65729F3D}");

    /// <summary>
    /// (CSIDL_SENDTO) SendTo folder
    /// "%APPDATA%\Microsoft\Windows\SendTo"
    /// </summary>
    public static readonly Guid SendTo = new("{8983036C-27C0-404B-8F08-102D10DCFD74}");

    /// <summary>
    /// (CSIDL_STARTMENU) Start Menu folder
    /// "%APPDATA%\Microsoft\Windows\Start Menu"
    /// </summary>
    public static readonly Guid StartMenu = new("{625B53C3-AB48-4EC1-BA1F-A1EF4146FC19}");

    /// <summary>
    /// (CSIDL_STARTUP, CSIDL_ALTSTARTUP) Startup folder
    /// "%APPDATA%\Microsoft\Windows\Start Menu\Programs\StartUp"
    /// </summary>
    public static readonly Guid Startup = new("{B97D20BB-F46A-4C97-BA10-5E3608430854}");

    /// <summary>
    /// (CSIDL_SYSTEMX86) X86 System32 folder
    /// "%windir%\system32" or "%windir%\syswow64"
    /// </summary>
    public static readonly Guid SystemX86 = new("{D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27}");

    /// <summary>
    /// (CSIDL_TEMPLATES) Templates folder
    /// "%APPDATA%\Microsoft\Windows\Templates"
    /// </summary>
    public static readonly Guid Templates = new("{A63293E8-664E-48DB-A079-DF759E0509F7}");

    /// <summary>
    /// (CSIDL_MYVIDEO) Videos folder
    /// "%USERPROFILE%\Videos"
    /// </summary>
    public static readonly Guid Videos = new("{18989B1D-99B5-455B-841C-AB7C74E4DDFC}");

    /// <summary>
    /// (CSIDL_WINDOWS) Windows folder "%windir%"
    /// </summary>
    public static readonly Guid Windows = new("{F38BF404-1D43-42F2-9305-67DE0B28FC23}");
}
