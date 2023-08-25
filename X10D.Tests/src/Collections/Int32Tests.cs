#if NET5_0_OR_GREATER
using System.Runtime.Intrinsics.X86;
#endif
using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestFixture]
internal class Int32Tests
{
    [Test]
    public void Unpack_ShouldUnpackToArrayCorrectly()
    {
        const int value = 0b11010100;

        Assert.Multiple(() =>
        {
            bool[] bits = value.Unpack();
            Assert.That(bits, Has.Length.EqualTo(32));

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);

            for (var index = 8; index < 32; index++)
            {
                Assert.That(bits[index], Is.False);
            }
        });
    }

    [Test]
    public void Unpack_ShouldUnpackToSpanCorrectly()
    {
        const int value = 0b11010100;
        Assert.Multiple(() =>
        {
            Span<bool> bits = stackalloc bool[32];
            value.Unpack(bits);

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);

            for (var index = 8; index < 32; index++)
            {
                Assert.That(bits[index], Is.False);
            }
        });
    }

    [Test]
    public void UnpackInternal_Fallback_ShouldUnpackToSpanCorrectly()
    {
        const int value = 0b11010100;
        Assert.Multiple(() =>
        {
            Span<bool> bits = stackalloc bool[32];
            value.UnpackInternal_Fallback(bits);

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);

            for (var index = 8; index < 32; index++)
            {
                Assert.That(bits[index], Is.False);
            }
        });
    }

#if NET5_0_OR_GREATER
    [Test]
    public void UnpackInternal_Ssse3_ShouldUnpackToSpanCorrectly()
    {
        if (!Ssse3.IsSupported)
        {
            return;
        }

        const int value = 0b11010100;
        Assert.Multiple(() =>
        {
            Span<bool> bits = stackalloc bool[32];
            value.UnpackInternal_Ssse3(bits);

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);

            for (var index = 8; index < 32; index++)
            {
                Assert.That(bits[index], Is.False);
            }
        });
    }

    [Test]
    public void UnpackInternal_Avx2_ShouldUnpackToSpanCorrectly()
    {
        if (!Avx2.IsSupported)
        {
            return;
        }

        const int value = 0b11010100;
        Assert.Multiple(() =>
        {
            Span<bool> bits = stackalloc bool[32];
            value.UnpackInternal_Avx2(bits);

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);

            for (var index = 8; index < 32; index++)
            {
                Assert.That(bits[index], Is.False);
            }
        });
    }
#endif

    [Test]
    public void Unpack_ShouldRepackEqually()
    {
        const int value = 0b11010100;
        Assert.That(value.Unpack().PackInt32(), Is.EqualTo(value));
    }

    [Test]
    public void Unpack_ShouldThrow_GivenTooSmallSpan()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            const int value = 0b11010100;
            Span<bool> bits = stackalloc bool[0];
            value.Unpack(bits);
        });
    }
}
