using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
internal partial class Int32Tests
{
    [Test]
    public void CountDigits_ShouldReturn1_Given0()
    {
        const int value = 0;
        const int expected = 1;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountDigits_ShouldReturn1_Given1()
    {
        const int value = 1;
        const int expected = 1;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountDigits_ShouldReturn1_GivenNegative1()
    {
        const int value = -1;
        const int expected = 1;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountDigits_ShouldReturn2_Given10()
    {
        const int value = 10;
        const int expected = 2;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountDigits_ShouldReturn3_Given199()
    {
        const int value = 199;
        const int expected = 3;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DigitalRootShouldBeCorrect()
    {
        const int value = 238;
        Assert.That(value.DigitalRoot(), Is.EqualTo(4));
        Assert.That((-value).DigitalRoot(), Is.EqualTo(4));
    }

    [Test]
    public void FactorialShouldBeCorrect()
    {
        Assert.That(0.Factorial(), Is.EqualTo(1L));
        Assert.That(1.Factorial(), Is.EqualTo(1L));
        Assert.That(2.Factorial(), Is.EqualTo(2L));
        Assert.That(3.Factorial(), Is.EqualTo(6L));
        Assert.That(4.Factorial(), Is.EqualTo(24L));
        Assert.That(5.Factorial(), Is.EqualTo(120L));
        Assert.That(6.Factorial(), Is.EqualTo(720L));
        Assert.That(7.Factorial(), Is.EqualTo(5040L));
        Assert.That(8.Factorial(), Is.EqualTo(40320L));
        Assert.That(9.Factorial(), Is.EqualTo(362880L));
        Assert.That(10.Factorial(), Is.EqualTo(3628800L));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const int first = 5;
        const int second = 7;

        int multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(1));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const int first = 12;
        const int second = 18;

        int multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(6));
    }

    [Test]
    public void IsEvenShouldBeCorrect()
    {
        const int one = 1;
        const int two = 2;

        Assert.That(one.IsEven(), Is.False);
        Assert.That(two.IsEven());
    }

    [Test]
    public void IsOddShouldBeCorrect()
    {
        const int one = 1;
        const int two = 2;

        Assert.That(one.IsOdd());
        Assert.That(two.IsOdd(), Is.False);
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const int value1 = 2;
        const int value2 = 3;
        const int expected = 6;

        int result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const int value1 = 0;
        const int value2 = 10;
        const int expected = 0;

        int result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const int value1 = 1;
        const int value2 = 10;
        const int expected = 10;

        int result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const int value1 = 5;
        const int value2 = 5;
        const int expected = 5;

        int result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithNegativeValues()
    {
        const int value1 = -2;
        const int value2 = 3;
        const int expected = -6;

        int result1 = value1.LowestCommonMultiple(value2);
        int result2 = value2.LowestCommonMultiple(value1);

        Assert.That(result1, Is.EqualTo(expected));
        Assert.That(result2, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplicativePersistence_ShouldReturn1_ForAnyDigitBeing0()
    {
        Assert.That(10.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(201.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(200.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(20007.MultiplicativePersistence(), Is.EqualTo(1));
    }

    [Test]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.That(0.MultiplicativePersistence(), Is.Zero);
        Assert.That(10.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(25.MultiplicativePersistence(), Is.EqualTo(2));
        Assert.That(39.MultiplicativePersistence(), Is.EqualTo(3));
        Assert.That(77.MultiplicativePersistence(), Is.EqualTo(4));
        Assert.That(679.MultiplicativePersistence(), Is.EqualTo(5));
        Assert.That(6788.MultiplicativePersistence(), Is.EqualTo(6));
        Assert.That(68889.MultiplicativePersistence(), Is.EqualTo(7));
        Assert.That(2677889.MultiplicativePersistence(), Is.EqualTo(8));
        Assert.That(26888999.MultiplicativePersistence(), Is.EqualTo(9));
    }

    [Test]
    public void NegativeFactorialShouldThrow()
    {
        Assert.Throws<ArithmeticException>(() => (-1).Factorial());
    }

    [Test]
    public void SignShouldBeCorrect()
    {
        const int one = 1;
        const int zero = 0;
        Assert.That(one.Sign(), Is.EqualTo(one));
        Assert.That(zero.Sign(), Is.EqualTo(zero));
        Assert.That((-one).Sign(), Is.EqualTo(-one));
    }
}
