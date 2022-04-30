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
        IEnumerable<object> enumerable = o.AsEnumerableValue()!;
        Assert.IsNotNull(enumerable);
        Assert.IsTrue(enumerable.Count() == 1);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow("f")]
    [DataRow(true)]
    public void AsEnumerableValue_ShouldContainValue_Given_Value(object o)
    {
        IEnumerable<object> enumerable = o.AsEnumerableValue()!;
        Assert.IsNotNull(enumerable);
        Assert.AreEqual(o, enumerable.ElementAt(0));
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow("f")]
    [DataRow(true)]
    public void RepeatValue_ShouldContainRepeatedValue_GivenValue(object o)
    {
        IEnumerable<object> enumerable = o.RepeatValue(10);
        Assert.IsNotNull(enumerable);

        object[] array = enumerable.ToArray();
        Assert.AreEqual(10, array.Length);
        CollectionAssert.AreEqual(new[] {o, o, o, o, o, o, o, o, o, o}, array);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow("f")]
    [DataRow(true)]
    public void RepeatValue_ShouldThrow_GivenNegativeCount(object o)
    {
        // we must force enumeration via ToArray() to ensure the exception is thrown
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => o.RepeatValue(-1).ToArray());
    }
}
