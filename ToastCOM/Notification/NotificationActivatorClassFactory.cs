﻿#if DEBUG
using Microsoft.Extensions.Logging;
#endif
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
// ReSharper disable CommentTypo
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable NotAccessedField.Local

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    [GeneratedComClass]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class NotificationActivatorClassFactory : IClassFactory
    {
        private NotificationActivator? _instance;
        private bool _asElevatedUser;

        public void UseExistingInstance(NotificationActivator instance, bool asElevatedUser)
        {
            _instance = instance;
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

                if (riid == IidGuid.GuidIClassFactory)
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
                _instance?.Logger?.LogDebug($"[NotificationActivatorClassFactory::CreateInstance] NotificationActivator has been created successfully! (pUnkOuter: 0x{pUnkOuter:x8} riid: {riid} ppvObject: 0x{ppvObject:x8})");
            #endif
            }
        }

        public int LockServer([MarshalAs(UnmanagedType.VariantBool)] in bool fLock)
        {
            return 0;
        }
    }
}
