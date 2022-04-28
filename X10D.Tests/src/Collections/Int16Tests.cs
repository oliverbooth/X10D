using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class Int16Tests
{
    [TestMethod]
    public void UnpackBits_ShouldUnpackToArrayCorrectly()
    {
        bool[] bits = ((short)0b11010100).Unpack();
        
        Assert.AreEqual(16, bits.Length);

        Assert.IsFalse(bits[0]);
        Assert.IsFalse(bits[1]);
        Assert.IsTrue(bits[2]);
        Assert.IsFalse(bits[3]);
        Assert.IsTrue(bits[4]);
        Assert.IsFalse(bits[5]);
        Assert.IsTrue(bits[6]);
        Assert.IsTrue(bits[7]);

        for (var index = 8; index < 16; index++)
        {
            Assert.IsFalse(bits[index]);
        }
    }

    [TestMethod]
    public void UnpackBits_ShouldUnpackToSpanCorrectly()
    {
        Span<bool> bits = stackalloc bool[16];
        ((short)0b11010100).Unpack(bits);

        Assert.IsFalse(bits[0]);
        Assert.IsFalse(bits[1]);
        Assert.IsTrue(bits[2]);
        Assert.IsFalse(bits[3]);
        Assert.IsTrue(bits[4]);
        Assert.IsFalse(bits[5]);
        Assert.IsTrue(bits[6]);
        Assert.IsTrue(bits[7]);

        for (var index = 8; index < 16; index++)
        {
            Assert.IsFalse(bits[index]);
        }
    }

    [TestMethod]
    public void UnpackBits_ShouldRepackEqually()
    {
        Assert.AreEqual(0b11010100, ((short)0b11010100).Unpack().PackInt16());
    }

    [TestMethod]
    public void UnpackBits_ShouldThrow_GivenTooSmallSpan()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            Span<bool> bits = stackalloc bool[0];
            ((short)0b11010100).Unpack(bits);
        });
    }
}
