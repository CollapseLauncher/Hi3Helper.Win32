using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    public unsafe partial class NotificationUserInput : IReadOnlyDictionary<string, string?>
    {
        #region Properties
        private NOTIFICATION_USER_INPUT_DATA[] _data;

        internal NotificationUserInput(byte* dataPtr, uint dataCount, ILogger? logger = null)
        {
            if (dataPtr == null)
            {
                _data = Array.Empty<NOTIFICATION_USER_INPUT_DATA>();
                return;
            }

#if DEBUG
            logger?.LogDebug($"[NotificationUserInput::Ctor] Getting input data from address: 0x{(nint)dataPtr:x8} with data count: {dataCount}");
#endif

            _data = new NOTIFICATION_USER_INPUT_DATA[dataCount];

            int sizeOfStruct = Marshal.SizeOf<NOTIFICATION_USER_INPUT_DATA>();
            byte* curPos = dataPtr;

            for (int i = 0; i < dataCount; i++)
            {
                _data[i] = Marshal.PtrToStructure<NOTIFICATION_USER_INPUT_DATA>((nint)curPos);
                curPos += sizeOfStruct;
            }
        }

        public string this[string key] => _data.First(i => i.Key == key).Value;

        public IEnumerable<string> Keys => _data.Select(i => i.Key);

        public IEnumerable<string> Values => _data.Select(i => i.Value);

        public int Count => _data is null ? 0 : _data.Length;
        #endregion

        #region Methods
        public bool ContainsKey(string key)
        {
            return _data.Any(i => i.Key == key);
        }

        public IEnumerator<KeyValuePair<string, string?>> GetEnumerator()
        {
            return _data.Select(i => new KeyValuePair<string, string?>(i.Key, i.Value)).GetEnumerator();
        }

        public bool TryGetValue(string key, out string? value)
        {
            foreach (var item in _data)
            {
                if (item.Key == key)
                {
                    value = item.Value;
                    return true;
                }
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
