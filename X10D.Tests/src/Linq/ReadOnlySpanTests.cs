using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
public class ReadOnlySpanTests
{
    [TestMethod]
    public void AllShouldReturnTrueForEmptySpan()
    {
        var span = new ReadOnlySpan<int>();
        Assert.IsTrue(span.All(x => x > 0));
    }

    [TestMethod]
    public void AllShouldBeCorrect()
    {
        var span = new ReadOnlySpan<int>(new[] {2, 4, 6, 8, 10});
        Assert.IsTrue(span.All(x => x % 2 == 0));
        Assert.IsFalse(span.All(x => x % 2 == 1));
    }

    [TestMethod]
    public void AnyShouldReturnFalseForEmptySpan()
    {
        var span = new ReadOnlySpan<int>();
        Assert.IsFalse(span.Any(x => x > 0));
    }

    [TestMethod]
    public void AnyShouldBeCorrect()
    {
        var span = new ReadOnlySpan<int>(new[] {2, 4, 6, 8, 10});
        Assert.IsTrue(span.Any(x => x % 2 == 0));
        Assert.IsFalse(span.Any(x => x % 2 == 1));
    }

    [TestMethod]
    public void AllNullPredicateShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            var span = new ReadOnlySpan<int>();
            return span.All(null!);
        });
    }

    [TestMethod]
    public void AnyNullPredicateShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            var span = new ReadOnlySpan<int>();
            return span.Any(null!);
        });
    }
}
