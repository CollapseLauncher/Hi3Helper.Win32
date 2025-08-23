using System;
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global

namespace Hi3Helper.Win32.Native.Enums
{
    [Flags]
    public enum MiniDumpType
    {
        Normal                         = 0x00000000, // Basic dump with limited information
        WithDataSegs                   = 0x00000080, // Includes global variables
        WithFullMemory                 = 0x00000002, // Includes all accessible memory
        WithHandleData                 = 0x00000004, // Includes handle data
        FilterMemory                   = 0x00000008, // Filters memory data to reduce size
        ScanMemory                     = 0x00000001, // Scans memory for relevant data
        WithUnloadedModules            = 0x00000020, // Includes unloaded modules
        WithIndirectlyReferencedMemory = 0x00000040, // Includes memory referenced by stack/registers
        FilterModulePaths              = 0x00020000, // Removes module paths to reduce size
        WithProcessThreadData          = 0x01000000, // Includes thread state information
        WithFullAuxiliaryState         = 0x02000000, // Includes auxiliary state data
        WithThreadInfo                 = 0x00000010, // Includes additional thread information
        WithPrivateReadWriteMemory     = 0x00000100  // Includes private read/write memory
    }
}