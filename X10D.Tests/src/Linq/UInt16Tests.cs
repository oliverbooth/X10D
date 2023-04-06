using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
[CLSCompliant(false)]
public class UInt16Tests
{
    [Test]
    public void ProductShouldBeCorrect()
    {
        ushort Cast(int i) => (ushort)i;

        Assert.That(Enumerable.Range(0, 10).Select(Cast).Product(), Is.EqualTo(0U));
        Assert.That(Enumerable.Range(1, 1).Select(Cast).Product(), Is.EqualTo(1U));
        Assert.That(Enumerable.Range(1, 2).Select(Cast).Product(), Is.EqualTo(2U));
        Assert.That(Enumerable.Range(1, 3).Select(Cast).Product(), Is.EqualTo(6U));
        Assert.That(Enumerable.Range(1, 4).Select(Cast).Product(), Is.EqualTo(24U));
        Assert.That(Enumerable.Range(1, 5).Select(Cast).Product(), Is.EqualTo(120U));
        Assert.That(Enumerable.Range(1, 6).Select(Cast).Product(), Is.EqualTo(720U));
        Assert.That(Enumerable.Range(1, 7).Select(Cast).Product(), Is.EqualTo(5040U));
        Assert.That(Enumerable.Range(1, 8).Select(Cast).Product(), Is.EqualTo(40320U));

        // 9! will overflow for ushort
    }

    [Test]
    public void ProductOfDoublesShouldBeCorrect()
    {
        ushort Double(int i) => (ushort)(i * 2);

        Assert.That(Enumerable.Range(0, 10).Product(Double), Is.EqualTo(0U));
        Assert.That(Enumerable.Range(1, 1).Product(Double), Is.EqualTo(2U));
        Assert.That(Enumerable.Range(1, 2).Product(Double), Is.EqualTo(8U));
        Assert.That(Enumerable.Range(1, 3).Product(Double), Is.EqualTo(48U));
        Assert.That(Enumerable.Range(1, 4).Product(Double), Is.EqualTo(384U));
        Assert.That(Enumerable.Range(1, 5).Product(Double), Is.EqualTo(3840U));
        Assert.That(Enumerable.Range(1, 6).Product(Double), Is.EqualTo(46080U));

        // Π_(i=1)^n (2i) will overflow at i=7 for ushort
    }

    [Test]
    public void Product_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<ushort> source = null!;
        Assert.Throws<ArgumentNullException>(() => source.Product());
        Assert.Throws<ArgumentNullException>(() => source.Product(v => v));
    }
}
