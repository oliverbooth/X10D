namespace X10D.ReExposed.IntegerExtensions.ByteExtensions;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class ByteExtensions
{
    /// <inheritdoc cref="Encoding.GetString(ReadOnlySpan{byte})"/>
    public static string GetString(this ReadOnlySpan<byte> bytes, Encoding? encoding = null)
    {
        return (encoding ?? Encoding.Default).GetString(bytes);
    }

    /// <inheritdoc cref="Encoding.GetString(ReadOnlySpan{byte})"/>
    public static string GetString(this Span<byte> bytes, Encoding? encoding = null)
    {
        return (encoding ?? Encoding.Default).GetString(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt16(ReadOnlySpan{byte})"/>
    public static short ToInt16(this ReadOnlySpan<byte> bytes)
    {
        return BitConverter.ToInt16(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt16(ReadOnlySpan{byte})"/>
    public static short ToInt16(this Span<byte> bytes)
    {
        return BitConverter.ToInt16(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt32(ReadOnlySpan{byte})"/>
    public static int ToInt32(this ReadOnlySpan<byte> bytes)
    {
        return BitConverter.ToInt32(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt32(ReadOnlySpan{byte})"/>
    public static int ToInt32(this Span<byte> bytes)
    {
        return BitConverter.ToInt32(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt64(ReadOnlySpan{byte})"/>
    public static long ToInt64(this ReadOnlySpan<byte> bytes)
    {
        return BitConverter.ToInt64(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt64(ReadOnlySpan{byte})"/>
    public static long ToInt64(this Span<byte> bytes)
    {
        return BitConverter.ToInt64(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt16(ReadOnlySpan{byte})"/>
    public static ushort ToUInt16(this ReadOnlySpan<byte> bytes)
    {
        return BitConverter.ToUInt16(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt16(ReadOnlySpan{byte})"/>
    public static ushort ToUInt16(this Span<byte> bytes)
    {
        return BitConverter.ToUInt16(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt32(ReadOnlySpan{byte})"/>
    public static uint ToUInt32(this ReadOnlySpan<byte> bytes)
    {
        return BitConverter.ToUInt32(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt32(ReadOnlySpan{byte})"/>
    public static uint ToUInt32(this Span<byte> bytes)
    {
        return BitConverter.ToUInt32(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt64(ReadOnlySpan{byte})"/>
    public static ulong ToUInt64(this ReadOnlySpan<byte> bytes)
    {
        return BitConverter.ToUInt64(bytes);
    }

    /// <inheritdoc cref="BitConverter.ToInt64(ReadOnlySpan{byte})"/>
    public static ulong ToUInt64(this Span<byte> bytes)
    {
        return BitConverter.ToUInt64(bytes);
    }
}