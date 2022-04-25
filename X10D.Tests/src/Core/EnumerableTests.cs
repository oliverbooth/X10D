using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Core;

namespace X10D.Tests.Core;

[TestClass]
public class EnumerableTests
{
    [TestMethod]
    [DataRow(1)]
    [DataRow("f")]
    [DataRow(true)]
    public void AsEnumerable_ShouldWrapElement_GivenValue(object o)
    {
        IEnumerable<object?> array = o.AsEnumerable().ToArray(); // prevent multiple enumeration of IEnumerable
        Assert.IsNotNull(array);
        Assert.IsTrue(array.Count() == 1);
        Assert.AreEqual(o, array.ElementAt(0));
    }
}
