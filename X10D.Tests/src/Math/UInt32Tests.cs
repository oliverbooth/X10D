using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
[CLSCompliant(false)]
public class UInt32Tests
{
    [TestMethod]
    public void DigitalRootShouldBeCorrect()
    {
        const uint value = 238;
        Assert.AreEqual(4U, value.DigitalRoot());
        Assert.AreEqual(4U, (-value).DigitalRoot());
    }

    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1UL, 0U.Factorial());
        Assert.AreEqual(1UL, 1U.Factorial());
        Assert.AreEqual(2UL, 2U.Factorial());
        Assert.AreEqual(6UL, 3U.Factorial());
        Assert.AreEqual(24UL, 4U.Factorial());
        Assert.AreEqual(120UL, 5U.Factorial());
        Assert.AreEqual(720UL, 6U.Factorial());
        Assert.AreEqual(5040UL, 7U.Factorial());
        Assert.AreEqual(40320UL, 8U.Factorial());
        Assert.AreEqual(362880UL, 9U.Factorial());
        Assert.AreEqual(3628800UL, 10U.Factorial());
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const uint first = 5U;
        const uint second = 7U;

        uint multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(1U, multiple);
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const uint first = 12U;
        const uint second = 18U;

        uint multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(6U, multiple);
    }

    [TestMethod]
    public void IsEvenShouldBeCorrect()
    {
        const uint one = 1;
        const uint two = 2;

        Assert.IsFalse(one.IsEven());
        Assert.IsTrue(two.IsEven());
    }

    [TestMethod]
    public void IsOddShouldBeCorrect()
    {
        const uint one = 1;
        const uint two = 2;

        Assert.IsTrue(one.IsOdd());
        Assert.IsFalse(two.IsOdd());
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const uint value1 = 2;
        const uint value2 = 3;
        const uint expected = 6;

        uint result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const uint value1 = 0;
        const uint value2 = 10;
        const uint expected = 0;

        uint result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const uint value1 = 1;
        const uint value2 = 10;
        const uint expected = 10;

        uint result1 = value1.LowestCommonMultiple(value2);
        uint result2 = value2.LowestCommonMultiple(value1);

        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const uint value1 = 5;
        const uint value2 = 5;
        const uint expected = 5;

        uint result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.AreEqual(0, 0U.MultiplicativePersistence());
        Assert.AreEqual(1, 10U.MultiplicativePersistence());
        Assert.AreEqual(2, 25U.MultiplicativePersistence());
        Assert.AreEqual(3, 39U.MultiplicativePersistence());
        Assert.AreEqual(4, 77U.MultiplicativePersistence());
        Assert.AreEqual(5, 679U.MultiplicativePersistence());
        Assert.AreEqual(6, 6788U.MultiplicativePersistence());
        Assert.AreEqual(7, 68889U.MultiplicativePersistence());
        Assert.AreEqual(8, 2677889U.MultiplicativePersistence());
        Assert.AreEqual(9, 26888999U.MultiplicativePersistence());
        Assert.AreEqual(10, 3778888999U.MultiplicativePersistence());
    }
}
