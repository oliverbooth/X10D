using System.Globalization;
using System.Text;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

public partial class TextWriterTests
{
    [Test]
    public void WriteNoAlloc_ShouldThrowArgumentNullException_GivenUInt64_AndNullWriter()
    {
        TextWriter writer = null!;
        Assert.Throws<ArgumentNullException>(() => writer.WriteNoAlloc(420UL));
        Assert.Throws<ArgumentNullException>(() => writer.WriteNoAlloc(420UL, "N0"));
        Assert.Throws<ArgumentNullException>(() => writer.WriteNoAlloc(420UL, "N0", null));
    }

    [Test]
    public void WriteNoAlloc_ShouldThrowObjectDisposedException_GivenUInt64_AndDisposedStream()
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream, Encoding.UTF8);
        writer.Dispose();
        stream.Dispose();

        Assert.Throws<ObjectDisposedException>(() => writer.WriteNoAlloc(420UL));
        Assert.Throws<ObjectDisposedException>(() => writer.WriteNoAlloc(420UL, "N0"));
        Assert.Throws<ObjectDisposedException>(() => writer.WriteNoAlloc(420UL, "N0", null));
    }

    [Test]
    public void WriteLineNoAlloc_ShouldThrowArgumentNullException_GivenUInt64_AndNullWriter()
    {
        TextWriter writer = null!;
        Assert.Throws<ArgumentNullException>(() => writer.WriteLineNoAlloc(420UL));
        Assert.Throws<ArgumentNullException>(() => writer.WriteLineNoAlloc(420UL, "N0"));
        Assert.Throws<ArgumentNullException>(() => writer.WriteLineNoAlloc(420UL, "N0", null));
    }

    [Test]
    public void WriteLineNoAlloc_ShouldThrowObjectDisposedException_GivenUInt64_AndDisposedStream()
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream, Encoding.UTF8);
        writer.Dispose();
        stream.Dispose();

        Assert.Throws<ObjectDisposedException>(() => writer.WriteLineNoAlloc(420UL));
        Assert.Throws<ObjectDisposedException>(() => writer.WriteLineNoAlloc(420UL, "N0"));
        Assert.Throws<ObjectDisposedException>(() => writer.WriteLineNoAlloc(420UL, "N0", null));
    }

    [Test]
    public void WriteNoAlloc_ShouldWriteTextValue_GivenUInt64()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteNoAlloc(420UL);
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        const string expected = "420";

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteNoAlloc_ShouldWriteTextValue_GivenUInt64_AndFormatString()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteNoAlloc(420UL, "N0");
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        const string expected = "420";

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteNoAlloc_ShouldWriteTextValue_GivenUInt64_AndFormatString_AndCultureInfo()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteNoAlloc(420UL, "N0", CultureInfo.CurrentCulture);
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        const string expected = "420";

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteLineNoAlloc_ShouldWriteTextValue_GivenUInt64()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteLineNoAlloc(420UL);
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        var expected = $"420{Environment.NewLine}";

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteLineNoAlloc_ShouldWriteTextValue_GivenUInt64_AndFormatString()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteLineNoAlloc(420UL, "N0");
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        var expected = $"420{Environment.NewLine}";

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WriteLineNoAlloc_ShouldWriteTextValue_GivenUInt64_AndFormatString_AndCultureInfo()
    {
        Assert.That(_stream.Length, Is.Zero);
        _writer.WriteLineNoAlloc(420UL, "N0", CultureInfo.CurrentCulture);
        _writer.Flush();

        string actual = Encoding.UTF8.GetString(_stream.ToArray());
        var expected = $"420{Environment.NewLine}";

        Assert.That(actual, Is.EqualTo(expected));
    }
}
