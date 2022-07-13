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
    public void GetClosestConsoleColor_ShouldReturnClosestColor_GivenValidColor()
    {
        Assert.AreEqual(ConsoleColor.White, Color.Transparent.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.AliceBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.AntiqueWhite.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Cyan, Color.Aqua.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.Aquamarine.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Azure.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Beige.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Bisque.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Black, Color.Black.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.BlanchedAlmond.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Blue, Color.Blue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkMagenta, Color.BlueViolet.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkRed, Color.Brown.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.BurlyWood.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.CadetBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Yellow, Color.Chartreuse.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkYellow, Color.Chocolate.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkYellow, Color.Coral.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.CornflowerBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Cornsilk.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Red, Color.Crimson.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Cyan, Color.Cyan.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkBlue, Color.DarkBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkCyan, Color.DarkCyan.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkYellow, Color.DarkGoldenrod.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.DarkGray.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGreen, Color.DarkGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.DarkKhaki.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkMagenta, Color.DarkMagenta.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.DarkOliveGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkYellow, Color.DarkOrange.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkMagenta, Color.DarkOrchid.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkRed, Color.DarkRed.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.DarkSalmon.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.DarkSeaGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.DarkSlateBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGreen, Color.DarkSlateGray.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Cyan, Color.DarkTurquoise.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkMagenta, Color.DarkViolet.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Magenta, Color.DeepPink.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Cyan, Color.DeepSkyBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.DimGray.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Cyan, Color.DodgerBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkRed, Color.Firebrick.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.FloralWhite.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Green, Color.ForestGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Magenta, Color.Fuchsia.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Gainsboro.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.GhostWhite.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Yellow, Color.Gold.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkYellow, Color.Goldenrod.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.Gray.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Green, Color.Green.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Yellow, Color.GreenYellow.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Honeydew.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.HotPink.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.IndianRed.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkMagenta, Color.Indigo.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Ivory.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.Khaki.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Lavender.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.LavenderBlush.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Yellow, Color.LawnGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.LemonChiffon.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.LightBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.LightCoral.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.LightCyan.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.LightGoldenrodYellow.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.LightGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.LightGray.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.LightPink.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.LightSalmon.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkCyan, Color.LightSeaGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.LightSkyBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.LightSlateGray.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.LightSteelBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.LightYellow.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Green, Color.Lime.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Green, Color.LimeGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Linen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Magenta, Color.Magenta.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkRed, Color.Maroon.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.MediumAquamarine.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Blue, Color.MediumBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.MediumOrchid.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.MediumPurple.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkCyan, Color.MediumSeaGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.MediumSlateBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Cyan, Color.MediumSpringGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Cyan, Color.MediumTurquoise.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkMagenta, Color.MediumVioletRed.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkBlue, Color.MidnightBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.MintCream.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.MistyRose.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Moccasin.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.NavajoWhite.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkBlue, Color.Navy.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.OldLace.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.Olive.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.OliveDrab.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkYellow, Color.Orange.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Red, Color.OrangeRed.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.Orchid.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.PaleGoldenrod.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.PaleGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.PaleTurquoise.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.PaleVioletRed.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.PapayaWhip.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.PeachPuff.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkYellow, Color.Peru.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Pink.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.Plum.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.PowderBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkMagenta, Color.Purple.GetClosestConsoleColor());
#if NET6_0_OR_GREATER
        Assert.AreEqual(ConsoleColor.DarkMagenta, Color.RebeccaPurple.GetClosestConsoleColor());
#endif
        Assert.AreEqual(ConsoleColor.Red, Color.Red.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.RosyBrown.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkCyan, Color.RoyalBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkRed, Color.SaddleBrown.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.Salmon.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkYellow, Color.SandyBrown.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkCyan, Color.SeaGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.SeaShell.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkRed, Color.Sienna.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.Silver.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.SkyBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.SlateBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.SlateGray.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Snow.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkCyan, Color.SpringGreen.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.SteelBlue.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.Tan.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkCyan, Color.Teal.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.Thistle.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkYellow, Color.Tomato.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Cyan, Color.Turquoise.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.DarkGray, Color.Violet.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.Wheat.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.White.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.White, Color.WhiteSmoke.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Yellow, Color.Yellow.GetClosestConsoleColor());
        Assert.AreEqual(ConsoleColor.Gray, Color.YellowGreen.GetClosestConsoleColor());
    }

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
