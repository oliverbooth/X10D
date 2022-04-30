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

    [TestMethod]
    public void ToConnectionString_ShouldReturnConnectionString()
    {
        var dictionary = new Dictionary<string, string?>
        {
            ["Data Source"] = "localhost", ["Initial Catalog"] = "test", ["Integrated Security"] = "True", ["Foobar"] = null
        };

        string connectionString = dictionary.ToConnectionString();
        Assert.AreEqual("Data Source=localhost;Initial Catalog=test;Integrated Security=True;Foobar=", connectionString);
    }

    [TestMethod]
    public void ToConnectionString_ShouldReturnTransformedValueConnectionString()
    {
        var dictionary = new Dictionary<string, string?>
        {
            ["Data Source"] = "localhost", ["Initial Catalog"] = "test", ["Integrated Security"] = "True", ["Foobar"] = null
        };

        string connectionString = dictionary.ToConnectionString(v => v?.ToUpperInvariant());
        Assert.AreEqual("Data Source=LOCALHOST;Initial Catalog=TEST;Integrated Security=TRUE;Foobar=", connectionString);
    }

    [TestMethod]
    public void ToConnectionString_ShouldReturnTransformedKeyValueConnectionString()
    {
        var dictionary = new Dictionary<string, string?>
        {
            ["Data Source"] = "localhost", ["Initial Catalog"] = "test", ["Integrated Security"] = "True", ["Foobar"] = null
        };

        string connectionString = dictionary.ToConnectionString(k => k.ToUpper(), v => v?.ToUpperInvariant());
        Assert.AreEqual("DATA SOURCE=LOCALHOST;INITIAL CATALOG=TEST;INTEGRATED SECURITY=TRUE;FOOBAR=", connectionString);
    }

    [TestMethod]
    public void ToConnectionString_ShouldThrow_GivenNullSource()
    {
        Dictionary<string, string>? dictionary = null;
        Assert.ThrowsException<ArgumentNullException>(() => dictionary!.ToConnectionString());
        Assert.ThrowsException<ArgumentNullException>(() => dictionary!.ToConnectionString(null!));
        Assert.ThrowsException<ArgumentNullException>(() => dictionary!.ToConnectionString(null!, null!));
    }

    [TestMethod]
    public void ToConnectionString_ShouldThrow_GivenNullSelector()
    {
        var dictionary = new Dictionary<string, string>();
        Assert.ThrowsException<ArgumentNullException>(() => dictionary.ToConnectionString(null!));
        Assert.ThrowsException<ArgumentNullException>(() => dictionary.ToConnectionString(null!, _ => _));
        Assert.ThrowsException<ArgumentNullException>(() => dictionary.ToConnectionString(_ => _, null!));
    }

    [TestMethod]
    public void ToGetParameters_ShouldReturnParameters()
    {
        var dictionary = new Dictionary<string, string> {["id"] = "1", ["user"] = "hello world", ["foo"] = "bar"};

        string queryString = dictionary.ToGetParameters();
        Assert.AreEqual("id=1&user=hello+world&foo=bar", queryString);
    }

    [TestMethod]
    public void ToGetParameters_ShouldReturnTransformedValueParameters()
    {
        var dictionary = new Dictionary<string, string?> {["id"] = "1", ["user"] = "hello world", ["foo"] = null};

        string queryString = dictionary.ToGetParameters(v => v?.ToUpper());
        Assert.AreEqual("id=1&user=HELLO+WORLD&foo=", queryString);
    }

    [TestMethod]
    public void ToGetParameters_ShouldReturnTransformedKeyValueParameters()
    {
        var dictionary = new Dictionary<string, string?> {["id"] = "1", ["user"] = "hello world", ["foo"] = null};

        string queryString = dictionary.ToGetParameters(k => k.ToUpper(), v => v?.ToUpper());
        Assert.AreEqual("ID=1&USER=HELLO+WORLD&FOO=", queryString);
    }

    [TestMethod]
    public void ToGetParameters_ShouldThrow_GivenNullSource()
    {
        Dictionary<string, string>? dictionary = null;
        Assert.ThrowsException<ArgumentNullException>(() => dictionary!.ToGetParameters());
        Assert.ThrowsException<ArgumentNullException>(() => dictionary!.ToGetParameters(null!));
        Assert.ThrowsException<ArgumentNullException>(() => dictionary!.ToGetParameters(null!, null!));
    }

    [TestMethod]
    public void ToGetParameters_ShouldThrow_GivenNullSelector()
    {
        var dictionary = new Dictionary<string, string>();
        Assert.ThrowsException<ArgumentNullException>(() => dictionary.ToGetParameters(null!));
        Assert.ThrowsException<ArgumentNullException>(() => dictionary.ToGetParameters(null!, _ => _));
        Assert.ThrowsException<ArgumentNullException>(() => dictionary.ToGetParameters(_ => _, null!));
    }
}
