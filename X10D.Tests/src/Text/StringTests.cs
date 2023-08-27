using System.Text;
#if NET5_0_OR_GREATER
using System.Text.Json.Serialization;
#endif
using NUnit.Framework;
using X10D.Text;

namespace X10D.Tests.Text;

[TestFixture]
internal class StringTests
{
    [Test]
    public void AsNullIfEmpty_ShouldBeCorrect()
    {
        const string sampleString = "Hello World";
        const string whitespaceString = " ";
        const string emptyString = "";
        const string? nullString = null;

        string sampleResult = sampleString.AsNullIfEmpty();
        string whitespaceResult = whitespaceString.AsNullIfEmpty();
        string emptyResult = emptyString.AsNullIfEmpty();
        string? nullResult = nullString.AsNullIfEmpty();

        Assert.Multiple(() =>
        {
            Assert.That(sampleResult, Is.EqualTo(sampleString));
            Assert.That(whitespaceResult, Is.EqualTo(whitespaceString));
            Assert.That(emptyResult, Is.EqualTo(nullString));
            Assert.That(nullResult, Is.EqualTo(nullString));
        });
    }

    [Test]
    public void AsNullIfWhiteSpace_ShouldBeCorrect()
    {
        const string sampleString = "Hello World";
        const string whitespaceString = " ";
        const string emptyString = "";
        const string? nullString = null;

        string sampleResult = sampleString.AsNullIfWhiteSpace();
        string whitespaceResult = whitespaceString.AsNullIfWhiteSpace();
        string emptyResult = emptyString.AsNullIfWhiteSpace();
        string? nullResult = nullString.AsNullIfWhiteSpace();

        Assert.Multiple(() =>
        {
            Assert.That(sampleResult, Is.EqualTo(sampleString));
            Assert.That(whitespaceResult, Is.EqualTo(nullString));
            Assert.That(emptyResult, Is.EqualTo(nullString));
            Assert.That(nullResult, Is.EqualTo(nullString));
        });
    }

    [Test]
    public void Base64Decode_ShouldReturnHelloWorld_GivenBase64String()
    {
        Assert.That("SGVsbG8gV29ybGQ=".Base64Decode(), Is.EqualTo("Hello World"));
    }

