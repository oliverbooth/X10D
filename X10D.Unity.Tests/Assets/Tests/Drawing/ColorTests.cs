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
            Assert.That(r, Is.EqualTo(1.0f));
            Assert.That(g, Is.EqualTo(1.0f));
            Assert.That(b, Is.EqualTo(1.0f));

            (a, r, g, b) = Yellow;
            Assert.That(a, Is.EqualTo(1.0f));
            Assert.That(r, Is.EqualTo(1.0f));
            Assert.That(g, Is.EqualTo(1.0f));
            Assert.That(b, Is.EqualTo(0.0f));
        }

        [Test]
        public void GetClosestConsoleColor_ShouldReturnClosestColor_GivenValidColor()
        {
            Assert.That(Color.red.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Red));
            Assert.That(Color.green.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Green));
            Assert.That(Color.blue.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Blue));
            Assert.That(Color.white.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(Color.black.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Black));
            Assert.That(Color.yellow.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Yellow));
            Assert.That(Color.cyan.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(Color.magenta.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Magenta));
            Assert.That(Color.gray.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.grey.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(Color.clear.GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Black));
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
            var expected = new Color(0, 0, 0, 1);
            var actual = new Color(1, 1, 1, 1).Inverted();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ToSystemDrawingColor_ShouldReturnEquivalentColor()
        {
            System.Drawing.Color expected = System.Drawing.Color.FromArgb(255, 255, 255);
            System.Drawing.Color actual = White.ToSystemDrawingColor();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ToUnityColor_ShouldReturnEquivalentColor()
        {
            Color expected = White;
            Color actual = System.Drawing.Color.FromArgb(255, 255, 255).ToUnityColor();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WithA0_ShouldReturnSameColor_GivenWhite()
        {
            var transparent = new Color(1, 1, 1, 0);
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
}
