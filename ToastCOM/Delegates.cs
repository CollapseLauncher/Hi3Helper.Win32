using System.Collections.Generic;

namespace Hi3Helper.Win32.ToastCOM
{
    public delegate void ToastAction(string app, string arg, List<KeyValuePair<string, string?>> kvs);
}
