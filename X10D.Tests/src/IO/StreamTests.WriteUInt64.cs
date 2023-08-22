using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
        public void WriteUInt64_ShouldThrowArgumentException_GivenNonWriteableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.Write(420UL, Endianness.LittleEndian));
        Assert.Throws<ArgumentException>(() => stream.Write(420UL, Endianness.BigEndian));
    }

    [Test]
        public void WriteUInt64_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.Write(420UL, Endianness.LittleEndian));
        Assert.Throws<ArgumentNullException>(() => stream.Write(420UL, Endianness.BigEndian));
    }

    [Test]
        public void WriteUInt64_ShouldThrowArgumentOutOfRangeException_GivenInvalidEndiannessValue()
    {
        // we don't need to enclose this stream in a using declaration, since disposing a
        // null stream is meaningless. NullStream.Dispose actually does nothing, anyway.
        // that - coupled with the fact that encapsulating the stream in a using declaration causes the
        // analyser to trip up and think the stream is disposed by the time the local is captured in
        // assertion lambda - means this line is fine as it is. please do not change.
        Stream stream = Stream.Null;
        Assert.Throws<ArgumentOutOfRangeException>(() => stream.Write(420UL, (Endianness)(-1)));
        Assert.Throws<ArgumentOutOfRangeException>(() => stream.Write(420UL, (Endianness)(-1)));
    }

    [Test]
        public void WriteUInt64_ShouldWriteBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        stream.Write(420UL, Endianness.BigEndian);
        Assert.That(stream.Position, Is.EqualTo(8));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[8];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0xA4};
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(8));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }

    [Test]
        public void WriteUInt64_ShouldWriteLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        stream.Write(420UL, Endianness.LittleEndian);
        Assert.That(stream.Position, Is.EqualTo(8));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[8];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0xA4, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(8));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }
}
