using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core
{
    /// <summary>
    ///     Tests for <see cref="StringExtensions" />.
    /// </summary>
    [TestClass]
    public class StringTests
    {
        /// <summary>
        ///     Tests for <see cref="StringExtensions.AsNullIfEmpty" />.
        /// </summary>
        [TestMethod]
        public void AsNullIfEmpty()
        {
            Assert.AreEqual(null, string.Empty.AsNullIfEmpty());
            Assert.AreEqual(null, ((string)null).AsNullIfEmpty());
            Assert.AreEqual("   ", "   ".AsNullIfEmpty());
            Assert.AreEqual("foo", "foo".AsNullIfEmpty());
        }

        /// <summary>
        ///     Tests for <see cref="StringExtensions.AsNullIfWhiteSpace" />.
        /// </summary>
        [TestMethod]
        public void AsNullIfWhiteSpace()
        {
            Assert.AreEqual(null, string.Empty.AsNullIfWhiteSpace());
            Assert.AreEqual(null, ((string)null).AsNullIfWhiteSpace());
            Assert.AreEqual(null, "   ".AsNullIfWhiteSpace());
            Assert.AreEqual("foo", "foo".AsNullIfWhiteSpace());
        }

        /// <summary>
        ///     Tests for <see cref="StringExtensions.Repeat" />.
        /// </summary>
        [TestMethod]
        public void Repeat()
        {
            Assert.AreEqual("foofoofoofoofoo", "foo".Repeat(5));
        }

        /// <summary>
        ///     Tests for <see cref="StringExtensions.Reverse" />.
        /// </summary>
        [TestMethod]
        public void Reverse()
        {
            Assert.AreEqual("dlroW olleH", StringExtensions.Reverse("Hello World"));
            Assert.AreEqual("Foobar", StringExtensions.Reverse("rabooF"));
        }

        /// <summary>
        ///     Tests for <see cref="StringExtensions.Split" />.
        /// </summary>
        [TestMethod]
        public void Split()
        {
            const string str = "Hello World";

            // ReSharper disable once SuggestVarOrType_Elsewhere
            var arr = str.Split(2).ToArray();
            CollectionAssert.AreEqual(new[] { "He", "ll", "o ", "Wo", "rl", "d" }, arr);
        }

        /// <summary>
        ///     Tests for <see cref="StringExtensions.WithAlternative" />.
        /// </summary>
        [TestMethod]
        public void WithAlternative()
        {
            Assert.AreEqual("Hello", "Hello".WithAlternative("Discarded"));
            Assert.AreEqual("Alternative", string.Empty.WithAlternative("Alternative"));
            Assert.AreEqual("   ", "   ".WithAlternative("Discarded"));
            Assert.AreEqual("Alternative", "   ".WithAlternative("Alternative", true));
            Assert.AreEqual("Alternative", ((string)null).WithAlternative("Alternative"));
        }
    }
}
