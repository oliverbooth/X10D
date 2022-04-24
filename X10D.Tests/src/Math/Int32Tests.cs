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
