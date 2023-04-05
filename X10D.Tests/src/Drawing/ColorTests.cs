using System.Drawing;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
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

    [Test]
    public void Deconstruct_ShouldDeconstructColor_GivenColor()
    {
        (byte r, byte g, byte b) = Black;
        Assert.Multiple(() =>
        {
            Assert.That(r, Is.Zero);
            Assert.That(g, Is.Zero);
            Assert.That(b, Is.Zero);
        });

        (byte a, r, g, b) = Black;
        Assert.Multiple(() =>
        {
            Assert.That(a, Is.EqualTo(255));
            Assert.That(r, Is.Zero);
            Assert.That(g, Is.Zero);
            Assert.That(b, Is.Zero);
        });

        (r, g, b) = Red;
        Assert.Multiple(() =>
        {
            Assert.That(r, Is.EqualTo(255));
            Assert.That(g, Is.Zero);
            Assert.That(b, Is.Zero);
        });

        (a, r, g, b) = Red;
        Assert.Multiple(() =>
        {
            Assert.That(a, Is.EqualTo(255));
            Assert.That(r, Is.EqualTo(255));
            Assert.That(g, Is.Zero);
            Assert.That(b, Is.Zero);
        });

        (r, g, b) = Green;
        Assert.Multiple(() =>
        {
            Assert.That(r, Is.Zero);
            Assert.That(g, Is.EqualTo(255));
            Assert.That(b, Is.Zero);
        });

        (a, r, g, b) = Green;
        Assert.Multiple(() =>
        {
            Assert.That(a, Is.EqualTo(255));
            Assert.That(r, Is.Zero);
            Assert.That(g, Is.EqualTo(255));
            Assert.That(b, Is.Zero);
        });

        (r, g, b) = Blue;
        Assert.Multiple(() =>
        {
            Assert.That(r, Is.Zero);
            Assert.That(g, Is.Zero);
            Assert.That(b, Is.EqualTo(255));
        });

        (a, r, g, b) = Blue;
        Assert.Multiple(() =>
        {
            Assert.That(a, Is.EqualTo(255));
            Assert.That(r, Is.Zero);
            Assert.That(g, Is.Zero);
            Assert.That(b, Is.EqualTo(255));
        });
    }

    [Test]
    public void GetClosestConsoleColor_ShouldReturnClosestColor_GivenValidColor()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Color.Transparent.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.AliceBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.AntiqueWhite.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Aqua.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(Color.Aquamarine.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.Azure.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Beige.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Bisque.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Black.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Black));
            Assert.That(Color.BlanchedAlmond.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Blue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Blue));
            Assert.That(Color.BlueViolet.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkMagenta));
            Assert.That(Color.Brown.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkRed));
            Assert.That(Color.BurlyWood.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.CadetBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.Chartreuse.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Yellow));
            Assert.That(Color.Chocolate.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkYellow));
            Assert.That(Color.Coral.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkYellow));
            Assert.That(Color.CornflowerBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.Cornsilk.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Crimson.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Red));
            Assert.That(Color.Cyan.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(Color.DarkBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkBlue));
            Assert.That(Color.DarkCyan.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkCyan));
            Assert.That(Color.DarkGoldenrod.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkYellow));
            Assert.That(Color.DarkGray.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.DarkGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGreen));
            Assert.That(Color.DarkKhaki.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.DarkMagenta.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkMagenta));
            Assert.That(Color.DarkOliveGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.DarkOrange.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkYellow));
            Assert.That(Color.DarkOrchid.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkMagenta));
            Assert.That(Color.DarkRed.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkRed));
            Assert.That(Color.DarkSalmon.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.DarkSeaGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.DarkSlateBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.DarkSlateGray.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGreen));
            Assert.That(Color.DarkTurquoise.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(Color.DarkViolet.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkMagenta));
            Assert.That(Color.DeepPink.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Magenta));
            Assert.That(Color.DeepSkyBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(Color.DimGray.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.DodgerBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(Color.Firebrick.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkRed));
            Assert.That(Color.FloralWhite.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.ForestGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Green));
            Assert.That(Color.Fuchsia.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Magenta));
            Assert.That(Color.Gainsboro.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.GhostWhite.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Gold.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Yellow));
            Assert.That(Color.Goldenrod.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkYellow));
            Assert.That(Color.Gray.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.Green.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Green));
            Assert.That(Color.GreenYellow.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Yellow));
            Assert.That(Color.Honeydew.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.HotPink.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.IndianRed.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.Indigo.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkMagenta));
            Assert.That(Color.Ivory.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Khaki.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.Lavender.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.LavenderBlush.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.LawnGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Yellow));
            Assert.That(Color.LemonChiffon.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.LightBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.LightCoral.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.LightCyan.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.LightGoldenrodYellow.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.LightGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.LightGray.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.LightPink.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.LightSalmon.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.LightSeaGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkCyan));
            Assert.That(Color.LightSkyBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.LightSlateGray.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.LightSteelBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.LightYellow.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Lime.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Green));
            Assert.That(Color.LimeGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Green));
            Assert.That(Color.Linen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Magenta.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Magenta));
            Assert.That(Color.Maroon.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkRed));
            Assert.That(Color.MediumAquamarine.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.MediumBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Blue));
            Assert.That(Color.MediumOrchid.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.MediumPurple.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.MediumSeaGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkCyan));
            Assert.That(Color.MediumSlateBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.MediumSpringGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(Color.MediumTurquoise.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(Color.MediumVioletRed.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkMagenta));
            Assert.That(Color.MidnightBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkBlue));
            Assert.That(Color.MintCream.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.MistyRose.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Moccasin.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.NavajoWhite.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Navy.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkBlue));
            Assert.That(Color.OldLace.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Olive.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.OliveDrab.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.Orange.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkYellow));
            Assert.That(Color.OrangeRed.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Red));
            Assert.That(Color.Orchid.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.PaleGoldenrod.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.PaleGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.PaleTurquoise.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.PaleVioletRed.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.PapayaWhip.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.PeachPuff.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Peru.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkYellow));
            Assert.That(Color.Pink.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Plum.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.PowderBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.Purple.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkMagenta));
