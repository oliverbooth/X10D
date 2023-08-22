using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
internal partial class UInt32Tests
{
    [Test]
    public void CountDigits_ShouldReturn1_Given0()
    {
        const uint value = 0;
        const int expected = 1;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountDigits_ShouldReturn1_Given1()
    {
        const uint value = 1;
        const int expected = 1;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void CountDigits_ShouldReturn2_Given10()
    {
        const uint value = 10;
        const int expected = 2;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountDigits_ShouldReturn3_Given199()
    {
        const uint value = 199;
        const int expected = 3;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DigitalRootShouldBeCorrect()
    {
        const uint value = 238;
        Assert.That(value.DigitalRoot(), Is.EqualTo(4U));
        Assert.That((-value).DigitalRoot(), Is.EqualTo(4U));
    }

    [Test]
    public void FactorialShouldBeCorrect()
    {
        Assert.That(0U.Factorial(), Is.EqualTo(1UL));
        Assert.That(1U.Factorial(), Is.EqualTo(1UL));
        Assert.That(2U.Factorial(), Is.EqualTo(2UL));
        Assert.That(3U.Factorial(), Is.EqualTo(6UL));
        Assert.That(4U.Factorial(), Is.EqualTo(24UL));
        Assert.That(5U.Factorial(), Is.EqualTo(120UL));
        Assert.That(6U.Factorial(), Is.EqualTo(720UL));
        Assert.That(7U.Factorial(), Is.EqualTo(5040UL));
        Assert.That(8U.Factorial(), Is.EqualTo(40320UL));
        Assert.That(9U.Factorial(), Is.EqualTo(362880UL));
        Assert.That(10U.Factorial(), Is.EqualTo(3628800UL));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const uint first = 5U;
        const uint second = 7U;

        uint multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(1U));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const uint first = 12U;
        const uint second = 18U;

        uint multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(6U));
    }

    [Test]
    public void IsEvenShouldBeCorrect()
    {
        const uint one = 1;
        const uint two = 2;

        Assert.That(one.IsEven(), Is.False);
        Assert.That(two.IsEven());
    }

    [Test]
    public void IsOddShouldBeCorrect()
    {
        const uint one = 1;
        const uint two = 2;

        Assert.That(one.IsOdd());
        Assert.That(two.IsOdd(), Is.False);
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const uint value1 = 2;
        const uint value2 = 3;
        const uint expected = 6;

        uint result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const uint value1 = 0;
        const uint value2 = 10;
        const uint expected = 0;

        uint result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const uint value1 = 1;
        const uint value2 = 10;
        const uint expected = 10;

        uint result1 = value1.LowestCommonMultiple(value2);
        uint result2 = value2.LowestCommonMultiple(value1);

        Assert.That(result1, Is.EqualTo(expected));
        Assert.That(result2, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const uint value1 = 5;
        const uint value2 = 5;
        const uint expected = 5;

        uint result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplicativePersistence_ShouldReturn1_ForAnyDigitBeing0()
    {
        Assert.That(10U.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(201U.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(200U.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(20007U.MultiplicativePersistence(), Is.EqualTo(1));
    }

    [Test]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.That(0U.MultiplicativePersistence(), Is.Zero);
        Assert.That(10U.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(25U.MultiplicativePersistence(), Is.EqualTo(2));
        Assert.That(39U.MultiplicativePersistence(), Is.EqualTo(3));
        Assert.That(77U.MultiplicativePersistence(), Is.EqualTo(4));
        Assert.That(679U.MultiplicativePersistence(), Is.EqualTo(5));
        Assert.That(6788U.MultiplicativePersistence(), Is.EqualTo(6));
        Assert.That(68889U.MultiplicativePersistence(), Is.EqualTo(7));
        Assert.That(2677889U.MultiplicativePersistence(), Is.EqualTo(8));
        Assert.That(26888999U.MultiplicativePersistence(), Is.EqualTo(9));
        Assert.That(3778888999U.MultiplicativePersistence(), Is.EqualTo(10));
    }
}
