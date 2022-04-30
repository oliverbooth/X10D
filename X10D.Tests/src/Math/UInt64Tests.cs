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
