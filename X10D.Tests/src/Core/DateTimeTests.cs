namespace X10D.Tests.Core
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     Tests for <see cref="DateTimeExtensions" />.
    /// </summary>
    [TestClass]
    public class DateTimeTests
    {
        /// <summary>
        ///     Tests for <see cref="DateTimeExtensions.Age(DateTime)" />.
        /// </summary>
        [TestMethod]
        public void Age()
        {
            // no choice but to create dynamic based on today's date.
            // age varies with time
            var now = DateTime.Now;
            var dt = new DateTime(now.Year - 18, 1, 1);

            Assert.AreEqual(18, dt.Age());
        }

        /// <summary>
        ///     Tests for <see cref="DateTimeExtensions.First" />.
        /// </summary>
        [TestMethod]
        public void First()
        {
            var dt = new DateTime(2018, 6, 20);

            Assert.AreEqual(4, dt.First(DayOfWeek.Monday).Day);
        }

        /// <summary>
        ///     Tests for <see cref="DateTimeExtensions.FirstDayOfMonth" />.
        /// </summary>
        [TestMethod]
        public void FirstDayOfMonth()
        {
            var dt = new DateTime(2018, 6, 20);
            var first = dt.FirstDayOfMonth();

            Assert.AreEqual(dt.Year, first.Year);
            Assert.AreEqual(dt.Month, first.Month);
            Assert.AreEqual(1, first.Day);
        }

        /// <summary>
        ///     Tests for <see cref="DateTimeExtensions.Last" />.
        /// </summary>
        [TestMethod]
        public void Last()
        {
            {
                var dt = new DateTime(2019, 12, 1);
                var last = dt.Last(DayOfWeek.Wednesday);

                Assert.AreEqual(dt.Year, last.Year);
                Assert.AreEqual(dt.Month, last.Month);
                Assert.AreEqual(25, last.Day);
            }

            {
                var dt = new DateTime(2020, 4, 14);
                var last = dt.Last(DayOfWeek.Friday);

                Assert.AreEqual(dt.Year, last.Year);
                Assert.AreEqual(dt.Month, last.Month);
                Assert.AreEqual(24, last.Day);

                last = dt.Last(DayOfWeek.Thursday);
                Assert.AreEqual(dt.Year, last.Year);
                Assert.AreEqual(dt.Month, last.Month);
                Assert.AreEqual(30, last.Day);
            }
        }

        /// <summary>
        ///     Tests for <see cref="DateTimeExtensions.LastDayOfMonth" />.
        /// </summary>
        [TestMethod]
        public void LastDayOfMonth()
        {
            var dt = new DateTime(2016, 2, 4);
            var last = dt.LastDayOfMonth();

            Assert.AreEqual(dt.Year, last.Year);
            Assert.AreEqual(dt.Month, last.Month);
            Assert.AreEqual(29, last.Day); // 2016 is a leap year
        }

        /// <summary>
        ///     Tests for <see cref="DateTimeExtensions.ToUnixTimeStamp" />.
        /// </summary>
        [TestMethod]
        public void ToUnixTimestamp()
        {
            var dt = new DateTime(2015, 10, 21, 1, 0, 0, DateTimeKind.Utc);
            var unix = dt.ToUnixTimeStamp();

            Assert.AreEqual(1445389200L, unix);
        }
    }
}
