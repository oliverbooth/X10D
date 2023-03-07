using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class LineFTests
{
    [TestMethod]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyAndOne()
    {
        Assert.AreEqual(-1, LineF.Empty.CompareTo(LineF.One));
    }

    [TestMethod]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyLineAndOneLineAsObject()
    {
        Assert.AreEqual(-1, LineF.Empty.CompareTo((object)LineF.One));
    }

    [TestMethod]
    public void CompareTo_ShouldBeOne_GivenNull()
    {
        Assert.AreEqual(1, LineF.One.CompareTo(null));
    }

    [TestMethod]
    public void CompareTo_ShouldBeOne_GivenOneAndEmpty()
    {
        Assert.AreEqual(1, LineF.One.CompareTo(LineF.Empty));
    }

    [TestMethod]
    public void CompareTo_ShouldBeZero_GivenUnitLine()
    {
        var unitLineF = LineF.One;
        Assert.AreEqual(0, unitLineF.CompareTo(unitLineF));
    }

    [TestMethod]
    public void CompareTo_ShouldThrowArgumentException_GivenInvalidType()
    {
        Assert.ThrowsException<ArgumentException>(() => LineF.Empty.CompareTo(new object()));
    }

    [TestMethod]
    public void Length_ShouldBe0_GivenEmptyLine()
    {
        Assert.AreEqual(0.0f, LineF.Empty.Length);
    }

    [TestMethod]
    public void Length_ShouldBe1_GivenUnitXLine()
    {
        Assert.AreEqual(1.0f, LineF.UnitX.Length, 1e-6f);
    }

    [TestMethod]
    public void Length_ShouldBe1_GivenUnitYLine()
    {
        Assert.AreEqual(1.0f, LineF.UnitY.Length, 1e-6f);
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoUnitLines()
    {
        LineF first = LineF.One;
        LineF second = LineF.One;

        Assert.AreEqual(first, second);
        Assert.IsTrue(first == second);
        Assert.IsFalse(first != second);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentLines()
    {
        Assert.AreNotEqual(LineF.One, LineF.Empty);
        Assert.IsFalse(LineF.One == LineF.Empty);
        Assert.IsTrue(LineF.One != LineF.Empty);
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = LineF.Empty.GetHashCode();
        Assert.AreEqual(hashCode, LineF.Empty.GetHashCode());
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenUnitLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = LineF.One.GetHashCode();
        Assert.AreEqual(hashCode, LineF.One.GetHashCode());
    }

    [TestMethod]
    public void op_Explicit_ShouldReturnEquivalentLine_GivenLine()
    {
        LineF oneLine = LineF.One;
        Line converted = (Line)oneLine;

        Assert.AreEqual(oneLine, converted);
        Assert.AreEqual(oneLine.Length, converted.Length);
        Assert.AreEqual(oneLine.Start, converted.Start);
        Assert.AreEqual(oneLine.End, converted.End);
    }

    [TestMethod]
    public void op_GreaterThan_True_GivenUnitAndEmptyCircle()
    {
        Assert.IsTrue(LineF.One > LineF.Empty);
        Assert.IsTrue(LineF.One >= LineF.Empty);
        Assert.IsFalse(LineF.One < LineF.Empty);
        Assert.IsFalse(LineF.One <= LineF.Empty);
    }

    [TestMethod]
    public void op_Implicit_ShouldReturnEquivalentLine_GivenLine()
    {
        Line oneLine = Line.One;
        LineF converted = oneLine;

        Assert.AreEqual(oneLine, converted);
        Assert.AreEqual(oneLine.Length, converted.Length);
        Assert.AreEqual(oneLine.Start, converted.Start);
        Assert.AreEqual(oneLine.End, converted.End);
    }

    [TestMethod]
    public void op_LessThan_True_GivenEmptyAndUnitCircle()
    {
        Assert.IsTrue(LineF.Empty < LineF.One);
        Assert.IsTrue(LineF.Empty <= LineF.One);
        Assert.IsFalse(LineF.Empty > LineF.One);
        Assert.IsFalse(LineF.Empty >= LineF.One);
    }
}
