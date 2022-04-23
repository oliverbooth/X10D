using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class Int64Tests
{
    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1L, 0L.Factorial());
        Assert.AreEqual(1L, 1L.Factorial());
        Assert.AreEqual(2L, 2L.Factorial());
        Assert.AreEqual(6L, 3L.Factorial());
        Assert.AreEqual(24L, 4L.Factorial());
        Assert.AreEqual(120L, 5L.Factorial());
        Assert.AreEqual(720L, 6L.Factorial());
        Assert.AreEqual(5040L, 7L.Factorial());
        Assert.AreEqual(40320L, 8L.Factorial());
        Assert.AreEqual(362880L, 9L.Factorial());
        Assert.AreEqual(3628800L, 10L.Factorial());
    }

    [TestMethod]
    public void NegativeFactorialShouldThrow()
    {
        Assert.ThrowsException<ArithmeticException>(() => (-1L).Factorial());
    }
}
