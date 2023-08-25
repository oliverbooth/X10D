using System.Security;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="DirectoryInfo" />.
/// </summary>
public static class DirectoryInfoExtensions
{
    /// <summary>
    ///     Removes all files and subdirectories in this directory, recursively, without deleting this directory.
    /// </summary>
    /// <param name="directory">The directory to clear.</param>
    /// <exception cref="DirectoryNotFoundException">
    ///     The directory described by this <see cref="DirectoryInfo" /> object does not exist or could not be found.
    /// </exception>
    /// <exception cref="IOException">
    ///     A target file is open or memory-mapped on a computer running Microsoft Windows NT.
    ///     -or-
    ///     There is an open handle on one of the files, and the operating system is Windows XP or earlier. This open handle can
    ///     result from enumerating directories and files.
    ///     -or-
    ///     The directory is read-only.
    ///     -or-
    ///     The directory contains one or more files or subdirectories and recursive is false.
    ///     -or-
    ///     The directory is the application's current working directory.
    ///     -or-
    ///     There is an open handle on the directory or on one of its files, and the operating system is Windows XP or earlier.
    ///     This open handle can result from enumerating directories and files.
    /// </exception>
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">This directory or one of its children contain a read-only file.</exception>
    public static void Clear(this DirectoryInfo directory)
    {
        if (directory is null)
        {
            throw new ArgumentNullException(nameof(directory));
        }

        if (!directory.Exists)
        {
            throw new DirectoryNotFoundException();
        }

        foreach (FileInfo file in directory.EnumerateFiles())
        {
            file.Delete();
        }

        foreach (DirectoryInfo childDirectory in directory.EnumerateDirectories())
        {
            childDirectory.Delete(true);
        }
    }
}
