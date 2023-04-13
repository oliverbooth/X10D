using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
public class DoubleTests
{
    [Test]
    public void GetBytes_ReturnsCorrectValue()
    {
        const double value = 42.5;
        byte[] bytes = BitConverter.IsLittleEndian
            ? new byte[] {0, 0, 0, 0, 0, 0x40, 0x45, 0x40}
            : new byte[] {0x40, 0x45, 0x40, 0, 0, 0, 0, 0};
        CollectionAssert.AreEqual(bytes, value.GetBytes());
    }

    [Test]
    public void GetBytes_ReturnsCorrectValue_WithEndianness()
    {
        const double value = 42.5;
        byte[] littleEndian = {0, 0, 0, 0, 0, 0x40, 0x45, 0x40};
        byte[] bigEndian = {0x40, 0x45, 0x40, 0, 0, 0, 0, 0};

        CollectionAssert.AreEqual(littleEndian, value.GetBytes(Endianness.LittleEndian));
        CollectionAssert.AreEqual(bigEndian, value.GetBytes(Endianness.BigEndian));
    }

    [Test]
    public void TryWriteBytes_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan_WithEndianness()
    {
        const double value = 42.5;
        byte[] littleEndian = {0, 0, 0, 0, 0, 0x40, 0x45, 0x40};
        byte[] bigEndian = {0x40, 0x45, 0x40, 0, 0, 0, 0, 0};

        Span<byte> buffer = stackalloc byte[8];

        Assert.That(value.TryWriteBytes(buffer, Endianness.LittleEndian));
        CollectionAssert.AreEqual(littleEndian, buffer.ToArray());

        Assert.That(value.TryWriteBytes(buffer, Endianness.BigEndian));
        CollectionAssert.AreEqual(bigEndian, buffer.ToArray());
    }
}
