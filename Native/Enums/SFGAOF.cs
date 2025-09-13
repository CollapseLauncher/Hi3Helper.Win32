// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

using System;

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum SFGAOF : uint
    {
        SFGAO_CANCOPY         = 0x00000001,
        SFGAO_CANMOVE         = 0x00000002,
        SFGAO_CANLINK         = 0x00000004,
        SFGAO_STORAGE         = 0x00000008,
        SFGAO_CANRENAME       = 0x00000010,
        SFGAO_CANDELETE       = 0x00000020,
        SFGAO_HASPROPSHEET    = 0x00000040,
        SFGAO_DROPTARGET      = 0x00000100,
        SFGAO_CAPABILITYMASK  = 0x00000177,
        SFGAO_SYSTEM          = 0x00001000,
        SFGAO_ENCRYPTED       = 0x00002000,
        SFGAO_ISSLOW          = 0x00004000,
        SFGAO_GHOSTED         = 0x00008000,
        SFGAO_LINK            = 0x00010000,
        SFGAO_SHARE           = 0x00020000,
        SFGAO_READONLY        = 0x00040000,
        SFGAO_HIDDEN          = 0x00080000,
        SFGAO_DISPLAYATTRMASK = 0x000FC000,
        SFGAO_NONENUMERATED   = 0x00100000,
        SFGAO_NEWCONTENT      = 0x00200000,
        SFGAO_CANMONIKER,
        SFGAO_HASSTORAGE,
        SFGAO_STREAM          = 0x00400000,
        SFGAO_STORAGEANCESTOR = 0x00800000,
        SFGAO_VALIDATE        = 0x01000000,
        SFGAO_REMOVABLE       = 0x02000000,
        SFGAO_COMPRESSED      = 0x04000000,
        SFGAO_BROWSABLE       = 0x08000000,
        SFGAO_FILESYSANCESTOR = 0x10000000,
        SFGAO_FOLDER          = 0x20000000,
        SFGAO_FILESYSTEM      = 0x40000000,
        SFGAO_STORAGECAPMASK  = 0x70C50008,
        SFGAO_HASSUBFOLDER    = 0x80000000,
        SFGAO_CONTENTSMASK    = SFGAO_HASSUBFOLDER,
        SFGAO_PKEYSFGAOMASK   = 0x81044000
    }
}
