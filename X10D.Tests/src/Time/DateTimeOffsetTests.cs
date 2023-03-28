using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class DateTimeOffsetTests
{
    [TestMethod]
    public void Age_ShouldBeDifference_Given1Jan2000()
    {
        DateTimeOffset birthday = new DateTime(2000, 1, 1);
        DateTimeOffset today = DateTime.Now.Date;

        Assert.AreEqual(today.Year - birthday.Year, birthday.Age());
    }

    [TestMethod]
    public void First_ShouldBeSaturday_Given1Jan2000()
    {
        DateTimeOffset date = new DateTime(2000, 1, 1);

        Assert.AreEqual(new DateTime(2000, 1, 1), date.First(DayOfWeek.Saturday));
        Assert.AreEqual(new DateTime(2000, 1, 2), date.First(DayOfWeek.Sunday));
        Assert.AreEqual(new DateTime(2000, 1, 3), date.First(DayOfWeek.Monday));
        Assert.AreEqual(new DateTime(2000, 1, 4), date.First(DayOfWeek.Tuesday));
        Assert.AreEqual(new DateTime(2000, 1, 5), date.First(DayOfWeek.Wednesday));
        Assert.AreEqual(new DateTime(2000, 1, 6), date.First(DayOfWeek.Thursday));
        Assert.AreEqual(new DateTime(2000, 1, 7), date.First(DayOfWeek.Friday));
    }

    [TestMethod]
    public void FirstDayOfMonth_ShouldBe1st_GivenToday()
    {
        DateTimeOffset today = DateTime.UtcNow.Date;

        Assert.AreEqual(new DateTime(today.Year, today.Month, 1), today.FirstDayOfMonth());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_Given1999()
    {
        DateTimeOffset date = new DateTime(1999, 1, 1);
        Assert.IsFalse(date.IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeTrue_Given2000()
    {
        DateTimeOffset date = new DateTime(2000, 1, 1);
        Assert.IsTrue(date.IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_Given2001()
    {
        DateTimeOffset date = new DateTime(2001, 1, 1);
        Assert.IsFalse(date.IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_Given2100()
    {
        DateTimeOffset date = new DateTime(2100, 1, 1);
        Assert.IsFalse(date.IsLeapYear());
    }

    [TestMethod]
    public void LastSaturday_ShouldBe29th_Given1Jan2000()
    {
        DateTimeOffset date = new DateTime(2000, 1, 1);

        Assert.AreEqual(new DateTime(2000, 1, 29), date.Last(DayOfWeek.Saturday));
        Assert.AreEqual(new DateTime(2000, 1, 30), date.Last(DayOfWeek.Sunday));
        Assert.AreEqual(new DateTime(2000, 1, 31), date.Last(DayOfWeek.Monday));
        Assert.AreEqual(new DateTime(2000, 1, 25), date.Last(DayOfWeek.Tuesday));
        Assert.AreEqual(new DateTime(2000, 1, 26), date.Last(DayOfWeek.Wednesday));
        Assert.AreEqual(new DateTime(2000, 1, 27), date.Last(DayOfWeek.Thursday));
        Assert.AreEqual(new DateTime(2000, 1, 28), date.Last(DayOfWeek.Friday));
    }

    [TestMethod]
    public void LastDayOfMonth_ShouldBe28th_GivenFebruary1999()
    {
        DateTimeOffset february = new DateTime(1999, 2, 1);

        Assert.AreEqual(new DateTime(february.Year, february.Month, 28), february.LastDayOfMonth());
    }

    [TestMethod]
    public void LastDayOfMonth_ShouldBe29th_GivenFebruary2000()
    {
        DateTimeOffset february = new DateTime(2000, 2, 1);

        Assert.AreEqual(new DateTime(february.Year, february.Month, 29), february.LastDayOfMonth());
    }

    [TestMethod]
    public void LastDayOfMonth_ShouldBe28th_GivenFebruary2001()
    {
        DateTimeOffset february = new DateTime(2001, 2, 1);

        Assert.AreEqual(new DateTime(february.Year, february.Month, 28), february.LastDayOfMonth());
    }

    [TestMethod]
    public void LastDayOfMonth_ShouldBe30th_GivenAprilJuneSeptemberNovember()
    {
        DateTimeOffset april = new DateTime(2000, 4, 1);
        DateTimeOffset june = new DateTime(2000, 6, 1);
        DateTimeOffset september = new DateTime(2000, 9, 1);
        DateTimeOffset november = new DateTime(2000, 11, 1);

        Assert.AreEqual(new DateTime(april.Year, april.Month, 30), april.LastDayOfMonth());
        Assert.AreEqual(new DateTime(june.Year, june.Month, 30), june.LastDayOfMonth());
        Assert.AreEqual(new DateTime(september.Year, september.Month, 30), september.LastDayOfMonth());
        Assert.AreEqual(new DateTime(november.Year, november.Month, 30), november.LastDayOfMonth());
    }

    [TestMethod]
    public void LastDayOfMonth_ShouldBe31st_GivenJanuaryMarchMayJulyAugustOctoberDecember()
    {
        DateTimeOffset january = new DateTime(2000, 1, 1);
        DateTimeOffset march = new DateTime(2000, 3, 1);
        DateTimeOffset may = new DateTime(2000, 5, 1);
        DateTimeOffset july = new DateTime(2000, 7, 1);
        DateTimeOffset august = new DateTime(2000, 8, 1);
        DateTimeOffset october = new DateTime(2000, 10, 1);
        DateTimeOffset december = new DateTime(2000, 12, 1);

        Assert.AreEqual(new DateTime(january.Year, january.Month, 31), january.LastDayOfMonth());
        Assert.AreEqual(new DateTime(march.Year, march.Month, 31), march.LastDayOfMonth());
        Assert.AreEqual(new DateTime(may.Year, may.Month, 31), may.LastDayOfMonth());
        Assert.AreEqual(new DateTime(july.Year, july.Month, 31), july.LastDayOfMonth());
        Assert.AreEqual(new DateTime(august.Year, august.Month, 31), august.LastDayOfMonth());
        Assert.AreEqual(new DateTime(october.Year, october.Month, 31), october.LastDayOfMonth());
        Assert.AreEqual(new DateTime(december.Year, december.Month, 31), december.LastDayOfMonth());
    }

    [TestMethod]
    public void NextSaturday_ShouldBe8th_Given1Jan2000()
    {
        DateTimeOffset date = new DateTime(2000, 1, 1);

        Assert.AreEqual(new DateTime(2000, 1, 8), date.Next(DayOfWeek.Saturday));
    }
}
