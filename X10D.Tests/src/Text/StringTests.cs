using System.Text.Json.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Text;

namespace X10D.Tests.Text;

[TestClass]
public class StringTests
{
    [TestMethod]
    public void AsNullIfEmptyShouldBeCorrect()
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

    [TestMethod]
    public void AsNullIfWhiteSpaceShouldBeCorrect()
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

    [TestMethod]
    public void FromJsonShouldDeserializeCorrectly()
    {
        const string json = "{\"values\": [1, 2, 3]}";
        var target = json.FromJson<SampleStructure>();
        Assert.IsInstanceOfType(target, typeof(SampleStructure));
        Assert.IsNotNull(target);
        Assert.IsNotNull(target.Values);
        Assert.AreEqual(3, target.Values.Length);
        Assert.AreEqual(1, target.Values[0]);
        Assert.AreEqual(2, target.Values[1]);
        Assert.AreEqual(3, target.Values[2]);
    }

    [TestMethod]
    public void IsLowerShouldBeCorrect()
    {
        Assert.IsTrue("hello world".IsLower());
        Assert.IsFalse("HELLO WORLD".IsLower());
        Assert.IsFalse("Hello World".IsLower());
    }

    [TestMethod]
    public void IsLowerNullShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((string?)null)!.IsLower());
    }

    [TestMethod]
    public void IsPalindromeShouldBeCorrect()
    {
        const string inputA = "Race car";
        const string inputB = "Racecar";
        const string inputC = "A man, a plan, a canal, panama";
        const string inputD = "Jackdaws love my big sphinx of quartz";
        const string inputE = "Y";
        const string inputF = "1";

        Assert.IsTrue(inputA.IsPalindrome(), inputA);
        Assert.IsTrue(inputB.IsPalindrome(), inputB);
        Assert.IsTrue(inputC.IsPalindrome(), inputC);
        Assert.IsFalse(inputD.IsPalindrome(), inputD);
        Assert.IsTrue(inputE.IsPalindrome(), inputE);
        Assert.IsTrue(inputF.IsPalindrome(), inputF);
    }

    [TestMethod]
    public void IsPalindromeEmptyShouldBeFalse()
    {
        Assert.IsFalse(string.Empty.IsPalindrome());
    }

    [TestMethod]
    public void IsPalindromeNullShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((string?)null)!.IsPalindrome());
    }

    [TestMethod]
    public void IsUpperShouldBeCorrect()
    {
        Assert.IsTrue("HELLO WORLD".IsUpper());
        Assert.IsFalse("hello world".IsUpper());
        Assert.IsFalse("Hello World".IsUpper());
    }

    [TestMethod]
    public void IsUpperNullShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((string?)null)!.IsUpper());
    }

    [TestMethod]
    public void RepeatShouldBeCorrect()
    {
        const string expected = "aaaaaaaaaa";
        string actual = "a".Repeat(10);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void RepeatOneCountShouldBeLength1String()
    {
        string repeated = "a".Repeat(1);
        Assert.AreEqual(1, repeated.Length);
        Assert.AreEqual("a", repeated);
    }

    [TestMethod]
    public void RepeatZeroCountShouldBeEmpty()
    {
        Assert.AreEqual(string.Empty, "a".Repeat(0));
    }

    [TestMethod]
    public void RepeatNegativeCountShouldThrow()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => "a".Repeat(-1));
    }

    [TestMethod]
    public void RepeatNullShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((string?)null)!.Repeat(0));
    }

    [TestMethod]
    public void ReverseShouldBeCorrect()
    {
        const string input = "Hello World";
        const string expected = "dlroW olleH";

        string result = input.Reverse();

        Assert.AreEqual(string.Empty.Reverse(), string.Empty);
        Assert.AreEqual(" ".Reverse(), " ");
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ReverseNullShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((string?)null)!.Reverse());
    }

    [TestMethod]
    public void ShuffleShouldReorder()
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string shuffled = alphabet;

        Assert.AreEqual(alphabet, shuffled);

        shuffled = alphabet.Shuffled();

        Assert.AreNotEqual(alphabet, shuffled);
    }

    [TestMethod]
    public void NullShuffleShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((string?)null)!.Shuffled());
    }

    [TestMethod]
    public void WithEmptyAlternativeShouldBeCorrect()
    {
        const string inputA = "Hello World";
        const string inputB = " ";
        const string inputC = "";
        const string? inputD = null;
        const string alternative = "ALTERNATIVE";

        string resultA = inputA.WithEmptyAlternative(alternative);
        string resultB = inputB.WithEmptyAlternative(alternative);
        string resultC = inputC.WithEmptyAlternative(alternative);
        string resultD = inputD.WithEmptyAlternative(alternative);

        Assert.AreEqual(resultA, inputA);
        Assert.AreEqual(resultB, inputB);
        Assert.AreEqual(resultC, alternative);
        Assert.AreEqual(resultD, alternative);
        Assert.AreEqual(alternative, ((string?)null).WithEmptyAlternative(alternative));
    }

    [TestMethod]
    public void WithWhiteSpaceAlternativeShouldBeCorrect()
    {
        const string input = " ";
        const string alternative = "ALTERNATIVE";

        string result = input.WithWhiteSpaceAlternative(alternative);

        Assert.AreEqual(result, alternative);
        Assert.AreEqual(alternative, ((string?)null).WithWhiteSpaceAlternative(alternative));
    }

    private struct SampleStructure
    {
        [JsonPropertyName("values")]
        public int[] Values { get; set; }
    }
}
