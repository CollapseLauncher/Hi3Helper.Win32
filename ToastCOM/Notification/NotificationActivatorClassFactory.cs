using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    [GeneratedComClass]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class NotificationActivatorClassFactory : IClassFactory
    {
        private NotificationActivator? Instance;

        public void UseExistingInstance(NotificationActivator instance)
        {
            Instance = instance;
        }

        public unsafe int CreateInstance(nint pUnkOuter, in Guid riid, out nint ppvObject)
        {
            ppvObject = nint.Zero;

            try
            {
                // For now no aggregation support - could do Marshal.CreateAggregatedObject?
                if (pUnkOuter != nint.Zero)
                {
                    return 1;
                }

                if (riid == IIDGuid.Guid_IClassFactory)
                {
                    ppvObject = (nint)ComInterfaceMarshaller<NotificationActivator>.ConvertToUnmanaged(Instance);
                }
                else
                {
                    ppvObject = (nint)ComInterfaceMarshaller<NotificationActivator>.ConvertToUnmanaged(Instance);
                    int hrQI = Marshal.QueryInterface(ppvObject, in riid, out ppvObject);
                    if (hrQI != 0)
                    {
                        return 2;
                    }
                }
#if DEBUG
                Instance?._logger?.LogDebug($"[NotificationActivatorClassFactory::CreateInstance] NotificationActivator has been created successfully! (pUnkOuter: 0x{pUnkOuter:x8} riid: {riid} ppvObject: 0x{ppvObject:x8})");
#endif
                return 0;
            }
            finally
            {
                ComInterfaceMarshaller<NotificationService>.Free((void*)ppvObject);
            }
        }

        public int LockServer([MarshalAs(UnmanagedType.VariantBool)] in bool fLock)
        {
            return 0;
        }
    }
}
