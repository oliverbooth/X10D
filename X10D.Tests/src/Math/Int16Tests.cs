using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class Int16Tests
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
