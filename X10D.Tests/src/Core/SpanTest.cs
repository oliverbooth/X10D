using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;
using X10D.Core;

namespace X10D.Tests.Core;

[TestClass]
public class SpanTest
{
    [TestMethod]
    public void Contains_ShouldReturnFalse_GivenReadOnlySpanWithNoMatchingElements_UsingByteEnum()
    {
        ReadOnlySpan<EnumByte> span = stackalloc EnumByte[1] {EnumByte.B};

        Assert.IsFalse(span.Contains(EnumByte.A));
        Assert.IsFalse(span.Contains(EnumByte.C));
    }

    [TestMethod]
    public void Contains_ShouldReturnFalse_GivenReadOnlySpanWithNoMatchingElements_UsingInt16Enum()
    {
        ReadOnlySpan<EnumInt16> span = stackalloc EnumInt16[1] {EnumInt16.B};

        Assert.IsFalse(span.Contains(EnumInt16.A));
        Assert.IsFalse(span.Contains(EnumInt16.C));
    }

    [TestMethod]
    public void Contains_ShouldReturnFalse_GivenReadOnlySpanWithNoMatchingElements_UsingInt32Enum()
    {
        ReadOnlySpan<EnumInt32> span = stackalloc EnumInt32[1] {EnumInt32.B};

        Assert.IsFalse(span.Contains(EnumInt32.A));
        Assert.IsFalse(span.Contains(EnumInt32.C));
    }

    [TestMethod]
    public void Contains_ShouldReturnFalse_GivenReadOnlySpanWithNoMatchingElements_UsingInt64Enum()
    {
        ReadOnlySpan<EnumInt64> span = stackalloc EnumInt64[1] {EnumInt64.B};

        Assert.IsFalse(span.Contains(EnumInt64.A));
        Assert.IsFalse(span.Contains(EnumInt64.C));
    }

    [TestMethod]
    public void Contains_ShouldReturnTrue_GivenReadOnlySpanWithMatchingElements_UsingByteEnum()
    {
        ReadOnlySpan<EnumByte> span = stackalloc EnumByte[1] {EnumByte.B};

        Assert.IsTrue(span.Contains(EnumByte.B));
    }

    [TestMethod]
    public void Contains_ShouldReturnTrue_GivenReadOnlySpanWithMatchingElements_UsingInt16Enum()
    {
        ReadOnlySpan<EnumInt16> span = stackalloc EnumInt16[1] {EnumInt16.B};

        Assert.IsTrue(span.Contains(EnumInt16.B));
    }

    [TestMethod]
    public void Contains_ShouldReturnTrue_GivenReadOnlySpanWithMatchingElements_UsingInt32Enum()
    {
        ReadOnlySpan<EnumInt32> span = stackalloc EnumInt32[1] {EnumInt32.B};

        Assert.IsTrue(span.Contains(EnumInt32.B));
    }

    [TestMethod]
    public void Contains_ShouldReturnTrue_GivenReadOnlySpanWithMatchingElements_UsingInt64Enum()
    {
        ReadOnlySpan<EnumInt64> span = stackalloc EnumInt64[1] {EnumInt64.B};

        Assert.IsTrue(span.Contains(EnumInt64.B));
    }

    [TestMethod]
    public void Contains_ShouldReturnFalse_GivenSpanWithNoMatchingElements_UsingByteEnum()
    {
        Span<EnumByte> span = stackalloc EnumByte[1] {EnumByte.B};

        Assert.IsFalse(span.Contains(EnumByte.A));
        Assert.IsFalse(span.Contains(EnumByte.C));
    }

    [TestMethod]
    public void Contains_ShouldReturnFalse_GivenSpanWithNoMatchingElements_UsingInt16Enum()
    {
        Span<EnumInt16> span = stackalloc EnumInt16[1] {EnumInt16.B};

        Assert.IsFalse(span.Contains(EnumInt16.A));
        Assert.IsFalse(span.Contains(EnumInt16.C));
    }

    [TestMethod]
    public void Contains_ShouldReturnFalse_GivenSpanWithNoMatchingElements_UsingInt32Enum()
    {
        Span<EnumInt32> span = stackalloc EnumInt32[1] {EnumInt32.B};

        Assert.IsFalse(span.Contains(EnumInt32.A));
        Assert.IsFalse(span.Contains(EnumInt32.C));
    }

    [TestMethod]
    public void Contains_ShouldReturnFalse_GivenSpanWithNoMatchingElements_UsingInt64Enum()
    {
        Span<EnumInt64> span = stackalloc EnumInt64[1] {EnumInt64.B};

        Assert.IsFalse(span.Contains(EnumInt64.A));
        Assert.IsFalse(span.Contains(EnumInt64.C));
    }

