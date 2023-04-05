using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
[CLSCompliant(false)]
public partial class UInt64Tests
{
    [Test]
    public void DigitalRootShouldBeCorrect()
    {
        const ulong value = 238;
        Assert.That(value.DigitalRoot(), Is.EqualTo(4U));

        // -ulong operator not defined because it might exceed long.MinValue,
        // so instead, cast to long and then negate.
        // HAX.
        Assert.That((-(long)value).DigitalRoot(), Is.EqualTo(4U));
    }

    [Test]
    public void FactorialShouldBeCorrect()
    {
        Assert.That(0UL.Factorial(), Is.EqualTo(1UL));
        Assert.That(1UL.Factorial(), Is.EqualTo(1UL));
        Assert.That(2UL.Factorial(), Is.EqualTo(2UL));
        Assert.That(3UL.Factorial(), Is.EqualTo(6UL));
        Assert.That(4UL.Factorial(), Is.EqualTo(24UL));
        Assert.That(5UL.Factorial(), Is.EqualTo(120UL));
        Assert.That(6UL.Factorial(), Is.EqualTo(720UL));
        Assert.That(7UL.Factorial(), Is.EqualTo(5040UL));
        Assert.That(8UL.Factorial(), Is.EqualTo(40320UL));
        Assert.That(9UL.Factorial(), Is.EqualTo(362880UL));
        Assert.That(10UL.Factorial(), Is.EqualTo(3628800UL));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const ulong first = 5UL;
        const ulong second = 7UL;

        ulong multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(1UL));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const ulong first = 12UL;
        const ulong second = 18UL;

        ulong multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(6UL));
    }

    [Test]
    public void IsEvenShouldBeCorrect()
    {
        const ulong one = 1;
        const ulong two = 2;

        Assert.That(one.IsEven(), Is.False);
        Assert.That(two.IsEven());
    }

    [Test]
    public void IsOddShouldBeCorrect()
    {
        const ulong one = 1;
        const ulong two = 2;

        Assert.That(one.IsOdd());
        Assert.That(two.IsOdd(), Is.False);
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const ulong value1 = 2;
        const ulong value2 = 3;
        const ulong expected = 6;

        ulong result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const ulong value1 = 0;
        const ulong value2 = 10;
        const ulong expected = 0;

        ulong result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const ulong value1 = 1;
        const ulong value2 = 10;
        const ulong expected = 10;

        ulong result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const ulong value1 = 5;
        const ulong value2 = 5;
        const ulong expected = 5;

        ulong result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplicativePersistence_ShouldReturn1_ForAnyDigitBeing0()
    {
        Assert.That(10UL.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(201UL.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(200UL.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(20007UL.MultiplicativePersistence(), Is.EqualTo(1));
    }

    [Test]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.That(0UL.MultiplicativePersistence(), Is.Zero);
        Assert.That(10UL.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(25UL.MultiplicativePersistence(), Is.EqualTo(2));
        Assert.That(39UL.MultiplicativePersistence(), Is.EqualTo(3));
        Assert.That(77UL.MultiplicativePersistence(), Is.EqualTo(4));
        Assert.That(679UL.MultiplicativePersistence(), Is.EqualTo(5));
        Assert.That(6788UL.MultiplicativePersistence(), Is.EqualTo(6));
        Assert.That(68889UL.MultiplicativePersistence(), Is.EqualTo(7));
        Assert.That(2677889UL.MultiplicativePersistence(), Is.EqualTo(8));
        Assert.That(26888999UL.MultiplicativePersistence(), Is.EqualTo(9));
        Assert.That(3778888999UL.MultiplicativePersistence(), Is.EqualTo(10));
        Assert.That(277777788888899UL.MultiplicativePersistence(), Is.EqualTo(11));
    }
}
