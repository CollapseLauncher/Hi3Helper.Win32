using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.ManagedTools;

public static class ComMarshal<TComObject>
    where TComObject : class
{
    private static readonly Guid? ObjComIid = typeof(TComObject).GUID;

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
    /// <returns>Returns <see langword="true"/> if the COM Object has been successfully created. Otherwise, <see langword="false"/>.</returns>
    public static unsafe bool TryCreateComObject(
        in Guid classFactoryId,
        nint pIUnknownController,
        CLSCTX classContext,
        in Guid comObjIid,

        [NotNullWhen(true)] out TComObject? comObjResult,
        [NotNullWhen(false)] out Exception? exceptionIfFalse)
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
        HResult resultCreateObj = PInvoke.CoCreateInstance(in classFactoryId,
                                                           pIUnknownController,
                                                           classContext,
                                                           in comObjIid,
                                                           out nint comObjPpv);

        comObjResult = ComInterfaceMarshaller<TComObject>.ConvertToManaged((void*)comObjPpv);
        if (comObjPpv != nint.Zero)
        {
            Marshal.Release(comObjPpv);
        }

        // Get the exception if failed.
        exceptionIfFalse = resultCreateObj.GetException();
        return comObjResult != null && exceptionIfFalse == null;
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
    /// <returns>Returns <see langword="true"/> if the COM Object has been successfully created. Otherwise, <see langword="false"/>.</returns>
    public static bool TryCreateComObject(
        in Guid classFactoryId,
        CLSCTX classContext,
        in Guid comObjIid,

        [NotNullWhen(true)] out TComObject? comObjResult,
        [NotNullWhen(false)] out Exception? exceptionIfFalse)
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
    /// <returns>Returns <see langword="true"/> if the COM Object has been successfully created. Otherwise, <see langword="false"/>.</returns>
    public static bool TryCreateComObject(
        in Guid classFactoryId,
        CLSCTX classContext,

        [NotNullWhen(true)] out TComObject? comObjResult,
        [NotNullWhen(false)] out Exception? exceptionIfFalse)
        => TryCreateComObject(in classFactoryId,
                              classContext,
                              in Nullable.GetValueRefOrDefaultRef(in ObjComIid),
                              out comObjResult,
                              out exceptionIfFalse);



    /// <summary>
    /// Try to cast a COM Object (IUnknown) into another type of COM Object (IUnknown) based on its one derived implementation (or more).
    /// </summary>
    /// <typeparam name="TComCastTo">The type of COM Object (IUnknown) to cast into.</typeparam>
    /// <param name="comObjSource">The COM Object source to be cast into.</param>
    /// <param name="comObjTargetIid">Reference Identifier ID of the target COM Object to cast.</param>
    /// <param name="comObjTarget">The result of the target COM Object.</param>
    /// <param name="exceptionIfFalse">This should be null if the <paramref name="comObjTarget"/> is set.</param>
    /// <returns>Returns <see langword="true"/> if the target COM Object has been successfully created. Otherwise, <see langword="false"/>.</returns>
    public static unsafe bool TryCastComObjectAs<TComCastTo>(
        TComObject comObjSource,
        in Guid comObjTargetIid,

        [NotNullWhen(true)] out TComCastTo? comObjTarget,
        [NotNullWhen(false)] out Exception? exceptionIfFalse)
        where TComCastTo : class
    {
        Unsafe.SkipInit(out comObjTarget);

        nint ppvToCast = (nint)ComInterfaceMarshaller<TComObject>.ConvertToUnmanaged(comObjSource);
        if (ppvToCast == nint.Zero)
        {
            exceptionIfFalse = new COMException($"Cannot get the reference of the object: {typeof(TComObject).Name} as it might not be a COM Object");
            return false;
        }

        HResult hr = Marshal.QueryInterface(ppvToCast, in comObjTargetIid, out nint ppvCasted);
        exceptionIfFalse = hr.GetException();

        if (ppvCasted != nint.Zero)
        {
            comObjTarget = ComInterfaceMarshaller<TComCastTo>.ConvertToManaged((void*)ppvCasted);
            Marshal.Release(ppvCasted);
        }

        if (ppvToCast != nint.Zero)
        {
            Marshal.Release(ppvToCast);
        }

        return comObjTarget != null && exceptionIfFalse == null;
    }

    /// <summary>
    /// Try to cast a COM Object (IUnknown) into another type of COM Object (IUnknown) based on its one derived implementation (or more).
    /// </summary>
    /// <typeparam name="TComCastTo">The type of COM Object (IUnknown) to cast into.</typeparam>
    /// <param name="comObjSource">The COM Object source to be cast into.</param>
    /// <param name="comObjTarget">The result of the target COM Object.</param>
    /// <param name="exceptionIfFalse">This should be null if the <paramref name="comObjTarget"/> is set.</param>
    /// <returns>Returns <see langword="true"/> if the target COM Object has been successfully created. Otherwise, <see langword="false"/>.</returns>
    public static bool TryCastComObjectAs<TComCastTo>(
        TComObject comObjSource,

        [NotNullWhen(true)] out TComCastTo? comObjTarget,
        [NotNullWhen(false)] out Exception? exceptionIfFalse)
        where TComCastTo : class
    {
        Unsafe.SkipInit(out comObjTarget);

        ref readonly Guid comObjTargetIid = ref Nullable.GetValueRefOrDefaultRef(in ComMarshal<TComCastTo>.ObjComIid);
        if (!Unsafe.IsNullRef(in comObjTargetIid))
        {
            return TryCastComObjectAs(comObjSource, in comObjTargetIid, out comObjTarget, out exceptionIfFalse);
        }

        exceptionIfFalse = ThrowNoGuidDefined<TComCastTo>();
        return false;
    }

    /// <summary>
    /// Try to obtain COM Object Interface from a native pointer.
    /// </summary>
    /// <param name="comObjPpv">Pointer of the COM Object Interface which will be obtained from.</param>
    /// <param name="comObjResult">The resulting type <typeparamref name="TComObject"/> of COM Object Interface from the native pointer.</param>
    /// <param name="exceptionIfFalse">Exception if obtaining the COM Object Interface is failing.</param>
    /// <returns>Returns <see langword="true"/> if the target COM Object Interface has been successfully obtained. Otherwise, <see langword="false"/>.</returns>
    public static unsafe bool TryCreateComObjectFromReference(
        nint comObjPpv,

        [NotNullWhen(true)] out  TComObject? comObjResult,
        [NotNullWhen(false)] out Exception?  exceptionIfFalse)
    {
        Unsafe.SkipInit(out comObjResult);
        Unsafe.SkipInit(out exceptionIfFalse);

        // Return null exception if comObjPpv is null
        if (comObjPpv == nint.Zero)
        {
            exceptionIfFalse = new NullReferenceException($"Cannot obtain ComObject of type: {typeof(TComObject)} due to invalid Class factory ID, invalid COM object IID or invalid Class Context");
            return false;
        }

        try
        {
            // Get or Create Object
            comObjResult = ComInterfaceMarshaller<TComObject>.ConvertToManaged((void*)comObjPpv);
        }
        catch (Exception ex)
        {
            exceptionIfFalse = ex;
            return false;
        }

        // Fail-safe: Ensure the object is not null.
        // If null, then back to GetEnsureCreation with ppv set to null.
        // If not, then return true.
        if (comObjResult != null)
        {
            Marshal.Release(comObjPpv);
            return true;
        }

        // Fail-safe: Back to GetEnsureCreation with null ppv.
        comObjPpv = nint.Zero;
        // ReSharper disable once TailRecursiveCall
        return TryCreateComObjectFromReference(comObjPpv, out comObjResult, out exceptionIfFalse);
    }

    private static InvalidCastException ThrowNoGuidDefined<TObjTarget>() => new($"Type of {typeof(TObjTarget).Name} has no Class Identifier ID (IID)");
}
