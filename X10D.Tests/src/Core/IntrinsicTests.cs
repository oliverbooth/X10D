#if NET6_0_OR_GREATER
using System.Runtime.Intrinsics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using X10D.Core;

namespace X10D.Tests.Core;

[TestClass]
public class IntrinsicTests
{
    [TestMethod]
    public void CorrectBoolean_ShouldReturnExpectedVector64Result_GivenInputVector()
    {
        var mock = new Mock<ISse2SupportProvider>();
        mock.Setup(provider => provider.IsSupported).Returns(true);

        var inputVector = Vector64.Create(0, 1, 2, 0, 3, 0, 0, (byte)4);
        var expectedResult = Vector64.Create(0, 1, 1, 0, 1, 0, 0, (byte)1);

        Vector64<byte> result = inputVector.CorrectBoolean();

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void CorrectBoolean_ShouldReturnExpectedVector128Result_GivenInputVector()
    {
        var mock = new Mock<ISse2SupportProvider>();
        mock.Setup(provider => provider.IsSupported).Returns(true);

        var inputVector = Vector128.Create(0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0, 0, 7, (byte)8);
        var expectedResult = Vector128.Create(0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, (byte)1);

        Vector128<byte> result = inputVector.CorrectBooleanInternal(mock.Object);

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void CorrectBoolean_ShouldReturnExpectedVector128Result_WhenSse2NotSupported()
    {
        var mock = new Mock<ISse2SupportProvider>();
        mock.Setup(provider => provider.IsSupported).Returns(false);

        var inputVector = Vector128.Create(0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0, 0, 7, (byte)8);
        var expectedResult = Vector128.Create(0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, (byte)1);

        Vector128<byte> result = inputVector.CorrectBooleanInternal(mock.Object);

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void CorrectBoolean_ShouldReturnExpectedVector256Result_GivenInputVector()
    {
        var mock = new Mock<IAvx2SupportProvider>();
        mock.Setup(provider => provider.IsSupported).Returns(true);

        var inputVector = Vector256.Create(0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0, 0, 7, 8, 0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0,
            0, 7, (byte)8);
        var expectedResult = Vector256.Create(0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1,
            0, 0, 1, (byte)1);

        Vector256<byte> result = inputVector.CorrectBooleanInternal(mock.Object);

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void CorrectBoolean_ShouldReturnExpectedVector256Result_WhenSse2NotSupported()
    {
        var mock = new Mock<IAvx2SupportProvider>();
        mock.Setup(provider => provider.IsSupported).Returns(false);

        var inputVector = Vector256.Create(0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0, 0, 7, 8, 0, 1, 2, 0, 3, 0, 0, 4, 5, 0, 0, 6, 0,
            0, 7, (byte)8);
        var expectedResult = Vector256.Create(0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1,
            0, 0, 1, (byte)1);

        Vector256<byte> result = inputVector.CorrectBooleanInternal(mock.Object);

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void ReverseElements_ShouldReturnExpectedVector128Result_GivenInputVector()
    {
        var mock = new Mock<ISse2SupportProvider>();
        mock.Setup(provider => provider.IsSupported).Returns(true);

        var inputVector = Vector128.Create(42UL, 69UL);
        var expectedResult = Vector128.Create(69UL, 42UL);

        Vector128<ulong> result = inputVector.ReverseElementsInternal(mock.Object);

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void ReverseElements_ShouldReturnExpectedVector128Result_WhenSse2NotSupported()
    {
        var mock = new Mock<ISse2SupportProvider>();
        mock.Setup(provider => provider.IsSupported).Returns(false);

        var inputVector = Vector128.Create(42UL, 69UL);
        var expectedResult = Vector128.Create(69UL, 42UL);

        Vector128<ulong> result = inputVector.ReverseElementsInternal(mock.Object);

        Assert.AreEqual(expectedResult, result);
    }
}
#endif
