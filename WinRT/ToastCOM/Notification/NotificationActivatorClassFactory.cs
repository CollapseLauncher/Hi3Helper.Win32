#if DEBUG
using Microsoft.Extensions.Logging;
#endif
using Hi3Helper.Win32.Native.ClassIds;
using Hi3Helper.Win32.Native.Interfaces;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable CommentTypo
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable NotAccessedField.Local
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

namespace Hi3Helper.Win32.WinRT.ToastCOM.Notification
{
    [GeneratedComClass]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class NotificationActivatorClassFactory : IClassFactory
    {
        private NotificationActivator? _instance;

        public void UseExistingInstance(NotificationActivator instance)
        {
            _instance = instance;
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

                if (riid == ClassFactoryClsId.GuidIClassFactory)
                {
                    ppvObject = (nint)ComInterfaceMarshaller<NotificationActivator>.ConvertToUnmanaged(_instance);
                }
                else
                {
                    ppvObject = (nint)ComInterfaceMarshaller<NotificationActivator>.ConvertToUnmanaged(_instance);
                    return Marshal.QueryInterface(ppvObject, in riid, out ppvObject);
                }
                return 0;
            }
            finally
            {
                ComInterfaceMarshaller<NotificationService>.Free((void*)ppvObject);
            #if DEBUG
                _instance?.Logger?.LogDebug("[NotificationActivatorClassFactory::CreateComObject] NotificationActivator has been created successfully! (pUnkOuter: 0x{pUnkOuter} riid: {riid} ppvObject: {ppvObject})", pUnkOuter, riid, ppvObject);
            #endif
            }
        }

        public int LockServer([MarshalAs(UnmanagedType.VariantBool)] in bool fLock)
        {
            return 0;
        }
    }
}
