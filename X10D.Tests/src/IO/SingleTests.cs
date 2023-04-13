using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
public class SingleTests
{
    [Test]
    public void GetBytes_ReturnsCorrectValue()
    {
        const float value = 42.5f;
        byte[] bytes = BitConverter.IsLittleEndian
            ? new byte[] {0, 0, 0x2A, 0x42}
            : new byte[] {0x42, 0x2A, 0, 0};
        CollectionAssert.AreEqual(bytes, value.GetBytes());
    }

    [Test]
    public void GetBytes_ReturnsCorrectValue_WithEndianness()
    {
        const float value = 42.5f;
        byte[] littleEndian = {0, 0, 0x2A, 0x42};
        byte[] bigEndian = {0x42, 0x2A, 0, 0};

        CollectionAssert.AreEqual(littleEndian, value.GetBytes(Endianness.LittleEndian));
        CollectionAssert.AreEqual(bigEndian, value.GetBytes(Endianness.BigEndian));
    }

    [Test]
    public void TryWriteBytes_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan_WithEndianness()
    {
        const float value = 42.5f;
        byte[] littleEndian = {0, 0, 0x2A, 0x42};
        byte[] bigEndian = {0x42, 0x2A, 0, 0};

        Span<byte> buffer = stackalloc byte[4];

        Assert.That(value.TryWriteBytes(buffer, Endianness.LittleEndian));
        CollectionAssert.AreEqual(littleEndian, buffer.ToArray());

        Assert.That(value.TryWriteBytes(buffer, Endianness.BigEndian));
        CollectionAssert.AreEqual(bigEndian, buffer.ToArray());
    }
}
