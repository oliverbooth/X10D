using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
internal partial class Int64Tests
{
    [Test]
    public void CountDigits_ShouldReturn1_Given0()
    {
        const long value = 0;
        const int expected = 1;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountDigits_ShouldReturn1_Given1()
    {
        const long value = 1;
        const int expected = 1;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountDigits_ShouldReturn1_GivenNegative1()
    {
        const long value = -1;
        const int expected = 1;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountDigits_ShouldReturn2_Given10()
    {
        const long value = 10;
        const int expected = 2;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountDigits_ShouldReturn3_Given199()
    {
        const long value = 199;
        const int expected = 3;

        int result = value.CountDigits();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DigitalRootShouldBeCorrect()
    {
        const long value = 238;
        Assert.That(value.DigitalRoot(), Is.EqualTo(4));
        Assert.That((-value).DigitalRoot(), Is.EqualTo(4));
    }

    [Test]
    public void FactorialShouldBeCorrect()
    {
        Assert.That(0L.Factorial(), Is.EqualTo(1L));
        Assert.That(1L.Factorial(), Is.EqualTo(1L));
        Assert.That(2L.Factorial(), Is.EqualTo(2L));
        Assert.That(3L.Factorial(), Is.EqualTo(6L));
        Assert.That(4L.Factorial(), Is.EqualTo(24L));
        Assert.That(5L.Factorial(), Is.EqualTo(120L));
        Assert.That(6L.Factorial(), Is.EqualTo(720L));
        Assert.That(7L.Factorial(), Is.EqualTo(5040L));
        Assert.That(8L.Factorial(), Is.EqualTo(40320L));
        Assert.That(9L.Factorial(), Is.EqualTo(362880L));
        Assert.That(10L.Factorial(), Is.EqualTo(3628800L));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const long first = 5L;
        const long second = 7L;

        long multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(1L));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const long first = 12L;
        const long second = 18L;

        long multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(6L));
    }

    [Test]
    public void IsEvenShouldBeCorrect()
    {
        const long one = 1;
        const long two = 2;

        Assert.That(one.IsEven(), Is.False);
        Assert.That(two.IsEven());
    }

    [Test]
    public void IsOddShouldBeCorrect()
    {
        const long one = 1;
        const long two = 2;

        Assert.That(one.IsOdd());
        Assert.That(two.IsOdd(), Is.False);
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const long value1 = 2;
        const long value2 = 3;
        const long expected = 6;

        long result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const long value1 = 0;
        const long value2 = 10;
        const long expected = 0;

        long result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const long value1 = 1;
        const long value2 = 10;
        const long expected = 10;

        long result1 = value1.LowestCommonMultiple(value2);
        long result2 = value2.LowestCommonMultiple(value1);

        Assert.That(result1, Is.EqualTo(expected));
        Assert.That(result2, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const long value1 = 5;
        const long value2 = 5;
        const long expected = 5;

        long result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithNegativeValues()
    {
        const long value1 = -2;
        const long value2 = 3;
        const long expected = -6;

        long result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplicativePersistence_ShouldReturn1_ForAnyDigitBeing0()
    {
        Assert.That(10L.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(201L.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(200L.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(20007L.MultiplicativePersistence(), Is.EqualTo(1));
    }

    [Test]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.That(0L.MultiplicativePersistence(), Is.Zero);
        Assert.That(10L.MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(25L.MultiplicativePersistence(), Is.EqualTo(2));
        Assert.That(39L.MultiplicativePersistence(), Is.EqualTo(3));
        Assert.That(77L.MultiplicativePersistence(), Is.EqualTo(4));
        Assert.That(679L.MultiplicativePersistence(), Is.EqualTo(5));
        Assert.That(6788L.MultiplicativePersistence(), Is.EqualTo(6));
        Assert.That(68889L.MultiplicativePersistence(), Is.EqualTo(7));
        Assert.That(2677889L.MultiplicativePersistence(), Is.EqualTo(8));
        Assert.That(26888999L.MultiplicativePersistence(), Is.EqualTo(9));
        Assert.That(3778888999L.MultiplicativePersistence(), Is.EqualTo(10));
        Assert.That(277777788888899L.MultiplicativePersistence(), Is.EqualTo(11));
    }

    [Test]
    public void NegativeFactorialShouldThrow()
    {
        Assert.Throws<ArithmeticException>(() => (-1L).Factorial());
    }

    [Test]
    public void SignShouldBeCorrect()
    {
        const long one = 1;
        const long zero = 0;
        Assert.That(one.Sign(), Is.EqualTo(one));
        Assert.That(zero.Sign(), Is.EqualTo(zero));
        Assert.That((-one).Sign(), Is.EqualTo(-one));
    }
}
