using NUnit.Framework;
using X10D.Math;

namespace X10D.Tests.Math;

[TestFixture]
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

    [Test]
    public void Between_5_1_10_ShouldBeTrue()
    {
        Assert.That(_value.Between(_lower, _upper));
    }

    [Test]
    public void Between_1_1_10_ShouldBeFalse()
    {
        // default option is exclusive
        Assert.That(_lower.Between(_lower, _upper), Is.False);
    }

    [Test]
    public void Between_1_1_10_Inclusive_ShouldBeTrue()
    {
        Assert.That(_lower.Between(_lower, _upper, InclusiveOptions.Inclusive));
        Assert.That(_lower.Between(_lower, _upper, InclusiveOptions.LowerInclusive));
        Assert.That(_lower.Between(_lower, _upper, InclusiveOptions.UpperInclusive), Is.False);
    }

    [Test]
    public void Between_10_1_10_ShouldBeFalse()
    {
        // default option is exclusive
        Assert.That(_upper.Between(_lower, _upper), Is.False);
    }

    [Test]
    public void Between_10_1_10_Inclusive_ShouldBeTrue()
    {
        Assert.That(_upper.Between(_lower, _upper, InclusiveOptions.Inclusive));
        Assert.That(_upper.Between(_lower, _upper, InclusiveOptions.UpperInclusive));
        Assert.That(_upper.Between(_lower, _upper, InclusiveOptions.LowerInclusive), Is.False);
    }

    [Test]
    public void Between_1_10_5_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => _lower.Between(_upper, _value));
    }

    [Test]
    public void Between_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.Throws<ArgumentNullException>(() => ((ComparableTestClass?)null)!.Between(nullPointer!, nullPointer!));
    }

    [Test]
    public void Clamp_3_1_5_ShouldBe3()
    {
        Assert.That(3.Clamp(1, 5), Is.EqualTo(3));
    }

    [Test]
    public void Clamp_10_1_5_ShouldBe5()
    {
        Assert.That(10.Clamp(1, 5), Is.EqualTo(5));
    }

    [Test]
    public void Clamp_n_6_5_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => 0.Clamp(6, 5));
    }

    [Test]
    public void Clamp_ShouldThrowArgumentNullException_GivenNullValue()
    {
        string comparable = null!;
        Assert.Throws<ArgumentNullException>(() => comparable.Clamp(string.Empty, string.Empty));
    }

    [Test]
    public void GreaterThan_5_6_ShouldBeFalse()
    {
        Assert.That(5.GreaterThan(6), Is.False);
    }

    [Test]
    public void GreaterThan_6_5_ShouldBeTrue()
    {
        Assert.That(6.GreaterThan(5));
    }

    [Test]
    public void GreaterThan_5_5_ShouldBeFalse()
    {
        Assert.That(5.LessThan(5), Is.False);
    }

    [Test]
    public void GreaterThan_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.Throws<ArgumentNullException>(() => nullPointer!.GreaterThan(nullPointer!));
    }

    [Test]
    public void GreaterThanOrEqualTo_5_5_ShouldBeTrue()
    {
        Assert.That(5.GreaterThanOrEqualTo(5));
    }

    [Test]
    public void GreaterThanOrEqualTo_6_5_ShouldBeTrue()
    {
        Assert.That(6.GreaterThanOrEqualTo(5));
    }

    [Test]
    public void GreaterThanOrEqualTo_5_6_ShouldBeFalse()
    {
        Assert.That(5.GreaterThanOrEqualTo(6), Is.False);
    }

    [Test]
    public void GreaterThanOrEqualTo_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.Throws<ArgumentNullException>(() => nullPointer!.GreaterThanOrEqualTo(nullPointer!));
    }

    [Test]
    public void LessThan_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.Throws<ArgumentNullException>(() => nullPointer!.LessThan(nullPointer!));
    }

    [Test]
    public void LessThan_6_5_ShouldBeFalse()
    {
        Assert.That(6.LessThan(5), Is.False);
    }

    [Test]
    public void LessThan_5_6_ShouldBeTrue()
    {
        Assert.That(5.LessThan(6));
    }

    [Test]
    public void LessThan_5_5_ShouldBeFalse()
    {
        Assert.That(5.LessThan(5), Is.False);
    }

    [Test]
    public void LessThanOrEqualTo_5_5_ShouldBeTrue()
    {
        Assert.That(5.LessThanOrEqualTo(5));
    }

    [Test]
    public void LessThanOrEqualTo_5_6_ShouldBeTrue()
    {
        Assert.That(5.LessThanOrEqualTo(6));
    }

    [Test]
    public void LessThanOrEqualTo_6_5_ShouldBeFalse()
    {
        Assert.That(6.LessThanOrEqualTo(5), Is.False);
    }

    [Test]
    public void LessThanOrEqualTo_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.Throws<ArgumentNullException>(() => nullPointer!.LessThanOrEqualTo(nullPointer!));
    }

    [Test]
    public void Max_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.Throws<ArgumentNullException>(() => nullPointer!.Max(nullPointer!));
    }

    [Test]
    public void Min_Null_ShouldThrow()
    {
        ComparableTestClass? nullPointer = null;
        Assert.Throws<ArgumentNullException>(() => nullPointer!.Min(nullPointer!));
    }
}
