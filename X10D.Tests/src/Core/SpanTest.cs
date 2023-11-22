#if NET5_0_OR_GREATER
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
#endif
using NUnit.Framework;
using X10D.Core;

namespace X10D.Tests.Core;

[TestFixture]
public class SpanTest
{
    [Test]
    public void Contains_ShouldReturnFalse_GivenReadOnlySpanWithNoMatchingElements_UsingByteEnum()
    {
        Assert.Multiple(() =>
        {
            ReadOnlySpan<EnumByte> span = stackalloc EnumByte[1] {EnumByte.B};
            Assert.That(span.Contains(EnumByte.A), Is.False);
            Assert.That(span.Contains(EnumByte.C), Is.False);
        });
    }

    [Test]
    public void Contains_ShouldReturnFalse_GivenReadOnlySpanWithNoMatchingElements_UsingInt16Enum()
    {
        Assert.Multiple(() =>
        {
            ReadOnlySpan<EnumInt16> span = stackalloc EnumInt16[1] {EnumInt16.B};
            Assert.That(span.Contains(EnumInt16.A), Is.False);
            Assert.That(span.Contains(EnumInt16.C), Is.False);
        });
    }

    [Test]
    public void Contains_ShouldReturnFalse_GivenReadOnlySpanWithNoMatchingElements_UsingInt32Enum()
    {
        Assert.Multiple(() =>
        {
            ReadOnlySpan<EnumInt32> span = stackalloc EnumInt32[1] {EnumInt32.B};
            Assert.That(span.Contains(EnumInt32.A), Is.False);
            Assert.That(span.Contains(EnumInt32.C), Is.False);
        });
    }

    [Test]
    public void Contains_ShouldReturnFalse_GivenReadOnlySpanWithNoMatchingElements_UsingInt64Enum()
    {
        Assert.Multiple(() =>
        {
            ReadOnlySpan<EnumInt64> span = stackalloc EnumInt64[1] {EnumInt64.B};

            Assert.That(span.Contains(EnumInt64.A), Is.False);
            Assert.That(span.Contains(EnumInt64.C), Is.False);
        });
    }

    [Test]
    public void Contains_ShouldReturnTrue_GivenReadOnlySpanWithMatchingElements_UsingByteEnum()
    {
        ReadOnlySpan<EnumByte> span = stackalloc EnumByte[1] {EnumByte.B};

        Assert.That(span.Contains(EnumByte.B));
    }

    [Test]
    public void Contains_ShouldReturnTrue_GivenReadOnlySpanWithMatchingElements_UsingInt16Enum()
    {
        ReadOnlySpan<EnumInt16> span = stackalloc EnumInt16[1] {EnumInt16.B};

        Assert.That(span.Contains(EnumInt16.B));
    }

    [Test]
    public void Contains_ShouldReturnTrue_GivenReadOnlySpanWithMatchingElements_UsingInt32Enum()
    {
        ReadOnlySpan<EnumInt32> span = stackalloc EnumInt32[1] {EnumInt32.B};

        Assert.That(span.Contains(EnumInt32.B));
    }

    [Test]
    public void Contains_ShouldReturnTrue_GivenReadOnlySpanWithMatchingElements_UsingInt64Enum()
    {
        ReadOnlySpan<EnumInt64> span = stackalloc EnumInt64[1] {EnumInt64.B};

        Assert.That(span.Contains(EnumInt64.B));
    }

    [Test]
    public void Contains_ShouldReturnFalse_GivenSpanWithNoMatchingElements_UsingByteEnum()
    {
        Assert.Multiple(() =>
        {
            Span<EnumByte> span = stackalloc EnumByte[1] {EnumByte.B};

            Assert.That(span.Contains(EnumByte.A), Is.False);
            Assert.That(span.Contains(EnumByte.C), Is.False);
        });
    }

    [Test]
    public void Contains_ShouldReturnFalse_GivenSpanWithNoMatchingElements_UsingInt16Enum()
    {
        Span<EnumInt16> span = stackalloc EnumInt16[1] {EnumInt16.B};

        Assert.That(span.Contains(EnumInt16.A), Is.False);
        Assert.That(span.Contains(EnumInt16.C), Is.False);
    }

    [Test]
    public void Contains_ShouldReturnFalse_GivenSpanWithNoMatchingElements_UsingInt32Enum()
    {
        Span<EnumInt32> span = stackalloc EnumInt32[1] {EnumInt32.B};

        Assert.That(span.Contains(EnumInt32.A), Is.False);
        Assert.That(span.Contains(EnumInt32.C), Is.False);
    }

