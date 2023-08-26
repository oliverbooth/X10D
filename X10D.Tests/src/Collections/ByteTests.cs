using System.Runtime.Intrinsics.X86;
using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestFixture]
internal class ByteTests
{
    [Test]
    public void Unpack_ShouldUnpackToArrayCorrectly()
    {
        const byte value = 0b11010100;
        bool[] bits = value.Unpack();

        Assert.That(bits, Has.Length.EqualTo(8));
        Assert.Multiple(() =>
        {
            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);
        });
    }

    [Test]
    public void Unpack_ShouldUnpackToSpanCorrectly()
    {
        const byte value = 0b11010100;
        Assert.Multiple(() =>
        {
            Span<bool> bits = stackalloc bool[8];
            value.Unpack(bits);

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);
        });
    }

#if NET5_0_OR_GREATER
    [Test]
    public void UnpackInternal_Fallback_ShouldUnpackToSpanCorrectly()
    {
        const byte value = 0b11010100;
        Assert.Multiple(() =>
        {
            Span<bool> bits = stackalloc bool[8];
            value.UnpackInternal_Fallback(bits);

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);
        });
    }

    [Test]
    public void UnpackInternal_Ssse3_ShouldUnpackToSpanCorrectly()
    {
        if (!Sse3.IsSupported)
        {
            return;
        }

        const byte value = 0b11010100;
        Assert.Multiple(() =>
        {
            Span<bool> bits = stackalloc bool[8];
            value.Unpack(bits);

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);
        });
    }
#endif

    [Test]
    public void Unpack_ShouldRepackEqually()
    {
        const byte value = 0b11010100;
        Assert.That(value.Unpack().PackByte(), Is.EqualTo(value));
    }

    [Test]
    public void Unpack_ShouldThrow_GivenTooSmallSpan()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            const byte value = 0b11010100;
            Span<bool> bits = stackalloc bool[0];
            value.Unpack(bits);
        });
    }
}
