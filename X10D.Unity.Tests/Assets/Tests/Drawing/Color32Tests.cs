using System;
using NUnit.Framework;
using UnityEngine;
using X10D.Unity.Drawing;

namespace X10D.Unity.Tests.Drawing
{
    public class Color32Tests
    {
        private static readonly Color32 Black = new(0, 0, 0, 255);
        private static readonly Color32 White = new(255, 255, 255, 255);
        private static readonly Color32 Red = new(255, 0, 0, 255);
        private static readonly Color32 Green = new(0, 255, 0, 255);
        private static readonly Color32 Blue = new(0, 0, 255, 255);
        private static readonly Color32 Cyan = new(0, 255, 255, 255);
        private static readonly Color32 Magenta = new(255, 0, 255, 255);
        private static readonly Color32 Yellow = new(255, 255, 0, 255);

        [Test]
        public void Deconstruct_ShouldDeconstruct_ToCorrectValues()
        {
            byte a, r, g, b;

            (r, g, b) = White;
            Assert.That(r, Is.EqualTo(255));
            Assert.That(g, Is.EqualTo(255));
            Assert.That(b, Is.EqualTo(255));

            (a, r, g, b) = Yellow;
            Assert.That(a, Is.EqualTo(255));
            Assert.That(r, Is.EqualTo(255));
            Assert.That(g, Is.EqualTo(255));
            Assert.That(b, Is.EqualTo(0));
        }

        [Test]
        public void GetClosestConsoleColor_ShouldReturnClosestColor_GivenValidColor()
        {
            // I know it's just casting... but aim for 100% coverage babyyyy

            Assert.That(((Color32)Color.red).GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Red));
            Assert.That(((Color32)Color.green).GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Green));
            Assert.That(((Color32)Color.blue).GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Blue));
            Assert.That(((Color32)Color.white).GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.White));
            Assert.That(((Color32)Color.black).GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Black));
            Assert.That(((Color32)Color.yellow).GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Yellow));
            Assert.That(((Color32)Color.cyan).GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Cyan));
            Assert.That(((Color32)Color.magenta).GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Magenta));
            Assert.That(((Color32)Color.gray).GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(((Color32)Color.grey).GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Gray));
            Assert.That(((Color32)Color.clear).GetClosestConsoleColor(), Is.EqualTo(ConsoleColor.Black));
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
            var expected = new Color32(0, 0, 0, 255);
            var actual = new Color32(255, 255, 255, 255).Inverted();

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
        public void ToUnityColor32_ShouldReturnEquivalentColor()
        {
            Color32 expected = White;
            Color32 actual = System.Drawing.Color.FromArgb(255, 255, 255).ToUnityColor32();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WithA0_ShouldReturnSameColor_GivenWhite()
        {
            var transparent = new Color32(255, 255, 255, 0);
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
