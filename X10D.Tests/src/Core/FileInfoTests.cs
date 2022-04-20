using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

[TestClass]
public class FileInfoTests
{
    [TestMethod]
    public void GetHash()
    {
        string fileName = $"temp.{DateTimeOffset.Now.ToUnixTimeSeconds()}.bin";
        if (File.Exists(fileName))
        {
            Assert.Fail("Temporary file already exists");
        }
        
        const string expectedHash = "0A4D55A8D778E5022FAB701977C5D840BBC486D0"; // SHA-1
        File.WriteAllText(fileName, "Hello World");
        Assert.IsTrue(File.Exists(fileName), $"File.Exists(\"{fileName}\")");

        byte[] hash = new FileInfo(fileName).GetHash<SHA1>();
        string actualHash = BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
        Assert.AreEqual(expectedHash, actualHash);

        File.Delete(fileName); // cleanup is important
    }

    [TestMethod]
    public void GetHash_NullFileInfo()
    {
        // any HashAlgorithm will do, but SHA1 is used above. so to remain consistent, we use it here
        Assert.ThrowsException<ArgumentNullException>(() => ((FileInfo?)null)!.GetHash<SHA1>());
    }

    [TestMethod]
    public void GetHash_InvalidFile()
    {
        string fileName = $"temp.{DateTimeOffset.Now.ToUnixTimeSeconds()}.bin";
        if (File.Exists(fileName))
        {
            Assert.Fail("Temporary file already exists");
        }
        
        // any HashAlgorithm will do, but SHA1 is used above. so to remain consistent, we use it here
        Assert.ThrowsException<FileNotFoundException>(() => new FileInfo(fileName).GetHash<SHA1>());
    }
}
