using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
public partial class Int16Tests
{
    [Test]
    public void DigitalRootShouldBeCorrect()
    {
        const short value = 238;
        Assert.That(value.DigitalRoot(), Is.EqualTo(4));
        Assert.That((-value).DigitalRoot(), Is.EqualTo(4));
    }

    [Test]
    public void FactorialShouldBeCorrect()
    {
        Assert.That(((short)0).Factorial(), Is.EqualTo(1L));
        Assert.That(((short)1).Factorial(), Is.EqualTo(1L));
        Assert.That(((short)2).Factorial(), Is.EqualTo(2L));
        Assert.That(((short)3).Factorial(), Is.EqualTo(6L));
        Assert.That(((short)4).Factorial(), Is.EqualTo(24L));
        Assert.That(((short)5).Factorial(), Is.EqualTo(120L));
        Assert.That(((short)6).Factorial(), Is.EqualTo(720L));
        Assert.That(((short)7).Factorial(), Is.EqualTo(5040L));
        Assert.That(((short)8).Factorial(), Is.EqualTo(40320L));
        Assert.That(((short)9).Factorial(), Is.EqualTo(362880L));
        Assert.That(((short)10).Factorial(), Is.EqualTo(3628800L));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const short first = 5;
        const short second = 7;

        short multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(1));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const short first = 12;
        const short second = 18;

        short multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(6));
    }

    [Test]
    public void IsEvenShouldBeCorrect()
    {
        const short one = 1;
        const short two = 2;

        Assert.That(one.IsEven(), Is.False);
        Assert.That(two.IsEven());
    }

    [Test]
    public void IsOddShouldBeCorrect()
    {
        const short one = 1;
        const short two = 2;

        Assert.That(one.IsOdd());
        Assert.That(two.IsOdd(), Is.False);
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const short value1 = 2;
        const short value2 = 3;
        const short expected = 6;

        short result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const short value1 = 0;
        const short value2 = 10;
        const short expected = 0;

        short result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const short value1 = 1;
        const short value2 = 10;
        const short expected = 10;

        short result1 = value1.LowestCommonMultiple(value2);
        short result2 = value2.LowestCommonMultiple(value1);

        Assert.That(result1, Is.EqualTo(expected));
        Assert.That(result2, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const short value1 = 5;
        const short value2 = 5;
        const short expected = 5;

        short result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithNegativeValues()
    {
        const short value1 = -2;
        const short value2 = 3;
        const short expected = -6;

        short result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplicativePersistence_ShouldReturn1_ForAnyDigitBeing0()
    {
        Assert.That(((short)10).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((short)201).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((short)200).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((short)20007).MultiplicativePersistence(), Is.EqualTo(1));
    }

    [Test]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.That(((short)0).MultiplicativePersistence(), Is.Zero);
        Assert.That(((short)10).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((short)25).MultiplicativePersistence(), Is.EqualTo(2));
        Assert.That(((short)39).MultiplicativePersistence(), Is.EqualTo(3));
        Assert.That(((short)77).MultiplicativePersistence(), Is.EqualTo(4));
        Assert.That(((short)679).MultiplicativePersistence(), Is.EqualTo(5));
        Assert.That(((short)6788).MultiplicativePersistence(), Is.EqualTo(6));
    }

    [Test]
    public void NegativeFactorialShouldThrow()
    {
        Assert.Throws<ArithmeticException>(() => ((short)-1).Factorial());
    }

    [Test]
    public void SignShouldBeCorrect()
    {
        const short one = 1;
        const short zero = 0;
        Assert.That(one.Sign(), Is.EqualTo(one));
        Assert.That(zero.Sign(), Is.EqualTo(zero));
        Assert.That((-one).Sign(), Is.EqualTo(-one));
    }
}
