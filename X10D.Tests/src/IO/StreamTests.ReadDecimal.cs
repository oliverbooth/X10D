using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void ReadDecimal_ShouldThrowArgumentException_GivenNonReadableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.ReadDecimal());
        Assert.Throws<ArgumentException>(() => stream.ReadDecimal(Endianness.LittleEndian));
        Assert.Throws<ArgumentException>(() => stream.ReadDecimal(Endianness.BigEndian));
    }

    [Test]
    public void ReadDecimal_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.ReadDecimal());
        Assert.Throws<ArgumentNullException>(() => stream.ReadDecimal(Endianness.LittleEndian));
        Assert.Throws<ArgumentNullException>(() => stream.ReadDecimal(Endianness.BigEndian));
    }

    [Test]
    public void ReadDecimal_ShouldThrowArgumentOutOfRangeException_GivenInvalidEndiannessValue()
    {
        // we don't need to enclose this stream in a using declaration, since disposing a
        // null stream is meaningless. NullStream.Dispose actually does nothing, anyway.
        // that - coupled with the fact that encapsulating the stream in a using declaration causes the
        // analyser to trip up and think the stream is disposed by the time the local is captured in
        // assertion lambda - means this line is fine as it is. please do not change.
        Stream stream = Stream.Null;
        Assert.Throws<ArgumentOutOfRangeException>(() => stream.ReadDecimal((Endianness)(-1)));
    }

    [Test]
    public void ReadDecimal_ShouldReadBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[]
        {
            0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x68
        };
        stream.Write(bytes);
        stream.Position = 0;

        const decimal expected = 420.0m;
        decimal actual = stream.ReadDecimal(Endianness.BigEndian);

        Assert.Multiple(() =>
        {
            Assert.That(stream.Position, Is.EqualTo(16));
            Assert.That(actual, Is.EqualTo(expected));
        });
    }

    [Test]
    public void ReadDecimal_ShouldWriteLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        ReadOnlySpan<byte> bytes = stackalloc byte[]
        {
            0x68, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00
        };
        stream.Write(bytes);
        stream.Position = 0;

        const decimal expected = 420.0m;
        decimal actual = stream.ReadDecimal(Endianness.LittleEndian);

        Assert.Multiple(() =>
        {
            Assert.That(stream.Position, Is.EqualTo(16));
            Assert.That(actual, Is.EqualTo(expected));
        });
    }
}
