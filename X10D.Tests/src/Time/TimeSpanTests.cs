using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Time;

namespace X10D.Tests.Time;

[TestClass]
public class TimeSpanTests
{
    private TimeSpan _timeSpan;

    [TestInitialize]
    public void Initialize()
    {
        _timeSpan = new TimeSpan(1, 2, 3, 4, 5);
    }

    [TestMethod]
    public void Ago_ShouldBeInPast_GivenNow()
    {
        Assert.IsTrue(_timeSpan.Ago() < DateTime.Now);
    }

    [TestMethod]
    public void FromNow_ShouldBeInFuture_GivenNow()
    {
        Assert.IsTrue(_timeSpan.FromNow() > DateTime.Now);
    }

    [TestMethod]
    public void Ago_ShouldBeYesterday_GivenYesterday()
    {
        DateTime yesterday = DateTime.Now.AddDays(-1);
        Assert.AreEqual(yesterday.Date, 1.Days().Ago().Date);
    }

    [TestMethod]
    public void FromNow_ShouldBeTomorrow_GivenTomorrow()
    {
        DateTime tomorrow = DateTime.Now.AddDays(1);
        Assert.AreEqual(tomorrow.Date, 1.Days().FromNow().Date);
    }
}
