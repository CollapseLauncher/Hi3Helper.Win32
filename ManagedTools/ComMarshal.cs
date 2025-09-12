﻿using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using static Hi3Helper.Win32.Native.LibraryImport.PInvoke;

namespace Hi3Helper.Win32.ManagedTools
{
    // ReSharper disable once PartialTypeWithSinglePart
    file static class DefaultComWrappersStatic
    {
        public static readonly StrategyBasedComWrappers Default = new();
    }

    public static class ComMarshal<TObjSource>
        where TObjSource : class
    {
        private static readonly Guid? ObjComIid = typeof(TObjSource).GUID;

        /// <summary>
        /// Try to create COM Object based on its Class Factory ID and its Class Identifier ID (IID).
        /// This method utilizes <see cref="StrategyBasedComWrappers"/> to create the COM Object.
        /// </summary>
        /// <param name="classFactoryId">The <see cref="Guid"/> of the Class Factory used to create correspond COM Object based on Class Identifier ID (IID) passed from <paramref name="comObjIid"/>.</param>
        /// <param name="pIUnknownController">The pointer of external IUnknown implementation used to manage the creation of the COM Object. It must be set to <see cref="nint.Zero"/> if you want to use the default IUnknown.</param>
        /// <param name="classContext">
        /// Context in which the code that manages the newly created object will run.<br/>
        /// See more here: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wtypesbase/ne-wtypesbase-clsctx"/>
        /// </param>
        /// <param name="comObjIid">The Class Identifier ID (IID) in which what kind of object to be created. The value in this argument MUST BE the same as its interface's GUID (or at least included from an interface in which implements its derivation).</param>
        /// <param name="comObjResult">The result of a COM Object which has been created.</param>
        /// <param name="exceptionIfFalse">This should be null if the <paramref name="comObjResult"/> is set.</param>
        /// <returns>Returns true if the COM Object has been successfully created. Otherwise, false.</returns>
        public static bool TryCreateComObject(
            in Guid classFactoryId,
            nint    pIUnknownController,
            CLSCTX  classContext,
            in Guid comObjIid,

            [NotNullWhen(true)]
            out  TObjSource? comObjResult,
            [NotNullWhen(false)]
            out Exception?  exceptionIfFalse)
        {
            Unsafe.SkipInit(out comObjResult);

            if (Unsafe.IsNullRef(in classFactoryId))
            {
                exceptionIfFalse = new ArgumentNullException(nameof(classFactoryId), $"{nameof(classFactoryId)} cannot be null!");
                return false;
            }

            if (Unsafe.IsNullRef(in comObjIid))
            {
                exceptionIfFalse = new ArgumentNullException(nameof(comObjIid), $"{nameof(comObjIid)} cannot be null!");
                return false;
            }

            // Note for devs:
            // Running these unmanaged codes are guaranteed to be exception-free.
            // All the errors are handled from HResult so, don't worry about try-catch :D
            int resultCreateObj = CoCreateInstance(in classFactoryId,
                                                   pIUnknownController,
                                                   classContext,
                                                   in comObjIid,
                                                   out nint comObjPpv);

            // Get the exception if failed.
            exceptionIfFalse = Marshal.GetExceptionForHR(resultCreateObj);
            if (exceptionIfFalse != null)
            {
                return false;
            }

            return TryCreateComObjectFromReference(comObjPpv, out comObjResult, out exceptionIfFalse);
        }

        /// <summary>
        /// Try to create COM Object based on its Class Factory ID and its Class Identifier ID (IID).
        /// This method utilizes <see cref="StrategyBasedComWrappers"/> to create the COM Object.
        /// </summary>
        /// <param name="classFactoryId">The <see cref="Guid"/> of the Class Factory used to create correspond COM Object based on Class Identifier ID (IID) passed from <paramref name="comObjIid"/>.</param>
        /// <param name="classContext">
        /// Context in which the code that manages the newly created object will run.<br/>
        /// See more here: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wtypesbase/ne-wtypesbase-clsctx"/>
        /// </param>
        /// <param name="comObjIid">The Class Identifier ID (IID) in which what kind of object to be created. The value in this argument MUST BE the same as its interface's GUID (or at least included from an interface in which implements its derivation).</param>
        /// <param name="comObjResult">The result of a COM Object which has been created.</param>
        /// <param name="exceptionIfFalse">This should be null if the <paramref name="comObjResult"/> is set.</param>
        /// <returns>Returns true if the COM Object has been successfully created. Otherwise, false.</returns>
        public static bool TryCreateComObject(
            in Guid classFactoryId,
            CLSCTX  classContext,
            in Guid comObjIid,

            [NotNullWhen(true)]
            out  TObjSource? comObjResult,
            [NotNullWhen(false)]
            out Exception?  exceptionIfFalse)
            => TryCreateComObject(in classFactoryId,
                                  nint.Zero,
                                  classContext,
                                  in comObjIid,
                                  out comObjResult,
                                  out exceptionIfFalse);

        /// <summary>
        /// Try to create COM Object based on its Class Factory ID and its Class Identifier ID (IID).
        /// This method utilizes <see cref="StrategyBasedComWrappers"/> to create the COM Object.
        /// </summary>
        /// <param name="classFactoryId">The <see cref="Guid"/> of the Class Factory used to create correspond COM Object based on its Class Identifier ID (IID).</param>
        /// <param name="classContext">
        /// Context in which the code that manages the newly created object will run.<br/>
        /// See more here: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wtypesbase/ne-wtypesbase-clsctx"/>
        /// </param>
        /// <param name="comObjResult">The result of a COM Object which has been created.</param>
        /// <param name="exceptionIfFalse">This should be null if the <paramref name="comObjResult"/> is set.</param>
        /// <returns>Returns true if the COM Object has been successfully created. Otherwise, false.</returns>
        public static bool TryCreateComObject(
            in Guid classFactoryId,
            CLSCTX  classContext,

            [NotNullWhen(true)]
            out  TObjSource? comObjResult,
            [NotNullWhen(false)]
            out Exception?  exceptionIfFalse)
            => TryCreateComObject(in classFactoryId,
                                  classContext,
                                  in Nullable.GetValueRefOrDefaultRef(in ObjComIid),
                                  out comObjResult,
                                  out exceptionIfFalse);

        /// <summary>
        /// Try to cast a COM Object (IUnknown) into another type of COM Object (IUnknown) based on its one derived implementation (or more).
        /// </summary>
        /// <remarks>
        /// If you happened to keep the <typeparamref name="TObjSource"/> alive and wanted to reuse it in the future, please set <paramref name="isKeepAliveSource"/> to true.<br/>
        /// If <paramref name="isKeepAliveSource"/> set to false (by default), the COM Object reference will be released, untracked and no longer valid,<br/>
        /// causing <see cref="ExecutionEngineException"/> to happen.
        /// </remarks>
        /// <typeparam name="TObjTarget">The type of COM Object (IUnknown) to cast into.</typeparam>
        /// <param name="comObjSource">The COM Object source to be cast into.</param>
        /// <param name="comObjTargetIid">Reference Identifier ID of the target COM Object to cast.</param>
        /// <param name="comObjTarget">The result of the target COM Object.</param>
        /// <param name="exceptionIfFalse">This should be null if the <paramref name="comObjTarget"/> is set.</param>
        /// <param name="isKeepAliveSource">Whether to keep the <typeparamref name="TObjSource"/> alive/valid or not.</param>
        /// <returns>Returns true if the target COM Object has been successfully created. Otherwise, false.</returns>
        public static bool TryCastComObjectAs<TObjTarget>(
            TObjSource comObjSource,
            in Guid    comObjTargetIid,

            [NotNullWhen(true)]
            out  TObjTarget? comObjTarget,
            [NotNullWhen(false)]
            out Exception?  exceptionIfFalse,
            bool isKeepAliveSource = false)
            where TObjTarget : class
        {
            Unsafe.SkipInit(out comObjTarget);

            // Try to get tracked reference of a COM object from existing wrappers via runtime.
            if (!ComWrappers.TryGetComInstance(comObjSource, out nint ppvSource))
            {
                exceptionIfFalse =
                    new InvalidCastException($"Cannot cast this instance of type: {typeof(TObjSource).Name} to {typeof(TObjTarget).Name} as " +
                                             $"the source instance doesn't have COM Object implementation which derive from {typeof(TObjTarget).Name} type.");
                return false;
                /*
                ppvSource = DefaultComWrappersStatic
                           .Default
                           .GetOrCreateComInterfaceForObject(comObjSource, CreateComInterfaceFlags.None);
                */
            }

            // Perform IUnknown::QueryInterface
            int hResultQuery = Marshal.QueryInterface(ppvSource, in comObjTargetIid, out nint ppvTarget);
            // If fails, get the exception from the given HResult
            if ((exceptionIfFalse = Marshal.GetExceptionForHR(hResultQuery)) != null)
            {
                // Fail-safe: Only perform Marshal.Release if ppvTarget is allocated even the HResult returns a failure.
                if (ppvTarget != nint.Zero)
                {
                    Marshal.Release(ppvTarget);
                }

                return false;
            }

            // Note for Devs:
            // If you happened to keep the TObjSource alive and wanted to reuse it in the future, please set isKeepAliveSource to true.
            // If isKeepAliveSource set to false (by default), the COM Object reference will be released, untracked and no longer valid,
            // causing ExecutionEngineException to happen.
            if (!isKeepAliveSource)
            {
                Marshal.Release(ppvSource);
            }

            return ComMarshal<TObjTarget>.TryCreateComObjectFromReference(ppvTarget, out comObjTarget, out exceptionIfFalse);
        }

        /// <summary>
        /// Try to cast a COM Object (IUnknown) into another type of COM Object (IUnknown) based on its one derived implementation (or more).
        /// </summary>
        /// <remarks>
        /// If you happened to keep the <typeparamref name="TObjSource"/> alive and wanted to reuse it in the future, please set <paramref name="isKeepAliveSource"/> to true.<br/>
        /// If <paramref name="isKeepAliveSource"/> set to false (by default), the COM Object reference will be released, untracked and no longer valid,<br/>
        /// causing <see cref="ExecutionEngineException"/> to happen.
        /// </remarks>
        /// <typeparam name="TObjTarget">The type of COM Object (IUnknown) to cast into.</typeparam>
        /// <param name="comObjSource">The COM Object source to be cast into.</param>
        /// <param name="comObjTarget">The result of the target COM Object.</param>
        /// <param name="exceptionIfFalse">This should be null if the <paramref name="comObjTarget"/> is set.</param>
        /// <param name="isKeepAliveSource">Whether to keep the <typeparamref name="TObjSource"/> alive/valid or not.</param>
        /// <returns>Returns true if the target COM Object has been successfully created. Otherwise, false.</returns>
        public static bool TryCastComObjectAs<TObjTarget>(
            TObjSource comObjSource,

            [NotNullWhen(true)]
            out  TObjTarget? comObjTarget,
            [NotNullWhen(false)]
            out Exception?  exceptionIfFalse,
            bool isKeepAliveSource = false)
            where TObjTarget : class
        {
            Unsafe.SkipInit(out comObjTarget);

            ref readonly Guid comObjTargetIid = ref Nullable.GetValueRefOrDefaultRef(in ComMarshal<TObjTarget>.ObjComIid);
            if (!Unsafe.IsNullRef(in comObjTargetIid))
            {
                return TryCastComObjectAs(comObjSource, in comObjTargetIid, out comObjTarget, out exceptionIfFalse);
            }

            exceptionIfFalse = new InvalidCastException($"Type of {typeof(TObjTarget).Name} has no Class Identifier ID (IID)");
            return false;
        }

        /// <summary>
        /// Try to release and invalidate COM Object reference.
        /// </summary>
        /// <param name="comObj">The COM Object to be released/invalidated.</param>
        /// <param name="exceptionIfFalse">Exception if releasing the reference is failing.</param>
        /// <returns>Returns true if the target COM Object has been successfully released/invalidated. Otherwise, false.</returns>
        public static bool TryReleaseComObject(
            TObjSource? comObj,

            [NotNullWhen(false)]
            out Exception?  exceptionIfFalse)
        {
            Unsafe.SkipInit(out exceptionIfFalse);

            if (comObj == null)
            {
                exceptionIfFalse = new ArgumentNullException(nameof(comObj), $"{comObj} cannot be null!");
                return false;
            }

            // Try to get the cached wrapper. If any, directly release the COM Object reference.
            if (ComWrappers.TryGetComInstance(comObj, out nint ppv))
            {
                Marshal.Release(ppv);
                return true;
            }

            // Otherwise, try to free the COM Object from tracked runtime wrapper.
            int hResult = Marshal.ReleaseComObject(comObj);
            // If fails, get the exception from the given HResult
            return (exceptionIfFalse = Marshal.GetExceptionForHR(hResult)) == null;
        }

        private static bool TryCreateComObjectFromReference(
            IntPtr          comObjPpv,
            out TObjSource? comObjResult,
            out Exception?  exceptionIfFalse)
        {
            Unsafe.SkipInit(out comObjResult);
            Unsafe.SkipInit(out exceptionIfFalse);

            GetEnsureCreation:
            // Return null exception if comObjPpv is null
            if (comObjPpv == nint.Zero)
            {
                exceptionIfFalse = new NullReferenceException($"Cannot create ComObject of type: {typeof(TObjSource)} either from invalid Class factory ID, invalid COM object IID or invalid Class Context");
                return false;
            }

            // If the runtime has already cached the wrapped object, use one instead.
            if (ComWrappers.TryGetObject(comObjPpv, out object? cachedWrappedObject))
            {
                Unsafe.SkipInit(out exceptionIfFalse);
                comObjResult = (TObjSource)cachedWrappedObject;
                return true;
            }

            // Get or Create Object
            comObjResult = (TObjSource)DefaultComWrappersStatic
                                      .Default
                                      .GetOrCreateObjectForComInstance(comObjPpv, CreateObjectFlags.Unwrap);

            // Fail-safe: Ensure the object is not null.
            // If null, then back to GetEnsureCreation with ppv set to null.
            // If not, then return true.
            if (!Unsafe.IsNullRef(ref comObjResult))
            {
                return true;
            }

            // Fail-safe: Back to GetEnsureCreation with null ppv.
            comObjPpv = nint.Zero;
            goto GetEnsureCreation;
        }
    }
}
