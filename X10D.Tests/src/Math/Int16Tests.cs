using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class Int16Tests
{
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
    public void NegativeFactorialShouldThrow()
    {
        Assert.ThrowsException<ArithmeticException>(() => ((short)-1).Factorial());
    }
}
