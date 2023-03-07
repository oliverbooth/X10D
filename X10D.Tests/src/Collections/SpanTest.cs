using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class SpanTest
{
    [TestMethod]
    public void Split_OnEmptySpan_ShouldYieldNothing()
    {
        ReadOnlySpan<char> span = ReadOnlySpan<char>.Empty;

        var index = 0;
        foreach (ReadOnlySpan<char> unused in span.Split(' '))
        {
            index++;
        }

        Assert.AreEqual(0, index);
    }

    [TestMethod]
    public void Split_OnOneWord_ShouldYieldLength1()
    {
        ReadOnlySpan<char> span = "Hello ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            if (index == 0)
            {
                Assert.AreEqual("Hello", subSpan.ToString());
            }

            index++;
        }

        Assert.AreEqual(1, index);
    }

    [TestMethod]
    public void Split_OnTwoWords_ShouldYieldLength2()
    {
        ReadOnlySpan<char> span = "Hello World ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            if (index == 0)
            {
                Assert.AreEqual("Hello", subSpan.ToString());
            }
            else if (index == 1)
            {
                Assert.AreEqual("World", subSpan.ToString());
            }

            index++;
        }

        Assert.AreEqual(2, index);
    }

    [TestMethod]
    public void Split_OnThreeWords_ShouldYieldLength3()
    {
        ReadOnlySpan<char> span = "Hello, the World ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            if (index == 0)
            {
                Assert.AreEqual("Hello,", subSpan.ToString());
            }
            else if (index == 1)
            {
                Assert.AreEqual("the", subSpan.ToString());
            }
            else if (index == 2)
            {
                Assert.AreEqual("World", subSpan.ToString());
            }

            index++;
        }

        Assert.AreEqual(3, index);
    }
}
