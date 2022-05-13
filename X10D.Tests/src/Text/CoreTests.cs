using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Text;

namespace X10D.Tests.Text;

[TestClass]
public class CoreTests
{
#if NET5_0_OR_GREATER
    [TestMethod]
    public void ToJsonShouldNotBeEmpty()
    {
        object? obj = null;
        string json = obj.ToJson();
        Assert.IsFalse(string.IsNullOrEmpty(json));
    }

    [TestMethod]
    public void ToJsonShouldDeserializeEquivalent()
    {
        int[] source = Enumerable.Range(1, 100).ToArray();
        string json = source.ToJson();
        int[]? target = json.FromJson<int[]>();
        CollectionAssert.AreEqual(source, target);
        CollectionAssert.AreEquivalent(source, target);
    }
#endif
}
