using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;
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
        IEnumerable<object?> array = o.AsEnumerableValue().ToArray(); // prevent multiple enumeration of IEnumerable
        Assert.IsNotNull(array);
        Assert.IsTrue(array.Count() == 1);
        Assert.AreEqual(o, array.ElementAt(0));
    }

    [TestMethod]
    public void For_ShouldTransform_GivenTransformationDelegate()
    {
        var oneToTen = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var multipliedByIndex = new[] {0, 2, 6, 12, 20, 30, 42, 56, 72, 90};

        IEnumerable<DummyClass> source = oneToTen.Select(i => new DummyClass {Value = i}).ToArray();
        IEnumerable<int> values = source.Select(o => o.Value);
        CollectionAssert.AreEqual(oneToTen, values.ToArray());

        source.For((i, o) => o.Value *= i);
        values = source.Select(o => o.Value);
        CollectionAssert.AreEqual(multipliedByIndex, values.ToArray());
    }

    [TestMethod]
    public void For_ShouldThrow_GivenNullSource()
    {
        IEnumerable<object>? source = null;
        Assert.ThrowsException<ArgumentNullException>(() => source!.For((_, _) => { }));
    }

    [TestMethod]
    public void For_ShouldThrow_GivenNullAction()
    {
        IEnumerable<object> source = ArraySegment<object>.Empty;
        Assert.ThrowsException<ArgumentNullException>(() => source.For(null!));
    }

    [TestMethod]
    public void ForEach_ShouldTransform_GivenTransformationDelegate()
    {
        var oneToTen = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var oneToTenDoubled = new[] {2, 4, 6, 8, 10, 12, 14, 16, 18, 20};

        IEnumerable<DummyClass> source = oneToTen.Select(i => new DummyClass {Value = i}).ToArray();
        IEnumerable<int> values = source.Select(o => o.Value);
        CollectionAssert.AreEqual(oneToTen, values.ToArray());

        source.ForEach(o => o.Value *= 2);
        values = source.Select(o => o.Value);
        CollectionAssert.AreEqual(oneToTenDoubled, values.ToArray());
    }

    [TestMethod]
    public void ForEach_ShouldThrow_GivenNullSource()
    {
        IEnumerable<object>? source = null;
        Assert.ThrowsException<ArgumentNullException>(() => source!.ForEach(_ => { }));
    }

    [TestMethod]
    public void ForEach_ShouldThrow_GivenNullAction()
    {
        IEnumerable<object> source = ArraySegment<object>.Empty;
        Assert.ThrowsException<ArgumentNullException>(() => source.ForEach(null!));
    }

    private class DummyClass
    {
        public int Value { get; set; }
    }
}
