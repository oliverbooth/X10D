using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
[CLSCompliant(false)]
public partial class UInt16Tests
{
    [TestMethod]
    public void DigitalRootShouldBeCorrect()
    {
        const ushort value = 238;
        Assert.AreEqual(4, value.DigitalRoot());
        Assert.AreEqual(4, (-value).DigitalRoot());
    }

    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1UL, ((ushort)0).Factorial());
        Assert.AreEqual(1UL, ((ushort)1).Factorial());
        Assert.AreEqual(2UL, ((ushort)2).Factorial());
        Assert.AreEqual(6UL, ((ushort)3).Factorial());
        Assert.AreEqual(24UL, ((ushort)4).Factorial());
        Assert.AreEqual(120UL, ((ushort)5).Factorial());
        Assert.AreEqual(720UL, ((ushort)6).Factorial());
        Assert.AreEqual(5040UL, ((ushort)7).Factorial());
        Assert.AreEqual(40320UL, ((ushort)8).Factorial());
        Assert.AreEqual(362880UL, ((ushort)9).Factorial());
        Assert.AreEqual(3628800UL, ((ushort)10).Factorial());
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe1_ForPrimeNumbers()
    {
        const ushort first = 5;
        const ushort second = 7;

        ushort multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(1, multiple);
    }

    [TestMethod]
    public void GreatestCommonFactor_ShouldBe6_Given12And18()
    {
        const ushort first = 12;
        const ushort second = 18;

        ushort multiple = first.GreatestCommonFactor(second);

        Assert.AreEqual(6, multiple);
    }

    [TestMethod]
    public void IsEvenShouldBeCorrect()
    {
        const ushort one = 1;
        const ushort two = 2;

        Assert.IsFalse(one.IsEven());
        Assert.IsTrue(two.IsEven());
    }

    [TestMethod]
    public void IsOddShouldBeCorrect()
    {
        const ushort one = 1;
        const ushort two = 2;

        Assert.IsTrue(one.IsOdd());
        Assert.IsFalse(two.IsOdd());
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnCorrectValue_WhenCalledWithValidInput()
    {
        const ushort value1 = 2;
        const ushort value2 = 3;
        const ushort expected = 6;

        ushort result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnZero_WhenCalledWithZero()
    {
        const ushort value1 = 0;
        const ushort value2 = 10;
        const ushort expected = 0;

        ushort result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnGreaterValue_WhenCalledWithOne()
    {
        const ushort value1 = 1;
        const ushort value2 = 10;
        const ushort expected = 10;

        ushort result1 = value1.LowestCommonMultiple(value2);
        ushort result2 = value2.LowestCommonMultiple(value1);

        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    public void LowestCommonMultiple_ShouldReturnOtherValue_WhenCalledWithSameValue()
    {
        const ushort value1 = 5;
        const ushort value2 = 5;
        const ushort expected = 5;

        ushort result = value1.LowestCommonMultiple(value2);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.AreEqual(0, ((ushort)0).MultiplicativePersistence());
        Assert.AreEqual(1, ((ushort)10).MultiplicativePersistence());
        Assert.AreEqual(2, ((ushort)25).MultiplicativePersistence());
        Assert.AreEqual(3, ((ushort)39).MultiplicativePersistence());
        Assert.AreEqual(4, ((ushort)77).MultiplicativePersistence());
        Assert.AreEqual(5, ((ushort)679).MultiplicativePersistence());
        Assert.AreEqual(6, ((ushort)6788).MultiplicativePersistence());
    }
}
