using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Text;

namespace X10D.Tests.Text;

[TestClass]
public class EnumerableTests
{
    [TestMethod]
    public void Grep_ShouldFilterCorrectly_GivenPattern()
    {
        int year = DateTime.Now.Year;
        var source = new[] {"Hello", "World", "String 123", $"The year is {year}"};
        var expectedResult = new[] {"String 123", $"The year is {year}"};

        const string pattern = /*lang=regex*/@"[0-9]+";
        string[] actualResult = source.Grep(pattern).ToArray();

        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void Grep_ShouldYieldNoResults_GivenEmptySource()
    {
        string[] source = Array.Empty<string>();
        string[] expectedResult = Array.Empty<string>();

        const string pattern = /*lang=regex*/@"[0-9]+";
        string[] actualResult = source.Grep(pattern).ToArray();

        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void Grep_ShouldMatchUpperCase_GivenIgnoreCaseTrue()
    {
        int year = DateTime.Now.Year;
        var source = new[] {"Hello", "WORLD", "String 123", $"The year is {year}"};
        var expectedResult = new[] {"WORLD"};

        const string pattern = /*lang=regex*/@"world";
        string[] actualResult = source.Grep(pattern, true).ToArray();

        CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void Grep_ShouldNotMatchUpperCase_GivenIgnoreCaseFalse()
    {
        int year = DateTime.Now.Year;
        var source = new[] {"Hello", "WORLD", "String 123", $"The year is {year}"};

        const string pattern = /*lang=regex*/@"world";
        string[] actualResult = source.Grep(pattern, false).ToArray();

        Assert.AreEqual(0, actualResult.Length);
    }

    [TestMethod]
    public void Grep_ShouldThrowArgumentNullException_GivenNullPattern()
    {
        IEnumerable<string> source = Enumerable.Empty<string>();
        Assert.ThrowsException<ArgumentNullException>(() => source.Grep(null!));
    }

    [TestMethod]
    public void Grep_ShouldThrowArgumentNullException_GivenNullSource()
    {
        IEnumerable<string> source = null!;
        Assert.ThrowsException<ArgumentNullException>(() => source.Grep("foo"));
    }

    [TestMethod]
    public void Grep_ShouldYieldNoElements_GivenNoMatchingStrings()
    {
        var source = new[] {"Hello", "World", "String"};

        const string pattern = /*lang=regex*/@"[0-9]+";
        string[] actualResult = source.Grep(pattern).ToArray();

        Assert.AreEqual(0, actualResult.Length);
    }
}
