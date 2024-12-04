using Hi3Helper.Win32.Native.LibraryImport;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.ShellLinkCOM
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PropVariant
    {
        public short variantType;
        public short Reserved1, Reserved2, Reserved3;
        public nint pointerValue;

        public static PropVariant FromString(string str)
        {
            var pv = new PropVariant()
            {
                variantType = 31,  // VT_LPWSTR
                pointerValue = Marshal.StringToCoTaskMemUni(str),
            };

            return pv;
        }

        public static PropVariant FromGuid(Guid guid)
        {
            byte[] bytes = guid.ToByteArray();
            var pv = new PropVariant()
            {
                variantType = 72,  // VT_CLSID
                pointerValue = Marshal.AllocCoTaskMem(bytes.Length),
            };
            Marshal.Copy(bytes, 0, pv.pointerValue, bytes.Length);

            return pv;
        }

        /// <summary>
        /// Called to clear the PropVariant's referenced and local memory.
        /// </summary>
        /// <remarks>
        /// You must call Clear to avoid memory leaks.
        /// </remarks>
        public unsafe void Clear()
        {
            PInvoke.PropVariantClear((PropVariant*)Unsafe.AsPointer(ref this))
                .ThrowOnFailure();
        }
    }
}
