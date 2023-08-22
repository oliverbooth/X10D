#if NET6_0_OR_GREATER
using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
internal class DateOnlyTests
{
    [Test]
    public void Age_ShouldBe17_Given31December1991Birthday_And30December2017Date()
    {
        var reference = new DateOnly(2017, 12, 30);
        var birthday = new DateOnly(1999, 12, 31);

        int age = birthday.Age(reference);

        Assert.That(age, Is.EqualTo(17));
    }

    [Test]
    public void Age_ShouldBe18_Given31December1991Birthday_And1January2018Date()
    {
        var reference = new DateOnly(2018, 1, 1);
        var birthday = new DateOnly(1999, 12, 31);

        int age = birthday.Age(reference);

        Assert.That(age, Is.EqualTo(18));
    }

    [Test]
    public void Age_ShouldBe18_Given31December1991Birthday_And31December2017Date()
    {
        var reference = new DateOnly(2017, 12, 31);
        var birthday = new DateOnly(1999, 12, 31);

        int age = birthday.Age(reference);

        Assert.That(age, Is.EqualTo(18));
    }

    [Test]
    public void Deconstruct_ShouldDeconstructToTuple_GivenDateOnly()
    {
        var date = new DateOnly(2017, 12, 31);

        (int year, int month, int day) = date;

        Assert.That(year, Is.EqualTo(2017));
        Assert.That(month, Is.EqualTo(12));
        Assert.That(day, Is.EqualTo(31));
    }

    [Test]
    public void First_ShouldBeSaturday_Given1Jan2000()
    {
        var date = new DateOnly(2000, 1, 1);

        Assert.Multiple(() =>
        {
            Assert.That(date.First(DayOfWeek.Saturday), Is.EqualTo(new DateOnly(2000, 1, 1)));
            Assert.That(date.First(DayOfWeek.Sunday), Is.EqualTo(new DateOnly(2000, 1, 2)));
            Assert.That(date.First(DayOfWeek.Monday), Is.EqualTo(new DateOnly(2000, 1, 3)));
            Assert.That(date.First(DayOfWeek.Tuesday), Is.EqualTo(new DateOnly(2000, 1, 4)));
            Assert.That(date.First(DayOfWeek.Wednesday), Is.EqualTo(new DateOnly(2000, 1, 5)));
            Assert.That(date.First(DayOfWeek.Thursday), Is.EqualTo(new DateOnly(2000, 1, 6)));
            Assert.That(date.First(DayOfWeek.Friday), Is.EqualTo(new DateOnly(2000, 1, 7)));
        });
    }

