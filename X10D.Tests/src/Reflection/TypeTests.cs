using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Reflection;

namespace X10D.Tests.Reflection;

[TestClass]
public class TypeTests
{
    [TestMethod]
    public void Inherits_ShouldBeTrue_GivenStringInheritsObject()
    {
        Assert.IsTrue(typeof(string).Inherits(typeof(object)));
        Assert.IsTrue(typeof(string).Inherits<object>());
    }

    [TestMethod]
    public void Inherits_ShouldBeFalse_GivenObjectInheritsString()
    {
        Assert.IsFalse(typeof(object).Inherits(typeof(string)));
        Assert.IsFalse(typeof(object).Inherits<string>());
    }

    [TestMethod]
    public void Inherits_ShouldThrow_GivenValueType()
    {
        Assert.ThrowsException<ArgumentException>(() => typeof(int).Inherits(typeof(object)));
        Assert.ThrowsException<ArgumentException>(() => typeof(object).Inherits(typeof(int)));
    }

    [TestMethod]
    public void Inherits_ShouldThrow_GivenNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => typeof(object).Inherits(null!));
        Assert.ThrowsException<ArgumentNullException>(() => ((Type?)null)!.Inherits(typeof(object)));
    }

    [TestMethod]
    public void Implements_ShouldBeTrue_GivenInt32ImplementsIComparable()
    {
        Assert.IsTrue(typeof(int).Implements<IComparable>());
        Assert.IsTrue(typeof(int).Implements<IComparable<int>>());
        Assert.IsTrue(typeof(int).Implements(typeof(IComparable)));
        Assert.IsTrue(typeof(int).Implements(typeof(IComparable<int>)));
    }

    [TestMethod]
    public void Implements_ShouldThrow_GivenNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => typeof(object).Implements(null!));
        Assert.ThrowsException<ArgumentNullException>(() => ((Type?)null)!.Implements(typeof(object)));
    }

    [TestMethod]
    public void Implements_ShouldThrow_GivenNonInterface()
    {
        Assert.ThrowsException<ArgumentException>(() => typeof(string).Implements<object>());
        Assert.ThrowsException<ArgumentException>(() => typeof(string).Implements(typeof(object)));
    }
}
