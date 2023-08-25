using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
internal class SingleTests
{
    [Test]
    public void ProductShouldBeCorrect()
    {
        float Cast(int i) => i;

        Assert.That(Enumerable.Range(0, 10).Select(Cast).Product(), Is.EqualTo(0f));
        Assert.That(Enumerable.Range(1, 1).Select(Cast).Product(), Is.EqualTo(1f));
        Assert.That(Enumerable.Range(1, 2).Select(Cast).Product(), Is.EqualTo(2f));
        Assert.That(Enumerable.Range(1, 3).Select(Cast).Product(), Is.EqualTo(6f));
        Assert.That(Enumerable.Range(1, 4).Select(Cast).Product(), Is.EqualTo(24f));
        Assert.That(Enumerable.Range(1, 5).Select(Cast).Product(), Is.EqualTo(120f));
        Assert.That(Enumerable.Range(1, 6).Select(Cast).Product(), Is.EqualTo(720f));
        Assert.That(Enumerable.Range(1, 7).Select(Cast).Product(), Is.EqualTo(5040f));
        Assert.That(Enumerable.Range(1, 8).Select(Cast).Product(), Is.EqualTo(40320f));
        Assert.That(Enumerable.Range(1, 9).Select(Cast).Product(), Is.EqualTo(362880f));
        Assert.That(Enumerable.Range(1, 10).Select(Cast).Product(), Is.EqualTo(3628800f));
    }

    [Test]
    public void ProductOfDoublesShouldBeCorrect()
    {
        float Double(int i) => i * 2f;

        Assert.That(Enumerable.Range(0, 10).Product(Double), Is.EqualTo(0f));
        Assert.That(Enumerable.Range(1, 1).Product(Double), Is.EqualTo(2f));
        Assert.That(Enumerable.Range(1, 2).Product(Double), Is.EqualTo(8f));
        Assert.That(Enumerable.Range(1, 3).Product(Double), Is.EqualTo(48f));
        Assert.That(Enumerable.Range(1, 4).Product(Double), Is.EqualTo(384f));
        Assert.That(Enumerable.Range(1, 5).Product(Double), Is.EqualTo(3840f));
        Assert.That(Enumerable.Range(1, 6).Product(Double), Is.EqualTo(46080f));
        Assert.That(Enumerable.Range(1, 7).Product(Double), Is.EqualTo(645120f));
        Assert.That(Enumerable.Range(1, 8).Product(Double), Is.EqualTo(10321920f));
        Assert.That(Enumerable.Range(1, 9).Product(Double), Is.EqualTo(185794560f));
        Assert.That(Enumerable.Range(1, 10).Product(Double), Is.EqualTo(3715891200f));
    }

    [Test]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<float> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.Product());
        Assert.Throws<ArgumentNullException>(() => source.Product(v => v));
    }
}
