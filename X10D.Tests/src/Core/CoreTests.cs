using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Core;

namespace X10D.Tests.Core;

[TestClass]
public class CoreTests
{
    [TestMethod]
    [DataRow(1)]
    [DataRow("f")]
    [DataRow(true)]
    public void AsArrayValue_ShouldBeLength1_GivenValue(object o)
    {
        object[] array = o.AsArrayValue()!;
        Assert.IsNotNull(array);
        Assert.IsTrue(array.Length == 1);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow("f")]
    [DataRow(true)]
    public void AsArrayValue_ShouldContainValue_Given_Value(object o)
    {
        object[] array = o.AsArrayValue()!;
        Assert.IsNotNull(array);
        Assert.AreEqual(o, array[0]);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow("f")]
    [DataRow(true)]
    public void AsEnumerableValue_ShouldBeLength1_GivenValue(object o)
    {
        IEnumerable<object> array = o.AsEnumerableValue()!;
        Assert.IsNotNull(array);
        Assert.IsTrue(array.Count() == 1);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow("f")]
    [DataRow(true)]
    public void AsEnumerableValue_ShouldContainValue_Given_Value(object o)
    {
        IEnumerable<object> array = o.AsEnumerableValue()!;
        Assert.IsNotNull(array);
        Assert.AreEqual(o, array.ElementAt(0));
    }
}
