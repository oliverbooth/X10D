using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
internal class ByteTests
{
    [Test]
    public void ProductShouldBeCorrect()
    {
        byte Cast(int i) => (byte)i;

        Assert.That(Enumerable.Range(0, 10).Select(Cast).Product(), Is.Zero);
        Assert.That(Enumerable.Range(1, 1).Select(Cast).Product(), Is.EqualTo(1));
        Assert.That(Enumerable.Range(1, 2).Select(Cast).Product(), Is.EqualTo(2));
        Assert.That(Enumerable.Range(1, 3).Select(Cast).Product(), Is.EqualTo(6));
        Assert.That(Enumerable.Range(1, 4).Select(Cast).Product(), Is.EqualTo(24));
        Assert.That(Enumerable.Range(1, 5).Select(Cast).Product(), Is.EqualTo(120));

        // 6! will overflow for byte
    }

    [Test]
    public void ProductOfDoublesShouldBeCorrect()
    {
        byte Double(int i) => (byte)(i * 2);

        Assert.That(Enumerable.Range(0, 10).Product(Double), Is.Zero);
        Assert.That(Enumerable.Range(1, 1).Product(Double), Is.EqualTo(2));
        Assert.That(Enumerable.Range(1, 2).Product(Double), Is.EqualTo(8));
        Assert.That(Enumerable.Range(1, 3).Product(Double), Is.EqualTo(48));

        // Π_(i=1)^n (2i) will overflow at i=4 for byte
    }

    [Test]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<byte> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.Product());
        Assert.Throws<ArgumentNullException>(() => source.Product(v => v));
    }

    [Test]
    public void RangeTo_ShouldYieldCorrectValues()
    {
        const byte start = 1;
        const byte end = 10;

        byte current = 1;
        foreach (byte value in start.RangeTo(end))
        {
            Assert.That(value, Is.EqualTo(current++));
        }

        Assert.That(current, Is.EqualTo(end));
    }
}
