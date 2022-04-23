﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Text;

namespace X10D.Tests.Text;

[TestClass]
public class CharTests
{
    [TestMethod]
    public void RepeatShouldBeCorrect()
    {
        const string expected = "aaaaaaaaaa";
        string actual = 'a'.Repeat(10);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void RepeatOneCountShouldBeLength1String()
    {
        string repeated = 'a'.Repeat(1);
        Assert.AreEqual(1, repeated.Length);
        Assert.AreEqual("a", repeated);
    }

    [TestMethod]
    public void RepeatZeroCountShouldBeEmpty()
    {
        Assert.AreEqual(string.Empty, 'a'.Repeat(0));
    }

    [TestMethod]
    public void RepeatNegativeCountShouldThrow()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => 'a'.Repeat(-1));
    }
}
