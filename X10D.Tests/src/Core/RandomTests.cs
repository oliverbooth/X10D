using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;
using X10D.Core;

namespace X10D.Tests.Core;

[TestClass]
public class RandomTests
{
    [TestMethod]
    public void NextBoolean_ShouldBeFalse_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.IsFalse(random.NextBoolean());
    }

    [TestMethod]
    public void NextBoolean_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextBoolean());
    }

    [TestMethod]
    public void NextByte_ShouldBe101_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(101, random.NextByte());
    }

    [TestMethod]
    public void NextByte_WithMax10_ShouldBe3_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(3, random.NextByte(10));
    }

    [TestMethod]
    public void NextByte_WithMin0Max10_ShouldBe3_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(3, random.NextByte(0, 10));
    }

    [TestMethod]
    public void NextByte_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextByte());
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextByte(10));
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextByte(0, 10));
    }

    [TestMethod]
    public void NextDouble_WithMax10_ShouldBe3point9908097935797695_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(3.9908097935797695, random.NextDouble(10));
    }

    [TestMethod]
    public void NextDouble_WithMin0Max10_ShouldBe3point9908097935797695_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(3.9908097935797695, random.NextDouble(0, 10));
    }

    [TestMethod]
    public void NextDouble_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextDouble(10));
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextDouble(0, 10));
    }

    [TestMethod]
    public void NextDouble_ShouldThrow_GivenMaxLessThan0()
    {
        var random = new Random(1234);
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => random.NextDouble(-1));
    }

    [TestMethod]
    public void NextDouble_ShouldThrow_GivenMaxLessThanMin()
    {
        var random = new Random(1234);
        Assert.ThrowsException<ArgumentException>(() => random.NextDouble(0, -1));
    }

    [TestMethod]
    public void NextEnum_ShouldBeTuesday_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(DayOfWeek.Tuesday, random.Next<DayOfWeek>());
    }

    [TestMethod]
    public void NextEnum_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.Next<DayOfWeek>());
    }

    [TestMethod]
    public void NextFrom_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextFrom(""));
    }

    [TestMethod]
    public void NextFrom_ShouldThrow_GivenNullSource()
    {
        var random = new Random(1234);
        Assert.ThrowsException<ArgumentNullException>(() => random.NextFrom((string?)null!));
    }

    [TestMethod]
    public void NextFrom_ShouldEnumerate_GivenNonList()
    {
        IEnumerable<int> Source()
        {
            yield return 0;
        }

        var random = new Random(1234);
        Assert.AreEqual(0, random.NextFrom(Source()));
    }

    [TestMethod]
    public void NextFromSpan_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Span<int> span = stackalloc int[1];
            return random!.NextFrom(span);
        });
    }

    [TestMethod]
    public void NextFromReadOnlySpan_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            Span<int> span = stackalloc int[1];
            return random!.NextFrom(span.AsReadOnly());
        });
    }

    [TestMethod]
    public void NextFromSpan_ShouldReturnOnlyValue_GivenSpanWithLength1()
    {
        Span<int> span = stackalloc int[1];
        span[0] = 42;

        var random = new Random(1234);
        Assert.AreEqual(42, random.NextFrom(span));
    }

    [TestMethod]
    public void NextFromReadOnlySpan_ShouldReturnOnlyValue_GivenSpanWithLength1()
    {
        Span<int> span = stackalloc int[1];
        span[0] = 42;

        var random = new Random(1234);
        Assert.AreEqual(42, random.NextFrom(span.AsReadOnly()));
    }

    [TestMethod]
    public void NextInt16_ShouldBe13076_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(13076, random.NextInt16());
    }

    [TestMethod]
    public void NextInt16_WithMax10_ShouldBe3_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(3, random.NextInt16(10));
    }

    [TestMethod]
    public void NextInt16_WithMin0Max10_ShouldBe3_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(3, random.NextInt16(0, 10));
    }

    [TestMethod]
    public void NextInt16_ShouldThrow_GivenMaxLessThan0()
    {
        var random = new Random(1234);
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => random.NextInt16(-1));
    }

    [TestMethod]
    public void NextInt16_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextInt16());
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextInt16(10));
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextInt16(0, 10));
    }

    [TestMethod]
    public void NextSingle_WithMax10_ShouldBe3point99081_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(3.99081f, random.NextSingle(10));
    }

    [TestMethod]
    public void NextSingle_WithMin0Max10_ShouldBe3point99081_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.AreEqual(3.99081f, random.NextSingle(0, 10));
    }

    [TestMethod]
    public void NextSingle_ShouldThrow_GivenNull()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextSingle(10));
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextSingle(0, 10));
    }

    [TestMethod]
    public void NextSingle_ShouldThrow_GivenMaxLessThan0()
    {
        var random = new Random(1234);
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => random.NextSingle(-1));
    }

    [TestMethod]
    public void NextSingle_ShouldThrow_GivenMaxLessThanMin()
    {
        var random = new Random(1234);
        Assert.ThrowsException<ArgumentException>(() => random.NextSingle(0, -1));
    }

    [TestMethod]
    public void NextString_ShouldBe_kxiyiyvnqi_GivenSeed1234()
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";

        var random = new Random(1234);
        Assert.AreEqual("kxiyiyvnqi", random.NextString(alphabet.ToCharArray(), 10));
    }

    [TestMethod]
    public void NextString_ShouldBeEmpty_GivenLength0()
    {
        var random = new Random(1234);
        Assert.AreEqual(string.Empty, random.NextString(ArraySegment<char>.Empty, 0));
    }

    [TestMethod]
    public void NextString_ShouldBeLength1_GivenLength1()
    {
        var random = new Random(1234);
        Assert.AreEqual(1, random.NextString("hello world".ToCharArray(), 1).Length);
    }

    [TestMethod]
    public void NextString_ShouldThrow_GivenNullRandom()
    {
        Random? random = null;
        Assert.ThrowsException<ArgumentNullException>(() => random!.NextString(ArraySegment<char>.Empty, 0));
    }

    [TestMethod]
    public void NextString_ShouldThrow_GivenNullSource()
    {
        var random = new Random(1234);
        Assert.ThrowsException<ArgumentNullException>(() => random.NextString(null!, 0));
    }

    [TestMethod]
    public void NextString_ShouldThrow_GivenNegativeLength()
    {
        var random = new Random(1234);
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => random.NextString(ArraySegment<char>.Empty, -1));
    }
}
