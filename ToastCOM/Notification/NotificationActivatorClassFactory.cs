using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    [GeneratedComClass]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class NotificationActivatorClassFactory : IClassFactory
    {
        private NotificationActivator? Instance;
        // ReSharper disable once NotAccessedField.Local
        private bool _asElevatedUser;

        public void UseExistingInstance(NotificationActivator instance, bool asElevatedUser)
        {
            Instance = instance;
            _asElevatedUser = asElevatedUser;
        }

        public unsafe int CreateInstance(nint pUnkOuter, in Guid riid, out nint ppvObject)
        {
            ppvObject = nint.Zero;

            try
            {
                if (pUnkOuter != nint.Zero)
                {
                    return unchecked((int)0x80004002); // Return CLASS_E_NOAGGREGATION
                }

                if (riid == IIDGuid.Guid_IClassFactory)
                {
                    ppvObject = (nint)ComInterfaceMarshaller<NotificationActivator>.ConvertToUnmanaged(Instance);
                }
                else
                {
                    ppvObject = (nint)ComInterfaceMarshaller<NotificationActivator>.ConvertToUnmanaged(Instance);
                    return Marshal.QueryInterface(ppvObject, in riid, out ppvObject);
                }
                return 0;
            }
            finally
            {
                ComInterfaceMarshaller<NotificationService>.Free((void*)ppvObject);
            #if DEBUG
                Instance?._logger?.LogDebug($"[NotificationActivatorClassFactory::CreateInstance] NotificationActivator has been created successfully! (pUnkOuter: 0x{pUnkOuter:x8} riid: {riid} ppvObject: 0x{ppvObject:x8})");
            #endif
            }
        }

        public int LockServer([MarshalAs(UnmanagedType.VariantBool)] in bool fLock)
        {
            return 0;
        }
    }
}