    [Test]
    public void Base64Decode_ShouldThrow_GivenNull()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.Base64Decode());
    }

    [Test]
    public void Base64Encode_ShouldReturnBase64String_GivenHelloWorld()
    {
        Assert.That("Hello World".Base64Encode(), Is.EqualTo("SGVsbG8gV29ybGQ="));
    }

    [Test]
    public void Base64Encode_ShouldThrow_GivenNull()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.Base64Encode());
    }

    [Test]
    public void ChangeEncoding_ShouldReturnAsciiString_GivenUtf8()
    {
        Assert.That("Hello World".ChangeEncoding(Encoding.UTF8, Encoding.ASCII), Is.EqualTo("Hello World"));
    }

    [Test]
    public void ChangeEncoding_ShouldThrow_GivenNullString()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.ChangeEncoding(Encoding.UTF8, Encoding.ASCII));
    }

    [Test]
    public void ChangeEncoding_ShouldThrow_GivenNullSourceEncoding()
    {
        Assert.Throws<ArgumentNullException>(() => _ = "Hello World".ChangeEncoding(null!, Encoding.ASCII));
    }

    [Test]
    public void ChangeEncoding_ShouldThrow_GivenNullDestinationEncoding()
    {
        Assert.Throws<ArgumentNullException>(() => _ = "Hello World".ChangeEncoding(Encoding.UTF8, null!));
    }

    [Test]
    public void ConcatIf_ShouldConcatenateString_GivenTrueCondition()
    {
        Assert.Multiple(() =>
        {
            Assert.That("Hello".ConcatIf(true, " World"), Is.EqualTo("Hello World"));
            Assert.That("Hello".ConcatIf(true, () => " World"), Is.EqualTo("Hello World"));
            Assert.That("Hello".ConcatIf(true, _ => " World"), Is.EqualTo("Hello World"));
            Assert.That("Hello".ConcatIf(() => true, " World"), Is.EqualTo("Hello World"));
            Assert.That("Hello".ConcatIf(() => true, () => " World"), Is.EqualTo("Hello World"));
            Assert.That("Hello".ConcatIf(() => true, _ => " World"), Is.EqualTo("Hello World"));
        });
    }

    [Test]
    public void ConcatIf_ShouldNotConcatenateString_GivenFalseCondition()
    {
        Assert.Multiple(() =>
        {
            Assert.That("Hello".ConcatIf(false, " World"), Is.EqualTo("Hello"));
            Assert.That("Hello".ConcatIf(false, () => " World"), Is.EqualTo("Hello"));
            Assert.That("Hello".ConcatIf(false, _ => " World"), Is.EqualTo("Hello"));
            Assert.That("Hello".ConcatIf(() => false, " World"), Is.EqualTo("Hello"));
            Assert.That("Hello".ConcatIf(() => false, () => " World"), Is.EqualTo("Hello"));
            Assert.That("Hello".ConcatIf(() => false, _ => " World"), Is.EqualTo("Hello"));
            Assert.That("Hello".ConcatIf(_ => false, " World"), Is.EqualTo("Hello"));
            Assert.That("Hello".ConcatIf(_ => false, () => " World"), Is.EqualTo("Hello"));
            Assert.That("Hello".ConcatIf(_ => false, _ => " World"), Is.EqualTo("Hello"));
        });
    }

    [Test]
    public void ConcatIf_ShouldThrowArgumentNullException_GivenNullConditionFactory()
    {
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf((Func<bool>)null!, "Hello World"));
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf((Func<bool>)null!, () => "Hello World"));
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf((Func<bool>)null!, _ => "Hello World"));
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf((Func<string?, bool>)null!, "Hello World"));
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf((Func<string?, bool>)null!, () => "Hello World"));
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf((Func<string?, bool>)null!, _ => "Hello World"));
    }

    [Test]
    public void ConcatIf_ShouldThrowArgumentNullException_GivenNullValueFactory()
    {
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf(true, (Func<string?>)null!));
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf(() => true, (Func<string?>)null!));
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf(_ => true, (Func<string?>)null!));
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf(true, (Func<string?, string?>)null!));
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf(() => true, (Func<string?, string?>)null!));
        Assert.Throws<ArgumentNullException>(() => _ = "".ConcatIf(_ => true, (Func<string?, string?>)null!));
    }

    [Test]
    public void CountSubstring_ShouldHonor_StringComparison()
    {
        Assert.Multiple(() =>
        {
            Assert.That("Hello World".CountSubstring('E'), Is.Zero);
#pragma warning disable CA1307
            Assert.That("Hello World".CountSubstring("E"), Is.Zero);
#pragma warning restore CA1307
            Assert.That("Hello World".CountSubstring("E", StringComparison.OrdinalIgnoreCase), Is.EqualTo(1));
        });
    }

    [Test]
    public void CountSubstring_ShouldReturn0_GivenNoInstanceChar()
    {
        Assert.Multiple(() =>
        {
            Assert.That("Hello World".CountSubstring('z'), Is.Zero);
#pragma warning disable CA1307
            Assert.That("Hello World".CountSubstring("z"), Is.Zero);
#pragma warning restore CA1307
            Assert.That("Hello World".CountSubstring("z", StringComparison.OrdinalIgnoreCase), Is.Zero);
        });
    }

    [Test]
    public void CountSubstring_ShouldReturn1_GivenSingleInstanceChar()
    {
        Assert.Multiple(() =>
        {
            Assert.That("Hello World".CountSubstring('e'), Is.EqualTo(1));
#pragma warning disable CA1307
            Assert.That("Hello World".CountSubstring("e"), Is.EqualTo(1));
#pragma warning restore CA1307
            Assert.That("Hello World".CountSubstring("e", StringComparison.OrdinalIgnoreCase), Is.EqualTo(1));
        });
    }

    [Test]
    public void CountSubstring_ShouldReturn0_GivenEmptyHaystack()
    {
        Assert.Multiple(() =>
        {
            Assert.That(string.Empty.CountSubstring('\0'), Is.Zero);
#pragma warning disable CA1307
            Assert.That(string.Empty.CountSubstring(string.Empty), Is.Zero);
#pragma warning restore CA1307
            Assert.That(string.Empty.CountSubstring(string.Empty, StringComparison.OrdinalIgnoreCase), Is.Zero);
        });
    }

    [Test]
    public void CountSubstring_ShouldThrow_GivenNullHaystack()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => value.CountSubstring('\0'));
