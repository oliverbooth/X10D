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
}
