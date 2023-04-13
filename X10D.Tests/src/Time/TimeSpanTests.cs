using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
public class TimeSpanTests
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
}
