using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class DecimalTests
{
    [Test]
    public void GetBigEndianBytes_ShouldReturnBytes_InBigEndian()
    {
        const decimal value = 1234m;
        byte[] expected = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 210];

        byte[] bytes = value.GetBigEndianBytes();

        Assert.That(bytes, Is.EqualTo(expected).AsCollection);
    }

    [Test]
    public void GetLittleEndianBytes_ShouldReturnBytes_InLittleEndian()
    {
        const decimal value = 1234m;
        byte[] expected = [210, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        byte[] bytes = value.GetLittleEndianBytes();

        Assert.That(bytes, Is.EqualTo(expected).AsCollection);
    }

    [Test]
    public void TryWriteBigEndianBytes_ShouldWriteBytes_InBigEndian()
    {
        const decimal value = 1234m;
        byte[] expected = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 210];

        Assert.Multiple(() =>
        {
            Span<byte> bytes = stackalloc byte[16];
            Assert.That(value.TryWriteBigEndianBytes(bytes));
            Assert.That(bytes.ToArray(), Is.EqualTo(expected).AsCollection);
        });
    }

    [Test]
    public void TryWriteLittleEndianBytes_ShouldWriteBytes_InLittleEndian()
    {
        const decimal value = 1234m;
        byte[] expected = [210, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        Assert.Multiple(() =>
        {
            Span<byte> bytes = stackalloc byte[16];
            Assert.That(value.TryWriteLittleEndianBytes(bytes));
            Assert.That(bytes.ToArray(), Is.EqualTo(expected).AsCollection);
        });
    }

    [Test]
    public void TryWriteBigEndianBytes_ShouldReturnFalse_GivenSmallSpan()
    {
        const decimal value = 1234m;

        Span<byte> bytes = Span<byte>.Empty;
        Assert.That(value.TryWriteBigEndianBytes(bytes), Is.False);
    }

    [Test]
    public void TryWriteLittleEndianBytes_ShouldReturnFalse_GivenSmallSpan()
    {
        const decimal value = 1234m;

        Span<byte> bytes = Span<byte>.Empty;
        Assert.That(value.TryWriteLittleEndianBytes(bytes), Is.False);
    }
}
