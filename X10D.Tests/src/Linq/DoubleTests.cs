using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
public class DoubleTests
{
    [Test]
    public void ProductShouldBeCorrect()
    {
        double Cast(int i) => i;

        Assert.Multiple(() =>
        {
            Assert.That(Enumerable.Range(0, 10).Select(Cast).Product(), Is.EqualTo(0.0));
            Assert.That(Enumerable.Range(1, 1).Select(Cast).Product(), Is.EqualTo(1.0));
            Assert.That(Enumerable.Range(1, 2).Select(Cast).Product(), Is.EqualTo(2.0));
            Assert.That(Enumerable.Range(1, 3).Select(Cast).Product(), Is.EqualTo(6.0));
            Assert.That(Enumerable.Range(1, 4).Select(Cast).Product(), Is.EqualTo(24.0));
            Assert.That(Enumerable.Range(1, 5).Select(Cast).Product(), Is.EqualTo(120.0));
            Assert.That(Enumerable.Range(1, 6).Select(Cast).Product(), Is.EqualTo(720.0));
            Assert.That(Enumerable.Range(1, 7).Select(Cast).Product(), Is.EqualTo(5040.0));
            Assert.That(Enumerable.Range(1, 8).Select(Cast).Product(), Is.EqualTo(40320.0));
            Assert.That(Enumerable.Range(1, 9).Select(Cast).Product(), Is.EqualTo(362880.0));
            Assert.That(Enumerable.Range(1, 10).Select(Cast).Product(), Is.EqualTo(3628800.0));
        });
    }

    [Test]
    public void ProductOfDoublesShouldBeCorrect()
    {
        double Double(int i) => i * 2.0;

        Assert.Multiple(() =>
        {
            Assert.That(Enumerable.Range(0, 10).Product(Double), Is.EqualTo(0.0));
            Assert.That(Enumerable.Range(1, 1).Product(Double), Is.EqualTo(2.0));
            Assert.That(Enumerable.Range(1, 2).Product(Double), Is.EqualTo(8.0));
            Assert.That(Enumerable.Range(1, 3).Product(Double), Is.EqualTo(48.0));
            Assert.That(Enumerable.Range(1, 4).Product(Double), Is.EqualTo(384.0));
            Assert.That(Enumerable.Range(1, 5).Product(Double), Is.EqualTo(3840.0));
            Assert.That(Enumerable.Range(1, 6).Product(Double), Is.EqualTo(46080.0));
            Assert.That(Enumerable.Range(1, 7).Product(Double), Is.EqualTo(645120.0));
            Assert.That(Enumerable.Range(1, 8).Product(Double), Is.EqualTo(10321920.0));
            Assert.That(Enumerable.Range(1, 9).Product(Double), Is.EqualTo(185794560.0));
            Assert.That(Enumerable.Range(1, 10).Product(Double), Is.EqualTo(3715891200.0));
        });
    }

    [Test]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<double> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.Product());
        Assert.Throws<ArgumentNullException>(() => source.Product(v => v));
    }
}
