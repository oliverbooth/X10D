using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
public class SpanTests
{
    [TestMethod]
    public void AllShouldReturnTrueForEmptySpan()
    {
        var span = new Span<int>();
        Assert.IsTrue(span.All(x => x > 0));
    }

    [TestMethod]
    public void AllShouldBeCorrect()
    {
        var span = new Span<int>(new[] {2, 4, 6, 8, 10});
        Assert.IsTrue(span.All(x => x % 2 == 0));
        Assert.IsFalse(span.All(x => x % 2 == 1));
    }

    [TestMethod]
    public void AnyShouldReturnFalseForEmptySpan()
    {
        var span = new Span<int>();
        Assert.IsFalse(span.Any(x => x > 0));
    }

    [TestMethod]
    public void AnyShouldBeCorrect()
    {
        var span = new Span<int>(new[] {2, 4, 6, 8, 10});
        Assert.IsTrue(span.Any(x => x % 2 == 0));
        Assert.IsFalse(span.Any(x => x % 2 == 1));
    }

    [TestMethod]
    public void AllNullPredicateShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            var span = new Span<int>();
            return span.All(null!);
        });
    }

    [TestMethod]
    public void AnyNullPredicateShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            var span = new Span<int>();
            return span.Any(null!);
        });
    }

    [TestMethod]
    public void Count_ShouldReturn0_GivenEmptySpan()
    {
        var span = new Span<int>();
        Assert.AreEqual(0, span.Count(i => i % 2 == 0));
    }

    [TestMethod]
    public void Count_ShouldReturn5_ForEvenNumbers_GivenNumbers1To10()
    {
        var span = new Span<int>(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
        Assert.AreEqual(5, span.Count(i => i % 2 == 0));
    }

    [TestMethod]
    public void Count_ShouldThrow_GivenNullPredicate()
    {
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            var span = new Span<int>();
            return span.Count(null!);
        });
    }
}
