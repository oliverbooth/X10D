using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

[TestClass]
public partial class EnumerableTests
{
    [TestMethod]
    [DataRow(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
    public void Shuffled(params int[] source)
    {
        int[] shuffled = source.Shuffled().ToArray(); // ToArray forces type match
        CollectionAssert.AreNotEqual(source, shuffled);
    }
}
