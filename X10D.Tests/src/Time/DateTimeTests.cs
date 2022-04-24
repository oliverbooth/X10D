using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class DateTimeTests
{
    [TestMethod]
    public void AgeShouldBeCorrect()
    {
        var birthday = new DateTime(2000, 1, 1);
        DateTime today = DateTime.Now.Date;

        Assert.AreEqual(today.Year - birthday.Year, birthday.Age());
    }

    [TestMethod]
    public void FirstShouldBeCorrect()
    {
        var date = new DateTime(2000, 1, 1);

        Assert.AreEqual(new DateTime(2000, 1, 1), date.First(DayOfWeek.Saturday));
        Assert.AreEqual(new DateTime(2000, 1, 2), date.First(DayOfWeek.Sunday));
        Assert.AreEqual(new DateTime(2000, 1, 3), date.First(DayOfWeek.Monday));
        Assert.AreEqual(new DateTime(2000, 1, 4), date.First(DayOfWeek.Tuesday));
        Assert.AreEqual(new DateTime(2000, 1, 5), date.First(DayOfWeek.Wednesday));
        Assert.AreEqual(new DateTime(2000, 1, 6), date.First(DayOfWeek.Thursday));
        Assert.AreEqual(new DateTime(2000, 1, 7), date.First(DayOfWeek.Friday));
    }

    [TestMethod]
    public void FirstDayOfMonthShouldBeCorrect()
    {
        DateTime today = DateTime.Now.Date;

        Assert.AreEqual(new DateTime(today.Year, today.Month, 1), today.FirstDayOfMonth());
    }

    [TestMethod]
    public void LastShouldBeCorrect()
    {
        var date = new DateTime(2000, 1, 1);

        Assert.AreEqual(new DateTime(2000, 1, 29), date.Last(DayOfWeek.Saturday));
        Assert.AreEqual(new DateTime(2000, 1, 30), date.Last(DayOfWeek.Sunday));
        Assert.AreEqual(new DateTime(2000, 1, 31), date.Last(DayOfWeek.Monday));
        Assert.AreEqual(new DateTime(2000, 1, 25), date.Last(DayOfWeek.Tuesday));
        Assert.AreEqual(new DateTime(2000, 1, 26), date.Last(DayOfWeek.Wednesday));
        Assert.AreEqual(new DateTime(2000, 1, 27), date.Last(DayOfWeek.Thursday));
        Assert.AreEqual(new DateTime(2000, 1, 28), date.Last(DayOfWeek.Friday));
    }

    [TestMethod]
    public void LastDayOfMonthShouldBeCorrect()
    {
        var date = new DateTime(2000, 1, 1);

        Assert.AreEqual(new DateTime(date.Year, date.Month, 31), date.LastDayOfMonth());
    }

    [TestMethod]
    public void NextShouldBeCorrect()
    {
        var date = new DateTime(2000, 1, 1);

        Assert.AreEqual(new DateTime(2000, 1, 8), date.Next(DayOfWeek.Saturday));
    }

    [TestMethod]
    public void ToUnixTimeMillisecondsShouldBeCorrect()
    {
        var date = new DateTime(2000, 1, 1);

        Assert.AreEqual(946684800000, date.ToUnixTimeMilliseconds());
    }

    [TestMethod]
    public void ToUnixTimeSecondsShouldBeCorrect()
    {
        var date = new DateTime(2000, 1, 1);

        Assert.AreEqual(946684800, date.ToUnixTimeSeconds());
    }
}
