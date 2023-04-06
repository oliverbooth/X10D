using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
[CLSCompliant(false)]
public partial class UInt16Tests
{
    [Test]
    public void DigitalRootShouldBeCorrect()
    {
        const ushort value = 238;
        Assert.That(value.DigitalRoot(), Is.EqualTo(4));
        Assert.That((-value).DigitalRoot(), Is.EqualTo(4));
    }

    [Test]
    public void FactorialShouldBeCorrect()
    {
        Assert.That(((ushort)0).Factorial(), Is.EqualTo(1UL));
        Assert.That(((ushort)1).Factorial(), Is.EqualTo(1UL));
        Assert.That(((ushort)2).Factorial(), Is.EqualTo(2UL));
        Assert.That(((ushort)3).Factorial(), Is.EqualTo(6UL));
        Assert.That(((ushort)4).Factorial(), Is.EqualTo(24UL));
        Assert.That(((ushort)5).Factorial(), Is.EqualTo(120UL));
        Assert.That(((ushort)6).Factorial(), Is.EqualTo(720UL));
        Assert.That(((ushort)7).Factorial(), Is.EqualTo(5040UL));
        Assert.That(((ushort)8).Factorial(), Is.EqualTo(40320UL));
        Assert.That(((ushort)9).Factorial(), Is.EqualTo(362880UL));
        Assert.That(((ushort)10).Factorial(), Is.EqualTo(3628800UL));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const ushort first = 5;
        const ushort second = 7;

        ushort multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(1));
    }

    [Test]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const ushort first = 12;
        const ushort second = 18;

        ushort multiple = first.GreatestCommonFactor(second);

        Assert.That(multiple, Is.EqualTo(6));
    }

    [Test]
    public void IsEvenShouldBeCorrect()
    {
        const ushort one = 1;
        const ushort two = 2;

        Assert.That(one.IsEven(), Is.False);
        Assert.That(two.IsEven());
    }

    [Test]
    public void IsOddShouldBeCorrect()
    {
        const ushort one = 1;
        const ushort two = 2;

        Assert.That(one.IsOdd());
        Assert.That(two.IsOdd(), Is.False);
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const ushort value1 = 2;
        const ushort value2 = 3;
        const ushort expected = 6;

        ushort result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const ushort value1 = 0;
        const ushort value2 = 10;
        const ushort expected = 0;

        ushort result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const ushort value1 = 1;
        const ushort value2 = 10;
        const ushort expected = 10;

        ushort result1 = value1.LowestCommonMultiple(value2);
        ushort result2 = value2.LowestCommonMultiple(value1);

        Assert.That(result1, Is.EqualTo(expected));
        Assert.That(result2, Is.EqualTo(expected));
    }

    [Test]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const ushort value1 = 5;
        const ushort value2 = 5;
        const ushort expected = 5;

        ushort result = value1.LowestCommonMultiple(value2);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplicativePersistence_ShouldReturn1_ForAnyDigitBeing0()
    {
        Assert.That(((ushort)10).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((ushort)201).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((ushort)200).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((ushort)20007).MultiplicativePersistence(), Is.EqualTo(1));
    }

    [Test]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.That(((ushort)0).MultiplicativePersistence(), Is.Zero);
        Assert.That(((ushort)10).MultiplicativePersistence(), Is.EqualTo(1));
        Assert.That(((ushort)25).MultiplicativePersistence(), Is.EqualTo(2));
        Assert.That(((ushort)39).MultiplicativePersistence(), Is.EqualTo(3));
        Assert.That(((ushort)77).MultiplicativePersistence(), Is.EqualTo(4));
        Assert.That(((ushort)679).MultiplicativePersistence(), Is.EqualTo(5));
        Assert.That(((ushort)6788).MultiplicativePersistence(), Is.EqualTo(6));
    }
}
