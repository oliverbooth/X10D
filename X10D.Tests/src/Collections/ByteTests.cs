using System.Runtime.Intrinsics.X86;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class ByteTests
{
    [TestMethod]
    public void Unpack_ShouldUnpackToArrayCorrectly()
    {
        const byte value = 0b11010100;
        bool[] bits = value.Unpack();

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
        const byte value = 0b11010100;
        Span<bool> bits = stackalloc bool[8];
        value.Unpack(bits);

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
    public void UnpackInternal_Fallback_ShouldUnpackToSpanCorrectly()
    {
        const byte value = 0b11010100;
        Span<bool> bits = stackalloc bool[8];
        value.UnpackInternal_Fallback(bits);

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
    public void UnpackInternal_Ssse3_ShouldUnpackToSpanCorrectly()
    {
        if (!Sse3.IsSupported)
        {
            return;
        }

        const byte value = 0b11010100;
        Span<bool> bits = stackalloc bool[8];
        value.UnpackInternal_Ssse3(bits);

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
        const byte value = 0b11010100;
        Assert.AreEqual(value, value.Unpack().PackByte());
    }

    [TestMethod]
    public void Unpack_ShouldThrow_GivenTooSmallSpan()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            const byte value = 0b11010100;
            Span<bool> bits = stackalloc bool[0];
            value.Unpack(bits);
        });
    }
}
