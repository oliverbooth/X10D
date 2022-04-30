using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class ByteTests
{
    [TestMethod]
    public void DigitalRootShouldBeCorrect()
    {
        const byte value = 238;
        Assert.AreEqual(4, value.DigitalRoot());
        Assert.AreEqual(4, (-value).DigitalRoot());
    }

    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1L, ((byte)0).Factorial());
        Assert.AreEqual(1L, ((byte)1).Factorial());
        Assert.AreEqual(2L, ((byte)2).Factorial());
        Assert.AreEqual(6L, ((byte)3).Factorial());
        Assert.AreEqual(24L, ((byte)4).Factorial());
        Assert.AreEqual(120L, ((byte)5).Factorial());
        Assert.AreEqual(720L, ((byte)6).Factorial());
        Assert.AreEqual(5040L, ((byte)7).Factorial());
        Assert.AreEqual(40320L, ((byte)8).Factorial());
        Assert.AreEqual(362880L, ((byte)9).Factorial());
        Assert.AreEqual(3628800L, ((byte)10).Factorial());
    }

    [TestMethod]
    public void IsEvenShouldBeCorrect()
    {
        const byte one = 1;
        const byte two = 2;

        Assert.IsFalse(one.IsEven());
        Assert.IsTrue(two.IsEven());
    }

    [TestMethod]
    public void IsOddShouldBeCorrect()
    {
        const byte one = 1;
        const byte two = 2;

        Assert.IsTrue(one.IsOdd());
        Assert.IsFalse(two.IsOdd());
    }

    [TestMethod]
    public void MultiplicativePersistence_ShouldBeCorrect_ForRecordHolders()
    {
        Assert.AreEqual(0, ((byte)0).MultiplicativePersistence());
        Assert.AreEqual(1, ((byte)10).MultiplicativePersistence());
        Assert.AreEqual(2, ((byte)25).MultiplicativePersistence());
        Assert.AreEqual(3, ((byte)39).MultiplicativePersistence());
        Assert.AreEqual(4, ((byte)77).MultiplicativePersistence());
    }
}
