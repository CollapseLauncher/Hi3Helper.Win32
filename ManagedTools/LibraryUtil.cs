using Hi3Helper.Win32.Native.LibraryImport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

#pragma warning disable IDE0130

namespace Hi3Helper.Win32.ManagedTools;

public static class LibraryUtil
{
    private static readonly Dictionary<string, nint> UserDefinedDllSearchKvp = [];

    public static Dictionary<string, nint>.KeyCollection UserDefinedDllSearchDirectories
    {
        get => UserDefinedDllSearchKvp.Keys;
    }

    public static bool TryAddUserDllSearchDirectory(
        string?  directoryPath,
        out nint cookieP)
    {
        Unsafe.SkipInit(out cookieP);
        if (string.IsNullOrEmpty(directoryPath) ||
            !Directory.Exists(directoryPath))
        {
            return false;
        }

        string key = GetNormalizedDirPath(directoryPath);
        if (UserDefinedDllSearchKvp.TryGetValue(key, out cookieP))
        {
            return true; // Already exist.
        }

        nint cookie = PInvoke.AddDllDirectory(key);
        if (cookie == nint.Zero)
        {
            return false;
        }

        cookieP = cookie;
        UserDefinedDllSearchKvp.TryAdd(key, cookie);
        return true;
    }

    public static bool TryRemoveUserDllSearchDirectory(
        string? directoryPath)
    {
        if (string.IsNullOrEmpty(directoryPath))
        {
            return false;
        }

        string key = GetNormalizedDirPath(directoryPath);
        return UserDefinedDllSearchKvp.Remove(key, out nint cookieP) &&
               TryRemoveUserDllSearchDirectory(cookieP);
    }

    public static bool TryRemoveUserDllSearchDirectory(nint cookieP)
        => PInvoke.RemoveDllDirectory(cookieP);

    private static string GetNormalizedDirPath(ReadOnlySpan<char> directoryPath)
    {
        ReadOnlySpan<char> key           = directoryPath.TrimEnd("\\/");
        Span<char>         normalizedKey = stackalloc char[directoryPath.Length];
        key.Replace(normalizedKey, '/', '\\');

        if (Path.IsPathFullyQualified(normalizedKey))
        {
            return normalizedKey.ToString();
        }

        // Try to normalize path if not qualified.
        ReadOnlySpan<char> pathKey           = normalizedKey;
        string             currentWorkingDir = Directory.GetCurrentDirectory();
        if (normalizedKey.StartsWith('\\')) // Root absolute path
        {
            ReadOnlySpan<char> rootDrive = Path.GetPathRoot(currentWorkingDir);
            pathKey = Path.Join(rootDrive, pathKey);
        }
        else // Join relative path
        {
            pathKey = Path.Join(currentWorkingDir, pathKey);
        }

        return pathKey.ToString();
    }
}