#pragma warning disable CA1307
        Assert.Throws<ArgumentNullException>(() => value.CountSubstring(string.Empty));
#pragma warning restore CA1307
        Assert.Throws<ArgumentNullException>(() => value.CountSubstring(string.Empty, StringComparison.OrdinalIgnoreCase));
    }

    [Test]
    public void EnsureEndsWith_ShouldPrependChar_GivenEndsWithReturnFalse()
    {
        const string value = "Hello Worl";
        const char substring = 'd';

#pragma warning disable CA1307
        Assert.That(value.EnsureEndsWith(substring), Is.EqualTo("Hello World"));
#pragma warning restore CA1307
        Assert.That(value.EnsureEndsWith(substring, StringComparison.Ordinal), Is.EqualTo("Hello World"));
    }

    [Test]
    public void EnsureEndsWith_ShouldReturnChar_GivenEndsWithReturnTrue()
    {
        const string value = "A";
        const char substring = 'A';

#pragma warning disable CA1307
        Assert.That(value.EnsureEndsWith(substring), Is.EqualTo(value));
#pragma warning restore CA1307
        Assert.That(value.EnsureEndsWith(substring, StringComparison.Ordinal), Is.EqualTo(value));
    }

    [Test]
    public void EnsureStartsWith_ShouldPrependChar_GivenEndsWithReturnFalse()
    {
        const string value = "B";
        const char substring = 'A';

#pragma warning disable CA1307
        Assert.That(value.EnsureStartsWith(substring), Is.EqualTo("AB"));
#pragma warning restore CA1307
        Assert.That(value.EnsureStartsWith(substring, StringComparison.Ordinal), Is.EqualTo("AB"));
    }

    [Test]
    public void EnsureStartsWith_ShouldReturnChar_GivenEndsWithReturnTrue()
    {
        const string value = "A";
        const char substring = 'A';

#pragma warning disable CA1307
        Assert.That(value.EnsureStartsWith(substring), Is.EqualTo(value));
#pragma warning restore CA1307
        Assert.That(value.EnsureStartsWith(substring, StringComparison.Ordinal), Is.EqualTo(value));
    }

    [Test]
    public void EnsureEndsWith_ShouldAppendSubstring_GivenEndsWithReturnFalse()
    {
        const string value = "Hello ";
        const string substring = "World";

#pragma warning disable CA1307
        Assert.That(value.EnsureEndsWith(substring), Is.EqualTo("Hello World"));
#pragma warning restore CA1307
        Assert.That(value.EnsureEndsWith(substring, StringComparison.Ordinal), Is.EqualTo("Hello World"));
    }

    [Test]
    public void EnsureEndsWith_ShouldReturnString_GivenEndsWithReturnTrue()
    {
        const string substring = "World";

#pragma warning disable CA1307
        Assert.That(substring.EnsureEndsWith(substring), Is.EqualTo(substring));
#pragma warning restore CA1307
        Assert.That(substring.EnsureEndsWith(substring, StringComparison.Ordinal), Is.EqualTo(substring));
    }

    [Test]
    public void EnsureEndsWith_ShouldReturnString_GivenEmptySourceString()
    {
        const string substring = "World";

#pragma warning disable CA1307
        Assert.That(string.Empty.EnsureEndsWith(substring), Is.EqualTo(substring));
#pragma warning restore CA1307
        Assert.That(string.Empty.EnsureEndsWith(substring, StringComparison.Ordinal), Is.EqualTo(substring));
    }

    [Test]
    public void EnsureEndsWith_ShouldReturnString_GivenEmptySubString()
    {
        const string substring = "World";

#pragma warning disable CA1307
        Assert.That(substring.EnsureEndsWith(string.Empty), Is.EqualTo(substring));
#pragma warning restore CA1307
        Assert.That(substring.EnsureEndsWith(string.Empty, StringComparison.Ordinal), Is.EqualTo(substring));
    }

    [Test]
    public void EnsureStartsWith_ShouldAppendSubstring_GivenEndsWithReturnFalse()
    {
        const string value = "World";
        const string substring = "Hello ";

#pragma warning disable CA1307
        Assert.That(value.EnsureStartsWith(substring), Is.EqualTo("Hello World"));
#pragma warning restore CA1307
        Assert.That(value.EnsureStartsWith(substring, StringComparison.Ordinal), Is.EqualTo("Hello World"));
    }

    [Test]
    public void EnsureStartsWith_ShouldReturnString_GivenEndsWithReturnTrue()
    {
        const string substring = "World";

#pragma warning disable CA1307
        Assert.That(substring.EnsureStartsWith(substring), Is.EqualTo(substring));
#pragma warning restore CA1307
        Assert.That(substring.EnsureStartsWith(substring, StringComparison.Ordinal), Is.EqualTo(substring));
    }

    [Test]
    public void EnsureStartsWith_ShouldReturnString_GivenEmptySourceString()
    {
        const string substring = "World";

#pragma warning disable CA1307
        Assert.That(string.Empty.EnsureStartsWith(substring), Is.EqualTo(substring));
#pragma warning restore CA1307
        Assert.That(string.Empty.EnsureStartsWith(substring, StringComparison.Ordinal), Is.EqualTo(substring));
    }

    [Test]
    public void EnsureStartsWith_ShouldReturnString_GivenEmptySubString()
    {
        const string substring = "World";

#pragma warning disable CA1307
        Assert.That(substring.EnsureStartsWith(string.Empty), Is.EqualTo(substring));
#pragma warning restore CA1307
        Assert.That(substring.EnsureStartsWith(string.Empty, StringComparison.Ordinal), Is.EqualTo(substring));
    }

    [Test]
    public void EnumParse_ShouldReturnCorrectValue_GivenString()
    {
        Assert.Multiple(() =>
        {
            Assert.That("Monday".EnumParse<DayOfWeek>(false), Is.EqualTo(DayOfWeek.Monday));
            Assert.That("Tuesday".EnumParse<DayOfWeek>(false), Is.EqualTo(DayOfWeek.Tuesday));
            Assert.That("Wednesday".EnumParse<DayOfWeek>(false), Is.EqualTo(DayOfWeek.Wednesday));
            Assert.That("Thursday".EnumParse<DayOfWeek>(false), Is.EqualTo(DayOfWeek.Thursday));
            Assert.That("Friday".EnumParse<DayOfWeek>(false), Is.EqualTo(DayOfWeek.Friday));
            Assert.That("Saturday".EnumParse<DayOfWeek>(false), Is.EqualTo(DayOfWeek.Saturday));
            Assert.That("Sunday".EnumParse<DayOfWeek>(false), Is.EqualTo(DayOfWeek.Sunday));
        });
    }

    [Test]
    public void EnumParse_ShouldTrim()
    {
        Assert.Multiple(() =>
        {
            Assert.That("   Monday   ".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Monday));
            Assert.That("   Tuesday   ".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Tuesday));
            Assert.That("   Wednesday   ".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Wednesday));
            Assert.That("   Thursday   ".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Thursday));
            Assert.That("   Friday   ".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Friday));
            Assert.That("   Saturday   ".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Saturday));
            Assert.That("   Sunday   ".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Sunday));
        });
    }

    [Test]
    public void EnumParse_ShouldReturnCorrectValue_GivenString_Generic()
    {
        Assert.Multiple(() =>
        {
            Assert.That("Monday".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Monday));
            Assert.That("Tuesday".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Tuesday));
            Assert.That("Wednesday".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Wednesday));
            Assert.That("Thursday".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Thursday));
            Assert.That("Friday".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Friday));
            Assert.That("Saturday".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Saturday));
            Assert.That("Sunday".EnumParse<DayOfWeek>(), Is.EqualTo(DayOfWeek.Sunday));
        });
    }

    [Test]
    public void EnumParse_ShouldThrow_GivenNullString()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.EnumParse<DayOfWeek>());
    }

    [Test]
    public void EnumParse_ShouldThrow_GivenEmptyOrWhiteSpaceString()
    {
        Assert.Throws<ArgumentException>(() => _ = string.Empty.EnumParse<DayOfWeek>());
        Assert.Throws<ArgumentException>(() => _ = " ".EnumParse<DayOfWeek>());
    }

