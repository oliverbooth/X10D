﻿using System.Runtime.Intrinsics.X86;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class Int16Tests
{
    [TestMethod]
    public void Unpack_ShouldUnpackToArrayCorrectly()
    {
        const short value = 0b11010100;
        bool[] bits = value.Unpack();

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
        const short value = 0b11010100;
        Span<bool> bits = stackalloc bool[16];
        value.Unpack(bits);

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
    public void Unpack_ShouldUnpackToSpanCorrectly_GivenFallbackImplementation()
    {
        const short value = 0b11010100;
        Span<bool> bits = stackalloc bool[16];
        value.UnpackInternal_Fallback(bits);

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
    public void UnpackInternal_Ssse3_ShouldUnpackToSpanCorrectly()
    {
        if (!Sse3.IsSupported)
        {
            return;
        }

        const short value = 0b11010100;
        Span<bool> bits = stackalloc bool[16];
        value.UnpackInternal_Ssse3(bits);

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
        const short value = 0b11010100;
        Assert.AreEqual(value, value.Unpack().PackInt16());
    }

    [TestMethod]
    public void Unpack_ShouldThrow_GivenTooSmallSpan()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            const short value = 0b11010100;
            Span<bool> bits = stackalloc bool[0];
            value.Unpack(bits);
        });
    }
}
