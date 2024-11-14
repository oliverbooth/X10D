using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class UInt16Tests
{
    [Test]
    public void GetLittleEndianBytes_ReturnsCorrectValue_WithEndianness()
    {
        const ushort value = 0x0F;
        byte[] expected = [0x0F, 0];
        byte[] actual = value.GetLittleEndianBytes();

        Assert.That(actual, Is.EqualTo(expected).AsCollection);
    }

    [Test]
    public void GetBigEndianBytes_ReturnsCorrectValue_WithEndianness()
    {
        const ushort value = 0x0F;
        byte[] expected = [0, 0x0F];
        byte[] actual = value.GetBigEndianBytes();

        Assert.That(actual, Is.EqualTo(expected).AsCollection);
    }

    [Test]
    public void TryWriteLittleEndian_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan()
    {
        const ushort value = 0x0F;
        byte[] expected = [0x0F, 0];

        Assert.Multiple(() =>
        {
            Span<byte> actual = stackalloc byte[2];
            Assert.That(value.TryWriteLittleEndianBytes(actual));
            Assert.That(actual.ToArray(), Is.EqualTo(expected).AsCollection);
        });
    }

    [Test]
    public void TryWriteBigEndian_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan()
    {
        const ushort value = 0x0F;
        byte[] expected = [0, 0x0F];

        Assert.Multiple(() =>
        {
            Span<byte> actual = stackalloc byte[2];
            Assert.That(value.TryWriteBigEndianBytes(actual));
            Assert.That(actual.ToArray(), Is.EqualTo(expected).AsCollection);
        });
    }

    [Test]
    public void TryWriteLittleEndian_RReturnsFalse_GivenSmallSpan()
    {
        const ushort value = 0x0F;
        Span<byte> buffer = [];
        Assert.That(value.TryWriteLittleEndianBytes(buffer), Is.False);
    }

    [Test]
    public void TryWriteBigEndian_ReturnsFalse_GivenSmallSpan()
    {
        const ushort value = 0x0F;
        Span<byte> buffer = [];
        Assert.That(value.TryWriteBigEndianBytes(buffer), Is.False);
    }
}
