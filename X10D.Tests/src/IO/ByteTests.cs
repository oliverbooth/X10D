using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
public class ByteTests
{
    [Test]
    public void GetBytes_ReturnsArrayContainingItself()
    {
        const byte value = 0xFF;
        CollectionAssert.AreEqual(new[] {value}, value.GetBytes());
    }

    [Test]
    public void TryWriteBytes_ReturnsTrue_FillsSpanContainingItself_GivenLargeEnoughSpan()
    {
        const byte value = 0xFF;
        Span<byte> buffer = stackalloc byte[1];
        Assert.That(value.TryWriteBytes(buffer));
        CollectionAssert.AreEqual(new[] {value}, buffer.ToArray());
    }

    [Test]
    public void TryWriteBytes_ReturnsFalse_GivenSmallSpan()
    {
        const byte value = 0x0F;
        Span<byte> buffer = stackalloc byte[0];
        Assert.That(value.TryWriteBytes(buffer), Is.False);
    }
}
