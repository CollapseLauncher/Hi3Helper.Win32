namespace Hi3Helper.Win32.TaskbarListCOM
{
    public enum TaskbarState
    {
        NoProgress    = 0,
        Indeterminate = 0x1,
        Normal        = 0x2,
        Error         = 0x4,
        Paused        = 0x8
    }
}
