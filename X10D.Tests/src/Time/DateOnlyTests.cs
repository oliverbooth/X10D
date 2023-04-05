#if NET6_0_OR_GREATER
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class DateOnlyTests
{
    [TestMethod]
    public void Age_ShouldBe17_Given31December1991Birthday_And30December2017Date()
    {
        var reference = new DateOnly(2017, 12, 30);
        var birthday = new DateOnly(1999, 12, 31);

        int age = birthday.Age(reference);

        Assert.AreEqual(17, age);
    }

    [TestMethod]
    public void Age_ShouldBe18_Given31December1991Birthday_And1January2018Date()
    {
        var reference = new DateOnly(2018, 1, 1);
        var birthday = new DateOnly(1999, 12, 31);

        int age = birthday.Age(reference);

        Assert.AreEqual(18, age);
    }

    [TestMethod]
    public void Age_ShouldBe18_Given31December1991Birthday_And31December2017Date()
    {
        var reference = new DateOnly(2017, 12, 31);
        var birthday = new DateOnly(1999, 12, 31);

        int age = birthday.Age(reference);

        Assert.AreEqual(18, age);
    }

    [TestMethod]
    public void Deconstruct_ShouldDeconstructToTuple_GivenDateOnly()
    {
        var date = new DateOnly(2017, 12, 31);

        (int year, int month, int day) = date;

        Assert.AreEqual(2017, year);
        Assert.AreEqual(12, month);
        Assert.AreEqual(31, day);
    }

    [TestMethod]
    public void First_ShouldBeSaturday_Given1Jan2000()
    {
        var date = new DateOnly(2000, 1, 1);

        Assert.AreEqual(new DateOnly(2000, 1, 1), date.First(DayOfWeek.Saturday));
        Assert.AreEqual(new DateOnly(2000, 1, 2), date.First(DayOfWeek.Sunday));
        Assert.AreEqual(new DateOnly(2000, 1, 3), date.First(DayOfWeek.Monday));
        Assert.AreEqual(new DateOnly(2000, 1, 4), date.First(DayOfWeek.Tuesday));
        Assert.AreEqual(new DateOnly(2000, 1, 5), date.First(DayOfWeek.Wednesday));
        Assert.AreEqual(new DateOnly(2000, 1, 6), date.First(DayOfWeek.Thursday));
        Assert.AreEqual(new DateOnly(2000, 1, 7), date.First(DayOfWeek.Friday));
    }

    [TestMethod]
    public void FirstDayOfMonth_ShouldBe1st_GivenToday()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now.Date);

        Assert.AreEqual(new DateOnly(today.Year, today.Month, 1), today.FirstDayOfMonth());
    }

    [TestMethod]
    public void GetIso8601WeekOfYear_ShouldReturn1_Given4January1970()
    {
        var date = new DateOnly(1970, 1, 4);
        int iso8601WeekOfYear = date.GetIso8601WeekOfYear();

        Assert.AreEqual(1, iso8601WeekOfYear);
    }

    [TestMethod]
    public void GetIso8601WeekOfYear_ShouldReturn1_Given31December1969()
    {
        var date = new DateOnly(1969, 12, 31);
        int iso8601WeekOfYear = date.GetIso8601WeekOfYear();

        Assert.AreEqual(1, iso8601WeekOfYear);
    }

    [TestMethod]
    public void GetIso8601WeekOfYear_ShouldReturn53_Given31December1970()
    {
        var date = new DateOnly(1970, 12, 31);
        int iso8601WeekOfYear = date.GetIso8601WeekOfYear();

        Assert.AreEqual(53, iso8601WeekOfYear);
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_Given1999()
    {
        var date = new DateOnly(1999, 1, 1);
        Assert.IsFalse(date.IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeTrue_Given2000()
    {
        var date = new DateOnly(2000, 1, 1);
        Assert.IsTrue(date.IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_Given2001()
    {
        var date = new DateOnly(2001, 1, 1);
        Assert.IsFalse(date.IsLeapYear());
    }

    [TestMethod]
    public void IsLeapYear_ShouldBeFalse_Given2100()
    {
        var date = new DateOnly(2100, 1, 1);
        Assert.IsFalse(date.IsLeapYear());
    }

    [TestMethod]
    public void LastSaturday_ShouldBe29th_Given1Jan2000()
    {
        var date = new DateOnly(2000, 1, 1);

        Assert.AreEqual(new DateOnly(2000, 1, 29), date.Last(DayOfWeek.Saturday));
        Assert.AreEqual(new DateOnly(2000, 1, 30), date.Last(DayOfWeek.Sunday));
        Assert.AreEqual(new DateOnly(2000, 1, 31), date.Last(DayOfWeek.Monday));
        Assert.AreEqual(new DateOnly(2000, 1, 25), date.Last(DayOfWeek.Tuesday));
        Assert.AreEqual(new DateOnly(2000, 1, 26), date.Last(DayOfWeek.Wednesday));
        Assert.AreEqual(new DateOnly(2000, 1, 27), date.Last(DayOfWeek.Thursday));
        Assert.AreEqual(new DateOnly(2000, 1, 28), date.Last(DayOfWeek.Friday));
    }

    [TestMethod]
    public void LastDayOfMonth_ShouldBe28th_GivenFebruary1999()
    {
        var february = new DateOnly(1999, 2, 1);

        Assert.AreEqual(new DateOnly(february.Year, february.Month, 28), february.LastDayOfMonth());
    }

    [TestMethod]
    public void LastDayOfMonth_ShouldBe29th_GivenFebruary2000()
    {
        var february = new DateOnly(2000, 2, 1);

        Assert.AreEqual(new DateOnly(february.Year, february.Month, 29), february.LastDayOfMonth());
    }

    [TestMethod]
    public void LastDayOfMonth_ShouldBe28th_GivenFebruary2001()
    {
        var february = new DateOnly(2001, 2, 1);

        Assert.AreEqual(new DateOnly(february.Year, february.Month, 28), february.LastDayOfMonth());
    }

    [TestMethod]
    public void LastDayOfMonth_ShouldBe30th_GivenAprilJuneSeptemberNovember()
    {
        var april = new DateOnly(2000, 4, 1);
        var june = new DateOnly(2000, 6, 1);
        var september = new DateOnly(2000, 9, 1);
        var november = new DateOnly(2000, 11, 1);

        Assert.AreEqual(new DateOnly(april.Year, april.Month, 30), april.LastDayOfMonth());
        Assert.AreEqual(new DateOnly(june.Year, june.Month, 30), june.LastDayOfMonth());
        Assert.AreEqual(new DateOnly(september.Year, september.Month, 30), september.LastDayOfMonth());
        Assert.AreEqual(new DateOnly(november.Year, november.Month, 30), november.LastDayOfMonth());
    }

    [TestMethod]
    public void LastDayOfMonth_ShouldBe31st_GivenJanuaryMarchMayJulyAugustOctoberDecember()
    {
        var january = new DateOnly(2000, 1, 1);
        var march = new DateOnly(2000, 3, 1);
        var may = new DateOnly(2000, 5, 1);
        var july = new DateOnly(2000, 7, 1);
        var august = new DateOnly(2000, 8, 1);
        var october = new DateOnly(2000, 10, 1);
        var december = new DateOnly(2000, 12, 1);

        Assert.AreEqual(new DateOnly(january.Year, january.Month, 31), january.LastDayOfMonth());
        Assert.AreEqual(new DateOnly(march.Year, march.Month, 31), march.LastDayOfMonth());
        Assert.AreEqual(new DateOnly(may.Year, may.Month, 31), may.LastDayOfMonth());
        Assert.AreEqual(new DateOnly(july.Year, july.Month, 31), july.LastDayOfMonth());
        Assert.AreEqual(new DateOnly(august.Year, august.Month, 31), august.LastDayOfMonth());
        Assert.AreEqual(new DateOnly(october.Year, october.Month, 31), october.LastDayOfMonth());
        Assert.AreEqual(new DateOnly(december.Year, december.Month, 31), december.LastDayOfMonth());
    }

    [TestMethod]
    public void NextSaturday_ShouldBe8th_Given1Jan2000()
    {
        var date = new DateOnly(2000, 1, 1);

        Assert.AreEqual(new DateOnly(2000, 1, 8), date.Next(DayOfWeek.Saturday));
    }

    [TestMethod]
    public void ToUnixTimeMilliseconds_ShouldBe946684800000_Given1Jan2000()
    {
        var date = new DateOnly(2000, 1, 1);
        var time = new TimeOnly(0, 0, 0);

        Assert.AreEqual(946684800000, date.ToUnixTimeMilliseconds(time));
    }

    [TestMethod]
    public void ToUnixTimeSeconds_ShouldBe946684800_Given1Jan2000()
    {
        var date = new DateOnly(2000, 1, 1);
        var time = new TimeOnly(0, 0, 0);

        Assert.AreEqual(946684800, date.ToUnixTimeSeconds(time));
    }
}
#endif
