using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
[CLSCompliant(false)]
public partial class SByteTests
{
    [Test]
    public void DigitalRootShouldBeCorrect()
    {
        const sbyte value = 127; // sbyte.MaxValue. can't use 238 like the other tests
        Assert.That(value.DigitalRoot(), Is.EqualTo(1));
        Assert.That((-value).DigitalRoot(), Is.EqualTo(1));
    }

    [Test]
    public void FactorialShouldBeCorrect()
    {
        Assert.That(((sbyte)0).Factorial(), Is.EqualTo(1L));
        Assert.That(((sbyte)1).Factorial(), Is.EqualTo(1L));
        Assert.That(((sbyte)2).Factorial(), Is.EqualTo(2L));
        Assert.That(((sbyte)3).Factorial(), Is.EqualTo(6L));
        Assert.That(((sbyte)4).Factorial(), Is.EqualTo(24L));
        Assert.That(((sbyte)5).Factorial(), Is.EqualTo(120L));
        Assert.That(((sbyte)6).Factorial(), Is.EqualTo(720L));
        Assert.That(((sbyte)7).Factorial(), Is.EqualTo(5040L));
        Assert.That(((sbyte)8).Factorial(), Is.EqualTo(40320L));
        Assert.That(((sbyte)9).Factorial(), Is.EqualTo(362880L));
        Assert.That(((sbyte)10).Factorial(), Is.EqualTo(3628800L));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const sbyte first = 5;
        const sbyte second = 7;

        sbyte multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(1));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const sbyte first = 12;
        const sbyte second = 18;

        sbyte multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(6));
    }

    [Test]
    public void IsEvenShouldBeCorrect()
    {
        const sbyte one = 1;
        const sbyte two = 2;

        Assert.That(one.IsEven(), Is.False);
        Assert.That(two.IsEven());
    }

    [Test]
    public void IsOddShouldBeCorrect()
    {
        const sbyte one = 1;
        const sbyte two = 2;

        Assert.That(one.IsOdd());
        Assert.That(two.IsOdd(), Is.False);
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const sbyte value1 = 2;
        const sbyte value2 = 3;
        const sbyte expected = 6;

        sbyte result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const sbyte value1 = 0;
        const sbyte value2 = 10;
        const sbyte expected = 0;

        sbyte result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const sbyte value1 = 1;
        const sbyte value2 = 10;
        const sbyte expected = 10;

        sbyte result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const sbyte value1 = 5;
        const sbyte value2 = 5;
        const sbyte expected = 5;

        sbyte result1 = value1.LowestCommonMultiple(value2);
        sbyte result2 = value2.LowestCommonMultiple(value1);

        Assert.That(result1, Is.EqualTo(expected));
        Assert.That(result2, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithNegativeValues()
    {
        const sbyte value1 = -2;
        const sbyte value2 = 3;
        const sbyte expected = -6;

        sbyte result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplicativePersistence_ShouldReturn1_ForAnyDigitBeing0()
    {
        Assert.That(((sbyte)10).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((sbyte)20).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((sbyte)101).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((sbyte)120).MultiplicativePersistence(), Is.EqualTo(1));
    }

    [Test]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.That(((sbyte)0).MultiplicativePersistence(), Is.Zero);
        Assert.That(((sbyte)10).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((sbyte)25).MultiplicativePersistence(), Is.EqualTo(2));
        Assert.That(((sbyte)39).MultiplicativePersistence(), Is.EqualTo(3));
        Assert.That(((sbyte)77).MultiplicativePersistence(), Is.EqualTo(4));
    }

    [Test]
    public void NegativeFactorialShouldThrow()
    {
        Assert.Throws<ArithmeticException>(() => ((sbyte)-1).Factorial());
    }

    [Test]
    public void SignShouldBeCorrect()
    {
        const sbyte one = 1;
        const sbyte zero = 0;
        Assert.That(one.Sign(), Is.EqualTo(one));
        Assert.That(zero.Sign(), Is.EqualTo(zero));
        Assert.That((-one).Sign(), Is.EqualTo(-one));
    }
}
