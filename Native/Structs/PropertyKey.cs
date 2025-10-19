using System;
using System.Runtime.InteropServices;
// ReSharper disable IdentifierTypo

namespace Hi3Helper.Win32.Native.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PropertyKey
    {
        public Guid  formatId;
        public nuint pid;

        public static PropertyKey PkeyAppUserModelID
        {
            get
            {
                return new PropertyKey
                {
                    formatId = Guid.ParseExact("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}", "B"),
                    pid = new nuint(5)
                };
            }
        }

        public static PropertyKey PkeyAppUserModelToastActivatorClsid
        {
            get
            {
                return new PropertyKey
                {
                    formatId = Guid.ParseExact("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}", "B"),
                    pid = new nuint(26)
                };
            }
        }
    }
}
