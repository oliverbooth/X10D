using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class Int32Tests
{
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
    public void NegativeFactorialShouldThrow()
    {
        Assert.ThrowsException<ArithmeticException>(() => (-1).Factorial());
    }
}