#if NET6_0_OR_GREATER
            Assert.That(Color.RebeccaPurple.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkMagenta));
#endif
            Assert.That(Color.Red.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Red));
            Assert.That(Color.RosyBrown.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.RoyalBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkCyan));
            Assert.That(Color.SaddleBrown.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkRed));
            Assert.That(Color.Salmon.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.SandyBrown.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkYellow));
            Assert.That(Color.SeaGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkCyan));
            Assert.That(Color.SeaShell.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Sienna.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkRed));
            Assert.That(Color.Silver.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.SkyBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.SlateBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.SlateGray.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.Snow.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.SpringGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkCyan));
            Assert.That(Color.SteelBlue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.Tan.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.Teal.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkCyan));
            Assert.That(Color.Thistle.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.Tomato.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkYellow));
            Assert.That(Color.Turquoise.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(Color.Violet.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.DarkGray));
            Assert.That(Color.Wheat.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.White.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.WhiteSmoke.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.Yellow.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Yellow));
            Assert.That(Color.YellowGreen.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
        });
    }

    [Test]
    public void Inverted_ShouldReturnInvertedColor()
    {
        Assert.That(Black.Inverted(), Is.EqualTo(White));
        Assert.That(White.Inverted(), Is.EqualTo(Black));
        Assert.That(Cyan.Inverted(), Is.EqualTo(Red));
        Assert.That(Red.Inverted(), Is.EqualTo(Cyan));
        Assert.That(Magenta.Inverted(), Is.EqualTo(Green));
        Assert.That(Green.Inverted(), Is.EqualTo(Magenta));
        Assert.That(Blue.Inverted(), Is.EqualTo(Yellow));
        Assert.That(Yellow.Inverted(), Is.EqualTo(Blue));
    }

    [Test]
    public void Inverted_ShouldIgnoreAlpha()
    {
        Color expected = Color.FromArgb(255, 0, 0, 0);
        Color actual = Color.FromArgb(255, 255, 255, 255).Inverted();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WithA0_ShouldReturnSameColor_GivenWhite()
    {
        Color transparent = Color.FromArgb(0, 255, 255, 255);
        Assert.That(White.WithA(0), Is.EqualTo(transparent));
        Assert.That(transparent.WithA(0), Is.EqualTo(transparent));
    }

    [Test]
    public void WithB0_ShouldReturnYellow_GivenWhite()
    {
        Assert.That(White.WithB(0), Is.EqualTo(Yellow));
        Assert.That(Yellow.WithB(0), Is.EqualTo(Yellow));
    }

    [Test]
    public void WithG0_ShouldReturnMagenta_GivenWhite()
    {
        Assert.That(White.WithG(0), Is.EqualTo(Magenta));
        Assert.That(Magenta.WithG(0), Is.EqualTo(Magenta));
    }

    [Test]
    public void WithR0_ShouldReturnCyan_GivenWhite()
    {
        Assert.That(White.WithR(0), Is.EqualTo(Cyan));
        Assert.That(Cyan.WithR(0), Is.EqualTo(Cyan));
    }
}
