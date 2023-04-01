using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class ByteTests
{
    [TestMethod]
    public void Unpack_ShouldUnpackToArrayCorrectly()
    {
        bool[] bits = ((byte)0b11010100).Unpack();

        Assert.AreEqual(8, bits.Length);

        Assert.IsFalse(bits[0]);
        Assert.IsFalse(bits[1]);
        Assert.IsTrue(bits[2]);
        Assert.IsFalse(bits[3]);
        Assert.IsTrue(bits[4]);
        Assert.IsFalse(bits[5]);
        Assert.IsTrue(bits[6]);
        Assert.IsTrue(bits[7]);
    }

    [TestMethod]
    public void Unpack_ShouldUnpackToSpanCorrectly()
    {
        Span<bool> bits = stackalloc bool[8];
        ((byte)0b11010100).Unpack(bits);

        Assert.IsFalse(bits[0]);
        Assert.IsFalse(bits[1]);
        Assert.IsTrue(bits[2]);
        Assert.IsFalse(bits[3]);
        Assert.IsTrue(bits[4]);
        Assert.IsFalse(bits[5]);
        Assert.IsTrue(bits[6]);
        Assert.IsTrue(bits[7]);
    }

#if NET5_0_OR_GREATER
    [TestMethod]
    public void Unpack_ShouldUnpackToSpanCorrectly_GivenFallbackImplementation()
    {
        var mock = new Mock<ISsse3SupportProvider>();
        mock.Setup(provider => provider.IsSupported).Returns(false);

        Span<bool> bits = stackalloc bool[8];
        ((byte)0b11010100).UnpackInternal(bits, mock.Object);

        Assert.IsFalse(bits[0]);
        Assert.IsFalse(bits[1]);
        Assert.IsTrue(bits[2]);
        Assert.IsFalse(bits[3]);
        Assert.IsTrue(bits[4]);
        Assert.IsFalse(bits[5]);
        Assert.IsTrue(bits[6]);
        Assert.IsTrue(bits[7]);
    }
#endif

    [TestMethod]
    public void Unpack_ShouldRepackEqually()
    {
        Assert.AreEqual(0b11010100, ((byte)0b11010100).Unpack().PackByte());
    }

    [TestMethod]
    public void Unpack_ShouldThrow_GivenTooSmallSpan()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            Span<bool> bits = stackalloc bool[0];
            ((byte)0b11010100).Unpack(bits);
        });
    }
}
