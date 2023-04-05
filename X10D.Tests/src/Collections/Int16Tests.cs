using System.Runtime.Intrinsics.X86;
using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestFixture]
public class Int16Tests
{
    [Test]
    public void Unpack_ShouldUnpackToArrayCorrectly()
    {
        Assert.Multiple(() =>
        {
            const short value = 0b11010100;
            bool[] bits = value.Unpack();

            Assert.That(bits, Has.Length.EqualTo(16));
            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);

            for (var index = 8; index < 16; index++)
            {
                Assert.That(bits[index], Is.False);
            }
        });
    }

    [Test]
    public void Unpack_ShouldUnpackToSpanCorrectly()
    {
        const short value = 0b11010100;
        Assert.Multiple(() =>
        {
            Span<bool> bits = stackalloc bool[16];
            value.Unpack(bits);

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);

            for (var index = 8; index < 16; index++)
            {
                Assert.That(bits[index], Is.False);
            }
        });
    }

    [Test]
    public void Unpack_ShouldUnpackToSpanCorrectly_GivenFallbackImplementation()
    {
        const short value = 0b11010100;
        Assert.Multiple(() =>
        {
            Span<bool> bits = stackalloc bool[16];
            value.UnpackInternal_Fallback(bits);

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);

            for (var index = 8; index < 16; index++)
            {
                Assert.That(bits[index], Is.False);
            }
        });
    }

#if NET5_0_OR_GREATER
    [Test]
    public void UnpackInternal_Ssse3_ShouldUnpackToSpanCorrectly()
    {
        if (!Sse3.IsSupported)
        {
            Assert.Pass();
            return;
        }

        const short value = 0b11010100;
        Assert.Multiple(() =>
        {
            Span<bool> bits = stackalloc bool[16];
            value.UnpackInternal_Ssse3(bits);

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);

            for (var index = 8; index < 16; index++)
            {
                Assert.That(bits[index], Is.False);
            }
        });
    }
#endif

    [Test]
    public void Unpack_ShouldRepackEqually()
    {
        const short value = 0b11010100;
        Assert.That(value.Unpack().PackInt16(), Is.EqualTo(value));
    }

    [Test]
    public void Unpack_ShouldThrow_GivenTooSmallSpan()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            const short value = 0b11010100;
            Span<bool> bits = stackalloc bool[0];
            value.Unpack(bits);
        });
    }
}
