using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

[TestClass]
public class DirectoryInfoTests
{
    [TestMethod]
    public void Clear_ShouldClear_GivenValidDirectory()
    {
        string tempPath = Path.GetTempPath();
        DirectoryInfo directory;
        do
        {
            string tempDirectory = Path.Combine(tempPath, Guid.NewGuid().ToString());
            directory = new DirectoryInfo(tempDirectory);
        } while (directory.Exists);

        directory.Create();
        Assert.IsTrue(directory.Exists);

        var file = new FileInfo(Path.Combine(directory.FullName, "file"));
        file.Create().Close();

        var childDirectory = new DirectoryInfo(Path.Combine(directory.FullName, "child"));
        childDirectory.Create();

        var childFile = new FileInfo(Path.Combine(childDirectory.FullName, "childFile"));
        childFile.Create().Close();

        Assert.AreEqual(1, directory.GetFiles().Length);
        Assert.AreEqual(1, directory.GetDirectories().Length);
        directory.Clear(false);
        Assert.AreEqual(0, directory.GetFiles().Length);
        Assert.AreEqual(0, directory.GetDirectories().Length);
        Assert.IsTrue(directory.Exists);

        directory.Delete();
    }

    [TestMethod]
    public void Clear_ShouldDoNothing_GivenNonExistentDirectory()
    {
        var directory = new DirectoryInfo(@"/@12#3");
        Assert.IsFalse(directory.Exists);
        directory.Clear();
    }

    [TestMethod]
    public void Clear_ShouldNotThrow_WhenThrowOnErrorIsFalse()
    {
        var directory = new DirectoryInfo(@"/@12#3");
        Assert.IsFalse(directory.Exists);

        directory.Clear();
        directory.Clear(false);

        Assert.IsTrue(true); // if this assertion passes, then the test passed
    }

    [TestMethod]
    public void Clear_ShouldThrowArgumentNullException_GivenNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((DirectoryInfo?)null)!.Clear());
        Assert.ThrowsException<ArgumentNullException>(() => ((DirectoryInfo?)null)!.Clear(true));
    }

    [TestMethod]
    public void Clear_ShouldThrowDirectoryNotFoundException_GivenInvalidDirectory()
    {
        var directory = new DirectoryInfo(@"123:/@12#3");
        Assert.ThrowsException<DirectoryNotFoundException>(() => directory.Clear(true));
    }

    [TestMethod]
    public void Clear_ShouldThrowDirectoryNotFoundException_GivenNonExistentDirectory()
    {
        var directory = new DirectoryInfo(@"/@12#3");
        Assert.IsFalse(directory.Exists);
        Assert.ThrowsException<DirectoryNotFoundException>(() => directory.Clear(true));
    }
}
