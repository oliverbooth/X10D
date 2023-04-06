using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
public partial class StreamTests
{
    [Test]
    public void GetHashSha1ShouldBeCorrect()
    {
        // SHA-1
        byte[] expectedHash =
        {
            0x0A, 0x4D, 0x55, 0xA8, 0xD7, 0x78, 0xE5, 0x02, 0x2F, 0xAB, 0x70, 0x19, 0x77, 0xC5, 0xD8, 0x40, 0xBB, 0xC4, 0x86,
            0xD0
        };

        using var stream = new MemoryStream();
        stream.Write(Encoding.UTF8.GetBytes("Hello World"));
        stream.Position = 0;

        byte[] hash = stream.GetHash<SHA1>();
        Trace.WriteLine($"Hash: {BitConverter.ToString(hash)}");
        Trace.WriteLine($"Expected: {BitConverter.ToString(expectedHash)}");
        CollectionAssert.AreEqual(expectedHash, hash);
    }

    [Test]
    public void GetHashNullShouldThrow()
    {
        // any HashAlgorithm will do, but SHA1 is used above. so to remain consistent, we use it here
        Assert.Throws<ArgumentNullException>(() => ((Stream?)null)!.GetHash<SHA1>());
        Assert.Throws<ArgumentNullException>(() => ((Stream?)null)!.TryWriteHash<SHA1>(Span<byte>.Empty, out _));
    }

    [Test]
    public void TryWriteHashSha1_ShouldBeCorrect()
    {
        // SHA-1
        byte[] expectedHash =
        {
            0x0A, 0x4D, 0x55, 0xA8, 0xD7, 0x78, 0xE5, 0x02, 0x2F, 0xAB, 0x70, 0x19, 0x77, 0xC5, 0xD8, 0x40, 0xBB, 0xC4, 0x86,
            0xD0
        };

        using var stream = new MemoryStream();
        stream.Write(Encoding.UTF8.GetBytes("Hello World"));
        stream.Position = 0;

        Span<byte> hash = stackalloc byte[20];
        stream.TryWriteHash<SHA1>(hash, out int bytesWritten);
        Assert.That(bytesWritten, Is.EqualTo(expectedHash.Length));
        CollectionAssert.AreEqual(expectedHash, hash.ToArray());
    }

    [Test]
    public void GetHash_TryWriteHash_ShouldThrow_GivenNonReadableStream()
    {
        Assert.Throws<IOException>(() =>
        {
            using var stream = new DummyStream();
            stream.GetHash<SHA1>();
        });

        Assert.Throws<IOException>(() =>
        {
            using var stream = new DummyStream();
            stream.TryWriteHash<SHA1>(Span<byte>.Empty, out _);
        });
    }

    [Test]
    public void LargeStreamShouldThrow()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            using var stream = new DummyStream(true);
            stream.TryWriteHash<SHA1>(Span<byte>.Empty, out _);
        });
    }

    [Test]
    public void NullCreateMethodShouldThrow()
    {
        Assert.Throws<TypeInitializationException>(() => Stream.Null.GetHash<HashAlgorithmTestClass>());
        Assert.Throws<TypeInitializationException>(() =>
            Stream.Null.TryWriteHash<HashAlgorithmTestClass>(Span<byte>.Empty, out _));
    }

    [Test]
    public void NoCreateMethodShouldThrow()
    {
        Assert.Throws<TypeInitializationException>(() => Stream.Null.GetHash<HashAlgorithmTestClassNoCreateMethod>());
        Assert.Throws<TypeInitializationException>(() =>
            Stream.Null.TryWriteHash<HashAlgorithmTestClassNoCreateMethod>(Span<byte>.Empty, out _));
    }

    private class DummyStream : Stream
    {
        public DummyStream(bool readable = false)
        {
            CanRead = readable;
            CanSeek = readable;
            CanWrite = readable;
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return 0;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return 0;
        }

        public override void SetLength(long value)
        {
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
        }

        public override bool CanRead { get; }

        public override bool CanSeek { get; }

        public override bool CanWrite { get; }

        public override long Length
        {
            get => long.MaxValue;
        }

        public override long Position
        {
            get => 0;
            set { }
        }
    }

    private class HashAlgorithmTestClass : HashAlgorithm
    {
        public static new HashAlgorithmTestClass? Create()
        {
            return null;
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
        }

        protected override byte[] HashFinal()
        {
            return Array.Empty<byte>();
        }

        public override void Initialize()
        {
        }
    }

    private class HashAlgorithmTestClassNoCreateMethod : HashAlgorithm
    {
        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
        }

        protected override byte[] HashFinal()
        {
            return Array.Empty<byte>();
        }

        public override void Initialize()
        {
        }
    }
}
