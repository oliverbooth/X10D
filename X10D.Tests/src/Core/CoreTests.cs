using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Core;

namespace X10D.Tests.Core;

[TestClass]
public class CoreTests
{
    [TestMethod]
    public void AsArrayShouldBeLength1()
    {
        Assert.AreEqual(1, 0.AsArrayValue().Length);
        Assert.AreEqual(1, string.Empty.AsArrayValue().Length);
        Assert.AreEqual(1, true.AsArrayValue().Length);
        Assert.AreEqual(1, ((object?)null).AsArrayValue().Length);
    }
    
    [TestMethod]
    public void AsEnumerableShouldBeLength1()
    {
        Assert.AreEqual(1, 0.AsEnumerableValue().Count());
        Assert.AreEqual(1, string.Empty.AsEnumerableValue().Count());
        Assert.AreEqual(1, true.AsEnumerableValue().Count());
        Assert.AreEqual(1, ((object?)null).AsEnumerableValue().Count());
    }
}
