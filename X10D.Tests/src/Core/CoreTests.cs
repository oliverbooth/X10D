using NUnit.Framework;
using X10D.Core;

namespace X10D.Tests.Core;

[TestFixture]
internal class CoreTests
{
    [Test]
    [TestCase(1)]
    [TestCase("f")]
    [TestCase(true)]
    public void AsArrayValue_ShouldBeLength1_GivenValue(object o)
    {
        object[] array = o.AsArrayValue();
        Assert.That(array, Is.Not.Null);
        Assert.That(array, Has.Length.EqualTo(1));
    }

    [Test]
    [TestCase(1)]
    [TestCase("f")]
    [TestCase(true)]
    public void AsArrayValue_ShouldContainValue_Given_Value(object o)
    {
        object[] array = o.AsArrayValue();
        Assert.That(array, Is.Not.Null);
        Assert.That(array[0], Is.EqualTo(o));
    }

    [Test]
    [TestCase(1)]
    [TestCase("f")]
    [TestCase(true)]
    public void AsEnumerableValue_ShouldBeLength1_GivenValue(object o)
    {
        object[] enumerable = o.AsEnumerableValue().ToArray();
        Assert.That(enumerable, Is.Not.Null);
        Assert.That(enumerable, Has.Length.EqualTo(1));
    }

    [Test]
    [TestCase(1)]
    [TestCase("f")]
    [TestCase(true)]
    public void AsEnumerableValue_ShouldContainValue_Given_Value(object o)
    {
        object[] enumerable = o.AsEnumerableValue().ToArray();
        Assert.That(enumerable, Is.Not.Null);
        Assert.That(enumerable.ElementAt(0), Is.EqualTo(o));
    }

    [Test]
    [TestCase(1)]
    [TestCase("f")]
    [TestCase(true)]
    public void RepeatValue_ShouldContainRepeatedValue_GivenValue(object o)
    {
        IEnumerable<object> enumerable = o.RepeatValue(10);
        // ReSharper disable once PossibleMultipleEnumeration
        Assert.That(enumerable, Is.Not.Null);

        // ReSharper disable once PossibleMultipleEnumeration
        object[] array = enumerable.ToArray();
        Assert.That(array, Has.Length.EqualTo(10));
        CollectionAssert.AreEqual(new[] {o, o, o, o, o, o, o, o, o, o}, array);
    }

    [Test]
    [TestCase(1)]
    [TestCase("f")]
    [TestCase(true)]
    public void RepeatValue_ShouldThrow_GivenNegativeCount(object o)
    {
        // we must force enumeration via ToArray() to ensure the exception is thrown
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = o.RepeatValue(-1).ToArray());
    }
}
