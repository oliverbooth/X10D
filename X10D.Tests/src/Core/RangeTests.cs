using NUnit.Framework;
using X10D.Core;

namespace X10D.Tests.Core;

[TestFixture]
internal class RangeTests
{
    [Test]
    public void Range_GetEnumerator_ShouldReturnRangeEnumerator()
    {
        Assert.Multiple(() =>
        {
            Assert.That(5..10, Is.TypeOf<Range>());
            Assert.That((5..10).GetEnumerator(), Is.TypeOf<RangeEnumerator>());
        });
    }

    [Test]
    public void Loop_OverRange0To10_ShouldCountFrom0To10Inclusive()
    {
        int value = 0;

        foreach (int i in 0..10)
        {
            Assert.That(i, Is.EqualTo(value));
            value++;
        }
    }

    [Test]
    public void Loop_OverRangeNegative5To5_ShouldCountFromNegative5To5Inclusive()
    {
        int value = -5;

        foreach (int i in ^5..5)
        {
            Assert.That(i, Is.EqualTo(value));
            value++;
        }
    }

    [Test]
    public void Loop_OverRange5ToNegative5_ShouldCountFrom5ToNegative5Inclusive()
    {
        int value = 5;

        foreach (int i in 5..^5)
        {
            Assert.That(i, Is.EqualTo(value));
            value--;
        }
    }

    [Test]
    public void Loop_OverRange10To0_ShouldCountFrom10To0Inclusive()
    {
        int value = 10;

        foreach (int i in 10..0)
        {
            Assert.That(i, Is.EqualTo(value));
            value--;
        }
    }
}
