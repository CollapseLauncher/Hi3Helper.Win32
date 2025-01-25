using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable UnusedParameter.Local
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable ForCanBeConvertedToForeach

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    public unsafe partial class NotificationUserInput : IReadOnlyDictionary<string?, string?>
    {
        #region Properties
        private readonly nint[] _data;

        internal NotificationUserInput(byte* dataPtr, uint dataCount, ILogger? logger = null)
        {
            if (dataPtr == null)
            {
                _data = [];
                return;
            }

#if DEBUG
            logger?.LogDebug($"[NotificationUserInput::Ctor] Getting input data from address: 0x{(nint)dataPtr:x8} with data count: {dataCount}");
#endif

            _data = new nint[dataCount];

            int sizeOfStruct = sizeof(NOTIFICATION_USER_INPUT_DATA);
            byte* curPos = dataPtr;

            for (int i = 0; i < dataCount; i++)
            {
                _data[i] = (nint)curPos;
                curPos += sizeOfStruct;
            }
        }

        public string? this[string? key]
        {
            get
            {
                for (int i = 0; i < _data.Length; i++)
                {
                    ref NOTIFICATION_USER_INPUT_DATA ptr    = ref GetRef<NOTIFICATION_USER_INPUT_DATA>(_data[i]);
                    string?                          keyM   = Marshal.PtrToStringUni(ptr.Key);
                    string?                          valueM = Marshal.PtrToStringUni(ptr.Value);

                    if (key == keyM)
                    {
                        return valueM;
                    }
                }
                return null;
            }
        }

        private static ref T GetRef<T>(nint ptr)
            where T : unmanaged => ref Unsafe.AsRef<T>((void*)ptr);

        public IEnumerable<string?> Keys
        {
            get
            {
                for (int i = 0; i < _data.Length; i++)
                {
                    ref NOTIFICATION_USER_INPUT_DATA ptr  = ref GetRef<NOTIFICATION_USER_INPUT_DATA>(_data[i]);
                    string?                          keyM = Marshal.PtrToStringUni(ptr.Key);
                    yield return keyM;
                }
            }
        }

        public IEnumerable<string?> Values
        {
            get
            {
                for (int i = 0; i < _data.Length; i++)
                {
                    ref NOTIFICATION_USER_INPUT_DATA ptr    = ref GetRef<NOTIFICATION_USER_INPUT_DATA>(_data[i]);
                    string?                          valueM = Marshal.PtrToStringUni(ptr.Value);
                    yield return valueM;
                }
            }
        }

        private static KeyValuePair<string?, string?> GetDataKeyAndValue(nint curPtr)
        {
            ref NOTIFICATION_USER_INPUT_DATA ptr    = ref GetRef<NOTIFICATION_USER_INPUT_DATA>(curPtr);
            string?                          keyM   = Marshal.PtrToStringUni(ptr.Key);
            string?                          valueM = Marshal.PtrToStringUni(ptr.Value);

            return new KeyValuePair<string?, string?>(keyM, valueM);
        }

        private static string? GetDataKey(nint curPtr)
        {
            ref NOTIFICATION_USER_INPUT_DATA ptr  = ref GetRef<NOTIFICATION_USER_INPUT_DATA>(curPtr);
            string?                          keyM = Marshal.PtrToStringUni(ptr.Key);

            return keyM;
        }

        private static string? GetDataValue(nint curPtr)
        {
            ref NOTIFICATION_USER_INPUT_DATA ptr    = ref GetRef<NOTIFICATION_USER_INPUT_DATA>(curPtr);
            string?                          valueM = Marshal.PtrToStringUni(ptr.Value);

            return valueM;
        }

        public int Count => _data.Length;
        #endregion

        #region Methods
        public bool ContainsKey(string? key)
        {
            return _data.Any(i => GetDataKey(i) == key);
        }

        public IEnumerator<KeyValuePair<string?, string?>> GetEnumerator()
        {
            return _data.Select(GetDataKeyAndValue).GetEnumerator();
        }

        public bool TryGetValue(string? key, out string? value)
        {
            foreach (var item in _data)
            {
                if (GetDataKey(item) != key)
                {
                    continue;
                }

                value = GetDataValue(item);
                return true;
            }

            value = null;
            return false;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
