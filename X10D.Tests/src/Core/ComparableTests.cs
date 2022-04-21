using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

/// <summary>
///     Tests for <see cref="ComparableExtensions" />.
/// </summary>
[TestClass]
public class ComparableTests
{
    /// <summary>
    ///     Tests <see cref="ComparableExtensions.Between{T1, T2, T3}" />
    /// </summary>
    [TestMethod]
    public void Between()
    {
        const int lower = 5;
        const int upper = 15;
        const int value = 10;

        Assert.IsTrue(value.Between(lower, upper), "value.Between(lower, upper)");
        Assert.IsFalse(lower.Between(value, upper), "lower.Between(value, upper)");
        Assert.IsFalse(upper.Between(lower, value), "upper.Between(lower, value)");
            
        Assert.IsTrue(upper.Between(lower, upper, InclusiveOptions.UpperInclusive), "upper.Between(lower, upper, Clusivity.UpperInclusive)");
        Assert.IsTrue(upper.Between(lower, upper, InclusiveOptions.Inclusive), "upper.Between(lower, upper, Clusivity.Inclusive)");
        Assert.IsFalse(upper.Between(lower, upper, InclusiveOptions.LowerInclusive), "upper.Between(lower, upper, Clusivity.LowerInclusive)");
            
        Assert.IsTrue(lower.Between(lower, upper, InclusiveOptions.LowerInclusive), "lower.Between(lower, upper, Clusivity.LowerInclusive)");
        Assert.IsTrue(lower.Between(lower, upper, InclusiveOptions.Inclusive), "lower.Between(lower, upper, Clusivity.Inclusive)");
        Assert.IsFalse(lower.Between(lower, upper, InclusiveOptions.UpperInclusive), "lower.Between(lower, upper, Clusivity.UpperInclusive)");
    }

    /// <summary>
    ///     Tests <see cref="ComparableExtensions.Clamp{T}" />
    /// </summary>
    [TestMethod]
    public void Clamp()
    {
        const int lower = 5;
        const int upper = 10;
        const int value = 15;

        Assert.AreEqual(upper, value.Clamp(lower, upper));
        Assert.AreEqual(upper, lower.Clamp(upper, value));
        Assert.AreEqual(upper, upper.Clamp(lower, value));
    }

    /// <summary>
    ///     Tests <see cref="ComparableExtensions.GreaterThan{T1, T2}" />
    /// </summary>
    [TestMethod]
    public void GreaterThan()
    {
        const int first = 5;
        const int second = 10;

        Assert.IsTrue(second.GreaterThan(first));
        Assert.IsFalse(first.GreaterThan(second));
    }

    /// <summary>
    ///     Tests <see cref="ComparableExtensions.GreaterThanOrEqualTo{T1, T2}" />
    /// </summary>
    [TestMethod]
    public void GreaterThanOrEqualTo()
    {
        const int first = 5;
        const int second = 10;

        Assert.IsTrue(second.GreaterThanOrEqualTo(first));
        Assert.IsTrue(second.GreaterThanOrEqualTo(second));
        Assert.IsTrue(first.GreaterThanOrEqualTo(first));
        Assert.IsFalse(first.GreaterThanOrEqualTo(second));
    }

    /// <summary>
    ///     Tests <see cref="ComparableExtensions.GreaterThan{T1, T2}" />
    /// </summary>
    [TestMethod]
    public void LessThan()
    {
        const int first = 5;
        const int second = 10;

        Assert.IsTrue(first.LessThan(second));
        Assert.IsFalse(second.LessThan(first));
    }

    /// <summary>
    ///     Tests <see cref="ComparableExtensions.LessThanOrEqualTo{T1, T2}" />
    /// </summary>
    [TestMethod]
    public void LessThanOrEqualTo()
    {
        const int first = 5;
        const int second = 10;

        Assert.IsTrue(first.LessThanOrEqualTo(second));
        Assert.IsTrue(first.LessThanOrEqualTo(first));
        Assert.IsTrue(second.LessThanOrEqualTo(second));
        Assert.IsFalse(second.LessThanOrEqualTo(first));
    }

    /// <summary>
    ///     Tests <see cref="ComparableExtensions.Max{T}" />
    /// </summary>
    [TestMethod]
    public void Max()
    {
        const int first = 5;
        const int second = 10;

        Assert.AreEqual(second, first.Max(second));
        Assert.AreEqual(second, second.Max(first));
    }

    /// <summary>
    ///     Tests <see cref="ComparableExtensions.Min{T}" />
    /// </summary>
    [TestMethod]
    public void Min()
    {
        const int first = 5;
        const int second = 10;

        Assert.AreEqual(first, first.Min(second));
        Assert.AreEqual(first, second.Min(first));
    }
}