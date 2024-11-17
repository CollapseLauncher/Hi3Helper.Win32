using Hi3Helper.Win32.Native.Structs;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.Native
{
    public static partial class PInvoke
    {
        public static void MoveFileToRecycleBin(IList<string> filePaths)
        {
            uint FO_DELETE = 0x0003;
            ushort FOF_ALLOWUNDO = 0x0040;
            ushort FOF_NOCONFIRMATION = 0x0010;

            var concat = string.Join('\0', filePaths) + '\0' + '\0';

            SHFILEOPSTRUCTW fileOp = new SHFILEOPSTRUCTW
            {
                wFunc = FO_DELETE,
                pFrom = concat,
                fFlags = (ushort)(FOF_ALLOWUNDO | FOF_NOCONFIRMATION)
            };

            int sizeOf = Marshal.SizeOf<SHFILEOPSTRUCTW>() + concat.Length;
            nint ptrBuffer = Marshal.AllocCoTaskMem(sizeOf);

            try
            {
                Marshal.StructureToPtr(fileOp, ptrBuffer, false);
                SHFileOperation(ptrBuffer);
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptrBuffer);
            }
        }
    }
}
