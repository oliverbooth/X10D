using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Core;

namespace X10D.Tests.Core;

[TestClass]
public class NullableTests
{
    [TestMethod]
    public void TryGetValue_ShouldBeTrue_GivenValue()
    {
        int? value = 42;
        Assert.IsTrue(value.TryGetValue(out int returnedValue));
        Assert.AreEqual(value, returnedValue);
    }

    [TestMethod]
    public void TryGetValue_ShouldBeFalse_GivenNull()
    {
        int? value = null;
        Assert.IsFalse(value.TryGetValue(out int returnedValue));
        Assert.AreEqual(default, returnedValue);
    }
}
