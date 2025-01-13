using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.ManagedTools;
using System;

namespace Hi3Helper.Win32.TaskbarListCOM
{
    public class TaskbarList
    {
        private readonly ITaskbarList3? m_taskbarList;

        public TaskbarList()
        {
            try
            {
                ComMarshal.CreateInstance(new Guid(CLSIDGuid.CLSID_TaskbarList),
                                          0,
                                          CLSCTX.CLSCTX_INPROC_SERVER,
                                          out ITaskbarList3? taskbarList).ThrowOnFailure();
                m_taskbarList = taskbarList;
            }
            catch (Exception)
            {
                // ignore
            }
        }

        ~TaskbarList()
        {
            if (m_taskbarList != null)
            {
                ComMarshal.FreeInstance(m_taskbarList);
            }
        }

        public int SetProgressState(nint hwnd, TaskbarState state)
        {
            try
            {
                return m_taskbarList?.SetProgressState(hwnd, state) ?? 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int SetProgressValue(nint hwnd, ulong ullCompleted, ulong ullTotal)
        {
            try
            {
                return m_taskbarList?.SetProgressValue(hwnd, ullCompleted, ullTotal) ?? 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
