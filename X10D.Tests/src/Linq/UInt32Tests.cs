using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
internal class UInt32Tests
{
    [Test]
    public void ProductShouldBeCorrect()
    {
        ulong Cast(int i) => (ulong)i;

        Assert.That(Enumerable.Range(0, 10).Select(Cast).Product(), Is.EqualTo(0U));
        Assert.That(Enumerable.Range(1, 1).Select(Cast).Product(), Is.EqualTo(1U));
        Assert.That(Enumerable.Range(1, 2).Select(Cast).Product(), Is.EqualTo(2U));
        Assert.That(Enumerable.Range(1, 3).Select(Cast).Product(), Is.EqualTo(6U));
        Assert.That(Enumerable.Range(1, 4).Select(Cast).Product(), Is.EqualTo(24U));
        Assert.That(Enumerable.Range(1, 5).Select(Cast).Product(), Is.EqualTo(120U));
        Assert.That(Enumerable.Range(1, 6).Select(Cast).Product(), Is.EqualTo(720U));
        Assert.That(Enumerable.Range(1, 7).Select(Cast).Product(), Is.EqualTo(5040U));
        Assert.That(Enumerable.Range(1, 8).Select(Cast).Product(), Is.EqualTo(40320U));
        Assert.That(Enumerable.Range(1, 9).Select(Cast).Product(), Is.EqualTo(362880U));
        Assert.That(Enumerable.Range(1, 10).Select(Cast).Product(), Is.EqualTo(3628800U));
    }

    [Test]
    public void ProductOfDoublesShouldBeCorrect()
    {
        uint Double(int i) => (uint)i * 2;

        Assert.That(Enumerable.Range(0, 10).Product(Double), Is.EqualTo(0U));
        Assert.That(Enumerable.Range(1, 1).Product(Double), Is.EqualTo(2U));
        Assert.That(Enumerable.Range(1, 2).Product(Double), Is.EqualTo(8U));
        Assert.That(Enumerable.Range(1, 3).Product(Double), Is.EqualTo(48U));
        Assert.That(Enumerable.Range(1, 4).Product(Double), Is.EqualTo(384U));
        Assert.That(Enumerable.Range(1, 5).Product(Double), Is.EqualTo(3840U));
        Assert.That(Enumerable.Range(1, 6).Product(Double), Is.EqualTo(46080U));
        Assert.That(Enumerable.Range(1, 7).Product(Double), Is.EqualTo(645120U));
        Assert.That(Enumerable.Range(1, 8).Product(Double), Is.EqualTo(10321920U));
        Assert.That(Enumerable.Range(1, 9).Product(Double), Is.EqualTo(185794560U));
        Assert.That(Enumerable.Range(1, 10).Product(Double), Is.EqualTo(3715891200U));
    }

    [Test]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<uint> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.Product());
        Assert.Throws<ArgumentNullException>(() => source.Product(v => v));
    }
}
