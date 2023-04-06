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

        // When StreamWriter flushes for the first time, an encoding preamble is written to the stream,
        // which is correctly mirrored by the behaviour of StreamReader.
        // however, we're not using StreamReader, we read the contents of the stream
        // using MemoryStream.ToArray(). This was causing one test to fail, as the first test
        // that runs would cause the preamble to be written and not be accounted for when reading.
        // Subsequent tests would pass since the preamble would not be written again.
        // The following 4 lines ensure that the preamble is written by manually flushing the
        // writer after writing a single space character. We then clear the stream, and allow
        // unit tests to do their thing. This took me an HOUR AND A HALF to narrow down.
        // I want to fucking die.
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
