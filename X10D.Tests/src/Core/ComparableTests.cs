using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core
{
    /// <summary>
    ///     Tests for <see cref="ComparableExtensions" />.
    /// </summary>
    [TestClass]
    public class ComparableTests
    {
        /// <summary>
        ///     Tests <see cref="ComparableExtensions.Between{T1, T2, T3}" />
        /// </summary>
        [TestMethod]
        public void Between()
        {
            const int lower = 5;
            const int upper = 15;
            const int value = 10;

            Assert.IsTrue(value.Between(lower, upper), "value.Between(lower, upper)");
            Assert.IsFalse(lower.Between(value, upper), "lower.Between(value, upper)");
            Assert.IsFalse(upper.Between(lower, value), "upper.Between(lower, value)");
            
            Assert.IsTrue(upper.Between(lower, upper, Clusivity.UpperInclusive), "upper.Between(lower, upper, Clusivity.UpperInclusive)");
            Assert.IsTrue(upper.Between(lower, upper, Clusivity.Inclusive), "upper.Between(lower, upper, Clusivity.Inclusive)");
            Assert.IsFalse(upper.Between(lower, upper, Clusivity.LowerInclusive), "upper.Between(lower, upper, Clusivity.LowerInclusive)");
            
            Assert.IsTrue(lower.Between(lower, upper, Clusivity.LowerInclusive), "lower.Between(lower, upper, Clusivity.LowerInclusive)");
            Assert.IsTrue(lower.Between(lower, upper, Clusivity.Inclusive), "lower.Between(lower, upper, Clusivity.Inclusive)");
            Assert.IsFalse(lower.Between(lower, upper, Clusivity.UpperInclusive), "lower.Between(lower, upper, Clusivity.UpperInclusive)");
        }
    }
}
