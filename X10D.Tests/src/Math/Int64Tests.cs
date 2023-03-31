using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public partial class Int64Tests
{
    [TestMethod]
    public void DigitalRootShouldBeCorrect()
    {
        const long value = 238;
        Assert.AreEqual(4, value.DigitalRoot());
        Assert.AreEqual(4, (-value).DigitalRoot());
    }

    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1L, 0L.Factorial());
        Assert.AreEqual(1L, 1L.Factorial());
        Assert.AreEqual(2L, 2L.Factorial());
        Assert.AreEqual(6L, 3L.Factorial());
        Assert.AreEqual(24L, 4L.Factorial());
        Assert.AreEqual(120L, 5L.Factorial());
        Assert.AreEqual(720L, 6L.Factorial());
        Assert.AreEqual(5040L, 7L.Factorial());
        Assert.AreEqual(40320L, 8L.Factorial());
        Assert.AreEqual(362880L, 9L.Factorial());
        Assert.AreEqual(3628800L, 10L.Factorial());
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const long first = 5L;
        const long second = 7L;

        long multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(1L, multiple);
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const long first = 12L;
        const long second = 18L;

        long multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(6L, multiple);
    }

    [TestMethod]
    public void IsEvenShouldBeCorrect()
    {
        const long one = 1;
        const long two = 2;

        Assert.IsFalse(one.IsEven());
        Assert.IsTrue(two.IsEven());
    }

    [TestMethod]
    public void IsOddShouldBeCorrect()
    {
        const long one = 1;
        const long two = 2;

        Assert.IsTrue(one.IsOdd());
        Assert.IsFalse(two.IsOdd());
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const long value1 = 2;
        const long value2 = 3;
        const long expected = 6;

        long result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const long value1 = 0;
        const long value2 = 10;
        const long expected = 0;

        long result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const long value1 = 1;
        const long value2 = 10;
        const long expected = 10;

        long result1 = value1.LowestCommonMultiple(value2);
        long result2 = value2.LowestCommonMultiple(value1);

        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const long value1 = 5;
        const long value2 = 5;
        const long expected = 5;

        long result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithNegativeValues()
    {
        const long value1 = -2;
        const long value2 = 3;
        const long expected = -6;

        long result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.AreEqual(0, 0L.MultiplicativePersistence());
        Assert.AreEqual(1, 10L.MultiplicativePersistence());
        Assert.AreEqual(2, 25L.MultiplicativePersistence());
        Assert.AreEqual(3, 39L.MultiplicativePersistence());
        Assert.AreEqual(4, 77L.MultiplicativePersistence());
        Assert.AreEqual(5, 679L.MultiplicativePersistence());
        Assert.AreEqual(6, 6788L.MultiplicativePersistence());
        Assert.AreEqual(7, 68889L.MultiplicativePersistence());
        Assert.AreEqual(8, 2677889L.MultiplicativePersistence());
        Assert.AreEqual(9, 26888999L.MultiplicativePersistence());
        Assert.AreEqual(10, 3778888999L.MultiplicativePersistence());
        Assert.AreEqual(11, 277777788888899L.MultiplicativePersistence());
    }

    [TestMethod]
    public void NegativeFactorialShouldThrow()
    {
        Assert.ThrowsException<ArithmeticException>(() => (-1L).Factorial());
    }

    [TestMethod]
    public void SignShouldBeCorrect()
    {
        const long one = 1;
        const long zero = 0;
        Assert.AreEqual(one, one.Sign());
        Assert.AreEqual(zero, zero.Sign());
        Assert.AreEqual(-one, (-one).Sign());
    }
}
