namespace X10D.ReExposed.DecimalExtensions.DecimalExtensions;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class DecimalExtensions
{
    /// <inheritdoc cref="decimal.Add(decimal,decimal)"/>
    public static decimal Add(this decimal d1, decimal d2)
    {
        return decimal.Add(d1, d2);
    }

    /// <inheritdoc cref="decimal.Ceiling(decimal)"/>
    public static decimal Ceiling(this decimal d)
    {
        return decimal.Ceiling(d);
    }

    /// <inheritdoc cref="decimal.Compare(decimal,decimal)"/>
    public static int Compare(this decimal d1, decimal d2)
    {
        return decimal.Compare(d1, d2);
    }

    /// <inheritdoc cref="decimal.Divide(decimal,decimal)"/>
    public static decimal Divide(this decimal d1, decimal d2)
    {
        return decimal.Divide(d1, d2);
    }

    /// <inheritdoc cref="decimal.Floor(decimal)"/>
    public static decimal Floor(this decimal d)
    {
        return decimal.Floor(d);
    }

    /// <inheritdoc cref="decimal.GetBits(decimal)"/>
    public static int[] GetBits(this decimal d)
    {
        return decimal.GetBits(d);
    }

    /// <inheritdoc cref="decimal.GetBits(decimal,Span{int})"/>
    public static int GetBits(this decimal d, Span<int> destination)
    {
        return decimal.GetBits(d, destination);
    }

    /// <inheritdoc cref="decimal.Multiply(decimal,decimal)"/>
    public static decimal Multiply(this decimal d1, decimal d2)
    {
        return decimal.Multiply(d1, d2);
    }

    /// <inheritdoc cref="decimal.Negate(decimal)"/>
    public static decimal Negate(this decimal d)
    {
        return decimal.Negate(d);
    }

    /// <inheritdoc cref="decimal.Remainder(decimal,decimal)"/>
    public static decimal Remainder(this decimal d1, decimal d2)
    {
        return decimal.Remainder(d1, d2);
    }

    /// <inheritdoc cref="decimal.Round(decimal)"/>
    public static decimal Round(this decimal d)
    {
        return decimal.Round(d);
    }

    /// <inheritdoc cref="decimal.Round(decimal,MidpointRounding)"/>
    public static decimal Round(this decimal d1, MidpointRounding mode)
    {
        return decimal.Round(d1, mode);
    }

    /// <inheritdoc cref="decimal.Round(decimal,int)"/>
    public static decimal Round(this decimal d, int decimals)
    {
        return decimal.Round(d, decimals);
    }

    /// <inheritdoc cref="decimal.Round(decimal,int,MidpointRounding)"/>
    public static decimal Round(this decimal d, int decimals, MidpointRounding mode)
    {
        return decimal.Round(d, decimals, mode);
    }

    /// <inheritdoc cref="decimal.Add(decimal,decimal)"/>
    public static decimal Subtract(this decimal d1, decimal d2)
    {
        return decimal.Subtract(d1, d2);
    }

    /// <inheritdoc cref="decimal.ToByte(decimal)"/>
    public static byte ToByte(this decimal d)
    {
        return decimal.ToByte(d);
    }

    /// <inheritdoc cref="decimal.ToDouble(decimal)"/>
    public static double ToDouble(this decimal d)
    {
        return decimal.ToDouble(d);
    }

    /// <inheritdoc cref="decimal.ToInt16(decimal)"/>
    public static short ToInt16(this decimal d)
    {
        return decimal.ToInt16(d);
    }

    /// <inheritdoc cref="decimal.ToInt32(decimal)"/>
    public static int ToInt32(this decimal d)
    {
        return decimal.ToInt32(d);
    }

    /// <inheritdoc cref="decimal.ToInt64(decimal)"/>
    public static long ToInt64(this decimal d)
    {
        return decimal.ToInt64(d);
    }

    /// <inheritdoc cref="decimal.ToOACurrency(decimal)"/>
    public static long ToOACurrency(this decimal d)
    {
        return decimal.ToOACurrency(d);
    }

    /// <inheritdoc cref="decimal.ToSByte(decimal)"/>
    public static sbyte ToSByte(this decimal d)
    {
        return decimal.ToSByte(d);
    }

    /// <inheritdoc cref="decimal.ToSingle(decimal)"/>
    public static float ToSingle(this decimal d)
    {
        return decimal.ToSingle(d);
    }

    /// <inheritdoc cref="decimal.ToUInt16(decimal)"/>
    public static ushort ToUInt16(this decimal d)
    {
        return decimal.ToUInt16(d);
    }

    /// <inheritdoc cref="decimal.ToUInt32(decimal)"/>
    public static uint ToUInt32(this decimal d)
    {
        return decimal.ToUInt32(d);
    }

    /// <inheritdoc cref="decimal.ToUInt64(decimal)"/>
    public static ulong ToUInt64(this decimal d)
    {
        return decimal.ToUInt64(d);
    }

    /// <inheritdoc cref="decimal.Truncate(decimal)"/>
    public static decimal Truncate(this decimal d)
    {
        return decimal.Truncate(d);
    }

    /// <inheritdoc cref="decimal.TryGetBits(decimal,Span{int},out int)"/>
    public static bool TryGetBits(this decimal d, Span<int> destination, out int valuesWritten)
    {
        return decimal.TryGetBits(d, destination, out valuesWritten);
    }
}