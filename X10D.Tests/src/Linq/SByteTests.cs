using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
internal class SByteTests
{
    [Test]
    public void ProductShouldBeCorrect()
    {
        sbyte Cast(int i) => (sbyte)i;

        Assert.That(Enumerable.Range(0, 10).Select(Cast).Product(), Is.Zero);
        Assert.That(Enumerable.Range(1, 1).Select(Cast).Product(), Is.EqualTo(1));
        Assert.That(Enumerable.Range(1, 2).Select(Cast).Product(), Is.EqualTo(2));
        Assert.That(Enumerable.Range(1, 3).Select(Cast).Product(), Is.EqualTo(6));
        Assert.That(Enumerable.Range(1, 4).Select(Cast).Product(), Is.EqualTo(24));
        Assert.That(Enumerable.Range(1, 5).Select(Cast).Product(), Is.EqualTo(120));

        // 6! will overflow for sbyte
    }

    [Test]
    public void ProductOfDoublesShouldBeCorrect()
    {
        sbyte Double(int i) => (sbyte)(i * 2);

        Assert.That(Enumerable.Range(0, 10).Product(Double), Is.Zero);
        Assert.That(Enumerable.Range(1, 1).Product(Double), Is.EqualTo(2));
        Assert.That(Enumerable.Range(1, 2).Product(Double), Is.EqualTo(8));
        Assert.That(Enumerable.Range(1, 3).Product(Double), Is.EqualTo(48));

        // Π_(i=1)^(n(i*2)) will overflow at i=4 for sbyte
    }

    [Test]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<sbyte> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.Product());
        Assert.Throws<ArgumentNullException>(() => source.Product(v => v));
    }
}
