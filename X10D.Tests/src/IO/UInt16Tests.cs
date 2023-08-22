using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class UInt16Tests
{
    [Test]
    public void GetBytes_ReturnsCorrectValue()
    {
        const ushort value = 0x0F;
        byte[] bytes = BitConverter.IsLittleEndian ? new byte[] {0x0F, 0} : new byte[] {0, 0x0F};
        CollectionAssert.AreEqual(bytes, value.GetBytes());
    }

    [Test]
    public void GetBytes_ReturnsCorrectValue_WithEndianness()
    {
        const ushort value = 0x0F;
        byte[] littleEndian = {0x0F, 0};
        byte[] bigEndian = {0, 0x0F};

        CollectionAssert.AreEqual(littleEndian, value.GetBytes(Endianness.LittleEndian));
        CollectionAssert.AreEqual(bigEndian, value.GetBytes(Endianness.BigEndian));
    }

    [Test]
    public void TryWriteBytes_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan()
    {
        const ushort value = 0x0F;
        byte[] bytes = BitConverter.IsLittleEndian ? new byte[] {0x0F, 0} : new byte[] {0, 0x0F};

        Span<byte> buffer = stackalloc byte[2];
        Assert.That(value.TryWriteBytes(buffer));
        CollectionAssert.AreEqual(bytes, buffer.ToArray());
    }

    [Test]
    public void TryWriteBytes_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan_WithEndianness()
    {
        const ushort value = 0x0F;
        byte[] littleEndian = {0x0F, 0};
        byte[] bigEndian = {0, 0x0F};

        Span<byte> buffer = stackalloc byte[2];

        Assert.That(value.TryWriteBytes(buffer, Endianness.LittleEndian));
        CollectionAssert.AreEqual(littleEndian, buffer.ToArray());

        Assert.That(value.TryWriteBytes(buffer, Endianness.BigEndian));
        CollectionAssert.AreEqual(bigEndian, buffer.ToArray());
    }

    [Test]
    public void TryWriteBytes_ReturnsFalse_GivenSmallSpan()
    {
        const ushort value = 0x0F;
        Span<byte> buffer = stackalloc byte[0];
        Assert.That(value.TryWriteBytes(buffer), Is.False);
    }
}
