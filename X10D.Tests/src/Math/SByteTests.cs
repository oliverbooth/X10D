using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
[CLSCompliant(false)]
public class SByteTests
{
    [TestMethod]
    public void DigitalRootShouldBeCorrect()
    {
        const sbyte value = 127; // sbyte.MaxValue. can't use 238 like the other tests
        Assert.AreEqual(1, value.DigitalRoot());
        Assert.AreEqual(1, (-value).DigitalRoot());
    }

    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1L, ((sbyte)0).Factorial());
        Assert.AreEqual(1L, ((sbyte)1).Factorial());
        Assert.AreEqual(2L, ((sbyte)2).Factorial());
        Assert.AreEqual(6L, ((sbyte)3).Factorial());
        Assert.AreEqual(24L, ((sbyte)4).Factorial());
        Assert.AreEqual(120L, ((sbyte)5).Factorial());
        Assert.AreEqual(720L, ((sbyte)6).Factorial());
        Assert.AreEqual(5040L, ((sbyte)7).Factorial());
        Assert.AreEqual(40320L, ((sbyte)8).Factorial());
        Assert.AreEqual(362880L, ((sbyte)9).Factorial());
        Assert.AreEqual(3628800L, ((sbyte)10).Factorial());
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const sbyte first = 5;
        const sbyte second = 7;

        sbyte multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(1, multiple);
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const sbyte first = 12;
        const sbyte second = 18;

        sbyte multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(6, multiple);
    }

    [TestMethod]
    public void IsEvenShouldBeCorrect()
    {
        const sbyte one = 1;
        const sbyte two = 2;

        Assert.IsFalse(one.IsEven());
        Assert.IsTrue(two.IsEven());
    }

    [TestMethod]
    public void IsOddShouldBeCorrect()
    {
        const sbyte one = 1;
        const sbyte two = 2;

        Assert.IsTrue(one.IsOdd());
        Assert.IsFalse(two.IsOdd());
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const sbyte value1 = 2;
        const sbyte value2 = 3;
        const sbyte expected = 6;

        sbyte result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const sbyte value1 = 0;
        const sbyte value2 = 10;
        const sbyte expected = 0;

        sbyte result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const sbyte value1 = 1;
        const sbyte value2 = 10;
        const sbyte expected = 10;

        sbyte result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const sbyte value1 = 5;
        const sbyte value2 = 5;
        const sbyte expected = 5;

        sbyte result1 = value1.LowestCommonMultiple(value2);
        sbyte result2 = value2.LowestCommonMultiple(value1);

        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithNegativeValues()
    {
        const sbyte value1 = -2;
        const sbyte value2 = 3;
        const sbyte expected = -6;

        sbyte result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.AreEqual(0, ((sbyte)0).MultiplicativePersistence());
        Assert.AreEqual(1, ((sbyte)10).MultiplicativePersistence());
        Assert.AreEqual(2, ((sbyte)25).MultiplicativePersistence());
        Assert.AreEqual(3, ((sbyte)39).MultiplicativePersistence());
        Assert.AreEqual(4, ((sbyte)77).MultiplicativePersistence());
    }

    [TestMethod]
    public void NegativeFactorialShouldThrow()
    {
        Assert.ThrowsException<ArithmeticException>(() => ((sbyte)-1).Factorial());
    }

    [TestMethod]
    public void SignShouldBeCorrect()
    {
        const sbyte one = 1;
        const sbyte zero = 0;
        Assert.AreEqual(one, one.Sign());
        Assert.AreEqual(zero, zero.Sign());
        Assert.AreEqual(-one, (-one).Sign());
    }
}
