using NUnit.Framework;
using X10D.Reflection;

namespace X10D.Tests.Reflection;

[TestFixture]
internal class TypeTests
{
    [Test]
    public void Inherits_ShouldBeTrue_GivenStringInheritsObject()
    {
        Assert.That(typeof(string).Inherits(typeof(object)));
        Assert.That(typeof(string).Inherits<object>());
    }

    [Test]
    public void Inherits_ShouldBeFalse_GivenObjectInheritsString()
    {
        Assert.That(typeof(object).Inherits(typeof(string)), Is.False);
        Assert.That(typeof(object).Inherits<string>(), Is.False);
    }

    [Test]
    public void Inherits_ShouldThrow_GivenValueType()
    {
        Assert.Throws<ArgumentException>(() => typeof(int).Inherits(typeof(object)));
        Assert.Throws<ArgumentException>(() => typeof(object).Inherits(typeof(int)));
    }

    [Test]
    public void Inherits_ShouldThrow_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => typeof(object).Inherits(null!));
        Assert.Throws<ArgumentNullException>(() => ((Type?)null)!.Inherits(typeof(object)));
        Assert.Throws<ArgumentNullException>(() => ((Type?)null)!.Inherits<object>());
    }

    [Test]
    public void Implements_ShouldBeTrue_GivenInt32ImplementsIComparable()
    {
        Assert.That(typeof(int).Implements<IComparable>());
        Assert.That(typeof(int).Implements<IComparable<int>>());
        Assert.That(typeof(int).Implements(typeof(IComparable)));
        Assert.That(typeof(int).Implements(typeof(IComparable<int>)));
    }

    [Test]
    public void Implements_ShouldThrow_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => typeof(object).Implements(null!));
        Assert.Throws<ArgumentNullException>(() => ((Type?)null)!.Implements(typeof(IComparable)));
        Assert.Throws<ArgumentNullException>(() => ((Type?)null)!.Implements<IComparable>());
    }

    [Test]
    public void Implements_ShouldThrow_GivenNonInterface()
    {
        Assert.Throws<ArgumentException>(() => typeof(string).Implements<object>());
        Assert.Throws<ArgumentException>(() => typeof(string).Implements(typeof(object)));
    }
}
