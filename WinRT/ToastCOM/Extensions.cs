using Hi3Helper.Win32.Native.ClassIds;
using System;

namespace Hi3Helper.Win32.WinRT.ToastCOM
{
    public static class Extensions
    {
        public static Guid GetGuidFromString(string str)
            => ClassFactoryClsId.GetGuidFromString(str);
    }
}