    [Test]
    public void Contains_ShouldReturnFalse_GivenSpanWithNoMatchingElements_UsingInt64Enum()
    {
        Span<EnumInt64> span = stackalloc EnumInt64[1] {EnumInt64.B};

        Assert.That(span.Contains(EnumInt64.A), Is.False);
        Assert.That(span.Contains(EnumInt64.C), Is.False);
    }

    [Test]
    public void Contains_ShouldReturnTrue_GivenSpanWithMatchingElements_UsingByteEnum()
    {
        Span<EnumByte> span = stackalloc EnumByte[1] {EnumByte.B};

        Assert.That(span.Contains(EnumByte.B));
    }

    [Test]
    public void Contains_ShouldReturnTrue_GivenSpanWithMatchingElements_UsingInt16Enum()
    {
        Span<EnumInt16> span = stackalloc EnumInt16[1] {EnumInt16.B};

        Assert.That(span.Contains(EnumInt16.B));
    }

    [Test]
    public void Contains_ShouldReturnTrue_GivenSpanWithMatchingElements_UsingInt32Enum()
    {
        Span<EnumInt32> span = stackalloc EnumInt32[1] {EnumInt32.B};

        Assert.That(span.Contains(EnumInt32.B));
    }

    [Test]
    public void Contains_ShouldReturnTrue_GivenSpanWithMatchingElements_UsingInt64Enum()
    {
        Span<EnumInt64> span = stackalloc EnumInt64[1] {EnumInt64.B};

        Assert.That(span.Contains(EnumInt64.B));
    }

    [Test]
    public void PackByte_ShouldThrowArgumentException_GivenSpanLengthGreaterThan8()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Span<bool> span = stackalloc bool[9];
            _ = span.PackByte();
        });
    }

    [Test]
    public void PackInt16_ShouldThrowArgumentException_GivenSpanLengthGreaterThan16()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Span<bool> span = stackalloc bool[17];
            _ = span.PackInt16();
        });
    }

    [Test]
    public void PackInt32_ShouldThrowArgumentException_GivenSpanLengthGreaterThan32()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Span<bool> span = stackalloc bool[33];
            _ = span.PackInt32();
        });
    }

    [Test]
    public void PackInt64_ShouldThrowArgumentException_GivenSpanLengthGreaterThan64()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Span<bool> span = stackalloc bool[65];
            _ = span.PackInt64();
        });
    }

    [Test]
    public void PackByteInternal_Fallback_ShouldReturnCorrectByte_GivenReadOnlySpan_Using()
    {
        const byte expected = 0b00110011;
        ReadOnlySpan<bool> span = stackalloc bool[8] {true, true, false, false, true, true, false, false};

        byte actual = span.PackByteInternal_Fallback();

        Assert.That(actual, Is.EqualTo(expected));
    }

#if NET5_0_OR_GREATER
    [Test]
    public void PackByteInternal_Sse2_ShouldReturnCorrectByte_GivenReadOnlySpan_Using()
    {
        if (!Sse2.IsSupported)
        {
            return;
        }

        const byte expected = 0b00110011;
        ReadOnlySpan<bool> span = stackalloc bool[8] {true, true, false, false, true, true, false, false};

        byte actual = span.PackByteInternal_Sse2();

        Assert.That(actual, Is.EqualTo(expected));
    }

    // [Test]
    // public void PackByteInternal_AdvSimd_ShouldReturnCorrectByte_GivenReadOnlySpan_Using()
    // {
    //     if (!AdvSimd.IsSupported)
    //     {
    //         return;
    //     }
    //
    //     const byte expected = 0b00110011;
    //     ReadOnlySpan<bool> span = stackalloc bool[8] {true, true, false, false, true, true, false, false};
    //
    //     byte actual = span.PackByteInternal_AdvSimd();
    //
    //     Assert.That(actual, Is.EqualTo(expected));
    // }
