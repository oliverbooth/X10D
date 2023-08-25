using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
internal class TimeSpanTests
{
    private TimeSpan _timeSpan;

    [SetUp]
    public void Initialize()
    {
        _timeSpan = new TimeSpan(1, 2, 3, 4, 5);
    }

    [Test]
    public void Ago_ShouldBeInPast_GivenNow()
    {
        Assert.That(_timeSpan.Ago() < DateTime.Now);
    }

    [Test]
    public void FromNow_ShouldBeInFuture_GivenNow()
    {
        Assert.That(_timeSpan.FromNow() > DateTime.Now);
    }

    [Test]
    public void Ago_ShouldBeYesterday_GivenYesterday()
    {
        DateTime yesterday = DateTime.Now.AddDays(-1);
        Assert.That(1.Days().Ago().Date, Is.EqualTo(yesterday.Date));
    }

    [Test]
    public void FromNow_ShouldBeTomorrow_GivenTomorrow()
    {
        DateTime tomorrow = DateTime.Now.AddDays(1);
        Assert.That(1.Days().FromNow().Date, Is.EqualTo(tomorrow.Date));
    }
}
