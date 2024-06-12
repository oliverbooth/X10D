using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
internal class DecimalTests
{
    [Test]
    public void ProductShouldBeCorrect()
    {
        decimal Cast(int i) => i;

        Assert.Multiple(() =>
        {
            Assert.That(Enumerable.Range(0, 10).Select(Cast).Product(), Is.EqualTo(0m));
            Assert.That(Enumerable.Range(1, 1).Select(Cast).Product(), Is.EqualTo(1m));
            Assert.That(Enumerable.Range(1, 2).Select(Cast).Product(), Is.EqualTo(2m));
            Assert.That(Enumerable.Range(1, 3).Select(Cast).Product(), Is.EqualTo(6m));
            Assert.That(Enumerable.Range(1, 4).Select(Cast).Product(), Is.EqualTo(24m));
            Assert.That(Enumerable.Range(1, 5).Select(Cast).Product(), Is.EqualTo(120m));
            Assert.That(Enumerable.Range(1, 6).Select(Cast).Product(), Is.EqualTo(720m));
            Assert.That(Enumerable.Range(1, 7).Select(Cast).Product(), Is.EqualTo(5040m));
            Assert.That(Enumerable.Range(1, 8).Select(Cast).Product(), Is.EqualTo(40320m));
            Assert.That(Enumerable.Range(1, 9).Select(Cast).Product(), Is.EqualTo(362880m));
            Assert.That(Enumerable.Range(1, 10).Select(Cast).Product(), Is.EqualTo(3628800m));
        });
    }

    [Test]
    public void ProductOfDoublesShouldBeCorrect()
    {
        decimal Double(int i) => i * 2m;

        Assert.Multiple(() =>
        {
            Assert.That(Enumerable.Range(0, 10).Product(Double), Is.EqualTo(0m));
            Assert.That(Enumerable.Range(1, 1).Product(Double), Is.EqualTo(2m));
            Assert.That(Enumerable.Range(1, 2).Product(Double), Is.EqualTo(8m));
            Assert.That(Enumerable.Range(1, 3).Product(Double), Is.EqualTo(48m));
            Assert.That(Enumerable.Range(1, 4).Product(Double), Is.EqualTo(384m));
            Assert.That(Enumerable.Range(1, 5).Product(Double), Is.EqualTo(3840m));
            Assert.That(Enumerable.Range(1, 6).Product(Double), Is.EqualTo(46080m));
            Assert.That(Enumerable.Range(1, 7).Product(Double), Is.EqualTo(645120m));
            Assert.That(Enumerable.Range(1, 8).Product(Double), Is.EqualTo(10321920m));
            Assert.That(Enumerable.Range(1, 9).Product(Double), Is.EqualTo(185794560m));
            Assert.That(Enumerable.Range(1, 10).Product(Double), Is.EqualTo(3715891200m));
        });
    }

    [Test]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<decimal> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.Product());
        Assert.Throws<ArgumentNullException>(() => source.Product(v => v));
    }
}
