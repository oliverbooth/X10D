using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

/// <summary>
///     Tests for <see cref="StringExtensions" />.
/// </summary>
[TestClass]
public class StringTests
{
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
}
