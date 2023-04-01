using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class Int32Tests
{
    [TestMethod]
    public void Unpack_ShouldUnpackToArrayCorrectly()
    {
        bool[] bits = 0b11010100.Unpack();

        Assert.AreEqual(32, bits.Length);

        Assert.IsFalse(bits[0]);
        Assert.IsFalse(bits[1]);
        Assert.IsTrue(bits[2]);
        Assert.IsFalse(bits[3]);
        Assert.IsTrue(bits[4]);
        Assert.IsFalse(bits[5]);
        Assert.IsTrue(bits[6]);
        Assert.IsTrue(bits[7]);

        for (var index = 8; index < 32; index++)
        {
            Assert.IsFalse(bits[index]);
        }
    }

    [TestMethod]
    public void Unpack_ShouldUnpackToSpanCorrectly()
    {
        Span<bool> bits = stackalloc bool[32];
        0b11010100.Unpack(bits);

        Assert.IsFalse(bits[0]);
        Assert.IsFalse(bits[1]);
        Assert.IsTrue(bits[2]);
        Assert.IsFalse(bits[3]);
        Assert.IsTrue(bits[4]);
        Assert.IsFalse(bits[5]);
        Assert.IsTrue(bits[6]);
        Assert.IsTrue(bits[7]);

        for (var index = 8; index < 32; index++)
        {
            Assert.IsFalse(bits[index]);
        }
    }

#if NET5_0_OR_GREATER
    [TestMethod]
    public void Unpack_ShouldUnpackToSpanCorrectly_GivenFallbackFromAvx2()
    {
        var ssse3Mock = new Mock<ISsse3SupportProvider>();
        var avx2Mock = new Mock<IAvx2SupportProvider>();
        avx2Mock.Setup(provider => provider.IsSupported).Returns(false);
        ssse3Mock.Setup(provider => provider.IsSupported).Returns(true);

        Span<bool> bits = stackalloc bool[32];
        0b11010100.UnpackInternal(bits, ssse3Mock.Object, avx2Mock.Object);

        Assert.IsFalse(bits[0]);
        Assert.IsFalse(bits[1]);
        Assert.IsTrue(bits[2]);
        Assert.IsFalse(bits[3]);
        Assert.IsTrue(bits[4]);
        Assert.IsFalse(bits[5]);
        Assert.IsTrue(bits[6]);
        Assert.IsTrue(bits[7]);

        for (var index = 8; index < 32; index++)
        {
            Assert.IsFalse(bits[index]);
        }
    }

    [TestMethod]
    public void Unpack_ShouldUnpackToSpanCorrectly_GivenFallback()
    {
        var ssse3Mock = new Mock<ISsse3SupportProvider>();
        var avx2Mock = new Mock<IAvx2SupportProvider>();
        ssse3Mock.Setup(provider => provider.IsSupported).Returns(false);
        avx2Mock.Setup(provider => provider.IsSupported).Returns(false);

        Span<bool> bits = stackalloc bool[32];
        0b11010100.UnpackInternal(bits, ssse3Mock.Object, avx2Mock.Object);

        Assert.IsFalse(bits[0]);
        Assert.IsFalse(bits[1]);
        Assert.IsTrue(bits[2]);
        Assert.IsFalse(bits[3]);
        Assert.IsTrue(bits[4]);
        Assert.IsFalse(bits[5]);
        Assert.IsTrue(bits[6]);
        Assert.IsTrue(bits[7]);

        for (var index = 8; index < 32; index++)
        {
            Assert.IsFalse(bits[index]);
        }
    }

#endif

    [TestMethod]
    public void Unpack_ShouldRepackEqually()
    {
        Assert.AreEqual(0b11010100, 0b11010100.Unpack().PackInt32());
    }

    [TestMethod]
    public void Unpack_ShouldThrow_GivenTooSmallSpan()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            Span<bool> bits = stackalloc bool[0];
            0b11010100.Unpack(bits);
        });
    }
}
