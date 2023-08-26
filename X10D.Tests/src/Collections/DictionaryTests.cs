using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestFixture]
internal class DictionaryTests
{
    [Test]
    public void AddOrUpdate_ShouldAddNewKey_IfNotExists_GivenConcreteDictionary()
    {
        var dictionary = new Dictionary<int, string>();
        Assert.That(dictionary.ContainsKey(1), Is.False);

        dictionary.AddOrUpdate(1, "one", (_, _) => string.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1));
            Assert.That(dictionary[1], Is.EqualTo("one"));
        });

        dictionary.Clear();
        Assert.That(dictionary.ContainsKey(1), Is.False);

        dictionary.AddOrUpdate(1, _ => "one", (_, _) => string.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1));
            Assert.That(dictionary[1], Is.EqualTo("one"));
        });

        dictionary.Clear();
        Assert.That(dictionary, Is.Empty);
        Assert.That(dictionary.ContainsKey(1), Is.False);

        dictionary.AddOrUpdate(1, (_, _) => "one", (_, _, _) => string.Empty, 0);
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1), Is.True);
            Assert.That(dictionary[1], Is.EqualTo("one"));
        });
    }

    [Test]
    public void AddOrUpdate_ShouldAddNewKey_IfNotExists_GivenIDictionary()
    {
        IDictionary<int, string> dictionary = new Dictionary<int, string>();
        Assert.That(dictionary.ContainsKey(1), Is.False);

        dictionary.AddOrUpdate(1, "one", (_, _) => string.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1), Is.True);
            Assert.That(dictionary[1], Is.EqualTo("one"));
        });

        dictionary.Clear();
        Assert.That(dictionary.ContainsKey(1), Is.False);

        dictionary.AddOrUpdate(1, _ => "one", (_, _) => string.Empty);
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1), Is.True);
            Assert.That(dictionary[1], Is.EqualTo("one"));
        });

        dictionary.Clear();
        Assert.That(dictionary, Is.Empty);
        Assert.That(dictionary.ContainsKey(1), Is.False);

        dictionary.AddOrUpdate(1, (_, _) => "one", (_, _, _) => string.Empty, 0);
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1), Is.True);
            Assert.That(dictionary[1], Is.EqualTo("one"));
        });
    }

    [Test]
    public void AddOrUpdate_ShouldUpdateKey_IfExists_GivenConcreteDirection()
    {
        var dictionary = new Dictionary<int, string> {[1] = "one"};
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1));
            Assert.That(dictionary[1], Is.EqualTo("one"));
        });

        dictionary.AddOrUpdate(1, string.Empty, (_, _) => "two");
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1));
            Assert.That(dictionary[1], Is.EqualTo("two"));
        });

        dictionary.Clear();
        Assert.That(dictionary, Is.Empty);
        Assert.That(dictionary.ContainsKey(1), Is.False);

        dictionary[1] = "one";
        dictionary.AddOrUpdate(1, _ => string.Empty, (_, _) => "two");

        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1));
            Assert.That(dictionary[1], Is.EqualTo("two"));
        });

        dictionary.Clear();
        Assert.That(dictionary, Is.Empty);
        Assert.That(dictionary.ContainsKey(1), Is.False);
        dictionary[1] = "one";

        dictionary.AddOrUpdate(1, (_, _) => string.Empty, (_, _, _) => "two", 0);
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1));
            Assert.That(dictionary[1], Is.EqualTo("two"));
        });
    }

    [Test]
    public void AddOrUpdate_ShouldUpdateKey_IfExists_GivenIDictionary()
    {
        IDictionary<int, string> dictionary = new Dictionary<int, string> {[1] = "one"};
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1));
            Assert.That(dictionary[1], Is.EqualTo("one"));
        });

        dictionary.AddOrUpdate(1, string.Empty, (_, _) => "two");
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1));
            Assert.That(dictionary[1], Is.EqualTo("two"));
        });

        dictionary.Clear();
        Assert.Multiple(() =>
        {
            Assert.That(dictionary, Is.Empty);
            Assert.That(dictionary.ContainsKey(1), Is.False);
        });

        dictionary[1] = "one";
        dictionary.AddOrUpdate(1, _ => string.Empty, (_, _) => "two");
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1));
            Assert.That(dictionary[1], Is.EqualTo("two"));
        });

        dictionary.Clear();
        Assert.Multiple(() =>
        {
            Assert.That(dictionary, Is.Empty);
            Assert.That(dictionary.ContainsKey(1), Is.False);
            dictionary[1] = "one";
        });

        dictionary.AddOrUpdate(1, (_, _) => string.Empty, (_, _, _) => "two", 0);
        Assert.Multiple(() =>
        {
            Assert.That(dictionary.ContainsKey(1));
            Assert.That(dictionary[1], Is.EqualTo("two"));
        });
    }

    [Test]
    public void AddOrUpdate_ShouldThrow_GivenNullDictionary_GivenConcreteDictionary()
    {
        Dictionary<int, string>? dictionary = null;
        Assert.Throws<ArgumentNullException>(() => dictionary!.AddOrUpdate(1, string.Empty, (_, _) => string.Empty));
        Assert.Throws<ArgumentNullException>(() =>
            dictionary!.AddOrUpdate(1, _ => string.Empty, (_, _) => string.Empty));
        Assert.Throws<ArgumentNullException>(() =>
            dictionary!.AddOrUpdate(1, (_, _) => string.Empty, (_, _, _) => string.Empty, 0));
    }

    [Test]
    public void AddOrUpdate_ShouldThrow_GivenNullDictionary_GivenIDictionary()
    {
        IDictionary<int, string>? dictionary = null;
        Assert.Throws<ArgumentNullException>(() => dictionary!.AddOrUpdate(1, string.Empty, (_, _) => string.Empty));
        Assert.Throws<ArgumentNullException>(() =>
            dictionary!.AddOrUpdate(1, _ => string.Empty, (_, _) => string.Empty));
        Assert.Throws<ArgumentNullException>(() =>
            dictionary!.AddOrUpdate(1, (_, _) => string.Empty, (_, _, _) => string.Empty, 0));
    }

    [Test]
    public void AddOrUpdate_ShouldThrow_GivenNullUpdateValueFactory_GivenConcreteDictionary()
    {
        var dictionary = new Dictionary<int, string>();
        Assert.Throws<ArgumentNullException>(() => dictionary.AddOrUpdate(1, string.Empty, null!));
        Assert.Throws<ArgumentNullException>(() => dictionary.AddOrUpdate(1, _ => string.Empty, null!));
        Assert.Throws<ArgumentNullException>(() => dictionary.AddOrUpdate(1, (_, _) => string.Empty, null!, 0));
    }

    [Test]
    public void AddOrUpdate_ShouldThrow_GivenNullUpdateValueFactory_GivenIDictionary()
    {
        IDictionary<int, string> dictionary = new Dictionary<int, string>();
        Assert.Throws<ArgumentNullException>(() => dictionary.AddOrUpdate(1, string.Empty, null!));
        Assert.Throws<ArgumentNullException>(() => dictionary.AddOrUpdate(1, _ => string.Empty, null!));
        Assert.Throws<ArgumentNullException>(() => dictionary.AddOrUpdate(1, (_, _) => string.Empty, null!, 0));
    }

    [Test]
    public void AddOrUpdate_ShouldThrow_GivenNullAddValueFactory_GivenConcreteDictionary()
    {
        var dictionary = new Dictionary<int, string>();
        Func<int, string>? addValueFactory = null;
        Assert.Throws<ArgumentNullException>(() => dictionary.AddOrUpdate(1, addValueFactory!, (_, _) => "one"));
        Assert.Throws<ArgumentNullException>(() => dictionary.AddOrUpdate(1, null!, (_, _, _) => "one", 0));
    }

    [Test]
    public void AddOrUpdate_ShouldThrow_GivenNullAddValueFactory_GivenIDictionary()
    {
        IDictionary<int, string> dictionary = new Dictionary<int, string>();
        Func<int, string>? addValueFactory = null;
        Assert.Throws<ArgumentNullException>(() => dictionary.AddOrUpdate(1, addValueFactory!, (_, _) => "one"));
        Assert.Throws<ArgumentNullException>(() => dictionary.AddOrUpdate(1, null!, (_, _, _) => "one", 0));
    }

    [Test]
    public void ToConnectionString_ShouldReturnConnectionString()
    {
        var dictionary = new Dictionary<string, string?>
        {
            ["Data Source"] = "localhost", ["Initial Catalog"] = "test", ["Integrated Security"] = "True", ["Foobar"] = null
        };

        string connectionString = dictionary.ToConnectionString();
        Assert.That(connectionString, Is.EqualTo("Data Source=localhost;Initial Catalog=test;Integrated Security=True;Foobar="));
    }

    [Test]
    public void ToConnectionString_ShouldReturnTransformedValueConnectionString()
    {
        var dictionary = new Dictionary<string, string?>
        {
            ["Data Source"] = "localhost", ["Initial Catalog"] = "test", ["Integrated Security"] = "True", ["Foobar"] = null
        };

        string connectionString = dictionary.ToConnectionString(v => v?.ToUpperInvariant());
        Assert.That(connectionString, Is.EqualTo("Data Source=LOCALHOST;Initial Catalog=TEST;Integrated Security=TRUE;Foobar="));
    }

    [Test]
    public void ToConnectionString_ShouldReturnTransformedKeyValueConnectionString()
    {
        var dictionary = new Dictionary<string, string?>
        {
            ["Data Source"] = "localhost", ["Initial Catalog"] = "test", ["Integrated Security"] = "True", ["Foobar"] = null
        };

        string connectionString = dictionary.ToConnectionString(k => k.ToUpper(), v => v?.ToUpperInvariant());
        Assert.That(connectionString, Is.EqualTo("DATA SOURCE=LOCALHOST;INITIAL CATALOG=TEST;INTEGRATED SECURITY=TRUE;FOOBAR="));
    }

    [Test]
    public void ToConnectionString_ShouldThrow_GivenNullSource()
    {
        Dictionary<string, string> dictionary = null!;
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToConnectionString());
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToConnectionString(null!));
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToConnectionString(null!, null!));
    }

    [Test]
    public void ToConnectionString_ShouldThrow_GivenNullSelector()
    {
        var dictionary = new Dictionary<string, string>();
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToConnectionString(null!));
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToConnectionString(null!, _ => _));
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToConnectionString(_ => _, null!));
    }

    [Test]
    public void ToGetParameters_ShouldReturnParameters()
    {
        var dictionary = new Dictionary<string, string> {["id"] = "1", ["user"] = "hello world", ["foo"] = "bar"};

        string queryString = dictionary.ToGetParameters();
        Assert.That(queryString, Is.EqualTo("id=1&user=hello+world&foo=bar"));
    }

    [Test]
    public void ToGetParameters_ShouldReturnTransformedValueParameters()
    {
        var dictionary = new Dictionary<string, string?> {["id"] = "1", ["user"] = "hello world", ["foo"] = null};

        string queryString = dictionary.ToGetParameters(v => v?.ToUpper());
        Assert.That(queryString, Is.EqualTo("id=1&user=HELLO+WORLD&foo="));
    }

    [Test]
    public void ToGetParameters_ShouldReturnTransformedKeyValueParameters()
    {
        var dictionary = new Dictionary<string, string?> {["id"] = "1", ["user"] = "hello world", ["foo"] = null};

        string queryString = dictionary.ToGetParameters(k => k.ToUpper(), v => v?.ToUpper());
        Assert.That(queryString, Is.EqualTo("ID=1&USER=HELLO+WORLD&FOO="));
    }

    [Test]
    public void ToGetParameters_ShouldThrow_GivenNullSource()
    {
        Dictionary<string, string> dictionary = null!;
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToGetParameters());
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToGetParameters(null!));
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToGetParameters(null!, null!));
    }

    [Test]
    public void ToGetParameters_ShouldThrow_GivenNullSelector()
    {
        var dictionary = new Dictionary<string, string>();
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToGetParameters(null!));
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToGetParameters(null!, _ => _));
        Assert.Throws<ArgumentNullException>(() => _ = dictionary.ToGetParameters(_ => _, null!));
    }
}
