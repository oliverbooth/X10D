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
        ///     Tests <see cref="StringExtensions.WithEmptyAlternative" /> and
        ///     <see cref="StringExtensions.WithWhiteSpaceAlternative"/>.
        /// </summary>
        [TestMethod]
        public void WithAlternative()
        {
            const string inputA = "Hello World";
            const string inputB = " ";
            const string inputC = "";
            const string? inputD = null;
            const string alternative = "ALTERNATIVE";

            string resultA = inputA.WithEmptyAlternative(alternative);
            string resultB = inputB.WithEmptyAlternative(alternative);
            string resultBWithWhitespace = inputB.WithWhiteSpaceAlternative(alternative);
            string resultC = inputC.WithEmptyAlternative(alternative);
            string resultD = inputD.WithEmptyAlternative(alternative);

            Assert.ThrowsException<ArgumentNullException>(() => ((string?)null).WithEmptyAlternative(null!));
            
            Assert.AreEqual(resultA, inputA);
            Assert.AreEqual(resultB, inputB);
            Assert.AreEqual(resultBWithWhitespace, alternative);
            Assert.AreEqual(resultC, alternative);
            Assert.AreEqual(resultD, alternative);
        }
    }
}
