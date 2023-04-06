#if NET6_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using NUnit.Framework;
using X10D.Core;

namespace X10D.Tests.Core;

[TestFixture]
public class IntrinsicTests
{
    [Test]
    public void CorrectBoolean_ShouldReturnExpectedVector64Result_GivenInputVector()
    {
        var inputVector = Vector64.Create(0, 1, 2, 0, 3, 0, 0, (byte)4);
        var expectedResult = Vector64.Create(0, 1, 1, 0, 1, 0, 0, (byte)1);

        Vector64<byte> result = inputVector.CorrectBoolean();

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CorrectBooleanInternal_Fallback_ShouldReturnExpectedVector128Result_GivenInputVector()
    {
        var inputVector = Vector128.Create(0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0, 0, 7, (byte)8);
        var expectedResult = Vector128.Create(0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, (byte)1);

        Vector128<byte> result = inputVector.CorrectBooleanInternal_Fallback();

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CorrectBooleanInternal_Sse2_ShouldReturnExpectedVector128Result_GivenInputVector()
    {
        if (!Sse2.IsSupported)
        {
            return;
        }

        var inputVector = Vector128.Create(0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0, 0, 7, (byte)8);
        var expectedResult = Vector128.Create(0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, (byte)1);

        Vector128<byte> result = inputVector.CorrectBooleanInternal_Sse2();

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CorrectBooleanInternal_Avx2_ShouldReturnExpectedVector256Result_GivenInputVector()
    {
        if (!Avx2.IsSupported)
        {
            return;
        }

        var inputVector = Vector256.Create(0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0, 0, 7, 8, 0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0,
            0, 7, (byte)8);
        var expectedResult = Vector256.Create(0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1,
            0, 0, 1, (byte)1);

        Vector256<byte> result = inputVector.CorrectBooleanInternal_Avx2();

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CorrectBooleanInternal_Fallback_ShouldReturnExpectedVector256Result_GivenInputVector()
    {
        var inputVector = Vector256.Create(0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0, 0, 7, 8, 0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0,
            0, 7, (byte)8);
        var expectedResult = Vector256.Create(0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1,
            0, 0, 1, (byte)1);

        Vector256<byte> result = inputVector.CorrectBooleanInternal_Fallback();

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void HorizontalOr_ShouldReturnCombinedVector_GivenInputVector128OfUInt32()
    {
        Vector128<uint> left = Vector128.Create(1U, 2U, 3U, 4U);
        Vector128<uint> right = Vector128.Create(5U, 6U, 7U, 8U);

        Vector128<uint> expected = Vector128.Create(3U, 7U, 7U, 15U);
        Vector128<uint> actual = IntrinsicUtility.HorizontalOr(left, right);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void HorizontalOrInternal_Sse_ShouldReturnCombinedVector_GivenInputVector128OfInt32()
    {
        Vector128<int> left = Vector128.Create(1, 2, 3, 4);
        Vector128<int> right = Vector128.Create(5, 6, 7, 8);

        Vector128<int> expected = Vector128.Create(3, 7, 7, 15);
        Vector128<int> actual = IntrinsicUtility.HorizontalOr_Sse(left, right);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void HorizontalOrInternal_Fallback_ShouldReturnCombinedVector_GivenInputVector128OfInt32()
    {
        Vector128<int> left = Vector128.Create(1, 2, 3, 4);
        Vector128<int> right = Vector128.Create(5, 6, 7, 8);

        Vector128<int> expected = Vector128.Create(3, 7, 7, 15);
        Vector128<int> actual = IntrinsicUtility.HorizontalOrInternal_Fallback(left, right);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Multiply_ShouldReturnMultipliedVector_GivenInputVector128OfInt64()
    {
        Vector128<long> left = Vector128.Create(6L, 4L);
        Vector128<long> right = Vector128.Create(2L, 3L);

        Vector128<long> expected = Vector128.Create(12L, 12L);
        Vector128<long> actual = IntrinsicUtility.Multiply(left, right);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplyInternal_Sse2_ShouldReturnMultipliedVector_GivenInputVector128OfUInt64()
    {
        if (!Sse2.IsSupported)
        {
            return;
        }

        Vector128<ulong> left = Vector128.Create(6UL, 4UL);
        Vector128<ulong> right = Vector128.Create(2UL, 3UL);

        Vector128<ulong> expected = Vector128.Create(12UL, 12UL);
        Vector128<ulong> actual = IntrinsicUtility.MultiplyInternal_Sse2(left, right);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplyInternal_Fallback_ShouldReturnMultipliedVector_GivenInputVector128OfUInt64()
    {
        Vector128<ulong> left = Vector128.Create(6UL, 4UL);
        Vector128<ulong> right = Vector128.Create(2UL, 3UL);

        Vector128<ulong> expected = Vector128.Create(12UL, 12UL);
        Vector128<ulong> actual = IntrinsicUtility.MultiplyInternal_Fallback(left, right);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Multiply_ShouldReturnMultipliedVector_GivenInputVector256OfInt64()
    {
        Vector256<long> left = Vector256.Create(4L, 6L, 8L, 10L);
        Vector256<long> right = Vector256.Create(2L, 3L, 4L, 5L);

        Vector256<long> expected = Vector256.Create(8L, 18L, 32L, 50L);
        Vector256<long> actual = IntrinsicUtility.Multiply(left, right);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplyInternal_Avx2_ShouldReturnMultipliedVector_GivenInputVector256OfUInt64()
    {
        if (!Avx2.IsSupported)
        {
            return;
        }

        Vector256<ulong> left = Vector256.Create(4UL, 6UL, 8UL, 10UL);
        Vector256<ulong> right = Vector256.Create(2UL, 3UL, 4UL, 5UL);

        Vector256<ulong> expected = Vector256.Create(8UL, 18UL, 32UL, 50UL);
        Vector256<ulong> actual = IntrinsicUtility.MultiplyInternal_Avx2(left, right);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MultiplyInternal_Fallback_ShouldReturnMultipliedVector_GivenInputVector256OfUInt64()
    {
        Vector256<ulong> left = Vector256.Create(4UL, 6UL, 8UL, 10UL);
        Vector256<ulong> right = Vector256.Create(2UL, 3UL, 4UL, 5UL);

        Vector256<ulong> expected = Vector256.Create(8UL, 18UL, 32UL, 50UL);
        Vector256<ulong> actual = IntrinsicUtility.MultiplyInternal_Fallback(left, right);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReverseElementsInternal_Fallback_ShouldReturnExpectedVector128Result_GivenInputVector()
    {
        var inputVector = Vector128.Create(42UL, 69UL);
        var expectedResult = Vector128.Create(69UL, 42UL);

        Vector128<ulong> result = inputVector.ReverseElementsInternal_Fallback();

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ReverseElementsInternal_Sse2_ShouldReturnExpectedVector128Result_GivenInputVector()
    {
        if (!Sse2.IsSupported)
        {
            return;
        }

        var inputVector = Vector128.Create(42UL, 69UL);
        var expectedResult = Vector128.Create(69UL, 42UL);

        Vector128<ulong> result = inputVector.ReverseElementsInternal_Sse2();

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
#endif
