using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class Int32Tests
{
    [TestMethod]
    public void DigitalRootShouldBeCorrect()
    {
        const int value = 238;
        Assert.AreEqual(4, value.DigitalRoot());
        Assert.AreEqual(4, (-value).DigitalRoot());
    }

    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1L, 0.Factorial());
        Assert.AreEqual(1L, 1.Factorial());
        Assert.AreEqual(2L, 2.Factorial());
        Assert.AreEqual(6L, 3.Factorial());
        Assert.AreEqual(24L, 4.Factorial());
        Assert.AreEqual(120L, 5.Factorial());
        Assert.AreEqual(720L, 6.Factorial());
        Assert.AreEqual(5040L, 7.Factorial());
        Assert.AreEqual(40320L, 8.Factorial());
        Assert.AreEqual(362880L, 9.Factorial());
        Assert.AreEqual(3628800L, 10.Factorial());
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const int first = 5;
        const int second = 7;

        int multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(1, multiple);
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const int first = 12;
        const int second = 18;

        int multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(6, multiple);
    }

    [TestMethod]
    public void IsEvenShouldBeCorrect()
    {
        const int one = 1;
        const int two = 2;

        Assert.IsFalse(one.IsEven());
        Assert.IsTrue(two.IsEven());
    }

    [TestMethod]
    public void IsOddShouldBeCorrect()
    {
        const int one = 1;
        const int two = 2;

        Assert.IsTrue(one.IsOdd());
        Assert.IsFalse(two.IsOdd());
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const int value1 = 2;
        const int value2 = 3;
        const int expected = 6;

        int result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const int value1 = 0;
        const int value2 = 10;
        const int expected = 0;

        int result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const int value1 = 1;
        const int value2 = 10;
        const int expected = 10;

        int result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const int value1 = 5;
        const int value2 = 5;
        const int expected = 5;

        int result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithNegativeValues()
    {
        const int value1 = -2;
        const int value2 = 3;
        const int expected = -6;

        int result1 = value1.LowestCommonMultiple(value2);
        int result2 = value2.LowestCommonMultiple(value1);

        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.AreEqual(0, 0.MultiplicativePersistence());
        Assert.AreEqual(1, 10.MultiplicativePersistence());
        Assert.AreEqual(2, 25.MultiplicativePersistence());
        Assert.AreEqual(3, 39.MultiplicativePersistence());
        Assert.AreEqual(4, 77.MultiplicativePersistence());
        Assert.AreEqual(5, 679.MultiplicativePersistence());
        Assert.AreEqual(6, 6788.MultiplicativePersistence());
        Assert.AreEqual(7, 68889.MultiplicativePersistence());
        Assert.AreEqual(8, 2677889.MultiplicativePersistence());
        Assert.AreEqual(9, 26888999.MultiplicativePersistence());
    }

    [TestMethod]
    public void NegativeFactorialShouldThrow()
    {
        Assert.ThrowsException<ArithmeticException>(() => (-1).Factorial());
    }

    [TestMethod]
    public void SignShouldBeCorrect()
    {
        const int one = 1;
        const int zero = 0;
        Assert.AreEqual(one, one.Sign());
        Assert.AreEqual(zero, zero.Sign());
        Assert.AreEqual(-one, (-one).Sign());
    }
}
