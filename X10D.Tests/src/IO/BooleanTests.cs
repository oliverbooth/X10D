using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class BooleanTests
{
    [Test]
    public void GetBytes_ReturnsArrayContaining1()
    {
        const bool value = true;
        Assert.That(value.GetBytes(), Is.EqualTo(new byte[] { 1 }).AsCollection);
    }

    [Test]
    public void TryWriteBytes_ReturnsTrue_FillsSpanContaining1_GivenLargeEnoughSpan()
    {
        const bool value = true;
        Span<byte> buffer = stackalloc byte[1];
        Assert.That(value.TryWriteBytes(buffer));
        Assert.That(buffer.ToArray(), Is.EqualTo(new byte[] { 1 }).AsCollection);
    }

    [Test]
    public void TryWriteBytes_ReturnsFalse_GivenSmallSpan()
    {
        const bool value = true;
        Span<byte> buffer = [];
        Assert.That(value.TryWriteBytes(buffer), Is.False);
    }
}
