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
        ///     Tests <see cref="StringExtensions.AsNullIfEmpty" />.
        /// </summary>
        [TestMethod]
        public void AsNullIfEmpty()
        {
            const string sampleString = "Hello World";
            const string whitespaceString = " ";
            const string emptyString = "";
            const string? nullString = null;

            string sampleResult = sampleString.AsNullIfEmpty();
            string whitespaceResult = whitespaceString.AsNullIfEmpty();
            string emptyResult = emptyString.AsNullIfEmpty();
            string? nullResult = nullString.AsNullIfEmpty();

            Assert.AreEqual(sampleString, sampleResult);
            Assert.AreEqual(whitespaceString, whitespaceResult);
            Assert.AreEqual(nullString, emptyResult);
            Assert.AreEqual(nullString, nullResult);
        }

        /// <summary>
        ///     Tests <see cref="StringExtensions.AsNullIfWhiteSpace" />.
        /// </summary>
        [TestMethod]
        public void AsNullIfWhiteSpace()
        {
            const string sampleString = "Hello World";
            const string whitespaceString = " ";
            const string emptyString = "";
            const string? nullString = null;

            string sampleResult = sampleString.AsNullIfWhiteSpace();
            string whitespaceResult = whitespaceString.AsNullIfWhiteSpace();
            string emptyResult = emptyString.AsNullIfWhiteSpace();
            string? nullResult = nullString.AsNullIfWhiteSpace();

            Assert.AreEqual(sampleString, sampleResult);
            Assert.AreEqual(nullString, whitespaceResult);
            Assert.AreEqual(nullString, emptyResult);
            Assert.AreEqual(nullString, nullResult);
        }

        /// <summary>
        ///     Tests <see cref="StringExtensions.Base64Decode" />.
        /// </summary>
        [TestMethod]
        public void Base64Decode()
        {
            const string input = "SGVsbG8gV29ybGQ=";
            const string expected = "Hello World";

            string result = input.Base64Decode();

            Assert.AreEqual(expected, result);
        }


        /// <summary>
        ///     Tests <see cref="StringExtensions.Base64Encode" />.
        /// </summary>
        [TestMethod]
        public void Base64Encode()
        {
            const string input = "Hello World";
            const string expected = "SGVsbG8gV29ybGQ=";

            string result = input.Base64Encode();

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        ///     Tests <see cref="StringExtensions.IsLower" />.
        /// </summary>
        [TestMethod]
        public void IsLower()
        {
            const string inputA = "Hello World";
            const string inputB = "hello world";
            const string? nullString = null;

            bool resultA = inputA.IsLower();
            bool resultB = inputB.IsLower();

            Assert.ThrowsException<ArgumentNullException>(() => nullString!.IsLower());
            Assert.IsFalse(resultA);
            Assert.IsTrue(resultB);
        }

        [TestMethod]
        public void IsPalindrome()
        {
            const string inputA = "Race car";
            const string inputB = "Racecar";
            const string inputC = "A man, a plan, a canal, panama";
            const string inputD = "Jackdaws love my big sphinx of quartz";
            const string inputE = "Y";
            const string inputF = "1";
            const string inputG = "";

            Assert.IsTrue(inputA.IsPalindrome(), inputA);
            Assert.IsTrue(inputB.IsPalindrome(), inputB);
            Assert.IsTrue(inputC.IsPalindrome(), inputC);
            Assert.IsFalse(inputD.IsPalindrome(), inputD);
            Assert.IsTrue(inputE.IsPalindrome(), inputE);
            Assert.IsTrue(inputF.IsPalindrome(), inputF);
            Assert.IsFalse(inputG.IsPalindrome(), inputG);
        }

        /// <summary>
        ///     Tests <see cref="StringExtensions.IsUpper" />.
        /// </summary>
        [TestMethod]
        public void IsUpper()
        {
            const string inputA = "Hello World";
            const string inputB = "HELLO WORLD";
            const string? nullString = null;

            bool resultA = inputA.IsUpper();
            bool resultB = inputB.IsUpper();

            Assert.ThrowsException<ArgumentNullException>(() => nullString!.IsUpper());
            Assert.IsFalse(resultA);
            Assert.IsTrue(resultB);
        }

        /// <summary>
        ///     Tests <see cref="StringExtensions.Shuffled(string, Random)" />.
        /// </summary>
        [TestMethod]
        public void Shuffled()
        {
            const string input = "Hello World";
            const string expected = " oHlldrWoel";
            var random = new Random(1);

            string result = input.Shuffled(random);

            Assert.ThrowsException<ArgumentNullException>(() => ((string?)null)!.Shuffled());
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        ///     Tests <see cref="StringExtensions.Randomize" />.
        /// </summary>
        [TestMethod]
        public void Randomize()
        {
            const string input = "Hello World";
            const string expected = "le rooldeoH";
            var random = new Random(1);

            string result = input.Randomize(input.Length, random);

            Assert.ThrowsException<ArgumentNullException>(() => ((string?)null)!.Randomize(1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => input.Randomize(-1));
            Assert.AreEqual(string.Empty, string.Empty.Randomize(0));
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        ///     Tests <see cref="StringExtensions.Repeat" />.
        /// </summary>
        [TestMethod]
        public void Repeat()
        {
            const string input = "Hello World";
            const string expected = "Hello WorldHello WorldHello WorldHello WorldHello WorldHello WorldHello WorldHello World";
            const int repeatCount = 8;

            string result = input.Repeat(repeatCount);

            Assert.ThrowsException<ArgumentNullException>(() => ((string?)null)!.Repeat(repeatCount));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => input.Repeat(-1));
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        ///     Tests <see cref="StringExtensions.Repeat" />.
        /// </summary>
        [TestMethod]
        public void Reverse()
        {
            const string input = "Hello World";
            const string expected = "dlroW olleH";

            string result = input.Reverse();

            Assert.ThrowsException<ArgumentNullException>(() => ((string?)null)!.Reverse());
            Assert.AreEqual(string.Empty.Reverse(), string.Empty);
            Assert.AreEqual(" ".Reverse(), " ");
            Assert.AreEqual(expected, result);
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
