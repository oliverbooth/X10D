using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

internal partial class StreamTests
{
    [Test]
    public void WriteInt16_ShouldThrowArgumentException_GivenNonWriteableStream()
    {
        Stream stream = new DummyStream();
        Assert.Throws<ArgumentException>(() => stream.Write((short)420, Endianness.LittleEndian));
        Assert.Throws<ArgumentException>(() => stream.Write((short)420, Endianness.BigEndian));
    }

    [Test]
    public void WriteInt16_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.Throws<ArgumentNullException>(() => stream.Write((short)420, Endianness.LittleEndian));
        Assert.Throws<ArgumentNullException>(() => stream.Write((short)420, Endianness.BigEndian));
    }

    [Test]
    public void WriteInt16_ShouldThrowArgumentOutOfRangeException_GivenInvalidEndiannessValue()
    {
        // we don't need to enclose this stream in a using declaration, since disposing a
        // null stream is meaningless. NullStream.Dispose actually does nothing, anyway.
        // that - coupled with the fact that encapsulating the stream in a using declaration causes the
        // analyser to trip up and think the stream is disposed by the time the local is captured in
        // assertion lambda - means this line is fine as it is. please do not change.
        Stream stream = Stream.Null;
        Assert.Throws<ArgumentOutOfRangeException>(() => stream.Write((short)420, (Endianness)(-1)));
        Assert.Throws<ArgumentOutOfRangeException>(() => stream.Write((short)420, (Endianness)(-1)));
    }

    [Test]
    public void WriteInt16_ShouldWriteBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        stream.Write((short)420, Endianness.BigEndian);
        Assert.That(stream.Position, Is.EqualTo(2));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[2];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0x01, 0xA4};
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(2));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }

    [Test]
    public void WriteInt16_ShouldWriteLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        stream.Write((short)420, Endianness.LittleEndian);
        Assert.That(stream.Position, Is.EqualTo(2));
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[2];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0xA4, 0x01};
        int read = stream.Read(actual);

        Assert.That(read, Is.EqualTo(2));
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }
}
