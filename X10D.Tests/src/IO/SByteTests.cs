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
        Assert.That(value.GetBytes(), Is.EqualTo(new[] { (byte)value }).AsCollection);
    }

    [Test]
    public void TryWriteBytes_ReturnsTrue_FillsSpanContainingItself_GivenLargeEnoughSpan()
    {
        const sbyte value = 0x0F;
        Assert.Multiple(() =>
        {
            Span<byte> buffer = stackalloc byte[1];
            Assert.That(value.TryWriteBytes(buffer));
            Assert.That(buffer.ToArray(), Is.EqualTo(new[] { (byte)value }).AsCollection);
        });
    }

    [Test]
    public void TryWriteBytes_ReturnsFalse_GivenSmallSpan()
    {
        const sbyte value = 0x0F;
        Span<byte> buffer = [];
        Assert.That(value.TryWriteBytes(buffer), Is.False);
    }
}
