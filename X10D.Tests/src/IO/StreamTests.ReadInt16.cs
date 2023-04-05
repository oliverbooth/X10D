using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

public partial class StreamTests
{
    [Test]
    public void ReadInt16_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadInt16());
        Assert.Throws<ArgumentException>(() => stream.ReadInt16(Endianness.LittleEndian));
        Assert.Throws<ArgumentException>(() => stream.ReadInt16(Endianness.BigEndian));
    }

    [Test]
    public void ReadInt16_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadInt16());
        Assert.Throws<ArgumentNullException>(() => stream.ReadInt16(Endianness.LittleEndian));
        Assert.Throws<ArgumentNullException>(() => stream.ReadInt16(Endianness.BigEndian));
    }

    [Test]
    public void ReadInt16_ShouldThrowArgumentOutOfRangeException_GivenInvalidEndiannessValue()
    {
        // we don't need to enclose this stream in a using declaration, since disposing a
        // null stream is meaningless. NullStream.Dispose actually does nothing, anyway.
        // that - coupled with the fact that encapsulating the stream in a using declaration causes the
        // analyser to trip up and think the stream is disposed by the time the local is captured in
        // assertion lambda - means this line is fine as it is. please do not change.
        Stream stream = Stream.Null;
        Assert.Throws<ArgumentOutOfRangeException>(() => stream.ReadInt16((Endianness)(-1)));
    }

    [Test]
    public void ReadInt16_ShouldReadBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] {0x01, 0xA4};
        stream.Write(bytes);
        stream.Position = 0;

        const short expected = 420;
        short actual = stream.ReadInt16(Endianness.BigEndian);

        Assert.That(stream.Position, Is.EqualTo(2));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReadInt16_ShouldReadLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[] {0xA4, 0x01};
        stream.Write(bytes);
        stream.Position = 0;

        const short expected = 420;
        short actual = stream.ReadInt16(Endianness.LittleEndian);

        Assert.That(stream.Position, Is.EqualTo(2));
        Assert.That(actual, Is.EqualTo(expected));
    }
}
