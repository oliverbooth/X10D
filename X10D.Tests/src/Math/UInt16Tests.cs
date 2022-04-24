using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
[CLSCompliant(false)]
public class UInt16Tests
{
    [TestMethod]
    public void DigitalRootShouldBeCorrect()
    {
        const ushort value = 238;
        Assert.AreEqual(4, value.DigitalRoot());
        Assert.AreEqual(4, (-value).DigitalRoot());
    }
    
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

    [TestMethod]
    public void IsEvenShouldBeCorrect()
    {
        const ushort one = 1;
        const ushort two = 2;
        
        Assert.IsFalse(one.IsEven());
        Assert.IsTrue(two.IsEven());
    }

    [TestMethod]
    public void IsOddShouldBeCorrect()
    {
        const ushort one = 1;
        const ushort two = 2;
        
        Assert.IsTrue(one.IsOdd());
        Assert.IsFalse(two.IsOdd());
    }
}
