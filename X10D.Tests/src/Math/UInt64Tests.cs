using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
[CLSCompliant(false)]
public class UInt64Tests
{
    [TestMethod]
    public void DigitalRootShouldBeCorrect()
    {
        const ulong value = 238;
        Assert.AreEqual(4U, value.DigitalRoot());

        // -ulong operator not defined because it might exceed long.MinValue,
        // so instead, cast to long and then negate.
        // HAX.
        Assert.AreEqual(4U, (-(long)value).DigitalRoot());
    }

    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1UL, 0UL.Factorial());
        Assert.AreEqual(1UL, 1UL.Factorial());
        Assert.AreEqual(2UL, 2UL.Factorial());
        Assert.AreEqual(6UL, 3UL.Factorial());
        Assert.AreEqual(24UL, 4UL.Factorial());
        Assert.AreEqual(120UL, 5UL.Factorial());
        Assert.AreEqual(720UL, 6UL.Factorial());
        Assert.AreEqual(5040UL, 7UL.Factorial());
        Assert.AreEqual(40320UL, 8UL.Factorial());
        Assert.AreEqual(362880UL, 9UL.Factorial());
        Assert.AreEqual(3628800UL, 10UL.Factorial());
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const ulong first = 5UL;
        const ulong second = 7UL;

        ulong multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(1UL, multiple);
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const ulong first = 12UL;
        const ulong second = 18UL;

        ulong multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(6UL, multiple);
    }

    [TestMethod]
    public void IsEvenShouldBeCorrect()
    {
        const ulong one = 1;
        const ulong two = 2;

        Assert.IsFalse(one.IsEven());
        Assert.IsTrue(two.IsEven());
    }

    [TestMethod]
    public void IsOddShouldBeCorrect()
    {
        const ulong one = 1;
        const ulong two = 2;

        Assert.IsTrue(one.IsOdd());
        Assert.IsFalse(two.IsOdd());
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const ulong value1 = 2;
        const ulong value2 = 3;
        const ulong expected = 6;

        ulong result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const ulong value1 = 0;
        const ulong value2 = 10;
        const ulong expected = 0;

        ulong result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const ulong value1 = 1;
        const ulong value2 = 10;
        const ulong expected = 10;

        ulong result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const ulong value1 = 5;
        const ulong value2 = 5;
        const ulong expected = 5;

        ulong result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.AreEqual(0, 0UL.MultiplicativePersistence());
        Assert.AreEqual(1, 10UL.MultiplicativePersistence());
        Assert.AreEqual(2, 25UL.MultiplicativePersistence());
        Assert.AreEqual(3, 39UL.MultiplicativePersistence());
        Assert.AreEqual(4, 77UL.MultiplicativePersistence());
        Assert.AreEqual(5, 679UL.MultiplicativePersistence());
        Assert.AreEqual(6, 6788UL.MultiplicativePersistence());
        Assert.AreEqual(7, 68889UL.MultiplicativePersistence());
        Assert.AreEqual(8, 2677889UL.MultiplicativePersistence());
        Assert.AreEqual(9, 26888999UL.MultiplicativePersistence());
        Assert.AreEqual(10, 3778888999UL.MultiplicativePersistence());
        Assert.AreEqual(11, 277777788888899UL.MultiplicativePersistence());
    }
}
