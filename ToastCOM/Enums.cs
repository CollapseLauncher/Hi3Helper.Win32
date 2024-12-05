namespace Hi3Helper.Win32.ToastCOM
{
    public enum ToastActivationType
    {
        Foreground,
        Background,
        Protocol
    }

    public enum ToastAfterActivationBehavior
    {
        Default,
        PendingUpdate
    }

    public enum ToastButtonStyle
    {
        Success,
        Critical
    }

    public enum ToastDuration
    {
        Long,
        Short
    }

    public enum ToastScenario
    {
        Reminder,
        Alarm,
        IncomingCall,
        Urgent
    }
}
