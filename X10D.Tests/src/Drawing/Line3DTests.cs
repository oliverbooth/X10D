using System.Drawing;
using System.Numerics;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
public class Line3DTests
{
    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyAndOne()
    {
        Assert.That(Line3D.Empty.CompareTo(Line3D.One), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyLineAndOneLineAsObject()
    {
        Assert.That(Line3D.Empty.CompareTo((object)Line3D.One), Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenNull()
    {
        Assert.That(Line3D.One.CompareTo(null), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeOne_GivenOneAndEmpty()
    {
        Assert.That(Line3D.One.CompareTo(Line3D.Empty), Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_ShouldBeZero_GivenUnitLine()
    {
        var unitLine3D = Line3D.One;
        Assert.That(unitLine3D.CompareTo(unitLine3D), Is.Zero);
    }

    [Test]
    public void CompareTo_ShouldThrowArgumentException_GivenInvalidType()
    {
        Assert.Throws<ArgumentException>(() => _ = Line3D.Empty.CompareTo(new object()));
    }

    [Test]
    public void Length_ShouldBe0_GivenEmptyLine()
    {
        Assert.That(Line3D.Empty.Length, Is.Zero);
    }

    [Test]
    public void Length_ShouldBe1_GivenUnitXLine()
    {
        Assert.That(Line3D.UnitX.Length, Is.EqualTo(1.0f).Within(1e-6f));
    }

    [Test]
    public void Length_ShouldBe1_GivenUnitYLine()
    {
        Assert.That(Line3D.UnitY.Length, Is.EqualTo(1.0f).Within(1e-6f));
    }

    [Test]
    public void Length_ShouldBe1_GivenUnitZLine()
    {
        Assert.That(Line3D.UnitZ.Length, Is.EqualTo(1.0f).Within(1e-6f));
    }

    [Test]
    public void Equals_ShouldBeTrue_GivenTwoUnitLines()
    {
        Line3D first = Line3D.One;
        Line3D second = Line3D.One;

        Assert.That(second, Is.EqualTo(first));
        Assert.That(second == first);
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentLines()
    {
        Assert.That(Line3D.Empty, Is.Not.EqualTo(Line3D.One));
        Assert.That(Line3D.Empty != Line3D.One);
    }

    [Test]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.That(Line3D.One, Is.Not.EqualTo(null));
        Assert.That(Line3D.One.Equals(null), Is.False);
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Line3D.Empty.GetHashCode();
        Assert.That(Line3D.Empty.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void GetHashCode_ShouldBeCorrect_GivenUnitLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Line3D.One.GetHashCode();
        Assert.That(Line3D.One.GetHashCode(), Is.EqualTo(hashCode));
    }

    [Test]
    public void op_Explicit_ShouldReturnEquivalentLine_GivenLine()
    {
        Line3D oneLine = new Line3D(Vector3.Zero, Vector3.UnitX + Vector3.UnitY);
        Line converted = (Line)oneLine;

        var expectedStart = new Point((int)oneLine.Start.X, (int)oneLine.Start.Y);
        var expectedEnd = new Point((int)oneLine.End.X, (int)oneLine.End.Y);

        Assert.Multiple(() =>
        {
            Assert.That(converted.Length, Is.EqualTo(oneLine.Length));
            Assert.That(converted.Start, Is.EqualTo(expectedStart));
            Assert.That(converted.End, Is.EqualTo(expectedEnd));
        });
    }

    [Test]
    public void op_Explicit_ShouldReturnEquivalentLineF_GivenLine()
    {
        Line3D oneLine = new Line3D(Vector3.Zero, Vector3.UnitX + Vector3.UnitY);
        LineF converted = (LineF)oneLine;

        var expectedStart = new PointF(oneLine.Start.X, oneLine.Start.Y);
        var expectedEnd = new PointF(oneLine.End.X, oneLine.End.Y);

        Assert.Multiple(() =>
        {
            Assert.That(converted.Length, Is.EqualTo(oneLine.Length));
            Assert.That(converted.Start, Is.EqualTo(expectedStart));
            Assert.That(converted.End, Is.EqualTo(expectedEnd));
        });
    }

    [Test]
    public void op_GreaterThan_True_GivenUnitAndEmptyCircle()
    {
        Assert.That(Line3D.One, Is.GreaterThan(Line3D.Empty));
        Assert.That(Line3D.One, Is.GreaterThanOrEqualTo(Line3D.Empty));

        Assert.That(Line3D.One > Line3D.Empty);
        Assert.That(Line3D.One >= Line3D.Empty);
    }

    [Test]
    public void op_Implicit_ShouldReturnEquivalentLine_GivenLine()
    {
        Line oneLine = Line.One;
        Line3D converted = oneLine;

        var expectedStart = new Vector3(oneLine.Start.X, oneLine.Start.Y, 0.0f);
        var expectedEnd = new Vector3(oneLine.End.X, oneLine.End.Y, 0.0f);

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((Line3D)oneLine));
            Assert.That(converted.Length, Is.EqualTo(oneLine.Length));
            Assert.That(converted.Start, Is.EqualTo(expectedStart));
            Assert.That(converted.End, Is.EqualTo(expectedEnd));
        });
    }

    [Test]
    public void op_Implicit_ShouldReturnEquivalentLine_GivenLineF()
    {
        LineF oneLine = LineF.One;
        Line3D converted = oneLine;

        var expectedStart = new Vector3(oneLine.Start.X, oneLine.Start.Y, 0.0f);
        var expectedEnd = new Vector3(oneLine.End.X, oneLine.End.Y, 0.0f);

        Assert.Multiple(() =>
        {
            Assert.That(converted, Is.EqualTo((Line3D)oneLine));
            Assert.That(converted == oneLine);
            Assert.That(converted.Length, Is.EqualTo(oneLine.Length));
            Assert.That(converted.Start, Is.EqualTo(expectedStart));
            Assert.That(converted.End, Is.EqualTo(expectedEnd));
        });
    }

    [Test]
    public void op_LessThan_True_GivenEmptyAndUnitCircle()
    {
        Assert.That(Line3D.Empty, Is.LessThan(Line3D.One));
        Assert.That(Line3D.Empty, Is.LessThanOrEqualTo(Line3D.One));
        Assert.That(Line3D.Empty < Line3D.One);
        Assert.That(Line3D.Empty <= Line3D.One);
    }
}
