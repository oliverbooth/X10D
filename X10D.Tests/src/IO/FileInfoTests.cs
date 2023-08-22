using System.Security.Cryptography;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class FileInfoTests
{
    [Test]
    public void GetHashSha1ShouldBeCorrect()
    {
        var fileName = $"temp.{DateTimeOffset.Now.ToUnixTimeSeconds()}.bin";
        if (File.Exists(fileName))
        {
            Assert.Fail("Temporary file already exists");
        }

        File.WriteAllText(fileName, "Hello World");
        Assert.That(File.Exists(fileName));

        // SHA-1
        byte[] expectedHash =
        {
            0x0A, 0x4D, 0x55, 0xA8, 0xD7, 0x78, 0xE5, 0x02, 0x2F, 0xAB, 0x70, 0x19, 0x77, 0xC5, 0xD8, 0x40, 0xBB, 0xC4, 0x86,
            0xD0
        };

        try
        {
            byte[] hash = new FileInfo(fileName).GetHash<SHA1>();
            CollectionAssert.AreEqual(expectedHash, hash);
        }
        finally
        {
            File.Delete(fileName); // cleanup is important
        }
    }

    [Test]
    public void TryWriteHashSha1ShouldBeCorrect()
    {
        var fileName = $"temp.{DateTimeOffset.Now.ToUnixTimeSeconds()}.bin";
        if (File.Exists(fileName))
        {
            Assert.Fail("Temporary file already exists");
        }

        File.WriteAllText(fileName, "Hello World");
        Assert.That(File.Exists(fileName));

        // SHA-1
        byte[] expectedHash =
        {
            0x0A, 0x4D, 0x55, 0xA8, 0xD7, 0x78, 0xE5, 0x02, 0x2F, 0xAB, 0x70, 0x19, 0x77, 0xC5, 0xD8, 0x40, 0xBB, 0xC4, 0x86,
            0xD0
        };

        try
        {
            Span<byte> hash = stackalloc byte[20];
            new FileInfo(fileName).TryWriteHash<SHA1>(hash, out int bytesWritten);
            Assert.That(bytesWritten, Is.EqualTo(expectedHash.Length));
            CollectionAssert.AreEqual(expectedHash, hash.ToArray());
        }
        finally
        {
            File.Delete(fileName); // cleanup is important
        }
    }

    [Test]
    public void GetHashNullShouldThrow()
    {
        // any HashAlgorithm will do, but SHA1 is used above. so to remain consistent, we use it here
        Assert.Throws<ArgumentNullException>(() => _ = ((FileInfo?)null)!.GetHash<SHA1>());
        Assert.Throws<ArgumentNullException>(() => ((FileInfo?)null)!.TryWriteHash<SHA1>(Span<byte>.Empty, out _));
    }

    [Test]
    public void GetHashInvalidFileShouldThrow()
    {
        var fileName = $"temp.{DateTimeOffset.Now.ToUnixTimeSeconds()}.bin";
        if (File.Exists(fileName))
        {
            Assert.Fail("Temporary file already exists");
        }

        // any HashAlgorithm will do, but SHA1 is used above. so to remain consistent, we use it here
        Assert.Throws<FileNotFoundException>(() => _ = new FileInfo(fileName).GetHash<SHA1>());
        Assert.Throws<FileNotFoundException>(() => new FileInfo(fileName).TryWriteHash<SHA1>(Span<byte>.Empty, out _));
    }
}
