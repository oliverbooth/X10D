﻿using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
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

        [UnityTest]
        public IEnumerator GetClosestConsoleColor_ShouldReturnClosestColor_GivenValidColor()
        {
            // I know it's just casting... but aim for 100% coverage babyyyy

            Assert.AreEqual(ConsoleColor.Red, ((Color32)Color.red).GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Green, ((Color32)Color.green).GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Blue, ((Color32)Color.blue).GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.White, ((Color32)Color.white).GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Black, ((Color32)Color.black).GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Yellow, ((Color32)Color.yellow).GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Cyan, ((Color32)Color.cyan).GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Magenta, ((Color32)Color.magenta).GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Gray, ((Color32)Color.gray).GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Gray, ((Color32)Color.grey).GetClosestConsoleColor());
            Assert.AreEqual(ConsoleColor.Black, ((Color32)Color.clear).GetClosestConsoleColor());

            yield break;
        }

        [UnityTest]
        public IEnumerator Inverted_ShouldReturnInvertedColor()
        {
            Assert.AreEqual(White, Black.Inverted());
            Assert.AreEqual(Black, White.Inverted());
            Assert.AreEqual(Red, Cyan.Inverted());
            Assert.AreEqual(Cyan, Red.Inverted());
            Assert.AreEqual(Green, Magenta.Inverted());
            Assert.AreEqual(Magenta, Green.Inverted());
            Assert.AreEqual(Yellow, Blue.Inverted());
            Assert.AreEqual(Blue, Yellow.Inverted());

            yield break;
        }

        [UnityTest]
        public IEnumerator Inverted_ShouldIgnoreAlpha()
        {
            var expected = new Color32(0, 0, 0, 255);
            var actual = new Color32(255, 255, 255, 255).Inverted();

            Assert.AreEqual(expected, actual);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToSystemDrawingColor_ShouldReturnEquivalentColor()
        {
            System.Drawing.Color expected = System.Drawing.Color.FromArgb(255, 255, 255);
            System.Drawing.Color actual = White.ToSystemDrawingColor();

            Assert.AreEqual(expected, actual);

            yield break;
        }

        [UnityTest]
        public IEnumerator ToUnityColor32_ShouldReturnEquivalentColor()
        {
            Color32 expected = White;
            Color32 actual = System.Drawing.Color.FromArgb(255, 255, 255).ToUnityColor32();

            Assert.AreEqual(expected, actual);

            yield break;
        }

        [UnityTest]
        public IEnumerator WithA0_ShouldReturnSameColor_GivenWhite()
        {
            var transparent = new Color32(255, 255, 255, 0);
            Assert.AreEqual(transparent, White.WithA(0));
            Assert.AreEqual(transparent, transparent.WithA(0));

            yield break;
        }

        [UnityTest]
        public IEnumerator WithB0_ShouldReturnYellow_GivenWhite()
        {
            Assert.AreEqual(Yellow, White.WithB(0));
            Assert.AreEqual(Yellow, Yellow.WithB(0));

            yield break;
        }

        [UnityTest]
        public IEnumerator WithG0_ShouldReturnMagenta_GivenWhite()
        {
            Assert.AreEqual(Magenta, White.WithG(0));
            Assert.AreEqual(Magenta, Magenta.WithG(0));

            yield break;
        }

        [UnityTest]
        public IEnumerator WithR0_ShouldReturnCyan_GivenWhite()
        {
            Assert.AreEqual(Cyan, White.WithR(0));
            Assert.AreEqual(Cyan, Cyan.WithR(0));

            yield break;
        }
    }
}