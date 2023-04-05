using System.Drawing;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
public class LineFTests
{
    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyAndOne()
    {
        Assert.That(LineF.Empty.CompareTo(LineF.One), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyLineAndOneLineAsObject()
    {
        Assert.That(LineF.Empty.CompareTo((object)LineF.One), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenNull()
    {
        Assert.That(LineF.One.CompareTo(null), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenOneAndEmpty()
    {
        Assert.That(LineF.One.CompareTo(LineF.Empty), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeZero_GivenUnitLine()
    {
        Assert.That(LineF.One.CompareTo(LineF.One), Is.Zero);
    }

    [Test]
    public void CompareTo_ShouldThrowArgumentException_GivenInvalidType()
    {
        Assert.Throws<ArgumentException>(() => _ = LineF.Empty.CompareTo(new object()));
    }

    [Test]
    public void Length_ShouldBe0_GivenEmptyLine()
    {
        Assert.That(LineF.Empty.Length, Is.Zero);
    }

    [Test]
    public void Length_ShouldBe1_GivenUnitXLine()
    {
        Assert.That(LineF.UnitX.Length, Is.EqualTo(1.0f).Within(1e-6f));
    }

    [Test]
    public void Length_ShouldBe1_GivenUnitYLine()
    {
        Assert.That(LineF.UnitY.Length, Is.EqualTo(1.0f).Within(1e-6f));
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoUnitLines()
    {
        LineF first = LineF.One;
        LineF second = LineF.One;

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.EqualTo(first));
            Assert.That(first, Is.EqualTo(second));
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentLines()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LineF.Empty, Is.Not.EqualTo(LineF.One));
            Assert.That(LineF.One, Is.Not.EqualTo(LineF.Empty));
        });
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.That(LineF.One, Is.Not.EqualTo(null));
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = LineF.Empty.GetHashCode();
        Assert.That(LineF.Empty.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenUnitLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = LineF.One.GetHashCode();
        Assert.That(LineF.One.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void op_Explicit_ShouldReturnEquivalentLine_GivenLine()
    {
        LineF oneLine = LineF.One;
        Line converted = (Line)oneLine;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((Line)oneLine));
            Assert.That(converted.Length, Is.EqualTo(oneLine.Length));
            Assert.That((PointF)converted.Start, Is.EqualTo(oneLine.Start));
            Assert.That((PointF)converted.End, Is.EqualTo(oneLine.End));
        });
    }

    [Test]
    public void op_GreaterThan_True_GivenUnitAndEmptyCircle()
    {
        Assert.That(LineF.One, Is.GreaterThan(LineF.Empty));
        Assert.That(LineF.One, Is.GreaterThanOrEqualTo(LineF.Empty));
    }

    [Test]
    public void op_Implicit_ShouldReturnEquivalentLine_GivenLine()
    {
        Line oneLine = Line.One;
        LineF converted = oneLine;

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((LineF)oneLine));
            Assert.That(converted.Length, Is.EqualTo(oneLine.Length));
            Assert.That(converted.Start, Is.EqualTo((PointF)oneLine.Start));
            Assert.That(converted.End, Is.EqualTo((PointF)oneLine.End));
        });
    }

    [Test]
    public void op_LessThan_True_GivenEmptyAndUnitCircle()
    {
        Assert.That(LineF.Empty, Is.LessThan(LineF.One));
        Assert.That(LineF.Empty, Is.LessThanOrEqualTo(LineF.One));
    }
}
