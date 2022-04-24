using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class ByteTests
{
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

        bool oneEven = one.IsEven();
        bool twoEven = two.IsEven();

        Assert.IsFalse(oneEven);
        Assert.IsTrue(twoEven);
    }

    [TestMethod]
    public void IsOddShouldBeCorrect()
    {
        const byte one = 1;
        const byte two = 2;

        bool oneOdd = one.IsOdd();
        bool twoOdd = two.IsOdd();

        Assert.IsTrue(oneOdd);
        Assert.IsFalse(twoOdd);
    }
}
