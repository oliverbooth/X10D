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
