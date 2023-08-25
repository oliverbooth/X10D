using NUnit.Framework;
using X10D.Collections;
using X10D.Core;

namespace X10D.Tests.Core;

[TestFixture]
internal class RandomTests
{
    [Test]
    public void NextBoolean_ShouldBeFalse_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextBoolean(), Is.False);
    }

    [Test]
    public void NextBoolean_ShouldThrow_GivenNull()
    {
        Random random = null!;
        Assert.Throws<ArgumentNullException>(() => random.NextBoolean());
    }

    [Test]
    public void NextByte_ShouldBe101_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextByte(), Is.EqualTo(101));
    }

    [Test]
    public void NextByte_WithMax10_ShouldBe3_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextByte(10), Is.EqualTo(3));
    }

    [Test]
    public void NextByte_WithMin0Max10_ShouldBe3_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextByte(0, 10), Is.EqualTo(3));
    }

    [Test]
    public void NextByte_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.Throws<ArgumentNullException>(() => random!.NextByte());
        Assert.Throws<ArgumentNullException>(() => random!.NextByte(10));
        Assert.Throws<ArgumentNullException>(() => random!.NextByte(0, 10));
    }

    [Test]
    public void NextDouble_WithMax10_ShouldBe3point9908097935797695_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextDouble(10), Is.EqualTo(3.9908097935797695));
    }

    [Test]
    public void NextDouble_WithMin0Max10_ShouldBe3point9908097935797695_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextDouble(0, 10), Is.EqualTo(3.9908097935797695));
    }

    [Test]
    public void NextDouble_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.Throws<ArgumentNullException>(() => random!.NextDouble(10));
        Assert.Throws<ArgumentNullException>(() => random!.NextDouble(0, 10));
    }

    [Test]
    public void NextDouble_ShouldThrow_GivenMaxLessThan0()
    {
        var random = new Random(1234);
        Assert.Throws<ArgumentOutOfRangeException>(() => random.NextDouble(-1));
    }

    [Test]
    public void NextDouble_ShouldThrow_GivenMaxLessThanMin()
    {
        var random = new Random(1234);
        Assert.Throws<ArgumentException>(() => random.NextDouble(0, -1));
    }

    [Test]
    public void NextEnum_ShouldBeTuesday_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.Next<DayOfWeek>(), Is.EqualTo(DayOfWeek.Tuesday));
    }

    [Test]
    public void NextEnum_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.Throws<ArgumentNullException>(() => random!.Next<DayOfWeek>());
    }

    [Test]
    public void NextFrom_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.Throws<ArgumentNullException>(() => random!.NextFrom(""));
    }

    [Test]
    public void NextFrom_ShouldThrow_GivenNullSource()
    {
        var random = new Random(1234);
        Assert.Throws<ArgumentNullException>(() => random.NextFrom((string?)null!));
    }

    [Test]
    public void NextFrom_ShouldEnumerate_GivenNonList()
    {
        IEnumerable<int> Source()
        {
            yield return 0;
        }

        var random = new Random(1234);
        Assert.That(random.NextFrom(Source()), Is.Zero);
    }

    [Test]
    public void NextFromSpan_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.Throws<ArgumentNullException>(() =>
        {
            Span<int> span = stackalloc int[1];
            _ = random!.NextFrom(span);
        });
    }

    [Test]
    public void NextFromReadOnlySpan_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.Throws<ArgumentNullException>(() =>
        {
            Span<int> span = stackalloc int[1];
            _ = random!.NextFrom(span.AsReadOnly());
        });
    }

    [Test]
    public void NextFromSpan_ShouldReturnOnlyValue_GivenSpanWithLength1()
    {
        Span<int> span = stackalloc int[1];
        span[0] = 42;

        var random = new Random(1234);
        Assert.That(random.NextFrom(span), Is.EqualTo(42));
    }

    [Test]
    public void NextFromReadOnlySpan_ShouldReturnOnlyValue_GivenSpanWithLength1()
    {
        Span<int> span = stackalloc int[1];
        span[0] = 42;

        var random = new Random(1234);
        Assert.That(random.NextFrom(span.AsReadOnly()), Is.EqualTo(42));
    }

    [Test]
    public void NextInt16_ShouldBe13076_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextInt16(), Is.EqualTo(13076));
    }

    [Test]
    public void NextInt16_WithMax10_ShouldBe3_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextInt16(10), Is.EqualTo(3));
    }

    [Test]
    public void NextInt16_WithMin0Max10_ShouldBe3_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextInt16(0, 10), Is.EqualTo(3));
    }

    [Test]
    public void NextInt16_ShouldThrow_GivenMaxLessThan0()
    {
        var random = new Random(1234);
        Assert.Throws<ArgumentOutOfRangeException>(() => random.NextInt16(-1));
    }

    [Test]
    public void NextInt16_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.Throws<ArgumentNullException>(() => random!.NextInt16());
        Assert.Throws<ArgumentNullException>(() => random!.NextInt16(10));
        Assert.Throws<ArgumentNullException>(() => random!.NextInt16(0, 10));
    }

    [Test]
    public void NextSingle_WithMax10_ShouldBe3point99081_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextSingle(10), Is.EqualTo(3.99081f));
    }

    [Test]
    public void NextSingle_WithMin0Max10_ShouldBe3point99081_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextSingle(0, 10), Is.EqualTo(3.99081f));
    }

    [Test]
    public void NextSingle_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.Throws<ArgumentNullException>(() => random!.NextSingle(10));
        Assert.Throws<ArgumentNullException>(() => random!.NextSingle(0, 10));
#if !NET6_0_OR_GREATER
        Assert.Throws<ArgumentNullException>(() => random!.NextSingle());
#endif
    }

    [Test]
    public void NextSingle_ShouldThrow_GivenMaxLessThan0()
    {
        var random = new Random(1234);
        Assert.Throws<ArgumentOutOfRangeException>(() => random.NextSingle(-1));
    }

    [Test]
    public void NextSingle_ShouldThrow_GivenMaxLessThanMin()
    {
        var random = new Random(1234);
        Assert.Throws<ArgumentException>(() => random.NextSingle(0, -1));
    }

    [Test]
    public void NextString_ShouldBe_kxiyiyvnqi_GivenSeed1234()
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";

        var random = new Random(1234);
        Assert.That(random.NextString(alphabet.ToCharArray(), 10), Is.EqualTo("kxiyiyvnqi"));
    }

    [Test]
    public void NextString_ShouldBeEmpty_GivenLength0()
    {
        var random = new Random(1234);
        Assert.That(random.NextString(ArraySegment<char>.Empty, 0), Is.EqualTo(string.Empty));
    }

    [Test]
    public void NextString_ShouldBeLength1_GivenLength1()
    {
        var random = new Random(1234);
        Assert.That(random.NextString("hello world".ToCharArray(), 1).Length, Is.EqualTo(1));
    }

    [Test]
    public void NextString_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.Throws<ArgumentNullException>(() => random!.NextString(ArraySegment<char>.Empty, 0));
    }

    [Test]
    public void NextString_ShouldThrow_GivenNullSource()
    {
        var random = new Random(1234);
        Assert.Throws<ArgumentNullException>(() => random.NextString(null!, 0));
    }

    [Test]
    public void NextString_ShouldThrow_GivenNegativeLength()
    {
        var random = new Random(1234);
        Assert.Throws<ArgumentOutOfRangeException>(() => random.NextString(ArraySegment<char>.Empty, -1));
    }
}
