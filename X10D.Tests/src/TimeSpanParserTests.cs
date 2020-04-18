namespace X10D.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TimeSpanParserTests
    {
        [TestMethod]
        public void TestParser()
        {
            Assert.AreEqual(TimeSpan.FromHours(3), "3h".ToTimeSpan());
            Assert.AreEqual(TimeSpan.FromMinutes(2.5), "2.5m".ToTimeSpan());
            Assert.AreEqual(TimeSpan.FromHours(1), "60m".ToTimeSpan());
            Assert.AreEqual(TimeSpan.FromDays(1), "1d".ToTimeSpan());
            Assert.AreEqual(TimeSpan.FromDays(8), "1w 1d".ToTimeSpan());
            Assert.AreEqual(TimeSpan.FromDays(8), "1w1d".ToTimeSpan());
        }
    }
}
