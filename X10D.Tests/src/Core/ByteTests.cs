using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

/// <summary>
///     Tests for <see cref="ByteExtensions" />
/// </summary>
[TestClass]
public class ByteTests
{
    /// <summary>
    ///     Tests <see cref="ByteExtensions.GetBytes" />.
    /// </summary>
    [TestMethod]
    public void GetBytes()
    {
        const byte byteMinValue = byte.MinValue;
        const byte byteMaxValue = byte.MaxValue;

        byte[] minValueBytes = {byteMinValue};
        byte[] maxValueBytes = {byteMaxValue};

        byte[] minValueResult = byteMinValue.GetBytes();
        byte[] maxValueResult = byteMaxValue.GetBytes();

        CollectionAssert.AreEqual(minValueBytes, minValueResult);
        CollectionAssert.AreEqual(maxValueBytes, maxValueResult);
    }
}
