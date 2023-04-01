using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class Int16Tests
{
    [TestMethod]
    public void Unpack_ShouldUnpackToArrayCorrectly()
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
    public void Unpack_ShouldUnpackToSpanCorrectly()
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

#if NET5_0_OR_GREATER
    [TestMethod]
    public void Unpack_ShouldUnpackToSpanCorrectly_GivenFallbackImplementation()
    {
        var mock = new Mock<ISsse3SupportProvider>();
        mock.Setup(provider => provider.IsSupported).Returns(false);

        Span<bool> bits = stackalloc bool[16];
        ((short)0b11010100).UnpackInternal(bits, mock.Object);

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
#endif

    [TestMethod]
    public void Unpack_ShouldRepackEqually()
    {
        Assert.AreEqual(0b11010100, ((short)0b11010100).Unpack().PackInt16());
    }

    [TestMethod]
    public void Unpack_ShouldThrow_GivenTooSmallSpan()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            Span<bool> bits = stackalloc bool[0];
            ((short)0b11010100).Unpack(bits);
        });
    }
}
