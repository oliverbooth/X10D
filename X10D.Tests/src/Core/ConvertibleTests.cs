namespace X10D.Tests.Core
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     Tests for <see cref="ConvertibleExtensions" />.
    /// </summary>
    [TestClass]
    public class ConvertibleTests
    {
        /// <summary>
        ///     Tests for <see cref="ConvertibleExtensions.To{T}" />.
        /// </summary>
        [TestMethod]
        public void To()
        {
            Assert.AreEqual(2, "2".To<int>());
            Assert.AreEqual("12.5", 12.50.To<string>());
            Assert.IsTrue("True".To<bool>());
        }

        /// <summary>
        ///     Tests for <see cref="ConvertibleExtensions.ToOrDefault{T}(System.IConvertible, System.IFormatProvider)" />.
        /// </summary>
        [TestMethod]
        public void ToOrDefault()
        {
            Assert.AreEqual(2, "2".ToOrDefault<int>());
            Assert.AreEqual("12.5", 12.50.ToOrDefault<string>());
            Assert.IsTrue("True".ToOrDefault<bool>());
            Assert.ThrowsException<FormatException>(() => "Foo".ToOrDefault<double>());
            Assert.IsTrue("1.5".ToOrDefault(out float f));
            Assert.AreEqual(1.5f, f);
        }

        /// <summary>
        ///     Tests for <see cref="ConvertibleExtensions.ToOrNull{T}(System.IConvertible, System.IFormatProvider)" />.
        /// </summary>
        [TestMethod]
        public void ToOrNull()
        {
            Assert.IsFalse("foo".ToOrNull(out ConvertibleTests t));
            Assert.IsNull(t);
        }

        /// <summary>
        ///     Tests for <see cref="ConvertibleExtensions.ToOrOther{T}(System.IConvertible, T, System.IFormatProvider)" />.
        /// </summary>
        [TestMethod]
        public void ToOrOther()
        {
            Assert.AreEqual(2.0, "Foo".ToOrOther(2.0));
            Assert.IsFalse("Foo".ToOrOther(out var d, 2.0));
            Assert.AreEqual(2.0, d);
        }
    }
}
