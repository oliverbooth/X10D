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
    public void Ago_Should_Be_In_The_Past()
    {
        Assert.IsTrue(_timeSpan.Ago() < DateTime.Now);
    }

    [TestMethod]
    public void FromNow_Should_Be_In_The_Past()
    {
        Assert.IsTrue(_timeSpan.FromNow() > DateTime.Now);
    }

    [TestMethod]
    public void One_Day_Ago_Should_Be_Yesterday()
    {
        DateTime yesterday = DateTime.Now.AddDays(-1);
        Assert.AreEqual(yesterday.Date, 1.Days().Ago().Date);
    }

    [TestMethod]
    public void One_Day_FromNow_Should_Be_Tomorrow()
    {
        DateTime tomorrow = DateTime.Now.AddDays(1);
        Assert.AreEqual(tomorrow.Date, 1.Days().FromNow().Date);
    }
}
