namespace X10D.ReExposed.DecimalExtensions.DecimalExtensions;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class DecimalExtensions
{
    /// <inheritdoc cref="decimal.Add(decimal,decimal)"/>
    public static decimal Add(this decimal value, decimal value2)
    {
        return decimal.Add(value, value2);
    }

    /// <inheritdoc cref="decimal.Ceiling(decimal)"/>
    public static decimal Ceiling(this decimal value)
    {
        return decimal.Ceiling(value);
    }

    /// <inheritdoc cref="decimal.Compare(decimal,decimal)"/>
    public static int Compare(this decimal value, decimal value2)
    {
        return decimal.Compare(value, value2);
    }

    /// <inheritdoc cref="decimal.Divide(decimal,decimal)"/>
    public static decimal Divide(this decimal value, decimal value2)
    {
        return decimal.Divide(value, value2);
    }

    /// <inheritdoc cref="decimal.Floor(decimal)"/>
    public static decimal Floor(this decimal value)
    {
        return decimal.Floor(value);
    }

    /// <inheritdoc cref="decimal.GetBits(decimal)"/>
    public static int[] GetBits(this decimal value)
    {
        return decimal.GetBits(value);
    }

    /// <inheritdoc cref="decimal.GetBits(decimal,Span{int})"/>
    public static int GetBits(this decimal value, Span<int> destination)
    {
        return decimal.GetBits(value, destination);
    }

    /// <inheritdoc cref="decimal.Multiply(decimal,decimal)"/>
    public static decimal Multiply(this decimal value, decimal value2)
    {
        return decimal.Multiply(value, value2);
    }

    /// <inheritdoc cref="decimal.Negate(decimal)"/>
    public static decimal Negate(this decimal value)
    {
        return decimal.Negate(value);
    }

    /// <inheritdoc cref="decimal.Remainder(decimal,decimal)"/>
    public static decimal Remainder(this decimal value, decimal value2)
    {
        return decimal.Remainder(value, value2);
    }

    /// <inheritdoc cref="decimal.Round(decimal)"/>
    public static decimal Round(this decimal value)
    {
        return decimal.Round(value);
    }

    /// <inheritdoc cref="decimal.Round(decimal,MidpointRounding)"/>
    public static decimal Round(this decimal value, MidpointRounding mode)
    {
        return decimal.Round(value, mode);
    }

    /// <inheritdoc cref="decimal.Round(decimal,int)"/>
    public static decimal Round(this decimal value, int digits)
    {
        return decimal.Round(value, digits);
    }

    /// <inheritdoc cref="decimal.Round(decimal,int,MidpointRounding)"/>
    public static decimal Round(this decimal value, int digits, MidpointRounding mode)
    {
        return decimal.Round(value, digits, mode);
    }

    /// <inheritdoc cref="decimal.Add(decimal,decimal)"/>
    public static decimal Subtract(this decimal value, decimal value2)
    {
        return decimal.Subtract(value, value2);
    }

    /// <inheritdoc cref="decimal.ToByte(decimal)"/>
    public static byte ToByte(this decimal value)
    {
        return decimal.ToByte(value);
    }

    /// <inheritdoc cref="decimal.ToDouble(decimal)"/>
    public static double ToDouble(this decimal value)
    {
        return decimal.ToDouble(value);
    }

    /// <inheritdoc cref="decimal.ToInt16(decimal)"/>
    public static short ToInt16(this decimal value)
    {
        return decimal.ToInt16(value);
    }

    /// <inheritdoc cref="decimal.ToInt32(decimal)"/>
    public static int ToInt32(this decimal value)
    {
        return decimal.ToInt32(value);
    }

    /// <inheritdoc cref="decimal.ToInt64(decimal)"/>
    public static long ToInt64(this decimal value)
    {
        return decimal.ToInt64(value);
    }

    /// <inheritdoc cref="decimal.ToOACurrency(decimal)"/>
    public static long ToOACurrency(this decimal value)
    {
        return decimal.ToOACurrency(value);
    }

    /// <inheritdoc cref="decimal.ToSByte(decimal)"/>
    public static sbyte ToSByte(this decimal value)
    {
        return decimal.ToSByte(value);
    }

    /// <inheritdoc cref="decimal.ToSingle(decimal)"/>
    public static float ToSingle(this decimal value)
    {
        return decimal.ToSingle(value);
    }

    /// <inheritdoc cref="decimal.ToUInt16(decimal)"/>
    public static ushort ToUInt16(this decimal value)
    {
        return decimal.ToUInt16(value);
    }

    /// <inheritdoc cref="decimal.ToUInt32(decimal)"/>
    public static uint ToUInt32(this decimal value)
    {
        return decimal.ToUInt32(value);
    }

    /// <inheritdoc cref="decimal.ToUInt64(decimal)"/>
    public static ulong ToUInt64(this decimal value)
    {
        return decimal.ToUInt64(value);
    }

    /// <inheritdoc cref="decimal.Truncate(decimal)"/>
    public static decimal Truncate(this decimal value)
    {
        return decimal.Truncate(value);
    }

    /// <inheritdoc cref="decimal.TryGetBits(decimal,Span{int},out int)"/>
    public static bool TryGetBits(this decimal value, Span<int> destination, out int valuesWritten)
    {
        return decimal.TryGetBits(value, destination, out valuesWritten);
    }
}