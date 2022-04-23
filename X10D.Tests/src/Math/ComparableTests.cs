using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Math;

namespace X10D.Tests.Math;

[TestClass]
public class ComparableTests
{
    private class ComparableTestClass : IComparable<ComparableTestClass>
    {
        public int CompareTo(ComparableTestClass? other)
        {
            return 0;
        }
    }

    private readonly int _lower = 1;
    private readonly int _upper = 10;
    private readonly int _value = 5;

    [TestMethod]
    public void Between_5_1_10_ShouldBeTrue()
    {
        Assert.IsTrue(_value.Between(_lower, _upper));
    }

    [TestMethod]
    public void Between_1_1_10_ShouldBeFalse()
    {
        // default option is exclusive
        Assert.IsFalse(_lower.Between(_lower, _upper));
    }

    [TestMethod]
    public void Between_1_1_10_Inclusive_ShouldBeTrue()
    {
        Assert.IsTrue(_lower.Between(_lower, _upper, InclusiveOptions.Inclusive));
        Assert.IsTrue(_lower.Between(_lower, _upper, InclusiveOptions.LowerInclusive));
        Assert.IsFalse(_lower.Between(_lower, _upper, InclusiveOptions.UpperInclusive));
    }

    [TestMethod]
    public void Between_10_1_10_ShouldBeFalse()
    {
        // default option is exclusive
        Assert.IsFalse(_upper.Between(_lower, _upper));
    }

    [TestMethod]
    public void Between_10_1_10_Inclusive_ShouldBeTrue()
    {
        Assert.IsTrue(_upper.Between(_lower, _upper, InclusiveOptions.Inclusive));
        Assert.IsTrue(_upper.Between(_lower, _upper, InclusiveOptions.UpperInclusive));
        Assert.IsFalse(_upper.Between(_lower, _upper, InclusiveOptions.LowerInclusive));
    }

    [TestMethod]
    public void Between_1_10_5_ShouldThrow()
    {
        Assert.ThrowsException<ArgumentException>(() => _lower.Between(_upper, _value));
    }

    [TestMethod]
    public void Between_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.ThrowsException<ArgumentNullException>(() => ((ComparableTestClass?)null)!.Between(nullPointer!, nullPointer!));
    }

    [TestMethod]
    public void Clamp_3_1_5_ShouldBe3()
    {
        Assert.AreEqual(3, 3.Clamp(1, 5));
    }

    [TestMethod]
    public void Clamp_10_1_5_ShouldBe5()
    {
        Assert.AreEqual(5, 10.Clamp(1, 5));
    }

    [TestMethod]
    public void Clamp_n_6_5_ShouldThrow()
    {
        Assert.ThrowsException<ArgumentException>(() => 0.Clamp(6, 5));
    }

    [TestMethod]
    public void GreaterThan_5_6_ShouldBeFalse()
    {
        Assert.IsFalse(5.GreaterThan(6));
    }

    [TestMethod]
    public void GreaterThan_6_5_ShouldBeTrue()
    {
        Assert.IsTrue(6.GreaterThan(5));
    }

    [TestMethod]
    public void GreaterThan_5_5_ShouldBeFalse()
    {
        Assert.IsFalse(5.LessThan(5));
    }

    [TestMethod]
    public void GreaterThan_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.ThrowsException<ArgumentNullException>(() => nullPointer!.GreaterThan(nullPointer!));
    }

    [TestMethod]
    public void GreaterThanOrEqualTo_5_5_ShouldBeTrue()
    {
        Assert.IsTrue(5.GreaterThanOrEqualTo(5));
    }

    [TestMethod]
    public void GreaterThanOrEqualTo_6_5_ShouldBeTrue()
    {
        Assert.IsTrue(6.GreaterThanOrEqualTo(5));
    }

    [TestMethod]
    public void GreaterThanOrEqualTo_5_6_ShouldBeFalse()
    {
        Assert.IsFalse(5.GreaterThanOrEqualTo(6));
    }

    [TestMethod]
    public void GreaterThanOrEqualTo_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.ThrowsException<ArgumentNullException>(() => nullPointer!.GreaterThanOrEqualTo(nullPointer!));
    }

    [TestMethod]
    public void LessThan_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.ThrowsException<ArgumentNullException>(() => nullPointer!.LessThan(nullPointer!));
    }

    [TestMethod]
    public void LessThan_6_5_ShouldBeFalse()
    {
        Assert.IsFalse(6.LessThan(5));
    }

    [TestMethod]
    public void LessThan_5_6_ShouldBeTrue()
    {
        Assert.IsTrue(5.LessThan(6));
    }

    [TestMethod]
    public void LessThan_5_5_ShouldBeFalse()
    {
        Assert.IsFalse(5.LessThan(5));
    }

    [TestMethod]
    public void LessThanOrEqualTo_5_5_ShouldBeTrue()
    {
        Assert.IsTrue(5.LessThanOrEqualTo(5));
    }

    [TestMethod]
    public void LessThanOrEqualTo_5_6_ShouldBeTrue()
    {
        Assert.IsTrue(5.LessThanOrEqualTo(6));
    }

    [TestMethod]
    public void LessThanOrEqualTo_6_5_ShouldBeFalse()
    {
        Assert.IsFalse(6.LessThanOrEqualTo(5));
    }

    [TestMethod]
    public void LessThanOrEqualTo_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.ThrowsException<ArgumentNullException>(() => nullPointer!.LessThanOrEqualTo(nullPointer!));
    }

    [TestMethod]
    public void Max_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.ThrowsException<ArgumentNullException>(() => nullPointer!.Max(nullPointer!));
    }

    [TestMethod]
    public void Min_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.ThrowsException<ArgumentNullException>(() => nullPointer!.Min(nullPointer!));
    }
}
