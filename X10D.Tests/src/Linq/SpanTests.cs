using NUnit.Framework;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestFixture]
internal class SpanTests
{
    [Test]
    public void AllShouldReturnTrueForEmptySpan()
    {
        Span<int> span = [];
        Assert.That(span.All(x => x > 0));
    }

    [Test]
    public void AllShouldBeCorrect()
    {
        Assert.Multiple(() =>
        {
            Span<int> span = [2, 4, 6, 8, 10];
            Assert.That(span.All(x => x % 2 == 0));
            Assert.That(span.All(x => x % 2 == 1), Is.False);
        });
    }

    [Test]
    public void AnyShouldReturnFalseForEmptySpan()
    {
        Span<int> span = [];
        Assert.That(span.Any(x => x > 0), Is.False);
    }

    [Test]
    public void AnyShouldBeCorrect()
    {
        Assert.Multiple(() =>
        {
            Span<int> span = [2, 4, 6, 8, 10];
            Assert.That(span.Any(x => x % 2 == 0));
            Assert.That(span.Any(x => x % 2 == 1), Is.False);
        });
    }

    [Test]
    public void AllNullPredicateShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            Span<int> span = [];
            _ = span.All(null!);
        });
    }

    [Test]
    public void AnyNullPredicateShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            Span<int> span = [];
            _ = span.Any(null!);
        });
    }

    [Test]
    public void Count_ShouldReturn0_GivenEmptySpan()
    {
        Span<int> span = [];
        Assert.That(span.Count(i => i % 2 == 0), Is.Zero);
    }

    [Test]
    public void Count_ShouldReturn5_ForEvenNumbers_GivenNumbers1To10()
    {
        Span<int> span = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        Assert.That(span.Count(i => i % 2 == 0), Is.EqualTo(5));
    }

    [Test]
    public void Count_ShouldThrow_GivenNullPredicate()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            Span<int> span = [];
            _ = span.Count((Predicate<int>)null!);
        });
    }
}
