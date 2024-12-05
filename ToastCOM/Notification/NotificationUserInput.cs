using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Hi3Helper.Win32.ToastCOM.Notification
{
    public class NotificationUserInput : IReadOnlyDictionary<string, string?>, IDisposable
    {
        #region Properties
        private NOTIFICATION_USER_INPUT_DATA[] _data;
        private nint[] _dataPtrs;

        ~NotificationUserInput() => Dispose();

        internal NotificationUserInput(nint[] data)
        {
            if (data == null)
            {
                _dataPtrs = Array.Empty<nint>();
                _data = Array.Empty<NOTIFICATION_USER_INPUT_DATA>();
                return;
            }

            _dataPtrs = data;
            _data = new NOTIFICATION_USER_INPUT_DATA[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                _data[i] = Marshal.PtrToStructure<NOTIFICATION_USER_INPUT_DATA>(data[i]);
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

        public void Dispose()
        {
            for (int i = 0; i < _dataPtrs.Length; i++)
            {
                Marshal.FreeCoTaskMem(_dataPtrs[i]);
            }
        }
        #endregion
    }
}