#endif

    [Test]
    public void PackInt16_ShouldReturnSameAsPackByte_WhenSpanHasLength8()
    {
        ReadOnlySpan<bool> span = stackalloc bool[8] {true, true, false, false, true, true, false, false};

        short expected = span.PackByte();
        short actual = span.PackInt16();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt16Internal_Fallback_ShouldReturnCorrectInt16_GivenReadOnlySpan()
    {
        const short expected = 0b00101101_11010100;
        ReadOnlySpan<bool> span = stackalloc bool[16]
        {
            false, false, true, false, true, false, true, true, true, false, true, true, false, true, false, false,
        };

        short actual = span.PackInt16Internal_Fallback();

        Assert.That(actual, Is.EqualTo(expected));
    }

#if NET5_0_OR_GREATER
    [Test]
    public void PackInt16Internal_Sse2_ShouldReturnCorrectInt16_GivenReadOnlySpan_Using()
    {
        if (!Sse2.IsSupported)
        {
            return;
        }

        const short expected = 0b00101101_11010100;
        ReadOnlySpan<bool> span = stackalloc bool[16]
        {
            false, false, true, false, true, false, true, true, true, false, true, true, false, true, false, false,
        };

        short actual = span.PackInt16Internal_Sse2();

        Assert.That(actual, Is.EqualTo(expected));
    }
#endif

    [Test]
    public void PackInt32Internal_Fallback_ShouldReturnCorrectInt32_GivenReadOnlySpan()
    {
        const int expected = 0b01010101_10101010_01010101_10101010;
        ReadOnlySpan<bool> span = stackalloc bool[32]
        {
            false, true, false, true, false, true, false, true, true, false, true, false, true, false, true, false, false,
            true, false, true, false, true, false, true, true, false, true, false, true, false, true, false,
        };

        int actual = span.PackInt32Internal_Fallback();

        Assert.That(actual, Is.EqualTo(expected));
    }

#if NET5_0_OR_GREATER
    [Test]
    public void PackInt32Internal_Sse2_ShouldReturnCorrectInt32_GivenReadOnlySpan()
    {
        if (!Sse2.IsSupported)
        {
            return;
        }

        const int expected = 0b01010101_10101010_01010101_10101010;
        ReadOnlySpan<bool> span = stackalloc bool[32]
        {
            false, true, false, true, false, true, false, true, true, false, true, false, true, false, true, false, false,
            true, false, true, false, true, false, true, true, false, true, false, true, false, true, false,
        };

        int actual = span.PackInt32Internal_Sse2();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt32Internal_Avx2_ShouldReturnCorrectInt32_GivenReadOnlySpan()
    {
        if (!Avx2.IsSupported)
        {
            return;
        }

        const int expected = 0b01010101_10101010_01010101_10101010;
        ReadOnlySpan<bool> span = stackalloc bool[32]
        {
            false, true, false, true, false, true, false, true, true, false, true, false, true, false, true, false, false,
            true, false, true, false, true, false, true, true, false, true, false, true, false, true, false,
        };

        int actual = span.PackInt32Internal_Avx2();

        Assert.That(actual, Is.EqualTo(expected));
    }

    // [Test]
    // public void PackInt32Internal_AdvSimd_ShouldReturnCorrectInt32_GivenReadOnlySpan()
    // {
    //     if (!AdvSimd.IsSupported)
    //     {
    //         return;
    //     }
    //
    //     const int expected = 0b01010101_10101010_01010101_10101010;
    //     ReadOnlySpan<bool> span = stackalloc bool[32]
    //     {
    //         false, true, false, true, false, true, false, true, true, false, true, false, true, false, true, false, false,
    //         true, false, true, false, true, false, true, true, false, true, false, true, false, true, false,
    //     };
    //
    //     int actual = span.PackInt32Internal_AdvSimd();
    //
    //     Assert.That(actual, Is.EqualTo(expected));
    // }
#endif

    [Test]
    public void PackInt32_ShouldReturnSameAsPackByte_WhenSpanHasLength8_UsingReadOnlySpan()
    {
        ReadOnlySpan<bool> span = stackalloc bool[8] {true, true, false, false, true, true, false, false};

        int expected = span.PackByte();
        int actual = span.PackInt32();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt32_ShouldReturnSameAsPackByte_WhenSpanHasLength8_UsingSpan()
    {
        Span<bool> span = stackalloc bool[8] {true, true, false, false, true, true, false, false};

        int expected = span.PackByte();
        int actual = span.PackInt32();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt32_ShouldReturnSameAsPackInt16_WhenSpanHasLength16_UsingReadOnlySpan()
    {
        ReadOnlySpan<bool> span = stackalloc bool[16]
        {
            false, false, true, false, true, false, true, true, true, false, true, true, false, true, false, false,
        };

        int expected = span.PackInt16();
        int actual = span.PackInt32();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt32_ShouldReturnSameAsPackInt16_WhenSpanHasLength16_UsingSpan()
    {
        Span<bool> span = stackalloc bool[16]
        {
            false, false, true, false, true, false, true, true, true, false, true, true, false, true, false, false,
        };

        int expected = span.PackInt16();
        int actual = span.PackInt32();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt64_ShouldReturnCorrectInt64_GivenReadOnlySpan()
    {
        const long expected = 0b01010101_11010110_01101001_11010110_00010010_10010111_00101100_10100101;
        ReadOnlySpan<bool> span = stackalloc bool[64]
        {
            true, false, true, false, false, true, false, true, false, false, true, true, false, true, false, false, true,
            true, true, false, true, false, false, true, false, true, false, false, true, false, false, false, false, true,
            true, false, true, false, true, true, true, false, false, true, false, true, true, false, false, true, true,
            false, true, false, true, true, true, false, true, false, true, false, true, false,
        };

        long actual = span.PackInt64();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt64_ShouldReturnCorrectInt64_GivenSpan()
    {
        const long expected = 0b01010101_11010110_01101001_11010110_00010010_10010111_00101100_10100101;
        Span<bool> span = stackalloc bool[64]
        {
            true, false, true, false, false, true, false, true, false, false, true, true, false, true, false, false, true,
            true, true, false, true, false, false, true, false, true, false, false, true, false, false, false, false, true,
            true, false, true, false, true, true, true, false, false, true, false, true, true, false, false, true, true,
            false, true, false, true, true, true, false, true, false, true, false, true, false,
        };

        long actual = span.PackInt64();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt64_ShouldReturnSameAsPackByte_WhenSpanHasLength8_UsingReadOnlySpan()
    {
        ReadOnlySpan<bool> span = stackalloc bool[8] {true, true, false, false, true, true, false, false};

        long expected = span.PackByte();
        long actual = span.PackInt64();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt64_ShouldReturnSameAsPackByte_WhenSpanHasLength8_UsingSpan()
    {
        Span<bool> span = stackalloc bool[8] {true, true, false, false, true, true, false, false};

        long expected = span.PackByte();
        long actual = span.PackInt64();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt64_ShouldReturnSameAsPackInt16_WhenSpanHasLength16_UsingReadOnlySpan()
    {
        ReadOnlySpan<bool> span = stackalloc bool[16]
        {
            false, false, true, false, true, false, true, true, true, false, true, true, false, true, false, false,
        };

        long expected = span.PackInt16();
        long actual = span.PackInt64();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt64_ShouldReturnSameAsPackInt16_WhenSpanHasLength16_UsingSpan()
    {
        Span<bool> span = stackalloc bool[16]
        {
            false, false, true, false, true, false, true, true, true, false, true, true, false, true, false, false,
        };

        long expected = span.PackInt16();
        long actual = span.PackInt64();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt64_ShouldReturnSameAsPackInt32_WhenSpanHasLength16_UsingReadOnlySpan()
    {
        ReadOnlySpan<bool> span = stackalloc bool[32]
        {
            false, true, false, true, false, true, false, true, true, false, true, false, true, false, true, false, false,
            true, false, true, false, true, false, true, true, false, true, false, true, false, true, false,
        };

        long expected = span.PackInt32();
        long actual = span.PackInt64();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt64_ShouldReturnSameAsPackInt32_WhenSpanHasLength16_UsingSpan()
    {
        Span<bool> span = stackalloc bool[32]
        {
            false, true, false, true, false, true, false, true, true, false, true, false, true, false, true, false, false,
            true, false, true, false, true, false, true, true, false, true, false, true, false, true, false,
        };

        long expected = span.PackInt32();
        long actual = span.PackInt64();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt64_ShouldFallbackAndReturnCorrectValue_GivenNonPowerOfTwoLength_UsingReadOnlySpan()
    {
        const long expected = 0b00000000_00000000_00000000_00000000_00000000_00000000_00000001_01010011;
        ReadOnlySpan<bool> span = stackalloc bool[10] {true, true, false, false, true, false, true, false, true, false};

        long actual = span.PackInt64();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PackInt64_ShouldFallbackAndReturnCorrectValue_GivenNonPowerOfTwoLength_UsingSpan()
    {
        const long expected = 0b00000000_00000000_00000000_00000000_00000000_00000000_00000001_01010011;
        Span<bool> span = stackalloc bool[10] {true, true, false, false, true, false, true, false, true, false};

        long actual = span.PackInt64();

        Assert.That(actual, Is.EqualTo(expected));
    }

    private enum EnumByte : byte
    {
        A,
        B,
        C
    }

    private enum EnumInt16 : short
    {
        A,
        B,
        C
    }

    private enum EnumInt32
    {
        A,
        B,
        C
    }

    private enum EnumInt64 : long
    {
        A,
        B,
        C
    }
}
