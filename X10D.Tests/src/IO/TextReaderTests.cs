using System.Text;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class TextReaderTests
{
    [Test]
    public void EnumerateLines_ShouldYield10Lines_Given10LineString()
    {
        using var stream = new MemoryStream();
        using (var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true))
        {
            for (var index = 0; index < 10; index++)
            {
                writer.WriteLine(index);
            }
        }

        stream.Position = 0;
        using var reader = new StreamReader(stream, Encoding.UTF8);
        var lineCount = 0;

        foreach (string _ in reader.EnumerateLines())
        {
            lineCount++;
        }

        Assert.That(lineCount, Is.EqualTo(10));
    }

    [Test]
    public async Task EnumerateLinesAsync_ShouldYield10Lines_Given10LineString()
    {
        using var stream = new MemoryStream();
        await using (var writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true))
        {
            for (var index = 0; index < 10; index++)
            {
                writer.WriteLine(index);
            }
        }

        stream.Position = 0;
        using var reader = new StreamReader(stream, Encoding.UTF8);
        var lineCount = 0;

        await foreach (string _ in reader.EnumerateLinesAsync().ConfigureAwait(false))
        {
            lineCount++;
        }

        Assert.That(lineCount, Is.EqualTo(10));
    }

    [Test]
    public void EnumerateLines_ShouldThrowArgumentNullException_GivenNullSource()
    {
        TextReader reader = null!;
        Assert.Throws<ArgumentNullException>(() =>
        {
            foreach (string _ in reader.EnumerateLines())
            {
                // loop body is intentionally empty
            }
        });
    }

    [Test]
    public void EnumerateLinesAsync_ShouldThrowArgumentNullException_GivenNullSource()
    {
        TextReader reader = null!;
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await foreach (string _ in reader.EnumerateLinesAsync().ConfigureAwait(false))
            {
                // loop body is intentionally empty
            }
        });
    }
}
