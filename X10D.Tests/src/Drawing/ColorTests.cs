using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class ColorTests
{
    [TestMethod]
    public void Inverted_ShouldReturnInvertedColor()
    {
        Color black = Color.FromArgb(0, 0, 0);
        Color white = Color.FromArgb(255, 255, 255);
        Color red = Color.FromArgb(255, 0, 0);
        Color green = Color.FromArgb(0, 255, 0);
        Color blue = Color.FromArgb(0, 0, 255);
        Color cyan = Color.FromArgb(0, 255, 255);
        Color magenta = Color.FromArgb(255, 0, 255);
        Color yellow = Color.FromArgb(255, 255, 0);

        Assert.AreEqual(white, black.Inverted());
        Assert.AreEqual(black, white.Inverted());
        Assert.AreEqual(red, cyan.Inverted());
        Assert.AreEqual(cyan, red.Inverted());
        Assert.AreEqual(green, magenta.Inverted());
        Assert.AreEqual(magenta, green.Inverted());
        Assert.AreEqual(yellow, blue.Inverted());
        Assert.AreEqual(blue, yellow.Inverted());
    }

    [TestMethod]
    public void Inverted_ShouldIgnoreAlpha()
    {
        Color expected = Color.FromArgb(255, 0, 0, 0);
        Color actual = Color.FromArgb(255, 255, 255, 255).Inverted();

        Assert.AreEqual(expected, actual);
    }
}
