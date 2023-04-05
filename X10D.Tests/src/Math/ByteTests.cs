using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
public partial class ByteTests
{
    [Test]
    public void DigitalRootShouldBeCorrect()
    {
        const byte value = 238;
        Assert.That(value.DigitalRoot(), Is.EqualTo(4));
        Assert.That((-value).DigitalRoot(), Is.EqualTo(4));
    }

    [Test]
    public void FactorialShouldBeCorrect()
    {
        Assert.That(((byte)0).Factorial(), Is.EqualTo(1L));
        Assert.That(((byte)1).Factorial(), Is.EqualTo(1L));
        Assert.That(((byte)2).Factorial(), Is.EqualTo(2L));
        Assert.That(((byte)3).Factorial(), Is.EqualTo(6L));
        Assert.That(((byte)4).Factorial(), Is.EqualTo(24L));
        Assert.That(((byte)5).Factorial(), Is.EqualTo(120L));
        Assert.That(((byte)6).Factorial(), Is.EqualTo(720L));
        Assert.That(((byte)7).Factorial(), Is.EqualTo(5040L));
        Assert.That(((byte)8).Factorial(), Is.EqualTo(40320L));
        Assert.That(((byte)9).Factorial(), Is.EqualTo(362880L));
        Assert.That(((byte)10).Factorial(), Is.EqualTo(3628800L));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const byte first = 5;
        const byte second = 7;

        byte multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(1));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const byte first = 12;
        const byte second = 18;

        byte multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(6));
    }

    [Test]
    public void IsEvenShouldBeCorrect()
    {
        const byte one = 1;
        const byte two = 2;

        Assert.That(one.IsEven(), Is.False);
        Assert.That(two.IsEven());
    }

    [Test]
    public void IsOddShouldBeCorrect()
    {
        const byte one = 1;
        const byte two = 2;

        Assert.That(one.IsOdd());
        Assert.That(two.IsOdd(), Is.False);
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const byte value1 = 2;
        const byte value2 = 3;
        const byte expected = 6;

        byte result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const byte value1 = 0;
        const byte value2 = 10;
        const byte expected = 0;

        byte result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const byte value1 = 1;
        const byte value2 = 10;
        const byte expected = 10;

        byte result1 = value1.LowestCommonMultiple(value2);
        byte result2 = value2.LowestCommonMultiple(value1);

        Assert.That(result1, Is.EqualTo(expected));
        Assert.That(result2, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const byte value1 = 5;
        const byte value2 = 5;
        const byte expected = 5;

        byte result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplicativePersistence_ShouldReturn1_ForAnyDigitBeing0()
    {
        Assert.That(((byte)10).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((byte)201).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((byte)200).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((byte)207).MultiplicativePersistence(), Is.EqualTo(1));
    }

    [Test]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.That(((byte)0).MultiplicativePersistence(), Is.Zero);
        Assert.That(((byte)10).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((byte)25).MultiplicativePersistence(), Is.EqualTo(2));
        Assert.That(((byte)39).MultiplicativePersistence(), Is.EqualTo(3));
        Assert.That(((byte)77).MultiplicativePersistence(), Is.EqualTo(4));
    }
}
