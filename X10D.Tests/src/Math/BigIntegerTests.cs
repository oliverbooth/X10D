using System.Numerics;
using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
public partial class BigIntegerTests
{
    [Test]
    public void DigitalRootShouldBeCorrect()
    {
        BigInteger value = 238;
        Assert.That(value.DigitalRoot(), Is.EqualTo(4));
        Assert.That((-value).DigitalRoot(), Is.EqualTo(4));
    }

    [Test]
    public void FactorialShouldBeCorrect()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((BigInteger)0).Factorial(), Is.EqualTo((BigInteger)1));
            Assert.That(((BigInteger)1).Factorial(), Is.EqualTo((BigInteger)1));
            Assert.That(((BigInteger)2).Factorial(), Is.EqualTo((BigInteger)2));
            Assert.That(((BigInteger)3).Factorial(), Is.EqualTo((BigInteger)6));
            Assert.That(((BigInteger)4).Factorial(), Is.EqualTo((BigInteger)24));
            Assert.That(((BigInteger)5).Factorial(), Is.EqualTo((BigInteger)120));
            Assert.That(((BigInteger)6).Factorial(), Is.EqualTo((BigInteger)720));
            Assert.That(((BigInteger)7).Factorial(), Is.EqualTo((BigInteger)5040));
            Assert.That(((BigInteger)8).Factorial(), Is.EqualTo((BigInteger)40320));
            Assert.That(((BigInteger)9).Factorial(), Is.EqualTo((BigInteger)362880));
            Assert.That(((BigInteger)10).Factorial(), Is.EqualTo((BigInteger)3628800));
        });
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        BigInteger first = 5;
        BigInteger second = 7;

        BigInteger multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo((BigInteger)1));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        BigInteger first = 12;
        BigInteger second = 18;

        BigInteger multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo((BigInteger)6));
    }

    [Test]
    public void IsOddShouldBeCorrect()
    {
        BigInteger one = 1;
        BigInteger two = 2;
        Assert.Multiple(() =>
        {
            Assert.That(one.IsOdd());
            Assert.That(two.IsOdd(), Is.False);
        });
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        BigInteger value1 = 2;
        BigInteger value2 = 3;
        BigInteger expected = 6;

        BigInteger result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        BigInteger value1 = 0;
        BigInteger value2 = 10;
        BigInteger expected = 0;

        BigInteger result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        BigInteger value1 = 1;
        BigInteger value2 = 10;
        BigInteger expected = 10;

        BigInteger result1 = value1.LowestCommonMultiple(value2);
        BigInteger result2 = value2.LowestCommonMultiple(value1);

        Assert.That(result1, Is.EqualTo(expected));
        Assert.That(result2, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        BigInteger value1 = 5;
        BigInteger value2 = 5;
        BigInteger expected = 5;

        BigInteger result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithNegativeValues()
    {
        BigInteger value1 = -2;
        BigInteger value2 = 3;
        BigInteger expected = -6;

        BigInteger result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplicativePersistence_ShouldReturn1_ForAnyDigitBeing0()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((BigInteger)10).MultiplicativePersistence(), Is.EqualTo(1));
            Assert.That(((BigInteger)201).MultiplicativePersistence(), Is.EqualTo(1));
            Assert.That(((BigInteger)200).MultiplicativePersistence(), Is.EqualTo(1));
            Assert.That(((BigInteger)20007).MultiplicativePersistence(), Is.EqualTo(1));
        });
    }

    [Test]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((BigInteger)0).MultiplicativePersistence(), Is.Zero);
            Assert.That(((BigInteger)10).MultiplicativePersistence(), Is.EqualTo(1));
            Assert.That(((BigInteger)25).MultiplicativePersistence(), Is.EqualTo(2));
            Assert.That(((BigInteger)39).MultiplicativePersistence(), Is.EqualTo(3));
            Assert.That(((BigInteger)77).MultiplicativePersistence(), Is.EqualTo(4));
            Assert.That(((BigInteger)679).MultiplicativePersistence(), Is.EqualTo(5));
            Assert.That(((BigInteger)6788).MultiplicativePersistence(), Is.EqualTo(6));
            Assert.That(((BigInteger)68889).MultiplicativePersistence(), Is.EqualTo(7));
            Assert.That(((BigInteger)2677889).MultiplicativePersistence(), Is.EqualTo(8));
            Assert.That(((BigInteger)26888999).MultiplicativePersistence(), Is.EqualTo(9));
            Assert.That(((BigInteger)3778888999).MultiplicativePersistence(), Is.EqualTo(10));
            Assert.That(((BigInteger)277777788888899).MultiplicativePersistence(), Is.EqualTo(11));
        });
    }

    [Test]
    public void NegativeFactorialShouldThrow()
    {
        Assert.Throws<ArithmeticException>(() => _ = ((BigInteger)(-1)).Factorial());
    }
}
