namespace Hi3Helper.Win32.Native.Enums
{
    public enum SnapshotFlags : uint
    {
        HeapList = 0x00000001u,
        Process = 0x00000002u,
        Thread = 0x00000004u,
        Module = 0x00000008u,
        Module32 = 0x00000010u,
        Inherit = 0x80000000u,
        All = 0x0000001fu,
        NoHeaps = 0x40000000u
    }
}