    [Test]
    public void FirstDayOfMonth_ShouldBe1st_GivenToday()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now.Date);

        Assert.That(today.FirstDayOfMonth(), Is.EqualTo(new DateOnly(today.Year, today.Month, 1)));
    }

    [Test]
    public void GetIso8601WeekOfYear_ShouldReturn1_Given4January1970()
    {
        var date = new DateOnly(1970, 1, 4);
        int iso8601WeekOfYear = date.GetIso8601WeekOfYear();

        Assert.That(iso8601WeekOfYear, Is.EqualTo(1));
    }

    [Test]
    public void GetIso8601WeekOfYear_ShouldReturn1_Given31December1969()
    {
        var date = new DateOnly(1969, 12, 31);
        int iso8601WeekOfYear = date.GetIso8601WeekOfYear();

        Assert.That(iso8601WeekOfYear, Is.EqualTo(1));
    }

    [Test]
    public void GetIso8601WeekOfYear_ShouldReturn53_Given31December1970()
    {
        var date = new DateOnly(1970, 12, 31);
        int iso8601WeekOfYear = date.GetIso8601WeekOfYear();

        Assert.That(iso8601WeekOfYear, Is.EqualTo(53));
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_Given1999()
    {
        var date = new DateOnly(1999, 1, 1);
        Assert.That(date.IsLeapYear(), Is.False);
    }

    [Test]
    public void IsLeapYear_ShouldBeTrue_Given2000()
    {
        var date = new DateOnly(2000, 1, 1);
        Assert.That(date.IsLeapYear());
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_Given2001()
    {
        var date = new DateOnly(2001, 1, 1);
        Assert.That(date.IsLeapYear(), Is.False);
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_Given2100()
    {
        var date = new DateOnly(2100, 1, 1);
        Assert.That(date.IsLeapYear(), Is.False);
    }

    [Test]
    public void LastSaturday_ShouldBe29th_Given1Jan2000()
    {
        var date = new DateOnly(2000, 1, 1);

        Assert.That(date.Last(DayOfWeek.Saturday), Is.EqualTo(new DateOnly(2000, 1, 29)));
        Assert.That(date.Last(DayOfWeek.Sunday), Is.EqualTo(new DateOnly(2000, 1, 30)));
        Assert.That(date.Last(DayOfWeek.Monday), Is.EqualTo(new DateOnly(2000, 1, 31)));
        Assert.That(date.Last(DayOfWeek.Tuesday), Is.EqualTo(new DateOnly(2000, 1, 25)));
        Assert.That(date.Last(DayOfWeek.Wednesday), Is.EqualTo(new DateOnly(2000, 1, 26)));
        Assert.That(date.Last(DayOfWeek.Thursday), Is.EqualTo(new DateOnly(2000, 1, 27)));
        Assert.That(date.Last(DayOfWeek.Friday), Is.EqualTo(new DateOnly(2000, 1, 28)));
    }

    [Test]
    public void LastDayOfMonth_ShouldBe28th_GivenFebruary1999()
    {
        var february = new DateOnly(1999, 2, 1);

        Assert.That(february.LastDayOfMonth(), Is.EqualTo(new DateOnly(february.Year, february.Month, 28)));
    }

    [Test]
    public void LastDayOfMonth_ShouldBe29th_GivenFebruary2000()
    {
        var february = new DateOnly(2000, 2, 1);

        Assert.That(february.LastDayOfMonth(), Is.EqualTo(new DateOnly(february.Year, february.Month, 29)));
    }

    [Test]
    public void LastDayOfMonth_ShouldBe28th_GivenFebruary2001()
    {
        var february = new DateOnly(2001, 2, 1);

        Assert.That(february.LastDayOfMonth(), Is.EqualTo(new DateOnly(february.Year, february.Month, 28)));
    }

    [Test]
    public void LastDayOfMonth_ShouldBe30th_GivenAprilJuneSeptemberNovember()
    {
        var april = new DateOnly(2000, 4, 1);
        var june = new DateOnly(2000, 6, 1);
        var september = new DateOnly(2000, 9, 1);
        var november = new DateOnly(2000, 11, 1);

        Assert.That(april.LastDayOfMonth(), Is.EqualTo(new DateOnly(april.Year, april.Month, 30)));
        Assert.That(june.LastDayOfMonth(), Is.EqualTo(new DateOnly(june.Year, june.Month, 30)));
        Assert.That(september.LastDayOfMonth(), Is.EqualTo(new DateOnly(september.Year, september.Month, 30)));
        Assert.That(november.LastDayOfMonth(), Is.EqualTo(new DateOnly(november.Year, november.Month, 30)));
    }

    [Test]
    public void LastDayOfMonth_ShouldBe31st_GivenJanuaryMarchMayJulyAugustOctoberDecember()
    {
        var january = new DateOnly(2000, 1, 1);
        var march = new DateOnly(2000, 3, 1);
        var may = new DateOnly(2000, 5, 1);
        var july = new DateOnly(2000, 7, 1);
        var august = new DateOnly(2000, 8, 1);
        var october = new DateOnly(2000, 10, 1);
        var december = new DateOnly(2000, 12, 1);

        Assert.That(january.LastDayOfMonth(), Is.EqualTo(new DateOnly(january.Year, january.Month, 31)));
        Assert.That(march.LastDayOfMonth(), Is.EqualTo(new DateOnly(march.Year, march.Month, 31)));
        Assert.That(may.LastDayOfMonth(), Is.EqualTo(new DateOnly(may.Year, may.Month, 31)));
        Assert.That(july.LastDayOfMonth(), Is.EqualTo(new DateOnly(july.Year, july.Month, 31)));
        Assert.That(august.LastDayOfMonth(), Is.EqualTo(new DateOnly(august.Year, august.Month, 31)));
        Assert.That(october.LastDayOfMonth(), Is.EqualTo(new DateOnly(october.Year, october.Month, 31)));
        Assert.That(december.LastDayOfMonth(), Is.EqualTo(new DateOnly(december.Year, december.Month, 31)));
    }

    [Test]
    public void NextSaturday_ShouldBe8th_Given1Jan2000()
    {
        var date = new DateOnly(2000, 1, 1);

        Assert.That(date.Next(DayOfWeek.Saturday), Is.EqualTo(new DateOnly(2000, 1, 8)));
    }

    [Test]
    public void ToUnixTimeMilliseconds_ShouldBe946684800000_Given1Jan2000()
    {
        var date = new DateOnly(2000, 1, 1);
        var time = new TimeOnly(0, 0, 0);

        Assert.That(date.ToUnixTimeMilliseconds(time), Is.EqualTo(946684800000));
    }

    [Test]
    public void ToUnixTimeSeconds_ShouldBe946684800_Given1Jan2000()
    {
        var date = new DateOnly(2000, 1, 1);
        var time = new TimeOnly(0, 0, 0);

        Assert.That(date.ToUnixTimeSeconds(time), Is.EqualTo(946684800));
    }
}
#endif
