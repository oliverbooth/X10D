using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public partial class Int16Tests
{
    [TestMethod]
    public void DigitalRootShouldBeCorrect()
    {
        const short value = 238;
        Assert.AreEqual(4, value.DigitalRoot());
        Assert.AreEqual(4, (-value).DigitalRoot());
    }

    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1L, ((short)0).Factorial());
        Assert.AreEqual(1L, ((short)1).Factorial());
        Assert.AreEqual(2L, ((short)2).Factorial());
        Assert.AreEqual(6L, ((short)3).Factorial());
        Assert.AreEqual(24L, ((short)4).Factorial());
        Assert.AreEqual(120L, ((short)5).Factorial());
        Assert.AreEqual(720L, ((short)6).Factorial());
        Assert.AreEqual(5040L, ((short)7).Factorial());
        Assert.AreEqual(40320L, ((short)8).Factorial());
        Assert.AreEqual(362880L, ((short)9).Factorial());
        Assert.AreEqual(3628800L, ((short)10).Factorial());
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const short first = 5;
        const short second = 7;

        short multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(1, multiple);
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const short first = 12;
        const short second = 18;

        short multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(6, multiple);
    }

    [TestMethod]
    public void IsEvenShouldBeCorrect()
    {
        const short one = 1;
        const short two = 2;

        Assert.IsFalse(one.IsEven());
        Assert.IsTrue(two.IsEven());
    }

    [TestMethod]
    public void IsOddShouldBeCorrect()
    {
        const short one = 1;
        const short two = 2;

        Assert.IsTrue(one.IsOdd());
        Assert.IsFalse(two.IsOdd());
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const short value1 = 2;
        const short value2 = 3;
        const short expected = 6;

        short result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const short value1 = 0;
        const short value2 = 10;
        const short expected = 0;

        short result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const short value1 = 1;
        const short value2 = 10;
        const short expected = 10;

        short result1 = value1.LowestCommonMultiple(value2);
        short result2 = value2.LowestCommonMultiple(value1);

        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const short value1 = 5;
        const short value2 = 5;
        const short expected = 5;

        short result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithNegativeValues()
    {
        const short value1 = -2;
        const short value2 = 3;
        const short expected = -6;

        short result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.AreEqual(0, ((short)0).MultiplicativePersistence());
        Assert.AreEqual(1, ((short)10).MultiplicativePersistence());
        Assert.AreEqual(2, ((short)25).MultiplicativePersistence());
        Assert.AreEqual(3, ((short)39).MultiplicativePersistence());
        Assert.AreEqual(4, ((short)77).MultiplicativePersistence());
        Assert.AreEqual(5, ((short)679).MultiplicativePersistence());
        Assert.AreEqual(6, ((short)6788).MultiplicativePersistence());
    }

    [TestMethod]
    public void NegativeFactorialShouldThrow()
    {
        Assert.ThrowsException<ArithmeticException>(() => ((short)-1).Factorial());
    }

    [TestMethod]
    public void SignShouldBeCorrect()
    {
        const short one = 1;
        const short zero = 0;
        Assert.AreEqual(one, one.Sign());
        Assert.AreEqual(zero, zero.Sign());
        Assert.AreEqual(-one, (-one).Sign());
    }
}
