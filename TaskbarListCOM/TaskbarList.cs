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
                if (!ComMarshal<ITaskbarList3>.TryCreateComObject(new Guid(CLSIDGuid.CLSID_TaskbarList),
                                                                  CLSCTX.CLSCTX_INPROC_SERVER,
                                                                  out _taskbarList,
                                                                  out Exception? exception))
                {
                    throw exception;
                }
            }
            catch (Exception)
            {
                // ignore
            }
        }

        ~TaskbarList() => ComMarshal<ITaskbarList3>.TryReleaseComObject(_taskbarList, out _);

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
