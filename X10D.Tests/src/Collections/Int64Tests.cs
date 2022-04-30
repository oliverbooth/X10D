using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class Int64Tests
{
    [TestMethod]
    public void UnpackBits_ShouldUnpackToArrayCorrectly()
    {
        bool[] bits = 0b11010100L.Unpack();

        Assert.AreEqual(64, bits.Length);

        Trace.WriteLine(Convert.ToString(0b11010100L, 2));
        Trace.WriteLine(string.Join("", bits.Select(b => b ? "1" : "0")));

        Assert.IsFalse(bits[0]);
        Assert.IsFalse(bits[1]);
        Assert.IsTrue(bits[2]);
        Assert.IsFalse(bits[3]);
        Assert.IsTrue(bits[4]);
        Assert.IsFalse(bits[5]);
        Assert.IsTrue(bits[6]);
        Assert.IsTrue(bits[7]);

        for (var index = 8; index < 64; index++)
        {
            Assert.IsFalse(bits[index], index.ToString());
        }
    }

    [TestMethod]
    public void UnpackBits_ShouldUnpackToSpanCorrectly()
    {
        Span<bool> bits = stackalloc bool[64];
        0b11010100L.Unpack(bits);

        Assert.IsFalse(bits[0]);
        Assert.IsFalse(bits[1]);
        Assert.IsTrue(bits[2]);
        Assert.IsFalse(bits[3]);
        Assert.IsTrue(bits[4]);
        Assert.IsFalse(bits[5]);
        Assert.IsTrue(bits[6]);
        Assert.IsTrue(bits[7]);

        for (var index = 8; index < 64; index++)
        {
            Assert.IsFalse(bits[index], index.ToString());
        }
    }

    [TestMethod]
    public void UnpackBits_ShouldRepackEqually()
    {
        Assert.AreEqual(0b11010100L, 0b11010100L.Unpack().PackInt64());
    }

    [TestMethod]
    public void UnpackBits_ShouldThrow_GivenTooSmallSpan()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            Span<bool> bits = stackalloc bool[0];
            0b11010100L.Unpack(bits);
        });
    }
}
