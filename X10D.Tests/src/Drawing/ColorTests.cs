using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class ColorTests
{
    private static readonly Color Black = Color.FromArgb(0, 0, 0);
    private static readonly Color White = Color.FromArgb(255, 255, 255);
    private static readonly Color Red = Color.FromArgb(255, 0, 0);
    private static readonly Color Green = Color.FromArgb(0, 255, 0);
    private static readonly Color Blue = Color.FromArgb(0, 0, 255);
    private static readonly Color Cyan = Color.FromArgb(0, 255, 255);
    private static readonly Color Magenta = Color.FromArgb(255, 0, 255);
    private static readonly Color Yellow = Color.FromArgb(255, 255, 0);

    [TestMethod]
    public void Inverted_ShouldReturnInvertedColor()
    {
        Assert.AreEqual(White, Black.Inverted());
        Assert.AreEqual(Black, White.Inverted());
        Assert.AreEqual(Red, Cyan.Inverted());
        Assert.AreEqual(Cyan, Red.Inverted());
        Assert.AreEqual(Green, Magenta.Inverted());
        Assert.AreEqual(Magenta, Green.Inverted());
        Assert.AreEqual(Yellow, Blue.Inverted());
        Assert.AreEqual(Blue, Yellow.Inverted());
    }

    [TestMethod]
    public void Inverted_ShouldIgnoreAlpha()
    {
        Color expected = Color.FromArgb(255, 0, 0, 0);
        Color actual = Color.FromArgb(255, 255, 255, 255).Inverted();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void WithA0_ShouldReturnSameColor_GivenWhite()
    {
        Color transparent = Color.FromArgb(0, 255, 255, 255);
        Assert.AreEqual(transparent, White.WithA(0));
        Assert.AreEqual(transparent, transparent.WithA(0));
    }

    [TestMethod]
    public void WithB0_ShouldReturnYellow_GivenWhite()
    {
        Assert.AreEqual(Yellow, White.WithB(0));
        Assert.AreEqual(Yellow, Yellow.WithB(0));
    }

    [TestMethod]
    public void WithG0_ShouldReturnMagenta_GivenWhite()
    {
        Assert.AreEqual(Magenta, White.WithG(0));
        Assert.AreEqual(Magenta, Magenta.WithG(0));
    }

    [TestMethod]
    public void WithR0_ShouldReturnCyan_GivenWhite()
    {
        Assert.AreEqual(Cyan, White.WithR(0));
        Assert.AreEqual(Cyan, Cyan.WithR(0));
    }
}
