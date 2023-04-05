using System;
using NUnit.Framework;
using UnityEngine;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class ColorTests
    {
        private static readonly Color Black = new(0, 0, 0);
        private static readonly Color White = new(1, 1, 1);
        private static readonly Color Red = new(1, 0, 0);
        private static readonly Color Green = new(0, 1, 0);
        private static readonly Color Blue = new(0, 0, 1);
        private static readonly Color Cyan = new(0, 1, 1);
        private static readonly Color Magenta = new(1, 0, 1);
        private static readonly Color Yellow = new(1, 1, 0);

        [Test]
        public void Deconstruct_ShouldDeconstruct_ToCorrectValues()
        {
            float a, r, g, b;

            (r, g, b) = White;
            Assert.AreEqual(1.0f, r);
            Assert.AreEqual(1.0f, g);
            Assert.AreEqual(1.0f, b);

            (a, r, g, b) = Yellow;
            Assert.AreEqual(1.0f, a);
            Assert.AreEqual(1.0f, r);
            Assert.AreEqual(1.0f, g);
            Assert.AreEqual(0.0f, b);
        }

        [Test]
        public void GetClosestConsoleColor_ShouldReturnClosestColor_GivenValidColor()
        {
            Assert.AreEqual(ConsoleColor.Red, Color.red.GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Green, Color.green.GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Blue, Color.blue.GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.White, Color.white.GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Black, Color.black.GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Yellow, Color.yellow.GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Cyan, Color.cyan.GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Magenta, Color.magenta.GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Gray, Color.gray.GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Gray, Color.grey.GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Black, Color.clear.GetClosestConsoleColor());
        }

        [Test]
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

        [Test]
        public void Inverted_ShouldIgnoreAlpha()
        {
            var expected = new Color(0, 0, 0, 1);
            var actual = new Color(1, 1, 1, 1).Inverted();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToSystemDrawingColor_ShouldReturnEquivalentColor()
        {
            System.Drawing.Color expected = System.Drawing.Color.FromArgb(255, 255, 255);
            System.Drawing.Color actual = White.ToSystemDrawingColor();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToUnityColor_ShouldReturnEquivalentColor()
        {
            Color expected = White;
            Color actual = System.Drawing.Color.FromArgb(255, 255, 255).ToUnityColor();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WithA0_ShouldReturnSameColor_GivenWhite()
        {
            var transparent = new Color(1, 1, 1, 0);
            Assert.AreEqual(transparent, White.WithA(0));
            Assert.AreEqual(transparent, transparent.WithA(0));
        }

        [Test]
        public void WithB0_ShouldReturnYellow_GivenWhite()
        {
            Assert.AreEqual(Yellow, White.WithB(0));
            Assert.AreEqual(Yellow, Yellow.WithB(0));
        }

        [Test]
        public void WithG0_ShouldReturnMagenta_GivenWhite()
        {
            Assert.AreEqual(Magenta, White.WithG(0));
            Assert.AreEqual(Magenta, Magenta.WithG(0));
        }

        [Test]
        public void WithR0_ShouldReturnCyan_GivenWhite()
        {
            Assert.AreEqual(Cyan, White.WithR(0));
            Assert.AreEqual(Cyan, Cyan.WithR(0));
        }
    }
}
