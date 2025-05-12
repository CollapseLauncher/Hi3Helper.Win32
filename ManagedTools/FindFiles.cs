using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.LibraryImport;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.IO;
using System.Runtime.InteropServices;
// ReSharper disable CommentTypo
// ReSharper disable GrammarMistakeInComment

namespace Hi3Helper.Win32.ManagedTools
{
    public static class FindFiles
    {
        private const nint InvalidHandle = -1;

        public static uint TryIsDirectoryEmpty(string path, out bool isEmpty)
        {
            uint result = TryGetDirectoryEntryCount(path, out int entryCount, true, true);
            isEmpty = entryCount == 0;
            return result;
        }

        public static unsafe uint TryGetDirectoryEntryCount(string path, out int entryCount, bool onlyCheckIsEmpty = false, bool includeInSymbolicLink = false, string searchPattern = "*")
        {
            entryCount = 0;
            ArgumentException.ThrowIfNullOrEmpty(path);

            // Check if the directory doesn't exist, return STG_E_PATHNOTFOUND.
            if (!Directory.Exists(path))
            {
                return 0x80030003; // STG_E_PATHNOTFOUND
            }

            // Check if the path is a valid absolute path. If not, return STG_E_PATHNOTFOUND.
            string? root = Path.GetPathRoot(path);
            if (string.IsNullOrEmpty(root))
            {
                return 0x80030003; // STG_E_PATHNOTFOUND
            }

            // Initialize enumerate struct
            Span<byte> findDataBuffer = stackalloc byte[sizeof(WIN32_FIND_DATA)];
            fixed (byte* bytes = &MemoryMarshal.GetReference(findDataBuffer))
            {
                WIN32_FIND_DATA* findData = (WIN32_FIND_DATA*)bytes;

                // Set the searching flags. By default, the symbolic link search is enabled.
                // This time, we will set the flag for any files that's available on disk only, physically.
                FINDEX_FLAGS indexFlags = FINDEX_FLAGS.FIND_FIRST_EX_LARGE_FETCH;
                if (!includeInSymbolicLink)
                {
                    indexFlags |= FINDEX_FLAGS.FIND_FIRST_EX_ON_DISK_ENTRIES_ONLY;
                }

                // Initialize the search pattern and find handle.
                string findUncPath = @"\\?\" + path.TrimEnd('\\') + Path.DirectorySeparatorChar + searchPattern;
                nint findHandle = PInvoke.FindFirstFileEx(findUncPath,
                                                          FINDEX_INFO_LEVELS.FindExInfoBasic,
                                                          findData,
                                                          FINDEX_SEARCH_OPS.FindExSearchLimitToDirectories,
                                                          null,
                                                          indexFlags);

                // Return if handle is invalid or null.
                if (findHandle == InvalidHandle || findHandle == nint.Zero)
                {
                    // If the handle is invalid, return HR Error.
                    return unchecked((uint)Marshal.GetHRForLastWin32Error());
                }

                try
                {
                    // Starts enumerate the directory.
                    bool isEmpty = true;
                    do
                    {
                        // If the file name starts with '.' or '..', skip it.
                        if (findData->cFileName[0] == '.' || findData->cFileName[1] == '.' || findData->cFileName[0] == '\0')
                        {
                            continue;
                        }

                        isEmpty = false;
                        ++entryCount;
                    }
                    while ((isEmpty || !onlyCheckIsEmpty) && PInvoke.FindNextFile(findHandle, findData));
                }
                finally
                {
                    // Close the handle.
                    PInvoke.FindClose(findHandle);
                }

                return 0;
            }
        }
    }
}
