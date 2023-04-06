using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
public class LineTests
{
    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyAndOne()
    {
        Assert.That(Line.Empty.CompareTo(Line.One), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyLineAndOneLineAsObject()
    {
        Assert.That(Line.Empty.CompareTo((object)Line.One), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenNull()
    {
        Assert.That(Line.One.CompareTo(null), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenOneAndEmpty()
    {
        Assert.That(Line.One.CompareTo(Line.Empty), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeZero_GivenUnitLine()
    {
        var unitLine = Line.One;
        Assert.That(unitLine.CompareTo(unitLine), Is.Zero);
    }

    [Test]
    public void CompareTo_ShouldThrowArgumentException_GivenInvalidType()
    {
        Assert.Throws<ArgumentException>(() => _ = Line.Empty.CompareTo(new object()));
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoUnitLines()
    {
        Line first = Line.One;
        Line second = Line.One;

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.EqualTo(first));
            Assert.That(first, Is.EqualTo(second));
            Assert.That(second == first);
            Assert.That(first == second);
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentLines()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Line.Empty, Is.Not.EqualTo(Line.One));
            Assert.That(Line.One, Is.Not.EqualTo(Line.Empty));
            Assert.That(Line.Empty != Line.One);
            Assert.That(Line.One != Line.Empty);
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.That(Line.One, Is.Not.EqualTo(null));
        Assert.That(Line.One.Equals(null), Is.False);
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Line.Empty.GetHashCode();
        Assert.That(Line.Empty.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenUnitLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Line.One.GetHashCode();
        Assert.That(Line.One.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void Length_ShouldBe0_GivenEmptyLine()
    {
        Assert.That(Line.Empty.Length, Is.Zero);
    }

    [Test]
    public void Length_ShouldBe1_GivenUnitXLine()
    {
        Assert.That(Line.UnitX.Length, Is.EqualTo(1.0f).Within(1e-6f));
    }

    [Test]
    public void Length_ShouldBe1_GivenUnitYLine()
    {
        Assert.That(Line.UnitY.Length, Is.EqualTo(1.0f).Within(1e-6f));
    }

    [Test]
    public void op_GreaterThan_True_GivenUnitAndEmptyCircle()
    {
        Assert.That(Line.One, Is.GreaterThan(Line.Empty));
        Assert.That(Line.One, Is.GreaterThanOrEqualTo(Line.Empty));
        Assert.That(Line.One > Line.Empty);
        Assert.That(Line.One >= Line.Empty);
    }

    [Test]
    public void op_LessThan_True_GivenEmptyAndUnitCircle()
    {
        Assert.That(Line.Empty, Is.LessThan(Line.One));
        Assert.That(Line.Empty, Is.LessThanOrEqualTo(Line.One));
        Assert.That(Line.Empty < Line.One);
        Assert.That(Line.Empty <= Line.One);
    }
}
