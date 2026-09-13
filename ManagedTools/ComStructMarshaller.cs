using System;
using System.Runtime.InteropServices.Marshalling;

namespace Hi3Helper.Win32.ManagedTools;

[CustomMarshaller(typeof(CustomMarshallerAttribute.GenericPlaceholder),
                  MarshalMode.Default,
                  typeof(TypedComVariantMarshaller<>))]
[CustomMarshaller(typeof(CustomMarshallerAttribute.GenericPlaceholder),
                  MarshalMode.UnmanagedToManagedRef,
                  typeof(TypedComVariantMarshaller<>.TypedComVariantRefMarshaller))]
public static class TypedComVariantMarshaller<T>
{
    public static ComVariant ConvertToUnmanaged(T managed) =>
        ComVariantMarshaller.ConvertToUnmanaged(managed);

    public static T ConvertToManaged(ComVariant unmanaged) =>
        Cast(ComVariantMarshaller.ConvertToManaged(unmanaged));

    public static void Free(ComVariant unmanaged) =>
        ComVariantMarshaller.Free(unmanaged);

    internal static T Cast(object? value)
    {
        return value switch
        {
            T typed                      => typed,
            null when default(T) is null => default!,
            _ => throw new InvalidCastException($"VARIANT contains {value?.GetType().FullName ?? "null"}, " +
                                                $"not {typeof(T).FullName}.")
        };
    }

    public struct TypedComVariantRefMarshaller
    {
        private ComVariantMarshaller.RefPropagate _inner;

        public void FromManaged(T managed) =>
            _inner.FromManaged(managed);

        public void FromUnmanaged(ComVariant unmanaged) =>
            _inner.FromUnmanaged(unmanaged);

        public T ToManaged() => Cast(_inner.ToManaged());

        public ComVariant ToUnmanaged() =>
            _inner.ToUnmanaged();

        public void Free() =>
            _inner.Free();
    }
}
