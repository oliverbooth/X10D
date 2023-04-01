using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

public partial class StreamTests
{
    [TestMethod]
    public void WriteInt64_ShouldThrowArgumentException_GivenNonWriteableStream()
    {
        Stream stream = new DummyStream();
        Assert.ThrowsException<ArgumentException>(() => stream.Write(420L, Endianness.LittleEndian));
        Assert.ThrowsException<ArgumentException>(() => stream.Write(420L, Endianness.BigEndian));
    }

    [TestMethod]
    public void WriteInt64_ShouldThrowArgumentNullException_GivenNullStream()
    {
        Stream stream = null!;
        Assert.ThrowsException<ArgumentNullException>(() => stream.Write(420L, Endianness.LittleEndian));
        Assert.ThrowsException<ArgumentNullException>(() => stream.Write(420L, Endianness.BigEndian));
    }

    [TestMethod]
    public void WriteInt64_ShouldThrowArgumentOutOfRangeException_GivenInvalidEndiannessValue()
    {
        // we don't need to enclose this stream in a using declaration, since disposing a
        // null stream is meaningless. NullStream.Dispose actually does nothing, anyway.
        // that - coupled with the fact that encapsulating the stream in a using declaration causes the
        // analyser to trip up and think the stream is disposed by the time the local is captured in
        // assertion lambda - means this line is fine as it is. please do not change.
        Stream stream = Stream.Null;
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => stream.Write(420L, (Endianness)(-1)));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => stream.Write(420L, (Endianness)(-1)));
    }

    [TestMethod]
    public void WriteInt64_ShouldWriteBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        stream.Write(420L, Endianness.BigEndian);
        Assert.AreEqual(8, stream.Position);
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[8];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0xA4};
        int read = stream.Read(actual);

        Assert.AreEqual(8, read);
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }

    [TestMethod]
    public void WriteInt64_ShouldWriteLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        stream.Write(420L, Endianness.LittleEndian);
        Assert.AreEqual(8, stream.Position);
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[8];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0xA4, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
        int read = stream.Read(actual);

        Assert.AreEqual(8, read);
        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }
}
