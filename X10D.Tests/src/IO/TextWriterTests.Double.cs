using System.Globalization;
using System.Text;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

public partial class TextWriterTests
{
    [Test]
    public void WriteNoAlloc_ShouldThrowArgumentNullException_GivenDouble_AndNullWriter()
    {
        TextWriter writer = null!;
        Assert.Throws<ArgumentNullException>(() => writer.WriteNoAlloc(420.0));
        Assert.Throws<ArgumentNullException>(() => writer.WriteNoAlloc(420.0, "N0"));
        Assert.Throws<ArgumentNullException>(() => writer.WriteNoAlloc(420.0, "N0", null));
    }

    [Test]
    public void WriteNoAlloc_ShouldThrowObjectDisposedException_GivenDouble_AndDisposedStream()
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream, Encoding.UTF8);
        writer.Dispose();
        stream.Dispose();

        Assert.Throws<ObjectDisposedException>(() => writer.WriteNoAlloc(420.0));
        Assert.Throws<ObjectDisposedException>(() => writer.WriteNoAlloc(420.0, "N0"));
        Assert.Throws<ObjectDisposedException>(() => writer.WriteNoAlloc(420.0, "N0", null));
    }

    [Test]
    public void WriteLineNoAlloc_ShouldThrowArgumentNullException_GivenDouble_AndNullWriter()
    {
        TextWriter writer = null!;
        Assert.Throws<ArgumentNullException>(() => writer.WriteLineNoAlloc(420.0));
        Assert.Throws<ArgumentNullException>(() => writer.WriteLineNoAlloc(420.0, "N0"));
        Assert.Throws<ArgumentNullException>(() => writer.WriteLineNoAlloc(420.0, "N0", null));
    }

    [Test]
    public void WriteLineNoAlloc_ShouldThrowObjectDisposedException_GivenDouble_AndDisposedStream()
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream, Encoding.UTF8);
        writer.Dispose();
        stream.Dispose();

        Assert.Throws<ObjectDisposedException>(() => writer.WriteLineNoAlloc(420.0));
        Assert.Throws<ObjectDisposedException>(() => writer.WriteLineNoAlloc(420.0, "N0"));
        Assert.Throws<ObjectDisposedException>(() => writer.WriteLineNoAlloc(420.0, "N0", null));
    }

    [Test]
    public void WriteNoAlloc_ShouldWriteTextValue_GivenDouble()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteNoAlloc(420.0);
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        const string expected = "420";

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteNoAlloc_ShouldWriteTextValue_GivenDouble_AndFormatString()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteNoAlloc(420.0, "N0");
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        const string expected = "420";

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteNoAlloc_ShouldWriteTextValue_GivenDouble_AndFormatString_AndCultureInfo()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteNoAlloc(420.0, "N0", CultureInfo.CurrentCulture);
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        const string expected = "420";

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteLineNoAlloc_ShouldWriteTextValue_GivenDouble()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteLineNoAlloc(420.0);
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        var expected = $"420{Environment.NewLine}";

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteLineNoAlloc_ShouldWriteTextValue_GivenDouble_AndFormatString()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteLineNoAlloc(420.0, "N0");
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        var expected = $"420{Environment.NewLine}";

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteLineNoAlloc_ShouldWriteTextValue_GivenDouble_AndFormatString_AndCultureInfo()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteLineNoAlloc(420.0, "N0", CultureInfo.CurrentCulture);
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        var expected = $"420{Environment.NewLine}";

        Assert.That(actual, Is.EqualTo(expected));
    }
}
