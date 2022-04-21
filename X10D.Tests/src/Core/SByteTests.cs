using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

/// <summary>
///     Tests for <see cref="SByteExtensions" />
/// </summary>
[CLSCompliant(false)]
[TestClass]
public class SByteTests
{
    /// <summary>
    ///     Tests <see cref="SByteExtensions.IsEven"/>.
    /// </summary>
    [TestMethod]
    public void IsEven()
    {
        const sbyte one = 1;
        const sbyte two = 2;

        var oneEven = one.IsEven();
        var twoEven = two.IsEven();

        Assert.AreEqual(false, oneEven);
        Assert.AreEqual(true, twoEven);
    }
        
    /// <summary>
    ///     Tests <see cref="SByteExtensions.IsOdd"/>.
    /// </summary>
    [TestMethod]
    public void IsOdd()
    {
        const sbyte one = 1;
        const sbyte two = 2;

        var oneOdd = one.IsOdd();
        var twoOdd = two.IsOdd();

        Assert.AreEqual(true, oneOdd);
        Assert.AreEqual(false, twoOdd);
    }
}