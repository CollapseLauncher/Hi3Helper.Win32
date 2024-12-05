using System.Collections.Generic;

namespace Hi3Helper.Win32.ToastCOM
{
    public delegate void ToastCallback(string app, string arg, Dictionary<string, string?>? userInputData);
}
