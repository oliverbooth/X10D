using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.IO;

namespace X10D.Tests.IO;

[TestClass]
public class StreamTests
{
    [TestMethod]
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

    [TestMethod]
    public void GetHashNullShouldThrow()
    {
        // any HashAlgorithm will do, but SHA1 is used above. so to remain consistent, we use it here
        Assert.ThrowsException<ArgumentNullException>(() => ((Stream?)null)!.GetHash<SHA1>());
        Assert.ThrowsException<ArgumentNullException>(() => ((Stream?)null)!.TryWriteHash<SHA1>(Span<byte>.Empty, out _));
    }

    [TestMethod]
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
        Assert.AreEqual(expectedHash.Length, bytesWritten);
        CollectionAssert.AreEqual(expectedHash, hash.ToArray());
    }

    [TestMethod]
    public void GetHash_TryWriteHash_ShouldThrow_GivenNonReadableStream()
    {
        Assert.ThrowsException<IOException>(() =>
        {
            using var stream = new DummyStream();
            stream.GetHash<SHA1>();
        });

        Assert.ThrowsException<IOException>(() =>
        {
            using var stream = new DummyStream();
            stream.TryWriteHash<SHA1>(Span<byte>.Empty, out _);
        });
    }

    [TestMethod]
    public void LargeStreamShouldThrow()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            using var stream = new DummyStream(true);
            stream.TryWriteHash<SHA1>(Span<byte>.Empty, out _);
        });
    }

    [TestMethod]
    public void NullCreateMethodShouldThrow()
    {
        Assert.ThrowsException<TypeInitializationException>(() => Stream.Null.GetHash<HashAlgorithmTestClass>());
        Assert.ThrowsException<TypeInitializationException>(() =>
            Stream.Null.TryWriteHash<HashAlgorithmTestClass>(Span<byte>.Empty, out _));
    }

    [TestMethod]
    public void NoCreateMethodShouldThrow()
    {
        Assert.ThrowsException<TypeInitializationException>(() => Stream.Null.GetHash<HashAlgorithmTestClassNoCreateMethod>());
        Assert.ThrowsException<TypeInitializationException>(() =>
            Stream.Null.TryWriteHash<HashAlgorithmTestClassNoCreateMethod>(Span<byte>.Empty, out _));
    }

    [TestMethod]
    public void Write_ShouldThrow_GivenUndefinedEndianness()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.Write(0.0f, (Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.Write(0.0, (Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.Write(0.0m, (Endianness)(-1));
        });

        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.Write((short)0, (Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.Write(0, (Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.Write(0L, (Endianness)(-1));
        });

        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.Write((ushort)0, (Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.Write(0U, (Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.Write(0UL, (Endianness)(-1));
        });
    }

    [TestMethod]
    public void Read_ShouldThrow_GivenNullStream()
    {
        Stream? stream = null;
        Assert.ThrowsException<ArgumentNullException>(() => stream!.ReadSingle());
        Assert.ThrowsException<ArgumentNullException>(() => stream!.ReadDouble());
        Assert.ThrowsException<ArgumentNullException>(() => stream!.ReadDecimal());
        Assert.ThrowsException<ArgumentNullException>(() => stream!.ReadInt16());
        Assert.ThrowsException<ArgumentNullException>(() => stream!.ReadInt32());
        Assert.ThrowsException<ArgumentNullException>(() => stream!.ReadInt64());
        Assert.ThrowsException<ArgumentNullException>(() => stream!.ReadUInt16());
        Assert.ThrowsException<ArgumentNullException>(() => stream!.ReadUInt32());
        Assert.ThrowsException<ArgumentNullException>(() => stream!.ReadUInt64());
    }

    [TestMethod]
    public void Write_ShouldThrow_GivenNullStream()
    {
        Stream? stream = null;
        Assert.ThrowsException<ArgumentNullException>(() => stream!.Write(0.0f, Endianness.LittleEndian));
        Assert.ThrowsException<ArgumentNullException>(() => stream!.Write(0.0, Endianness.LittleEndian));
        Assert.ThrowsException<ArgumentNullException>(() => stream!.Write(0.0m, Endianness.LittleEndian));
        Assert.ThrowsException<ArgumentNullException>(() => stream!.Write((short)0));
        Assert.ThrowsException<ArgumentNullException>(() => stream!.Write(0));
        Assert.ThrowsException<ArgumentNullException>(() => stream!.Write(0L));
        Assert.ThrowsException<ArgumentNullException>(() => stream!.Write((ushort)0));
        Assert.ThrowsException<ArgumentNullException>(() => stream!.Write(0U));
        Assert.ThrowsException<ArgumentNullException>(() => stream!.Write(0UL));
    }

    [TestMethod]
    public void Read_ShouldThrow_GivenUndefinedEndianness()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.ReadSingle((Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.ReadDouble((Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.ReadDecimal((Endianness)(-1));
        });

        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.ReadInt16((Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.ReadInt32((Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.ReadInt64((Endianness)(-1));
        });

        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.ReadUInt16((Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.ReadUInt32((Endianness)(-1));
        });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            using var stream = new MemoryStream();
            return stream.ReadUInt64((Endianness)(-1));
        });
    }

    [TestMethod]
    public void WriteDouble_ShouldWriteBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        stream.Write(420.0, Endianness.BigEndian);
        Assert.AreEqual(8, stream.Position);
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[8];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0x40, 0x7A, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00};
        int read = stream.Read(actual);

        byte[] actualArray = actual.ToArray();
        byte[] expectedArray = expected.ToArray();

        string actualBytes = string.Join(", ", actualArray.Select(b => $"0x{b:X2}"));
        string expectedBytes = string.Join(", ", expectedArray.Select(b => $"0x{b:X2}"));
        Trace.WriteLine($"Actual bytes: {actualBytes}");
        Trace.WriteLine($"Expected bytes: {expectedBytes}");

        Assert.AreEqual(8, read);
        CollectionAssert.AreEqual(expectedArray, actualArray);
    }

    [TestMethod]
    public void WriteDouble_ShouldWriteLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        stream.Write(420.0, Endianness.LittleEndian);
        Assert.AreEqual(8, stream.Position);
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[8];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x7A, 0x40};
        int read = stream.Read(actual);

        byte[] actualArray = actual.ToArray();
        byte[] expectedArray = expected.ToArray();

        string actualBytes = string.Join(", ", actualArray.Select(b => $"0x{b:X2}"));
        string expectedBytes = string.Join(", ", expectedArray.Select(b => $"0x{b:X2}"));
        Trace.WriteLine($"Actual bytes: {actualBytes}");
        Trace.WriteLine($"Expected bytes: {expectedBytes}");

        Assert.AreEqual(8, read);
        CollectionAssert.AreEqual(expectedArray, actualArray);
    }

    [TestMethod]
    public void WriteSingle_ShouldWriteBigEndian_GivenBigEndian()
    {
        using var stream = new MemoryStream();
        stream.Write(420.0f, Endianness.BigEndian);
        Assert.AreEqual(4, stream.Position);
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[4];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0x43, 0xD2, 0x00, 0x00};
        int read = stream.Read(actual);

        byte[] actualArray = actual.ToArray();
        byte[] expectedArray = expected.ToArray();

        string actualBytes = string.Join(", ", actualArray.Select(b => $"0x{b:X2}"));
        string expectedBytes = string.Join(", ", expectedArray.Select(b => $"0x{b:X2}"));
        Trace.WriteLine($"Actual bytes: {actualBytes}");
        Trace.WriteLine($"Expected bytes: {expectedBytes}");

        Assert.AreEqual(4, read);
        CollectionAssert.AreEqual(expectedArray, actualArray);
    }

    [TestMethod]
    public void WriteSingle_ShouldWriteLittleEndian_GivenLittleEndian()
    {
        using var stream = new MemoryStream();
        stream.Write(420.0f, Endianness.LittleEndian);
        Assert.AreEqual(4, stream.Position);
        stream.Position = 0;

        Span<byte> actual = stackalloc byte[4];
        ReadOnlySpan<byte> expected = stackalloc byte[] {0x00, 0x00, 0xD2, 0x43};
        int read = stream.Read(actual);

        byte[] actualArray = actual.ToArray();
        byte[] expectedArray = expected.ToArray();

        string actualBytes = string.Join(", ", actualArray.Select(b => $"0x{b:X2}"));
        string expectedBytes = string.Join(", ", expectedArray.Select(b => $"0x{b:X2}"));
        Trace.WriteLine($"Actual bytes: {actualBytes}");
        Trace.WriteLine($"Expected bytes: {expectedBytes}");

        Assert.AreEqual(4, read);
        CollectionAssert.AreEqual(expectedArray, actualArray);
    }

    [TestMethod]
    public void ReadSingle_WriteSingle_ShouldBeSymmetric()
    {
        using var stream = new MemoryStream();
        stream.Write(420.0f, BitConverter.IsLittleEndian ? Endianness.LittleEndian : Endianness.BigEndian);

        stream.Position = 0;
        Assert.AreEqual(420.0f, stream.ReadSingle(), 1e-6f);

        stream.Position = 0;
        stream.Write(420.0f, Endianness.LittleEndian);

        stream.Position = 0;
        Assert.AreEqual(420.0f, stream.ReadSingle(Endianness.LittleEndian), 1e-6f);

        stream.Position = 0;
        stream.Write(420.0f, Endianness.BigEndian);

        stream.Position = 0;
        Assert.AreEqual(420.0f, stream.ReadSingle(Endianness.BigEndian), 1e-6f);
    }

    [TestMethod]
    public void ReadInt16_WriteInt16_ShouldBeSymmetric()
    {
        using var stream = new MemoryStream();
        stream.Write((short)420);

        stream.Position = 0;
        Assert.AreEqual(420, stream.ReadInt16());

        stream.Position = 0;
        stream.Write((short)420, Endianness.LittleEndian);

        stream.Position = 0;
        Assert.AreEqual(420, stream.ReadInt16(Endianness.LittleEndian));

        stream.Position = 0;
        stream.Write((short)420, Endianness.BigEndian);

        stream.Position = 0;
        Assert.AreEqual(420, stream.ReadInt16(Endianness.BigEndian));
    }

    [TestMethod]
    public void ReadInt32_WriteInt32_ShouldBeSymmetric()
    {
        using var stream = new MemoryStream();
        stream.Write(420);

        stream.Position = 0;
        Assert.AreEqual(420, stream.ReadInt32());

        stream.Position = 0;
        stream.Write(420, Endianness.LittleEndian);

        stream.Position = 0;
        Assert.AreEqual(420, stream.ReadInt32(Endianness.LittleEndian));

        stream.Position = 0;
        stream.Write(420, Endianness.BigEndian);

        stream.Position = 0;
        Assert.AreEqual(420, stream.ReadInt32(Endianness.BigEndian));
    }

    [TestMethod]
    public void ReadInt64_WriteInt64_ShouldBeSymmetric()
    {
        using var stream = new MemoryStream();
        stream.Write(420L);

        stream.Position = 0;
        Assert.AreEqual(420L, stream.ReadInt64());

        stream.Position = 0;
        stream.Write(420L, Endianness.LittleEndian);

        stream.Position = 0;
        Assert.AreEqual(420L, stream.ReadInt64(Endianness.LittleEndian));

        stream.Position = 0;
        stream.Write(420L, Endianness.BigEndian);

        stream.Position = 0;
        Assert.AreEqual(420L, stream.ReadInt64(Endianness.BigEndian));
    }

    [TestMethod]
    [CLSCompliant(false)]
    public void ReadUInt16_WriteUInt16_ShouldBeSymmetric()
    {
        using var stream = new MemoryStream();
        stream.Write((ushort)420);

        stream.Position = 0;
        Assert.AreEqual((ushort)420, stream.ReadUInt16());

        stream.Position = 0;
        stream.Write((ushort)420, Endianness.LittleEndian);

        stream.Position = 0;
        Assert.AreEqual((ushort)420, stream.ReadUInt16(Endianness.LittleEndian));

        stream.Position = 0;
        stream.Write((ushort)420, Endianness.BigEndian);

        stream.Position = 0;
        Assert.AreEqual((ushort)420, stream.ReadUInt16(Endianness.BigEndian));
    }

    [TestMethod]
    [CLSCompliant(false)]
    public void ReadUInt32_WriteUInt32_ShouldBeSymmetric()
    {
        using var stream = new MemoryStream();
        stream.Write(420U);

        stream.Position = 0;
        Assert.AreEqual(420U, stream.ReadUInt32());

        stream.Position = 0;
        stream.Write(420U, Endianness.LittleEndian);

        stream.Position = 0;
        Assert.AreEqual(420U, stream.ReadUInt32(Endianness.LittleEndian));

        stream.Position = 0;
        stream.Write(420U, Endianness.BigEndian);

        stream.Position = 0;
        Assert.AreEqual(420U, stream.ReadUInt32(Endianness.BigEndian));
    }

    [TestMethod]
    [CLSCompliant(false)]
    public void ReadUInt64_WriteUInt64_ShouldBeSymmetric()
    {
        using var stream = new MemoryStream();
        stream.Write(420UL);

        stream.Position = 0;
        Assert.AreEqual(420UL, stream.ReadUInt64());

        stream.Position = 0;
        stream.Write(420UL, Endianness.LittleEndian);

        stream.Position = 0;
        Assert.AreEqual(420UL, stream.ReadUInt64(Endianness.LittleEndian));

        stream.Position = 0;
        stream.Write(420UL, Endianness.BigEndian);

        stream.Position = 0;
        Assert.AreEqual(420UL, stream.ReadUInt64(Endianness.BigEndian));
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
            throw new NotImplementedException();
        }

        protected override byte[] HashFinal()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }
    }

    private class HashAlgorithmTestClassNoCreateMethod : HashAlgorithm
    {
        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            throw new NotImplementedException();
        }

        protected override byte[] HashFinal()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
