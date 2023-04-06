using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace X10D.Tests.IO;

[TestFixture]
public partial class TextWriterTests
{
    private MemoryStream _stream = null!;
    private StreamWriter _writer = null!;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _stream = new MemoryStream();
        _writer = new StreamWriter(_stream, Encoding.UTF8);
        _writer.Write(' ');
        _writer.Flush();
        _stream.SetLength(0);
        _stream.Position = 0;

        Trace.Listeners.Add(new ConsoleTraceListener());
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _writer.Dispose();
        _stream.Dispose();

        Trace.Flush();
    }

    [SetUp]
    public void Setup()
    {
        _stream.SetLength(0);
    }

    [TearDown]
    public void TearDown()
    {
        _stream.SetLength(0);
    }
}
