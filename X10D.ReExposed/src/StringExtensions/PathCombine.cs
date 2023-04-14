namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="Path.Combine(string,string)"/>
    public static string PathCombine(this string path1, string path2)
    {
        return Path.Combine(path1, path2);
    }

    /// <inheritdoc cref="Path.Combine(string,string,string)"/>
    public static string PathCombine(this string path1, string path2, string path3)
    {
        return Path.Combine(path1, path2, path3);
    }

    /// <inheritdoc cref="Path.Combine(string,string,string,string)"/>
    public static string PathCombine(this string path1, string path2, string path3, string path4)
    {
        return Path.Combine(path1, path2, path3, path4);
    }
}