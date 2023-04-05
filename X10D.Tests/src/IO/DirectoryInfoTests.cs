using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
public class DirectoryInfoTests
{
    [Test]
    public void Clear_ShouldClear_GivenValidDirectory()
    {
        string tempDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        var tempDirectory = new DirectoryInfo(tempDirectoryPath);

        tempDirectory.Create();
        Assert.That(tempDirectory.Exists);

        var file = new FileInfo(Path.Combine(tempDirectory.FullName, "file"));
        file.Create().Close();

        var childDirectory = new DirectoryInfo(Path.Combine(tempDirectory.FullName, "child"));
        childDirectory.Create();

        var childFile = new FileInfo(Path.Combine(childDirectory.FullName, "childFile"));
        childFile.Create().Close();

        Assert.Multiple(() =>
        {
            Assert.That(tempDirectory.GetFiles(), Has.Length.EqualTo(1));
            Assert.That(tempDirectory.GetDirectories(), Has.Length.EqualTo(1));
        });

        tempDirectory.Clear();

        Assert.Multiple(() =>
        {
            Assert.That(tempDirectory.GetFiles(), Is.Empty);
            Assert.That(tempDirectory.GetDirectories(), Is.Empty);
            Assert.That(tempDirectory.Exists);
        });

        tempDirectory.Delete();
    }

    [Test]
    public void Clear_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((DirectoryInfo?)null)!.Clear());
    }

    [Test]
    public void Clear_ShouldThrowDirectoryNotFoundException_GivenInvalidDirectory()
    {
        var directory = new DirectoryInfo(@"123:/@12#3");
        Assert.Throws<DirectoryNotFoundException>(() => directory.Clear());
    }

    [Test]
    public void Clear_ShouldThrowDirectoryNotFoundException_GivenNonExistentDirectory()
    {
        var directory = new DirectoryInfo(@"/@12#3");
        Assert.That(directory.Exists, Is.False);
        Assert.Throws<DirectoryNotFoundException>(() => directory.Clear());
    }
}
