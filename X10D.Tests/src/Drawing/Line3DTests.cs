using System.Drawing;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class Line3DTests
{
    [TestMethod]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyAndOne()
    {
        Assert.AreEqual(-1, Line3D.Empty.CompareTo(Line3D.One));
    }

    [TestMethod]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyLineAndOneLineAsObject()
    {
        Assert.AreEqual(-1, Line3D.Empty.CompareTo((object)Line3D.One));
    }

    [TestMethod]
    public void CompareTo_ShouldBeOne_GivenNull()
    {
        Assert.AreEqual(1, Line3D.One.CompareTo(null));
    }

    [TestMethod]
    public void CompareTo_ShouldBeOne_GivenOneAndEmpty()
    {
        Assert.AreEqual(1, Line3D.One.CompareTo(Line3D.Empty));
    }

    [TestMethod]
    public void CompareTo_ShouldBeZero_GivenUnitLine()
    {
        var unitLine3D = Line3D.One;
        Assert.AreEqual(0, unitLine3D.CompareTo(unitLine3D));
    }

    [TestMethod]
    public void CompareTo_ShouldThrowArgumentException_GivenInvalidType()
    {
        Assert.ThrowsException<ArgumentException>(() => Line3D.Empty.CompareTo(new object()));
    }

    [TestMethod]
    public void Length_ShouldBe0_GivenEmptyLine()
    {
        Assert.AreEqual(0.0f, Line3D.Empty.Length);
    }

    [TestMethod]
    public void Length_ShouldBe1_GivenUnitXLine()
    {
        Assert.AreEqual(1.0f, Line3D.UnitX.Length, 1e-6f);
    }

    [TestMethod]
    public void Length_ShouldBe1_GivenUnitYLine()
    {
        Assert.AreEqual(1.0f, Line3D.UnitY.Length, 1e-6f);
    }

    [TestMethod]
    public void Length_ShouldBe1_GivenUnitZLine()
    {
        Assert.AreEqual(1.0f, Line3D.UnitZ.Length, 1e-6f);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoUnitLines()
    {
        Line3D first = Line3D.One;
        Line3D second = Line3D.One;

        Assert.AreEqual(first, second);
        Assert.IsTrue(first == second);
        Assert.IsFalse(first != second);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentLines()
    {
        Assert.AreNotEqual(Line3D.One, Line3D.Empty);
        Assert.IsFalse(Line3D.One == Line3D.Empty);
        Assert.IsTrue(Line3D.One != Line3D.Empty);
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Line3D.Empty.GetHashCode();
        Assert.AreEqual(hashCode, Line3D.Empty.GetHashCode());
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenUnitLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Line3D.One.GetHashCode();
        Assert.AreEqual(hashCode, Line3D.One.GetHashCode());
    }

    [TestMethod]
    public void op_Explicit_ShouldReturnEquivalentLine_GivenLine()
    {
        Line3D oneLine = new Line3D(Vector3.Zero, Vector3.UnitX + Vector3.UnitY);
        Line converted = (Line)oneLine;

        var expectedStart = new Point((int)oneLine.Start.X, (int)oneLine.Start.Y);
        var expectedEnd = new Point((int)oneLine.End.X, (int)oneLine.End.Y);

        Assert.AreEqual(oneLine.Length, converted.Length);
        Assert.AreEqual(expectedStart, converted.Start);
        Assert.AreEqual(expectedEnd, converted.End);
    }

    [TestMethod]
    public void op_Explicit_ShouldReturnEquivalentLineF_GivenLine()
    {
        Line3D oneLine = new Line3D(Vector3.Zero, Vector3.UnitX + Vector3.UnitY);
        LineF converted = (LineF)oneLine;

        var expectedStart = new PointF(oneLine.Start.X, oneLine.Start.Y);
        var expectedEnd = new PointF(oneLine.End.X, oneLine.End.Y);

        Assert.AreEqual(oneLine.Length, converted.Length);
        Assert.AreEqual(expectedStart, converted.Start);
        Assert.AreEqual(expectedEnd, converted.End);
    }

    [TestMethod]
    public void op_GreaterThan_True_GivenUnitAndEmptyCircle()
    {
        Assert.IsTrue(Line3D.One > Line3D.Empty);
        Assert.IsTrue(Line3D.One >= Line3D.Empty);
        Assert.IsFalse(Line3D.One < Line3D.Empty);
        Assert.IsFalse(Line3D.One <= Line3D.Empty);
    }

    [TestMethod]
    public void op_Implicit_ShouldReturnEquivalentLine_GivenLine()
    {
        Line oneLine = Line.One;
        Line3D converted = oneLine;

        var expectedStart = new Vector3(oneLine.Start.X, oneLine.Start.Y, 0.0f);
        var expectedEnd = new Vector3(oneLine.End.X, oneLine.End.Y, 0.0f);

        Assert.AreEqual(oneLine, converted);
        Assert.AreEqual(oneLine.Length, converted.Length);
        Assert.AreEqual(expectedStart, converted.Start);
        Assert.AreEqual(expectedEnd, converted.End);
    }

    [TestMethod]
    public void op_Implicit_ShouldReturnEquivalentLine_GivenLineF()
    {
        LineF oneLine = LineF.One;
        Line3D converted = oneLine;

        var expectedStart = new Vector3(oneLine.Start.X, oneLine.Start.Y, 0.0f);
        var expectedEnd = new Vector3(oneLine.End.X, oneLine.End.Y, 0.0f);

        Assert.AreEqual(oneLine, converted);
        Assert.AreEqual(oneLine.Length, converted.Length);
        Assert.AreEqual(expectedStart, converted.Start);
        Assert.AreEqual(expectedEnd, converted.End);
    }

    [TestMethod]
    public void op_LessThan_True_GivenEmptyAndUnitCircle()
    {
        Assert.IsTrue(Line3D.Empty < Line3D.One);
        Assert.IsTrue(Line3D.Empty <= Line3D.One);
        Assert.IsFalse(Line3D.Empty > Line3D.One);
        Assert.IsFalse(Line3D.Empty >= Line3D.One);
    }
}
