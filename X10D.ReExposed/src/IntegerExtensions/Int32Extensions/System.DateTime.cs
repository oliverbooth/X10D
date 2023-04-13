namespace X10D.ReExposed.IntegerExtensions.Int32Extensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class Int32Extensions
{
    /// <inheritdoc cref="DateTime.DaysInMonth(int,int)"/>
    public static int DaysInMonth(this int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }

    /// <inheritdoc cref="DateTime.IsLeapYear(int)"/>
    public static bool IsLeapYear(this int year)
    {
        return DateTime.IsLeapYear(year);
    }
}