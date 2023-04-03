using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class LineTests
{
    [TestMethod]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyAndOne()
    {
        Assert.AreEqual(-1, Line.Empty.CompareTo(Line.One));
    }

    [TestMethod]
    public void CompareTo_ShouldBeNegativeOne_GivenEmptyLineAndOneLineAsObject()
    {
        Assert.AreEqual(-1, Line.Empty.CompareTo((object)Line.One));
    }

    [TestMethod]
    public void CompareTo_ShouldBeOne_GivenNull()
    {
        Assert.AreEqual(1, Line.One.CompareTo(null));
    }

    [TestMethod]
    public void CompareTo_ShouldBeOne_GivenOneAndEmpty()
    {
        Assert.AreEqual(1, Line.One.CompareTo(Line.Empty));
    }

    [TestMethod]
    public void CompareTo_ShouldBeZero_GivenUnitLine()
    {
        var unitLine = Line.One;
        Assert.AreEqual(0, unitLine.CompareTo(unitLine));
    }

    [TestMethod]
    public void CompareTo_ShouldThrowArgumentException_GivenInvalidType()
    {
        Assert.ThrowsException<ArgumentException>(() => Line.Empty.CompareTo(new object()));
    }

    [TestMethod]
    public void Equals_ShouldBeTrue_GivenTwoUnitLines()
    {
        Line first = Line.One;
        Line second = Line.One;

        Assert.AreEqual(first, second);
        Assert.IsTrue(first == second);
        Assert.IsFalse(first != second);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentLines()
    {
        Assert.AreNotEqual(Line.One, Line.Empty);
        Assert.IsFalse(Line.One == Line.Empty);
        Assert.IsTrue(Line.One != Line.Empty);
    }

    [TestMethod]
    public void Equals_ShouldBeFalse_GivenDifferentObjects()
    {
        Assert.IsFalse(Line.One.Equals(null));
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenEmptyLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Line.Empty.GetHashCode();
        Assert.AreEqual(hashCode, Line.Empty.GetHashCode());
    }

    [TestMethod]
    public void GetHashCode_ShouldBeCorrect_GivenUnitLine()
    {
        // this test is pretty pointless, it exists only for code coverage purposes
        int hashCode = Line.One.GetHashCode();
        Assert.AreEqual(hashCode, Line.One.GetHashCode());
    }

    [TestMethod]
    public void Length_ShouldBe0_GivenEmptyLine()
    {
        Assert.AreEqual(0.0f, Line.Empty.Length);
    }

    [TestMethod]
    public void Length_ShouldBe1_GivenUnitXLine()
    {
        Assert.AreEqual(1.0f, Line.UnitX.Length, 1e-6f);
    }

    [TestMethod]
    public void Length_ShouldBe1_GivenUnitYLine()
    {
        Assert.AreEqual(1.0f, Line.UnitY.Length, 1e-6f);
    }

    [TestMethod]
    public void op_GreaterThan_True_GivenUnitAndEmptyCircle()
    {
        Assert.IsTrue(Line.One > Line.Empty);
        Assert.IsTrue(Line.One >= Line.Empty);
        Assert.IsFalse(Line.One < Line.Empty);
        Assert.IsFalse(Line.One <= Line.Empty);
    }

    [TestMethod]
    public void op_LessThan_True_GivenEmptyAndUnitCircle()
    {
        Assert.IsTrue(Line.Empty < Line.One);
        Assert.IsTrue(Line.Empty <= Line.One);
        Assert.IsFalse(Line.Empty > Line.One);
        Assert.IsFalse(Line.Empty >= Line.One);
    }
}
