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
    public void AsEnumerable(object o)
    {
        IEnumerable<object?> array = o.AsEnumerable().ToArray(); // prevent multiple enumeration of IEnumerable
        Assert.IsNotNull(array);
        Assert.IsTrue(array.Count() == 1);
        Assert.AreEqual(o, array.ElementAt(0));
    }

    [TestMethod]
    [DataRow(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
    public void Shuffled(params int[] source)
    {
        int[] shuffled = source.Shuffled().ToArray(); // ToArray forces type match
        CollectionAssert.AreNotEqual(source, shuffled);
    }
}
