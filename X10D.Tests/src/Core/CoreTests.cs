using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Core;

namespace X10D.Tests.Core;

[TestClass]
public class CoreTests
{
    [TestMethod]
    public void AsArrayShouldBeLength1()
    {
        Assert.AreEqual(1, 0.AsArray().Length);
        Assert.AreEqual(1, string.Empty.AsArray().Length);
        Assert.AreEqual(1, true.AsArray().Length);
        Assert.AreEqual(1, ((object?)null).AsArray().Length);
    }
    
    [TestMethod]
    public void AsEnumerableShouldBeLength1()
    {
        Assert.AreEqual(1, 0.AsEnumerable().Count());
        Assert.AreEqual(1, string.Empty.AsEnumerable().Count());
        Assert.AreEqual(1, true.AsEnumerable().Count());
        Assert.AreEqual(1, ((object?)null).AsEnumerable().Count());
    }
}
