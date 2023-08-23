using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class Int64Tests
{
    [Test]
    public void GetLittleEndianBytes_ReturnsCorrectValue()
    {
        const long value = 0x0F;

        byte[] expected = { 0x0F, 0, 0, 0, 0, 0, 0, 0 };
        byte[] actual = value.GetLittleEndianBytes();
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetBigEndianBytes_ReturnsCorrectValue()
    {
        const long value = 0x0F;

        byte[] expected = { 0, 0, 0, 0, 0, 0, 0, 0x0F };
        byte[] actual = value.GetBigEndianBytes();
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void TryWriteLittleEndian_ReturnsTrue_FillsSpanCorrectly()
    {
        const long value = 0x0F;

        byte[] expected = { 0x0F, 0, 0, 0, 0, 0, 0, 0 };
        Span<byte> actual = stackalloc byte[8];
        Assert.That(value.TryWriteLittleEndian(actual));
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [Test]
    public void TryWriteBigEndian_ReturnsTrue_FillsSpanCorrectly()
    {
        const long value = 0x0F;

        byte[] expected = { 0, 0, 0, 0, 0, 0, 0, 0x0F };
        Span<byte> actual = stackalloc byte[8];
        Assert.That(value.TryWriteBigEndian(actual));
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [Test]
    public void TryWriteLittleEndian_RReturnsFalse_GivenSmallSpan()
    {
        const long value = 0x0F;
        Span<byte> buffer = stackalloc byte[0];
        Assert.That(value.TryWriteLittleEndian(buffer), Is.False);
    }

    [Test]
    public void TryWriteBigEndian_ReturnsFalse_GivenSmallSpan()
    {
        const long value = 0x0F;
        Span<byte> buffer = stackalloc byte[0];
        Assert.That(value.TryWriteBigEndian(buffer), Is.False);
    }
}
