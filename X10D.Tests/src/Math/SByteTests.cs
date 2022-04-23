using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
[CLSCompliant(false)]
public class SByteTests
{
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
    public void NegativeFactorialShouldThrow()
    {
        Assert.ThrowsException<ArithmeticException>(() => ((sbyte)-1).Factorial());
    }
}
