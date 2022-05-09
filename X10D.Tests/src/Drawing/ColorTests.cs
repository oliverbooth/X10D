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
}
