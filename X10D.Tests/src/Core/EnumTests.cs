using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Core;

namespace X10D.Tests.Core;

[TestClass]
public class EnumTests
{
    // Microsoft wrongfully decided to have Sunday be 0, Monday be 1, etc.
    // I personally hate this, Sunday is not the first day of the week.
    // it's clearly Monday as defined by ISO 8601.
    // but Microsoft can't fix this without breaking compatibility.
    // I have feelings...

    [TestMethod]
    public void Next()
    {
        Assert.AreEqual(DayOfWeek.Monday, DayOfWeek.Sunday.Next());
        Assert.AreEqual(DayOfWeek.Tuesday, DayOfWeek.Monday.Next());
        Assert.AreEqual(DayOfWeek.Wednesday, DayOfWeek.Tuesday.Next());
        Assert.AreEqual(DayOfWeek.Thursday, DayOfWeek.Wednesday.Next());
        Assert.AreEqual(DayOfWeek.Friday, DayOfWeek.Thursday.Next());
        Assert.AreEqual(DayOfWeek.Saturday, DayOfWeek.Friday.Next());
        Assert.AreEqual(DayOfWeek.Sunday, DayOfWeek.Saturday.Next()); // Saturday is the "last" day. wrap to "first"
    }

    [TestMethod]
    public void NextUnchecked()
    {
        Assert.AreEqual(DayOfWeek.Monday, DayOfWeek.Sunday.NextUnchecked());
        Assert.AreEqual(DayOfWeek.Tuesday, DayOfWeek.Monday.NextUnchecked());
        Assert.AreEqual(DayOfWeek.Wednesday, DayOfWeek.Tuesday.NextUnchecked());
        Assert.AreEqual(DayOfWeek.Thursday, DayOfWeek.Wednesday.NextUnchecked());
        Assert.AreEqual(DayOfWeek.Friday, DayOfWeek.Thursday.NextUnchecked());
        Assert.AreEqual(DayOfWeek.Saturday, DayOfWeek.Friday.NextUnchecked());
        Assert.ThrowsException<IndexOutOfRangeException>(() => DayOfWeek.Saturday.NextUnchecked());
    }

    [TestMethod]
    public void Previous()
    {
        Assert.AreEqual(DayOfWeek.Saturday, DayOfWeek.Sunday.Previous()); // Sunday is the "first" day. wrap to "last"
        Assert.AreEqual(DayOfWeek.Sunday, DayOfWeek.Monday.Previous());
        Assert.AreEqual(DayOfWeek.Monday, DayOfWeek.Tuesday.Previous());
        Assert.AreEqual(DayOfWeek.Tuesday, DayOfWeek.Wednesday.Previous());
        Assert.AreEqual(DayOfWeek.Wednesday, DayOfWeek.Thursday.Previous());
        Assert.AreEqual(DayOfWeek.Thursday, DayOfWeek.Friday.Previous());
        Assert.AreEqual(DayOfWeek.Friday, DayOfWeek.Saturday.Previous());
    }

    [TestMethod]
    public void PreviousUnchecked()
    {
        Assert.AreEqual(DayOfWeek.Sunday, DayOfWeek.Monday.PreviousUnchecked());
        Assert.AreEqual(DayOfWeek.Monday, DayOfWeek.Tuesday.PreviousUnchecked());
        Assert.AreEqual(DayOfWeek.Tuesday, DayOfWeek.Wednesday.PreviousUnchecked());
        Assert.AreEqual(DayOfWeek.Wednesday, DayOfWeek.Thursday.PreviousUnchecked());
        Assert.AreEqual(DayOfWeek.Thursday, DayOfWeek.Friday.PreviousUnchecked());
        Assert.AreEqual(DayOfWeek.Friday, DayOfWeek.Saturday.PreviousUnchecked());
        Assert.ThrowsException<IndexOutOfRangeException>(() => DayOfWeek.Sunday.PreviousUnchecked());
    }
}
