using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public partial class BigIntegerTests
{
    [TestMethod]
    public void DigitalRootShouldBeCorrect()
    {
        BigInteger value = 238;
        Assert.AreEqual(4, value.DigitalRoot());
        Assert.AreEqual(4, (-value).DigitalRoot());
    }

    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1, ((BigInteger)0).Factorial());
        Assert.AreEqual(1, ((BigInteger)1).Factorial());
        Assert.AreEqual(2, ((BigInteger)2).Factorial());
        Assert.AreEqual(6, ((BigInteger)3).Factorial());
        Assert.AreEqual(24, ((BigInteger)4).Factorial());
        Assert.AreEqual(120, ((BigInteger)5).Factorial());
        Assert.AreEqual(720, ((BigInteger)6).Factorial());
        Assert.AreEqual(5040, ((BigInteger)7).Factorial());
        Assert.AreEqual(40320, ((BigInteger)8).Factorial());
        Assert.AreEqual(362880, ((BigInteger)9).Factorial());
        Assert.AreEqual(3628800, ((BigInteger)10).Factorial());
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        BigInteger first = 5L;
        BigInteger second = 7L;

        BigInteger multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(1L, multiple);
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        BigInteger first = 12L;
        BigInteger second = 18L;

        BigInteger multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(6L, multiple);
    }

    [TestMethod]
    public void IsOddShouldBeCorrect()
    {
        BigInteger one = 1;
        BigInteger two = 2;

        Assert.IsTrue(one.IsOdd());
        Assert.IsFalse(two.IsOdd());
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        BigInteger value1 = 2;
        BigInteger value2 = 3;
        BigInteger expected = 6;

        BigInteger result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        BigInteger value1 = 0;
        BigInteger value2 = 10;
        BigInteger expected = 0;

        BigInteger result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        BigInteger value1 = 1;
        BigInteger value2 = 10;
        BigInteger expected = 10;

        BigInteger result1 = value1.LowestCommonMultiple(value2);
        BigInteger result2 = value2.LowestCommonMultiple(value1);

        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        BigInteger value1 = 5;
        BigInteger value2 = 5;
        BigInteger expected = 5;

        BigInteger result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithNegativeValues()
    {
        BigInteger value1 = -2;
        BigInteger value2 = 3;
        BigInteger expected = -6;

        BigInteger result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void MultiplicativePersistence_ShouldReturn1_ForAnyDigitBeing0()
    {
        Assert.AreEqual(1, ((BigInteger)10).MultiplicativePersistence());
        Assert.AreEqual(1, ((BigInteger)201).MultiplicativePersistence());
        Assert.AreEqual(1, ((BigInteger)200).MultiplicativePersistence());
        Assert.AreEqual(1, ((BigInteger)20007).MultiplicativePersistence());
    }

    [TestMethod]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.AreEqual(0, ((BigInteger)0).MultiplicativePersistence());
        Assert.AreEqual(1, ((BigInteger)10).MultiplicativePersistence());
        Assert.AreEqual(2, ((BigInteger)25).MultiplicativePersistence());
        Assert.AreEqual(3, ((BigInteger)39).MultiplicativePersistence());
        Assert.AreEqual(4, ((BigInteger)77).MultiplicativePersistence());
        Assert.AreEqual(5, ((BigInteger)679).MultiplicativePersistence());
        Assert.AreEqual(6, ((BigInteger)6788).MultiplicativePersistence());
        Assert.AreEqual(7, ((BigInteger)68889).MultiplicativePersistence());
        Assert.AreEqual(8, ((BigInteger)2677889).MultiplicativePersistence());
        Assert.AreEqual(9, ((BigInteger)26888999).MultiplicativePersistence());
        Assert.AreEqual(10, ((BigInteger)3778888999).MultiplicativePersistence());
        Assert.AreEqual(11, ((BigInteger)277777788888899).MultiplicativePersistence());
    }

    [TestMethod]
    public void NegativeFactorialShouldThrow()
    {
        Assert.ThrowsException<ArithmeticException>(() => ((BigInteger)(-1)).Factorial());
    }
}
