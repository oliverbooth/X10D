using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class SingleTests
{
    [Test]
    public void GetBigEndianBytes_ReturnsCorrectValue()
    {
        const float value = 42.5f;

        var expected = new byte[] { 0x42, 0x2A, 0, 0 };
        byte[] actual = value.GetBigEndianBytes();
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetLittleEndianBytes_ReturnsCorrectValue()
    {
        const float value = 42.5f;

        var expected = new byte[] { 0, 0, 0x2A, 0x42 };
        byte[] actual = value.GetLittleEndianBytes();
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void TryWriteBigEndian_ReturnsTrue_FillsSpanCorrectly()
    {
        const float value = 42.5f;

        var expected = new byte[] { 0x42, 0x2A, 0, 0 };
        Span<byte> actual = stackalloc byte[4];
        Assert.That(value.TryWriteBigEndianBytes(actual));
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [Test]
    public void TryWriteLittleEndian_ReturnsTrue_FillsSpanCorrectly()
    {
        const float value = 42.5f;

        var expected = new byte[] { 0, 0, 0x2A, 0x42 };
        Span<byte> actual = stackalloc byte[4];
        Assert.That(value.TryWriteLittleEndianBytes(actual));
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [Test]
    public void TryWriteBigEndian_ReturnsFalse_GivenSmallSpan()
    {
        const float value = 42.5f;
        Span<byte> buffer = stackalloc byte[0];
        Assert.That(value.TryWriteBigEndianBytes(buffer), Is.False);
    }

    [Test]
    public void TryWriteLittleEndian_RReturnsFalse_GivenSmallSpan()
    {
        const float value = 42.5f;
        Span<byte> buffer = stackalloc byte[0];
        Assert.That(value.TryWriteLittleEndianBytes(buffer), Is.False);
    }
}
