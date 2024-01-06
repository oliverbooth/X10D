using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void ReadDecimalBigEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadDecimalBigEndian());
    }

    [Test]
    public void ReadDecimalLittleEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadDecimalLittleEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadDecimalBigEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadDecimalBigEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadDecimalLittleEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadDecimalLittleEndian());
    }

    [Test]
    public void ReadDecimalBigEndian_ShouldReadBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[]
        {
            0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x68
        };
        stream.Write(bytes);
        stream.Position = 0;

        const decimal expected = 420.0m;
        decimal actual = stream.ReadDecimalBigEndian();

        Assert.Multiple(() =>
        {
            Assert.That(stream.Position, Is.EqualTo(16));
            Assert.That(actual, Is.EqualTo(expected));
        });
    }

    [Test]
    public void ReadDecimalLittleEndian_ShouldWriteLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[]
        {
            0x68, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00
        };
        stream.Write(bytes);
        stream.Position = 0;

        const decimal expected = 420.0m;
        decimal actual = stream.ReadDecimalLittleEndian();

        Assert.Multiple(() =>
        {
            Assert.That(stream.Position, Is.EqualTo(16));
            Assert.That(actual, Is.EqualTo(expected));
        });
    }
}