    [TestMethod]
    public void Contains_ShouldReturnTrue_GivenSpanWithMatchingElements_UsingByteEnum()
    {
        Span<EnumByte> span = stackalloc EnumByte[1] {EnumByte.B};

        Assert.IsTrue(span.Contains(EnumByte.B));
    }

    [TestMethod]
    public void Contains_ShouldReturnTrue_GivenSpanWithMatchingElements_UsingInt16Enum()
    {
        Span<EnumInt16> span = stackalloc EnumInt16[1] {EnumInt16.B};

        Assert.IsTrue(span.Contains(EnumInt16.B));
    }

    [TestMethod]
    public void Contains_ShouldReturnTrue_GivenSpanWithMatchingElements_UsingInt32Enum()
    {
        Span<EnumInt32> span = stackalloc EnumInt32[1] {EnumInt32.B};

        Assert.IsTrue(span.Contains(EnumInt32.B));
    }

    [TestMethod]
    public void Contains_ShouldReturnTrue_GivenSpanWithMatchingElements_UsingInt64Enum()
    {
        Span<EnumInt64> span = stackalloc EnumInt64[1] {EnumInt64.B};

        Assert.IsTrue(span.Contains(EnumInt64.B));
    }

    [TestMethod]
    public void Pack8Bit_Should_Pack_Correctly()
    {
        Span<bool> span = stackalloc bool[8] {true, true, false, false, true, true, false, false};
        Assert.AreEqual(0b00110011, span.PackByte());
    }

    [TestMethod]
    public void Pack8Bit_Should_Pack_Correctly_Randomize()
    {
        var value = new Random().NextByte();

        Span<bool> unpacks = stackalloc bool[8];

        value.Unpack(unpacks);

        Assert.AreEqual(value, unpacks.PackByte());
    }

    [TestMethod]
    public void Pack16Bit_Should_Pack_Correctly()
    {
        ReadOnlySpan<bool> span = stackalloc bool[16]
        {
            false, false, true, false, true, false, true, true, true, false, true, true, false, true, false, false,
        };
        Assert.AreEqual(0b00101101_11010100, span.PackInt16());
    }

    [TestMethod]
    public void Pack16Bit_Should_Pack_Correctly_Randomize()
    {
        var value = new Random().NextInt16();

        Span<bool> unpacks = stackalloc bool[16];

        value.Unpack(unpacks);

        Assert.AreEqual(value, unpacks.PackInt16());
    }

    [TestMethod]
    public void Pack32Bit_Should_Pack_Correctly()
    {
        ReadOnlySpan<bool> span = stackalloc bool[]
        {
            false, true, false, true, false, true, false, true, true, false, true, false, true, false, true, false, false,
            true, false, true, false, true, false, true, true, false, true, false, true, false, true, false,
        };
        Assert.AreEqual(0b01010101_10101010_01010101_10101010, span.PackInt32());
    }

    [TestMethod]
    public void Pack32Bit_Should_Pack_Correctly_Randomize()
    {
        var value = new Random().Next(int.MinValue, int.MaxValue);

        Span<bool> unpacks = stackalloc bool[32];

        value.Unpack(unpacks);

        Assert.AreEqual(value, unpacks.PackInt32());
    }

    [TestMethod]
    public void Pack64Bit_Should_Pack_Correctly()
    {
        ReadOnlySpan<bool> span = stackalloc bool[]
        {
            true, false, true, false, false, true, false, true, false, false, true, true, false, true, false, false, true,
            true, true, false, true, false, false, true, false, true, false, false, true, false, false, false, false, true,
            true, false, true, false, true, true, true, false, false, true, false, true, true, false, false, true, true,
            false, true, false, true, true, true, false, true, false, true, false, true, false,
        };
        Assert.AreEqual(0b01010101_11010110_01101001_11010110_00010010_10010111_00101100_10100101, span.PackInt64());
    }

    [TestMethod]
    public void Pack64Bit_Should_Pack_Correctly_Randomize()
    {
        var rand = new Random();
        long value = ((long)rand.Next() << 32) | (long)rand.Next();

        Span<bool> unpacks = stackalloc bool[64];

        value.Unpack(unpacks);

        Assert.AreEqual(value, unpacks.PackInt64());
    }

    private enum EnumByte : byte
    {
        A,
        B,
        C
    }

    private enum EnumInt16 : short
    {
        A,
        B,
        C
    }

    private enum EnumInt32
    {
        A,
        B,
        C
    }

    private enum EnumInt64 : long
    {
        A,
        B,
        C
    }
}
