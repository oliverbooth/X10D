using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;
using X10D.Core;

namespace X10D.Tests.Core;

[TestClass]
public class SpanTest
{
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
}
