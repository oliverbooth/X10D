using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class SByteTests
{
    [Test]
    public void GetBytes_ReturnsArrayContainingItself()
    {
        const sbyte value = 0x0F;
        CollectionAssert.AreEqual(new[] {(byte)value}, value.GetBytes());
    }

    [Test]
    public void TryWriteBytes_ReturnsTrue_FillsSpanContainingItself_GivenLargeEnoughSpan()
    {
        const sbyte value = 0x0F;
        Span<byte> buffer = stackalloc byte[1];
        Assert.That(value.TryWriteBytes(buffer));
        CollectionAssert.AreEqual(new[] {(byte)value}, buffer.ToArray());
    }

    [Test]
    public void TryWriteBytes_ReturnsFalse_GivenSmallSpan()
    {
        const sbyte value = 0x0F;
        Span<byte> buffer = stackalloc byte[0];
        Assert.That(value.TryWriteBytes(buffer), Is.False);
    }
}
