using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
[CLSCompliant(false)]
public class UInt64Tests
{
    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1UL, 0UL.Factorial());
        Assert.AreEqual(1UL, 1UL.Factorial());
        Assert.AreEqual(2UL, 2UL.Factorial());
        Assert.AreEqual(6UL, 3UL.Factorial());
        Assert.AreEqual(24UL, 4UL.Factorial());
        Assert.AreEqual(120UL, 5UL.Factorial());
        Assert.AreEqual(720UL, 6UL.Factorial());
        Assert.AreEqual(5040UL, 7UL.Factorial());
        Assert.AreEqual(40320UL, 8UL.Factorial());
        Assert.AreEqual(362880UL, 9UL.Factorial());
        Assert.AreEqual(3628800UL, 10UL.Factorial());
    }
}
