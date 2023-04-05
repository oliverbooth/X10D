using System.Diagnostics;
using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestFixture]
public class Int64Tests
{
    [Test]
    public void UnpackBits_ShouldUnpackToArrayCorrectly()
    {
        bool[] bits = 0b11010100L.Unpack();

        Assert.That(bits, Has.Length.EqualTo(64));

        Trace.WriteLine(Convert.ToString(0b11010100L, 2));
        Trace.WriteLine(string.Join("", bits.Select(b => b ? "1" : "0")));
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

            for (var index = 8; index < 64; index++)
            {
                Assert.That(bits[index], Is.False, index.ToString());
            }
        });
    }

    [Test]
    public void UnpackBits_ShouldUnpackToSpanCorrectly()
    {
        Assert.Multiple(() =>
        {
            Span<bool> bits = stackalloc bool[64];
            0b11010100L.Unpack(bits);

            Assert.That(bits[0], Is.False);
            Assert.That(bits[1], Is.False);
            Assert.That(bits[2], Is.True);
            Assert.That(bits[3], Is.False);
            Assert.That(bits[4], Is.True);
            Assert.That(bits[5], Is.False);
            Assert.That(bits[6], Is.True);
            Assert.That(bits[7], Is.True);

            for (var index = 8; index < 64; index++)
            {
                Assert.That(bits[index], Is.False, index.ToString());
            }
        });
    }

    [Test]
    public void UnpackBits_ShouldRepackEqually()
    {
        Assert.That(0b11010100L.Unpack().PackInt64(), Is.EqualTo(0b11010100L));
    }

    [Test]
    public void UnpackBits_ShouldThrow_GivenTooSmallSpan()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Span<bool> bits = stackalloc bool[0];
            0b11010100L.Unpack(bits);
        });
    }
}
