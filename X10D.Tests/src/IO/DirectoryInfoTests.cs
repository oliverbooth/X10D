using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

[TestClass]
public class DirectoryInfoTests
{
    [TestMethod]
    public void Clear_ShouldClear_GivenValidDirectory()
    {
        string tempDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        var tempDirectory = new DirectoryInfo(tempDirectoryPath);

        tempDirectory.Create();
        Assert.IsTrue(tempDirectory.Exists);

        var file = new FileInfo(Path.Combine(tempDirectory.FullName, "file"));
        file.Create().Close();

        var childDirectory = new DirectoryInfo(Path.Combine(tempDirectory.FullName, "child"));
        childDirectory.Create();

        var childFile = new FileInfo(Path.Combine(childDirectory.FullName, "childFile"));
        childFile.Create().Close();

        Assert.AreEqual(1, tempDirectory.GetFiles().Length);
        Assert.AreEqual(1, tempDirectory.GetDirectories().Length);
        tempDirectory.Clear();
        Assert.AreEqual(0, tempDirectory.GetFiles().Length);
        Assert.AreEqual(0, tempDirectory.GetDirectories().Length);
        Assert.IsTrue(tempDirectory.Exists);

        tempDirectory.Delete();
    }

    [TestMethod]
    public void Clear_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((DirectoryInfo?)null)!.Clear());
    }

    [TestMethod]
    public void Clear_ShouldThrowDirectoryNotFoundException_GivenInvalidDirectory()
    {
        var directory = new DirectoryInfo(@"123:/@12#3");
        Assert.ThrowsException<DirectoryNotFoundException>(() => directory.Clear());
    }

    [TestMethod]
    public void Clear_ShouldThrowDirectoryNotFoundException_GivenNonExistentDirectory()
    {
        var directory = new DirectoryInfo(@"/@12#3");
        Assert.IsFalse(directory.Exists);
        Assert.ThrowsException<DirectoryNotFoundException>(() => directory.Clear());
    }
}
