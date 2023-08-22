using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
internal class Int16Tests
{
    [Test]
    public void ProductShouldBeCorrect()
    {
        short Cast(int i) => (short)i;
        Assert.Multiple(() =>
        {
            Assert.That(Enumerable.Range(0, 10).Select(Cast).Product(), Is.Zero);
            Assert.That(Enumerable.Range(1, 1).Select(Cast).Product(), Is.EqualTo(1));
            Assert.That(Enumerable.Range(1, 2).Select(Cast).Product(), Is.EqualTo(2));
            Assert.That(Enumerable.Range(1, 3).Select(Cast).Product(), Is.EqualTo(6));
            Assert.That(Enumerable.Range(1, 4).Select(Cast).Product(), Is.EqualTo(24));
            Assert.That(Enumerable.Range(1, 5).Select(Cast).Product(), Is.EqualTo(120));
            Assert.That(Enumerable.Range(1, 6).Select(Cast).Product(), Is.EqualTo(720));
            Assert.That(Enumerable.Range(1, 7).Select(Cast).Product(), Is.EqualTo(5040));
        });
    }

    [Test]
    public void ProductOfDoublesShouldBeCorrect()
    {
        short Double(int i) => (short)(i * 2);

        Assert.That(Enumerable.Range(0, 10).Product(Double), Is.Zero);
        Assert.That(Enumerable.Range(1, 1).Product(Double), Is.EqualTo(2));
        Assert.That(Enumerable.Range(1, 2).Product(Double), Is.EqualTo(8));
        Assert.That(Enumerable.Range(1, 3).Product(Double), Is.EqualTo(48));
        Assert.That(Enumerable.Range(1, 4).Product(Double), Is.EqualTo(384));
        Assert.That(Enumerable.Range(1, 5).Product(Double), Is.EqualTo(3840));

        // Π_(i=1)^n (2i) will overflow at i=6 for short
    }

    [Test]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<short> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.Product());
    }

    [Test]
    public void RangeTo_Int16_ShouldYieldCorrectValues()
    {
        const short start = 1;
        const short end = 10;

        short current = 1;

        foreach (short value in start.RangeTo(end))
        {
            Assert.That(value, Is.EqualTo(current++));
        }

        Assert.That(current, Is.EqualTo(end));
    }

    [Test]
    public void RangeTo_Int32_ShouldYieldCorrectValues()
    {
        const short start = 1;
        const int end = 10;

        var current = 1;

        foreach (int value in start.RangeTo(end))
        {
            Assert.That(value, Is.EqualTo(current++));
        }

        Assert.That(current, Is.EqualTo(end));
    }

    [Test]
    public void RangeTo_Int64_ShouldYieldCorrectValues()
    {
        const short start = 1;
        const long end = 10;

        long current = 1;

        foreach (long value in start.RangeTo(end))
        {
            Assert.That(value, Is.EqualTo(current++));
        }

        Assert.That(current, Is.EqualTo(end));
    }
}
