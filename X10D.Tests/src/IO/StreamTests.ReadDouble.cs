using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void ReadDoubleBigEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadDoubleBigEndian());
    }

    [Test]
    public void ReadDoubleLittleEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadDoubleLittleEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadDoubleBigEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadDoubleBigEndian());
    }

    [Test]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope")]
    public void ReadDoubleLittleEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadDoubleLittleEndian());
    }

    [Test]
    public void ReadDoubleBigEndian_ShouldReadBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0x40, 0x7A, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00 };
        stream.Write(bytes);
        stream.Position = 0;

        const double expected = 420.0;
        double actual = stream.ReadDoubleBigEndian();

        Assert.That(stream.Position, Is.EqualTo(8));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReadDoubleLittleEndian_ShouldWriteLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x7A, 0x40 };
        stream.Write(bytes);
        stream.Position = 0;

        const double expected = 420.0;
        double actual = stream.ReadDoubleLittleEndian();

        Assert.That(stream.Position, Is.EqualTo(8));
        Assert.That(actual, Is.EqualTo(expected));
    }
}
