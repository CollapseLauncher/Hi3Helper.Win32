using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.ManagedTools;
using System;

namespace Hi3Helper.Win32.TaskbarListCOM
{
    public class TaskbarList
    {
        private ITaskbarList3? m_taskbarList;

        public TaskbarList()
        {
            ComMarshal.CreateInstance(new Guid(CLSIDGuid.CLSID_TaskbarList),
                                      0,
                                      CLSCTX.CLSCTX_INPROC_SERVER,
                                      out ITaskbarList3? taskbarList).ThrowOnFailure();
            m_taskbarList = taskbarList;
        }

        ~TaskbarList()
        {
            ComMarshal.FreeInstance(m_taskbarList);
        }

        public int SetProgressState(nint hwnd, TaskbarState state)
        {
            return m_taskbarList!.SetProgressState(hwnd, state);
        }

        public int SetProgressValue(nint hwnd, ulong ullCompleted, ulong ullTotal)
        {
            return m_taskbarList!.SetProgressValue(hwnd, ullCompleted, ullTotal);
        }
    }
}
