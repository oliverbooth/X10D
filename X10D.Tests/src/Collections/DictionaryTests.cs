using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class DictionaryTests
{
    [TestMethod]
    public void AddOrUpdate_ShouldAddNewKey_IfNotExists()
    {
        var dictionary = new Dictionary<int, string>();
        Assert.IsFalse(dictionary.ContainsKey(1));

        dictionary.AddOrUpdate(1, "one", (_, _) => string.Empty);
        Assert.IsTrue(dictionary.ContainsKey(1));
        Assert.AreEqual("one", dictionary[1]);

        dictionary.Clear();
        Assert.IsFalse(dictionary.ContainsKey(1));

        dictionary.AddOrUpdate(1, _ => "one", (_, _) => string.Empty);
        Assert.IsTrue(dictionary.ContainsKey(1));
        Assert.AreEqual("one", dictionary[1]);

        dictionary.Clear();
        Assert.IsFalse(dictionary.ContainsKey(1));

        dictionary.AddOrUpdate(1, (_, _) => "one", (_, _, _) => string.Empty, 0);
        Assert.IsTrue(dictionary.ContainsKey(1));
        Assert.AreEqual("one", dictionary[1]);
    }

    [TestMethod]
    public void AddOrUpdate_ShouldUpdateKey_IfExists()
    {
        var dictionary = new Dictionary<int, string> {[1] = "one"};
        Assert.IsTrue(dictionary.ContainsKey(1));
        Assert.AreEqual("one", dictionary[1]);

        dictionary.AddOrUpdate(1, string.Empty, (_, _) => "two");
        Assert.IsTrue(dictionary.ContainsKey(1));
        Assert.AreEqual("two", dictionary[1]);

        dictionary.Clear();
        Assert.IsFalse(dictionary.ContainsKey(1));
        dictionary[1] = "one";

        dictionary.AddOrUpdate(1, _ => string.Empty, (_, _) => "two");
        Assert.IsTrue(dictionary.ContainsKey(1));
        Assert.AreEqual("two", dictionary[1]);

        dictionary.Clear();
        Assert.IsFalse(dictionary.ContainsKey(1));
        dictionary[1] = "one";

        dictionary.AddOrUpdate(1, (_, _) => string.Empty, (_, _, _) => "two", 0);
        Assert.IsTrue(dictionary.ContainsKey(1));
        Assert.AreEqual("two", dictionary[1]);
    }

    [TestMethod]
    public void AddOrUpdate_ShouldThrow_GivenNullDictionary()
    {
        Dictionary<int, string>? dictionary = null;
        Assert.ThrowsException<ArgumentNullException>(() => dictionary!.AddOrUpdate(1, string.Empty, (_, _) => string.Empty));
        Assert.ThrowsException<ArgumentNullException>(() =>
            dictionary!.AddOrUpdate(1, _ => string.Empty, (_, _) => string.Empty));
        Assert.ThrowsException<ArgumentNullException>(() =>
            dictionary!.AddOrUpdate(1, (_, _) => string.Empty, (_, _, _) => string.Empty, 0));
    }

    [TestMethod]
    public void AddOrUpdate_ShouldThrow_GivenNullUpdateValueFactory()
    {
        var dictionary = new Dictionary<int, string>();
        Assert.ThrowsException<ArgumentNullException>(() => dictionary.AddOrUpdate(1, string.Empty, null!));
        Assert.ThrowsException<ArgumentNullException>(() => dictionary.AddOrUpdate(1, _ => string.Empty, null!));
        Assert.ThrowsException<ArgumentNullException>(() => dictionary.AddOrUpdate(1, (_, _) => string.Empty, null!, 0));
    }

    [TestMethod]
    public void AddOrUpdate_ShouldThrow_GivenNullAddValueFactory()
    {
        var dictionary = new Dictionary<int, string>();
        Func<int, string>? addValueFactory = null;
        Assert.ThrowsException<ArgumentNullException>(() => dictionary.AddOrUpdate(1, addValueFactory!, (_, _) => "one"));
        Assert.ThrowsException<ArgumentNullException>(() => dictionary.AddOrUpdate(1, null!, (_, _, _) => "one", 0));
    }
}
