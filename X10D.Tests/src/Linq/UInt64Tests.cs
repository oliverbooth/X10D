using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
[CLSCompliant(false)]
public class UInt64Tests
{
    [Test]
    public void ProductShouldBeCorrect()
    {
        ulong Cast(int i) => (ulong)i;

        Assert.That(Enumerable.Range(0, 10).Select(Cast).Product(), Is.EqualTo(0UL));
        Assert.That(Enumerable.Range(1, 1).Select(Cast).Product(), Is.EqualTo(1UL));
        Assert.That(Enumerable.Range(1, 2).Select(Cast).Product(), Is.EqualTo(2UL));
        Assert.That(Enumerable.Range(1, 3).Select(Cast).Product(), Is.EqualTo(6UL));
        Assert.That(Enumerable.Range(1, 4).Select(Cast).Product(), Is.EqualTo(24UL));
        Assert.That(Enumerable.Range(1, 5).Select(Cast).Product(), Is.EqualTo(120UL));
        Assert.That(Enumerable.Range(1, 6).Select(Cast).Product(), Is.EqualTo(720UL));
        Assert.That(Enumerable.Range(1, 7).Select(Cast).Product(), Is.EqualTo(5040UL));
        Assert.That(Enumerable.Range(1, 8).Select(Cast).Product(), Is.EqualTo(40320UL));
        Assert.That(Enumerable.Range(1, 9).Select(Cast).Product(), Is.EqualTo(362880UL));
        Assert.That(Enumerable.Range(1, 10).Select(Cast).Product(), Is.EqualTo(3628800UL));
    }

    [Test]
    public void ProductOfDoublesShouldBeCorrect()
    {
        ulong Double(int i) => (ulong)i * 2;

        Assert.That(Enumerable.Range(0, 10).Product(Double), Is.EqualTo(0UL));
        Assert.That(Enumerable.Range(1, 1).Product(Double), Is.EqualTo(2UL));
        Assert.That(Enumerable.Range(1, 2).Product(Double), Is.EqualTo(8UL));
        Assert.That(Enumerable.Range(1, 3).Product(Double), Is.EqualTo(48UL));
        Assert.That(Enumerable.Range(1, 4).Product(Double), Is.EqualTo(384UL));
        Assert.That(Enumerable.Range(1, 5).Product(Double), Is.EqualTo(3840UL));
        Assert.That(Enumerable.Range(1, 6).Product(Double), Is.EqualTo(46080UL));
        Assert.That(Enumerable.Range(1, 7).Product(Double), Is.EqualTo(645120UL));
        Assert.That(Enumerable.Range(1, 8).Product(Double), Is.EqualTo(10321920UL));
        Assert.That(Enumerable.Range(1, 9).Product(Double), Is.EqualTo(185794560UL));
        Assert.That(Enumerable.Range(1, 10).Product(Double), Is.EqualTo(3715891200UL));
    }

    [Test]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<ulong> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.Product());
        Assert.Throws<ArgumentNullException>(() => source.Product(v => v));
    }
}
