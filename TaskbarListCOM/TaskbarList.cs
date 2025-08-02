using Hi3Helper.Win32.ManagedTools;
using Hi3Helper.Win32.Native.Enums;
using System;

namespace Hi3Helper.Win32.TaskbarListCOM
{
    public class TaskbarList
    {
        private readonly ITaskbarList3? _taskbarList;

        public TaskbarList()
        {
            try
            {
                ComMarshal.CreateInstance(new Guid(CLSIDGuid.CLSID_TaskbarList),
                                          0,
                                          CLSCTX.CLSCTX_INPROC_SERVER,
                                          out ITaskbarList3? taskbarList).ThrowOnFailure();
                _taskbarList = taskbarList;
            }
            catch (Exception)
            {
                // ignore
            }
        }

        ~TaskbarList()
        {
            if (_taskbarList != null)
            {
                ComMarshal.FreeInstance(_taskbarList);
            }
        }

        public int SetProgressState(nint windowHandle, TaskbarState state)
        {
            try
            {
                return _taskbarList?.SetProgressState(windowHandle, state) ?? 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int SetProgressValue(nint windowHandle, ulong ullCompleted, ulong ullTotal)
        {
            try
            {
                return _taskbarList?.SetProgressValue(windowHandle, ullCompleted, ullTotal) ?? 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
