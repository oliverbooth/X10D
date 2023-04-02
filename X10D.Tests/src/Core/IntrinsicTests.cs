#if NET6_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Core;

namespace X10D.Tests.Core;

[TestClass]
public class IntrinsicTests
{
    [TestMethod]
    public void CorrectBoolean_ShouldReturnExpectedVector64Result_GivenInputVector()
    {
        var inputVector = Vector64.Create(0, 1, 2, 0, 3, 0, 0, (byte)4);
        var expectedResult = Vector64.Create(0, 1, 1, 0, 1, 0, 0, (byte)1);

        Vector64<byte> result = inputVector.CorrectBoolean();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void CorrectBooleanInternal_Fallback_ShouldReturnExpectedVector128Result_GivenInputVector()
    {
        var inputVector = Vector128.Create(0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0, 0, 7, (byte)8);
        var expectedResult = Vector128.Create(0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, (byte)1);

        Vector128<byte> result = inputVector.CorrectBooleanInternal_Fallback();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void CorrectBooleanInternal_Sse2_ShouldReturnExpectedVector128Result_GivenInputVector()
    {
        if (!Sse2.IsSupported)
        {
            return;
        }

        var inputVector = Vector128.Create(0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0, 0, 7, (byte)8);
        var expectedResult = Vector128.Create(0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, (byte)1);

        Vector128<byte> result = inputVector.CorrectBooleanInternal_Sse2();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
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

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void CorrectBooleanInternal_Fallback_ShouldReturnExpectedVector256Result_GivenInputVector()
    {
        var inputVector = Vector256.Create(0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0, 0, 7, 8, 0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0,
            0, 7, (byte)8);
        var expectedResult = Vector256.Create(0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1,
            0, 0, 1, (byte)1);

        Vector256<byte> result = inputVector.CorrectBooleanInternal_Fallback();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void ReverseElementsInternal_Fallback_ShouldReturnExpectedVector128Result_GivenInputVector()
    {
        var inputVector = Vector128.Create(42UL, 69UL);
        var expectedResult = Vector128.Create(69UL, 42UL);

        Vector128<ulong> result = inputVector.ReverseElementsInternal_Fallback();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void ReverseElementsInternal_Sse2_ShouldReturnExpectedVector128Result_GivenInputVector()
    {
        if (!Sse2.IsSupported)
        {
            return;
        }

        var inputVector = Vector128.Create(42UL, 69UL);
        var expectedResult = Vector128.Create(69UL, 42UL);

        Vector128<ulong> result = inputVector.ReverseElementsInternal_Sse2();

        Assert.AreEqual(expectedResult, result);
    }
}
#endif