#if NET5_0_OR_GREATER
    [Test]
    public void FromJson_ShouldDeserializeCorrectly_GivenJsonString()
    {
        const string json = "{\"values\": [1, 2, 3]}";
        var target = json.FromJson<SampleStructure>();
        Assert.Multiple(() =>
        {
            Assert.IsInstanceOf<SampleStructure>(target);
            Assert.That(target.Values, Is.Not.Null);
            Assert.That(target.Values.Length, Is.EqualTo(3));
            Assert.That(target.Values[0], Is.EqualTo(1));
            Assert.That(target.Values[1], Is.EqualTo(2));
            Assert.That(target.Values[2], Is.EqualTo(3));
        });
    }
#endif

    [Test]
    public void GetBytes_ShouldReturnUtf8Bytes_GivenHelloWorld()
    {
        var expected = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64 };
        byte[] actual = "Hello World".GetBytes();

        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetBytes_ShouldReturnAsciiBytes_GivenHelloWorld()
    {
        var expected = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64 };
        byte[] actual = "Hello World".GetBytes(Encoding.ASCII);

        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetBytes_ShouldThrow_GivenNullString()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.GetBytes());
        Assert.Throws<ArgumentNullException>(() => _ = value.GetBytes(Encoding.ASCII));
    }

    [Test]
    public void GetBytes_ShouldThrow_GivenNullEncoding()
    {
        Assert.Throws<ArgumentNullException>(() => _ = "Hello World".GetBytes(null!));
    }

    [Test]
    public void IsEmoji_ShouldReturnTrue_GivenBasicEmoji()
    {
        Assert.Multiple(() =>
        {
            Assert.That("😀".IsEmoji());
            Assert.That("🤓".IsEmoji());
            Assert.That("🟦".IsEmoji());
            Assert.That("🟧".IsEmoji());
            Assert.That("🟨".IsEmoji());
            Assert.That("🟩".IsEmoji());
            Assert.That("🟪".IsEmoji());
            Assert.That("🟫".IsEmoji());
            Assert.That("📱".IsEmoji());
            Assert.That("🎨".IsEmoji());
        });
    }

    [Test]
    public void IsEmoji_ShouldReturnTrue_GivenMultiByteEmoji()
    {
        string[] regionalIndicatorCodes = Enumerable.Range(0, 26)
            .Select(i => Encoding.Unicode.GetString(new byte[] { 0x3C, 0xD8, (byte)(0xE6 + i), 0xDD }))
            .ToArray();

        for (var i = 0; i < 26; i++)
        {
            for (var j = 0; j < 26; j++)
            {
                string flag = (regionalIndicatorCodes[i] + regionalIndicatorCodes[j]);
                Assert.That(flag.IsEmoji());
            }
        }
    }

    [Test]
    public void IsEmoji_ShouldReturnFalse_GivenNonEmoji()
    {
        Assert.Multiple(() =>
        {
            Assert.That("Hello World".IsEmoji(), Is.False);
            Assert.That("Hello".IsEmoji(), Is.False);
            Assert.That("World".IsEmoji(), Is.False);
        });
    }

    [Test]
    public void IsEmoji_ShouldThrowArgumentNullException_GivenNullInput()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.IsEmoji());
    }

    [Test]
    public void IsEmpty_ShouldReturnTrue_GivenEmptyString()
    {
        Assert.Multiple(() =>
        {
            Assert.That("".IsEmpty());
            Assert.That(string.Empty.IsEmpty());
        });
    }

    [Test]
    public void IsEmpty_ShouldReturnFalse_GivenWhiteSpaceString()
    {
        Assert.That(" ".IsEmpty(), Is.False);
    }

    [Test]
    public void IsEmpty_ShouldReturnFalse_GivenNonEmptyString()
    {
        Assert.That("Hello World".IsEmpty(), Is.False);
    }

    [Test]
    public void IsEmpty_ShouldThrowArgumentNullException_GivenNullString()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.IsEmpty());
    }

    [Test]
    public void IsLower_ShouldReturnTrue_GivenLowercaseString()
    {
        Assert.That("hello world".IsLower());
    }

    [Test]
    public void IsLower_ShouldReturnFalse_GivenMixedCaseString()
    {
        Assert.That("Hello World".IsLower(), Is.False);
    }

    [Test]
    public void IsLower_ShouldReturnFalse_GivenUppercaseString()
    {
        Assert.That("HELLO WORLD".IsLower(), Is.False);
    }

    [Test]
    public void IsLower_ShouldThrow_GivenNull()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.IsLower());
    }

    [Test]
    public void IsNullOrEmpty_ShouldReturnTrue_GivenEmptyString()
    {
        Assert.Multiple(() =>
        {
            Assert.That("".IsNullOrEmpty());
            Assert.That(string.Empty.IsNullOrEmpty());
        });
    }

    [Test]
    public void IsNullOrEmpty_ShouldReturnFalse_GivenWhiteSpaceString()
    {
        Assert.That("   ".IsNullOrEmpty(), Is.False);
    }

    [Test]
    public void IsNullOrEmpty_ShouldReturnFalse_GivenNonEmptyString()
    {
        Assert.That("Hello World".IsNullOrEmpty(), Is.False);
    }

    [Test]
    public void IsNullOrEmpty_ShouldReturnTrue_GivenNullString()
    {
        string value = null!;
        Assert.That(value.IsNullOrEmpty());
    }

    [Test]
    public void IsNullOrWhiteSpace_ShouldReturnTrue_GivenEmptyString()
    {
        Assert.Multiple(() =>
        {
            Assert.That("".IsNullOrWhiteSpace());
            Assert.That(string.Empty.IsNullOrWhiteSpace());
        });
    }

    [Test]
    public void IsNullOrWhiteSpace_ShouldReturnTrue_GivenWhiteSpaceString()
    {
        Assert.That("   ".IsNullOrWhiteSpace());
    }

    [Test]
    public void IsNullOrWhiteSpace_ShouldReturnFalse_GivenNonEmptyString()
    {
        Assert.That("Hello World".IsNullOrWhiteSpace(), Is.False);
    }

    [Test]
    public void IsNullOrWhiteSpace_ShouldReturnTrue_GivenNullString()
    {
        string value = null!;
        Assert.That(value.IsNullOrWhiteSpace());
    }

    [Test]
    public void IsPalindrome_ShouldBeCorrect_GivenString()
    {
        const string inputA = "Race car";
        const string inputB = "Racecar";
        const string inputC = "A man, a plan, a canal, panama";
        const string inputD = "Jackdaws love my big sphinx of quartz";
        const string inputE = "Y";
        const string inputF = "1";

        Assert.Multiple(() =>
        {
            Assert.That(inputA.IsPalindrome());
            Assert.That(inputB.IsPalindrome());
            Assert.That(inputC.IsPalindrome());
            Assert.That(inputD.IsPalindrome(), Is.False);
            Assert.That(inputE.IsPalindrome());
            Assert.That(inputF.IsPalindrome());
        });
    }

    [Test]
    public void IsPalindrome_ShouldReturnFalse_GivenEmptyString()
    {
        Assert.That(string.Empty.IsPalindrome(), Is.False);
    }

    [Test]
    public void IsPalindrome_ShouldThrow_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => _ = ((string?)null)!.IsPalindrome());
    }

    [Test]
    public void IsUpper_ShouldReturnFalse_GivenLowercaseString()
    {
        Assert.That("hello world".IsUpper(), Is.False);
    }

    [Test]
    public void IsUpper_ShouldReturnFalse_GivenMixedCaseString()
    {
        Assert.That("Hello World".IsUpper(), Is.False);
    }

    [Test]
    public void IsUpper_ShouldReturnTrue_GivenUppercaseString()
    {
        Assert.That("HELLO WORLD".IsUpper());
    }

    [Test]
    public void IsUpper_ShouldThrow_GivenNull()
    {
        string? value = null;
        Assert.Throws<ArgumentNullException>(() => _ = value!.IsUpper());
    }

    [Test]
    public void IsWhiteSpace_ShouldReturnTrue_GivenEmptyString()
    {
        Assert.Multiple(() =>
        {
            Assert.That("".IsWhiteSpace());
            Assert.That(string.Empty.IsWhiteSpace());
        });
    }

    [Test]
    public void IsWhiteSpace_ShouldReturnTrue_GivenWhiteSpaceString()
    {
        Assert.That("   ".IsWhiteSpace());
    }

    [Test]
    public void IsWhiteSpace_ShouldReturnFalse_GivenNonEmptyString()
    {
        Assert.That("Hello World".IsWhiteSpace(), Is.False);
    }

    [Test]
    public void IsWhiteSpace_ShouldThrowArgumentNullException_GivenNullString()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.IsWhiteSpace());
    }

    [Test]
    public void Randomize_ShouldReorder_GivenString()
    {
        const string input = "Hello World";
        var random = new Random(1);
        Assert.That(input.Randomize(input.Length, random), Is.EqualTo("le rooldeoH"));
    }

    [Test]
    public void Randomize_ShouldReturnEmptyString_GivenLength1()
    {
        Assert.That("Hello World".Randomize(0), Is.EqualTo(string.Empty));
    }

    [Test]
    public void Randomize_ShouldThrow_GivenNull()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.Randomize(1));
    }

    [Test]
    public void Randomize_ShouldThrow_GivenNegativeLength()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => string.Empty.Randomize(-1));
    }

    [Test]
    public void Repeat_ShouldReturnRepeatedString_GivenString()
    {
        const string expected = "aaaaaaaaaa";
        string actual = "a".Repeat(10);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Repeat_ShouldReturnEmptyString_GivenCount0()
    {
        Assert.That("a".Repeat(0), Is.EqualTo(string.Empty));
    }

    [Test]
    public void Repeat_ShouldReturnItself_GivenCount1()
    {
        string repeated = "a".Repeat(1);
        Assert.That(repeated, Has.Length.EqualTo(1));
        Assert.That(repeated, Is.EqualTo("a"));
    }

    [Test]
    public void Repeat_ShouldThrowArgumentOutOfRangeException_GivenNegativeCount()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = "a".Repeat(-1));
    }

    [Test]
    public void Repeat_ShouldThrowArgumentNullException_GivenNull()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.Repeat(0));
    }

    [Test]
    public void Reverse_ShouldBeCorrect()
    {
        const string input = "Hello World";
        const string expected = "dlroW olleH";
        string result = input.Reverse();

        Assert.Multiple(() =>
        {
            Assert.That(string.Empty.Reverse(), Is.EqualTo(string.Empty));
            Assert.That(" ".Reverse(), Is.EqualTo(" "));
            Assert.That(result, Is.EqualTo(expected));
        });
    }

    [Test]
    public void Reverse_ShouldThrowArgumentNullException_GivenNull()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.Reverse());
    }

    [Test]
    public void Shuffled_ShouldReorder_GivenString()
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string shuffled = alphabet;
        Assert.That(shuffled, Is.EqualTo(alphabet));

        shuffled = alphabet.Shuffled();
        Assert.That(shuffled, Is.Not.EqualTo(alphabet));
    }

    [Test]
    public void Shuffled_ShouldThrowArgumentNullException_GivenNull()
    {
        string value = null!;
        Assert.Throws<ArgumentNullException>(() => _ = value.Shuffled());
    }

    [Test]
    public void Split_ShouldYieldCorrectStrings_GivenString()
    {
        string[] chunks = "Hello World".Split(2).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(chunks, Has.Length.EqualTo(6));
            Assert.That(chunks[0], Is.EqualTo("He"));
            Assert.That(chunks[1], Is.EqualTo("ll"));
            Assert.That(chunks[2], Is.EqualTo("o "));
            Assert.That(chunks[3], Is.EqualTo("Wo"));
            Assert.That(chunks[4], Is.EqualTo("rl"));
            Assert.That(chunks[5], Is.EqualTo("d"));
        });
    }

    [Test]
    public void Split_ShouldYieldEmptyString_GivenChunkSize0()
    {
        string[] chunks = "Hello World".Split(0).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(chunks, Has.Length.EqualTo(1));
            Assert.That(chunks[0], Is.EqualTo(string.Empty));
        });
    }

    [Test]
    public void Split_ShouldThrowArgumentNullException_GivenNullString()
    {
        string value = null!;

        // forcing enumeration with ToArray is required for the exception to be thrown
        Assert.Throws<ArgumentNullException>(() => _ = value.Split(0).ToArray());
    }

    [Test]
    public void StartsWithAny_ShouldReturnFalse_GivenNullInput()
    {
        string value = null!;
        Assert.Multiple(() =>
        {
            Assert.That(value.StartsWithAny(), Is.False);
            Assert.That(value.StartsWithAny(StringComparison.Ordinal), Is.False);
        });
    }

    [Test]
    public void StartsWithAny_ShouldReturnFalse_GivenEmptyInput()
    {
        Assert.Multiple(() =>
        {
            Assert.That(string.Empty.StartsWithAny(), Is.False);
            Assert.That(string.Empty.StartsWithAny(StringComparison.Ordinal), Is.False);
        });
    }

    [Test]
    public void StartsWithAny_ShouldReturnFalse_GivenValuesThatDontMatch()
    {
        const string value = "Hello World";
        Assert.Multiple(() =>
        {
            Assert.That(value.StartsWithAny("World", "Goodbye"), Is.False);
            Assert.That(value.StartsWithAny(StringComparison.Ordinal, "World", "Goodbye"), Is.False);
        });
    }

    [Test]
    public void StartsWithAny_ShouldReturnTrue_GivenValuesThatMatch()
    {
        const string value = "Hello World";
        Assert.Multiple(() =>
        {
            Assert.That(value.StartsWithAny("World", "Hello"));
            Assert.That(value.StartsWithAny(StringComparison.Ordinal, "World", "Hello"));
        });
    }

    [Test]
    public void StartsWithAny_ShouldReturnTrue_GivenValuesThatMatch_WithIgnoreCaseComparison()
    {
        const string value = "Hello World";
        Assert.That(value.StartsWithAny(StringComparison.OrdinalIgnoreCase, "WORLD", "HELLO"));
    }

    [Test]
    public void StartsWithAny_ShouldReturnFalse_GivenEmptyValues()
    {
        const string input = "Hello World";
        Assert.That(input.StartsWithAny(), Is.False);
    }

    [Test]
    public void StartsWithAny_ShouldThrowArgumentNullException_GivenNullValues()
    {
        Assert.Throws<ArgumentNullException>(() => string.Empty.StartsWithAny(null!));
        Assert.Throws<ArgumentNullException>(() => string.Empty.StartsWithAny(StringComparison.Ordinal, null!));
    }

    [Test]
    public void StartsWithAny_ShouldThrowArgumentNullException_GivenANullValue()
    {
        var values = new[] { "Hello", null!, "World" };
        Assert.Throws<ArgumentNullException>(() => "Foobar".StartsWithAny(values));
        Assert.Throws<ArgumentNullException>(() => "Foobar".StartsWithAny(StringComparison.Ordinal, values));
    }

    [Test]
    public void WithEmptyAlternative_ShouldBeCorrect()
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

        Assert.Multiple(() =>
        {
            Assert.That(resultA, Is.EqualTo(inputA));
            Assert.That(resultB, Is.EqualTo(inputB));
            Assert.That(resultC, Is.EqualTo(alternative));
            Assert.That(resultD, Is.EqualTo(alternative));
            Assert.That(((string?)null).WithEmptyAlternative(alternative), Is.EqualTo(alternative));
        });
    }

    [Test]
    public void WithWhiteSpaceAlternative_ShouldBeCorrect()
    {
        const string input = " ";
        const string alternative = "ALTERNATIVE";

        string result = input.WithWhiteSpaceAlternative(alternative);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(alternative));
            Assert.That(((string?)null).WithWhiteSpaceAlternative(alternative), Is.EqualTo(alternative));
        });
    }

#if NET5_0_OR_GREATER
    private struct SampleStructure
    {
        [JsonPropertyName("values")]
        public int[] Values { get; set; }
    }
#endif
}
