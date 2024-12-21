using Hi3Helper.Win32.Native.Enums;
using Hi3Helper.Win32.Native.Structs;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Hi3Helper.Win32.Native.LibraryImport.PInvoke;
// ReSharper disable ForCanBeConvertedToForeach

namespace Hi3Helper.Win32.Native.ManagedTools
{
    public static class RecycleBin
    {
        /// <summary>
        /// Moves a list of files to the Recycle Bin.
        /// </summary>
        /// <param name="filePaths">The list of file paths to be moved to the Recycle Bin.</param>
        /// <param name="needConfirmIfCannotRecycleBin">Whether to show a confirmation dialog if the Recycle Bin is not available.</param>
        public static void MoveFileToRecycleBin(List<string> filePaths, bool needConfirmIfCannotRecycleBin = false) =>
            MoveFileToRecycleBin(CollectionsMarshal.AsSpan(filePaths), needConfirmIfCannotRecycleBin);

        /// <summary>
        /// Moves a span of file paths to the Recycle Bin.
        /// </summary>
        /// <param name="filePathSpan">The span of file paths to be moved to the Recycle Bin.</param>
        /// <param name="needConfirmIfCannotRecycleBin">Whether to show a confirmation dialog if the Recycle Bin is not available.</param>
        public static unsafe void MoveFileToRecycleBin(ReadOnlySpan<string> filePathSpan, bool needConfirmIfCannotRecycleBin = false)
        {
            // Define the type of file operation to be performed (delete in this case)
            // and flags for the file operation (allow undo and no confirmation)
            FileFuncFlags funcType = FileFuncFlags.FO_DELETE;
            FILEOP_FLAGS  flags    = FILEOP_FLAGS.FOF_ALLOWUNDO | FILEOP_FLAGS.FOF_NOCONFIRMATION;

            // If the operation requires confirmation when the Recycle Bin is not available
            if (needConfirmIfCannotRecycleBin)
                flags |= FILEOP_FLAGS.FOF_WANTNUKEWARNING;

            // Calculate the length of the buffer needed to store the concatenated file paths
            // and SHFILEOPSTRUCTW_UNSAFE structure
            int concatBufLen = GetConcatBufferLength(filePathSpan);
            int structBufLen = Marshal.SizeOf<SHFILEOPSTRUCTW_UNSAFE>();

            // Rent a buffer from the shared array pool
            char[] concatBuf = GC.AllocateUninitializedArray<char>(concatBufLen);
            byte[] structBuf = ArrayPool<byte>.Shared.Rent(structBufLen);

            try
            {
                // Write the list of file paths to the concatenated buffer
                WriteFileListToConcatBuffer(filePathSpan, concatBuf);

                // Get a pointer to the rented buffer and cast it to SHFILEOPSTRUCTW_UNSAFE
                SHFILEOPSTRUCTW_UNSAFE* fileOpUnsafe = (SHFILEOPSTRUCTW_UNSAFE*)Marshal.UnsafeAddrOfPinnedArrayElement(structBuf, 0);

                // Set the file operation parameters
                fileOpUnsafe->wFunc  = funcType;
                fileOpUnsafe->fFlags = flags;
                fileOpUnsafe->pFrom  = Marshal.UnsafeAddrOfPinnedArrayElement(concatBuf, 0);

                // Perform the file operation
                int result = SHFileOperation((nint)fileOpUnsafe);

                // If the operation was cancelled, throw cancellation exception
                if (result == 0x75 || result == 0x4c7)
                    throw new OperationCanceledException("Operation was cancelled by the user");

                // Otherwise, throw other Win32 exception
                if (result != 0)
                    throw new Win32Exception(result);
            }
            finally
            {
                // Return the rented buffers
                ArrayPool<char>.Shared.Return(concatBuf);
                ArrayPool<byte>.Shared.Return(structBuf);
            }
        }

        /// <summary>
        /// Writes the list of file paths to a concatenated buffer.
        /// </summary>
        /// <param name="filePathSpan">The span of file paths to be written to the buffer.</param>
        /// <param name="concatBuf">The buffer to write the concatenated file paths to.</param>
        private static void WriteFileListToConcatBuffer(ReadOnlySpan<string> filePathSpan, Span<char> concatBuf)
        {
            int offset = 0;
            int pos    = 0;

            // Start write operation
            StartWrite:
            // If it's already EOD, write another null terminator and return
            if (filePathSpan.Length == pos)
            {
                concatBuf[offset] = '\0';
                return;
            }

            // Copy the file path to the buffer and move the offset
            int charLen = filePathSpan[pos].Length;
            filePathSpan[pos++].CopyTo(concatBuf[offset..]);
            offset            += charLen;
            concatBuf[offset++] =  '\0';
            goto StartWrite;
        }

        /// <summary>
        /// Gets the length of the buffer required to store the concatenated file paths.
        /// </summary>
        /// <param name="filePathSpan">The span of file paths.</param>
        /// <returns>The length of the buffer required.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetConcatBufferLength(ReadOnlySpan<string> filePathSpan)
        {
            // Calculate the length of the buffer required to store the concatenated file paths
            int length = 0;
            for (int i = 0; i < filePathSpan.Length; i++)
            {
                length += filePathSpan[i].Length + 1; // Add 1 for the null terminator
            }
            
            // Add 2 for the double null terminator as per Unicode character
            // Plus, round the length to the power of 2
            return (int)BitOperations.RoundUpToPowerOf2((uint)length + 2);
        }
    }
}
