using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class DoubleTests
{
    [Test]
    public void GetBigEndianBytes_ReturnsCorrectValue()
    {
        const double value = 42.5;

        var expected = new byte[] { 0x40, 0x45, 0x40, 0, 0, 0, 0, 0 };
        byte[] actual = value.GetBigEndianBytes();
        Assert.That(actual, Is.EqualTo(expected).AsCollection);
    }

    [Test]
    public void GetLittleEndianBytes_ReturnsCorrectValue()
    {
        const double value = 42.5;

        var expected = new byte[] { 0, 0, 0, 0, 0, 0x40, 0x45, 0x40 };
        byte[] actual = value.GetLittleEndianBytes();
        Assert.That(actual, Is.EqualTo(expected).AsCollection);
    }

    [Test]
    public void TryWriteBigEndian_ReturnsTrue_FillsSpanCorrectly()
    {
        const double value = 42.5;

        var expected = new byte[] { 0x40, 0x45, 0x40, 0, 0, 0, 0, 0 };
        Assert.Multiple(() =>
        {
            Span<byte> actual = stackalloc byte[8];
            Assert.That(value.TryWriteBigEndianBytes(actual));
            Assert.That(actual.ToArray(), Is.EqualTo(expected).AsCollection);
        });
    }

    [Test]
    public void TryWriteLittleEndian_ReturnsTrue_FillsSpanCorrectly()
    {
        const double value = 42.5;

        var expected = new byte[] { 0, 0, 0, 0, 0, 0x40, 0x45, 0x40 };
        Assert.Multiple(() =>
        {
            Span<byte> actual = stackalloc byte[8];
            Assert.That(value.TryWriteLittleEndianBytes(actual));
            Assert.That(actual.ToArray(), Is.EqualTo(expected).AsCollection);
        });
    }

    [Test]
    public void TryWriteBigEndian_ReturnsFalse_GivenSmallSpan()
    {
        const double value = 42.5;
        Span<byte> buffer = [];
        Assert.That(value.TryWriteBigEndianBytes(buffer), Is.False);
    }

    [Test]
    public void TryWriteLittleEndian_RReturnsFalse_GivenSmallSpan()
    {
        const double value = 42.5;
        Span<byte> buffer = [];
        Assert.That(value.TryWriteLittleEndianBytes(buffer), Is.False);
    }
}
