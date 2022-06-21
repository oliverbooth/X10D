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
    public static void Clear(this DirectoryInfo directory)
    {
        directory.Clear(false);
    }

    /// <summary>
    ///     Removes all files and subdirectories in this directory, recursively, without deleting this directory.
    /// </summary>
    /// <param name="directory">The directory to clear.</param>
    /// <param name="throwOnError">
    ///     <see langword="true" /> to throw any exceptions which were caught during the operation; otherwise,
    ///     <see langword="false." />
    /// </param>
    /// <exception cref="DirectoryNotFoundException">
    ///     The directory described by this <see cref="DirectoryInfo" /> object does not exist or could not be found. This
    ///     exception is not thrown if <paramref name="throwOnError" /> is <see langword="false" />.
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
    ///     This exception is not thrown if <paramref name="throwOnError" /> is <see langword="false" />.
    /// </exception>
    /// <exception cref="SecurityException">
    ///     The caller does not have the required permission. This exception is not thrown if <paramref name="throwOnError" /> is
    ///     <see langword="false" />.
    /// </exception>
    /// <exception cref="UnauthorizedAccessException">This directory or one of its children contain a read-only file. This
    ///     exception is not thrown if <paramref name="throwOnError" /> is <see langword="false" />.
    /// </exception>
    public static void Clear(this DirectoryInfo directory, bool throwOnError)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(directory);
#else
        if (directory is null)
        {
            throw new ArgumentNullException(nameof(directory));
        }
#endif

        if (!directory.Exists)
        {
            if (throwOnError)
            {
                throw new DirectoryNotFoundException();
            }

            return;
        }

        foreach (FileInfo file in directory.EnumerateFiles())
        {
            try
            {
                file.Delete();
            }
            catch when (throwOnError)
            {
                throw;
            }
            catch
            {
                // do nothing
            }
        }

        foreach (DirectoryInfo childDirectory in directory.EnumerateDirectories())
        {
            try
            {
                childDirectory.Delete(true);
            }
            catch when (throwOnError)
            {
                throw;
            }
            catch
            {
                // do nothing
            }
        }
    }
}
