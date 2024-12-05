using Hi3Helper.Win32.Native.Structs;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    [GeneratedComClass]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class NotificationServiceClassFactory : IClassFactory
    {
        private NotificationService? Instance;

        public void UseExistingInstance(NotificationService instance)
        {
            Instance = instance;
        }

        public unsafe int CreateInstance(nint pUnkOuter, in Guid riid, out nint ppvObject)
        {
            ppvObject = nint.Zero;

            if (pUnkOuter != nint.Zero)
            {
                // For now no aggregation support - could do Marshal.CreateAggregatedObject?
                return 1;
            }
            if (riid == new Guid("00000001-0000-0000-C000-000000000046"))
            {
                ppvObject = (nint)ComInterfaceMarshaller<NotificationService>.ConvertToUnmanaged(Instance);
            }
            else
            {
                ppvObject = (nint)ComInterfaceMarshaller<NotificationService>.ConvertToUnmanaged(Instance);
                int hrQI = Marshal.QueryInterface(ppvObject, in riid, out ppvObject);
                Marshal.Release(ppvObject);
                if (hrQI != 0)
                {
                    return 2;
                }
            }
            return 0;
        }

        public int LockServer([MarshalAs(UnmanagedType.VariantBool)] in bool fLock)
        {
            return 0;
        }
    }
}
