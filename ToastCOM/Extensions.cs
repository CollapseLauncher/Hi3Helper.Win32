using System;

namespace Hi3Helper.Win32.ToastCOM
{
    public static class Extensions
    {
        public static Guid GetGuidFromString(string str)
            => ClsidGuid.GetGuidFromString(str);
    }
}
