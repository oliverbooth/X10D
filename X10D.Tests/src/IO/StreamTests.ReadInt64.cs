using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void ReadInt64BigEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadInt64BigEndian());
    }

    [Test]
    public void ReadInt64LittleEndian_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadInt64LittleEndian());
    }

    [Test]
    public void ReadInt64BigEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadInt64BigEndian());
    }

    [Test]
    public void ReadInt64LittleEndian_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadInt64LittleEndian());
    }

    [Test]
    public void ReadInt64BigEndian_ShouldReadBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0xA4 };
        stream.Write(bytes);
        stream.Position = 0;

        const long expected = 420;
        long actual = stream.ReadInt64BigEndian();

        Assert.That(stream.Position, Is.EqualTo(8));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReadInt64LittleEndian_ShouldWriteLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] { 0xA4, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        stream.Write(bytes);
        stream.Position = 0;

        const long expected = 420;
        long actual = stream.ReadInt64LittleEndian();

        Assert.That(stream.Position, Is.EqualTo(8));
        Assert.That(actual, Is.EqualTo(expected));
    }
}
