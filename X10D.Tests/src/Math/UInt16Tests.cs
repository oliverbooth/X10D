using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
[CLSCompliant(false)]
public class UInt16Tests
{
    [TestMethod]
    public void FactorialShouldBeCorrect()
    {
        Assert.AreEqual(1UL, ((ushort)0).Factorial());
        Assert.AreEqual(1UL, ((ushort)1).Factorial());
        Assert.AreEqual(2UL, ((ushort)2).Factorial());
        Assert.AreEqual(6UL, ((ushort)3).Factorial());
        Assert.AreEqual(24UL, ((ushort)4).Factorial());
        Assert.AreEqual(120UL, ((ushort)5).Factorial());
        Assert.AreEqual(720UL, ((ushort)6).Factorial());
        Assert.AreEqual(5040UL, ((ushort)7).Factorial());
        Assert.AreEqual(40320UL, ((ushort)8).Factorial());
        Assert.AreEqual(362880UL, ((ushort)9).Factorial());
        Assert.AreEqual(3628800UL, ((ushort)10).Factorial());
    }
}
