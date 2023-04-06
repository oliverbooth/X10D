using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
public class Int32Tests
{
    [Test]
    public void ProductShouldBeCorrect()
    {
        Assert.That(Enumerable.Range(0, 10).Product(), Is.Zero);
        Assert.That(Enumerable.Range(1, 1).Product(), Is.EqualTo(1));
        Assert.That(Enumerable.Range(1, 2).Product(), Is.EqualTo(2));
        Assert.That(Enumerable.Range(1, 3).Product(), Is.EqualTo(6));
        Assert.That(Enumerable.Range(1, 4).Product(), Is.EqualTo(24));
        Assert.That(Enumerable.Range(1, 5).Product(), Is.EqualTo(120));
        Assert.That(Enumerable.Range(1, 6).Product(), Is.EqualTo(720));
        Assert.That(Enumerable.Range(1, 7).Product(), Is.EqualTo(5040));
        Assert.That(Enumerable.Range(1, 8).Product(), Is.EqualTo(40320));
        Assert.That(Enumerable.Range(1, 9).Product(), Is.EqualTo(362880));
        Assert.That(Enumerable.Range(1, 10).Product(), Is.EqualTo(3628800));
    }

    [Test]
    public void ProductOfDoublesShouldBeCorrect()
    {
        int Double(int i) => i * 2;

        Assert.That(Enumerable.Range(0, 10).Product(Double), Is.Zero);
        Assert.That(Enumerable.Range(1, 1).Product(Double), Is.EqualTo(2));
        Assert.That(Enumerable.Range(1, 2).Product(Double), Is.EqualTo(8));
        Assert.That(Enumerable.Range(1, 3).Product(Double), Is.EqualTo(48));
        Assert.That(Enumerable.Range(1, 4).Product(Double), Is.EqualTo(384));
        Assert.That(Enumerable.Range(1, 5).Product(Double), Is.EqualTo(3840));
        Assert.That(Enumerable.Range(1, 6).Product(Double), Is.EqualTo(46080));
        Assert.That(Enumerable.Range(1, 7).Product(Double), Is.EqualTo(645120));
        Assert.That(Enumerable.Range(1, 8).Product(Double), Is.EqualTo(10321920));
        Assert.That(Enumerable.Range(1, 9).Product(Double), Is.EqualTo(185794560));

        // Π_(i=1)^n (2i) will overflow at i=10 for int
    }

    [Test]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<int> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.Product());
        Assert.Throws<ArgumentNullException>(() => source.Product(v => v));
    }

    [Test]
    public void RangeTo_Int32_ShouldYieldCorrectValues()
    {
        const int start = 1;
        const int end = 10;

        int current = 1;
        foreach (int value in start.RangeTo(end))
        {
            Assert.That(value, Is.EqualTo(current++));
        }

        Assert.That(current, Is.EqualTo(end));
    }

    [Test]
    public void RangeTo_Int64_ShouldYieldCorrectValues()
    {
        const int start = 1;
        const long end = 10;

        long current = 1;
        foreach (long value in start.RangeTo(end))
        {
            Assert.That(value, Is.EqualTo(current++));
        }

        Assert.That(current, Is.EqualTo(end));
    }
}
