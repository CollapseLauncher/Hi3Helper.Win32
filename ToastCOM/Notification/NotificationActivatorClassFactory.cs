using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using static Hi3Helper.Win32.ToastCOM.Notification.DesktopNotificationManagerCompat;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    [GeneratedComClass]
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

        // [DllImport("ole32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        // private static extern int CoGetObject(
        //     string pszName,
        //     [In] ref BIND_OPTS3 pBindOptions,
        //     ref Guid riid,
        //     [MarshalAs(UnmanagedType.Interface)] out object ppv);

        // Constants
        // private const uint CLSCTX_LOCAL_SERVER = 0x4;
        // private const int S_OK = 0;
        // private const int E_FAIL = unchecked((int)0x80004005);

        // private static int CoCreateInstanceAsAdmin(IntPtr hwnd, Guid rclsid, Guid riid, out nint ppvObject)
        // {
        //     ppvObject = nint.Zero;
        //
        //     // Prepare moniker name
        //     char[] wszMonikerName = new char[300];
        //     string format = "Elevation:Administrator!new:{0}";
        //     string clsidString = rclsid.ToString();
        //     string monikerFormatted = string.Format(format, clsidString);
        //
        //     // Initialize BIND_OPTS3 structure
        //     var bindOpts = new BIND_OPTS3
        //     {
        //         cbStruct = (uint)Marshal.SizeOf<BIND_OPTS3>(),
        //         hwnd = hwnd,
        //         dwClassContext = CLSCTX_LOCAL_SERVER
        //     };
        //
        //     // Call CoGetObject
        //     int hr = CoGetObject(monikerFormatted, ref bindOpts, ref riid, out object ppv);
        //     return hr;
        // }

        public int LockServer([MarshalAs(UnmanagedType.VariantBool)] in bool fLock)
        {
            return 0;
        }
    }
}
