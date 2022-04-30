﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Linq;

[TestClass]
[CLSCompliant(false)]
public class SByteTests
{
    [TestMethod]
    public void ProductShouldBeCorrect()
    {
        sbyte Cast(int i) => (sbyte)i;

        Assert.AreEqual(0, Enumerable.Range(0, 10).Product());
        Assert.AreEqual(1, Enumerable.Range(1, 1).Product());
        Assert.AreEqual(2, Enumerable.Range(1, 2).Product());
        Assert.AreEqual(6, Enumerable.Range(1, 3).Product());
        Assert.AreEqual(24, Enumerable.Range(1, 4).Product());
        Assert.AreEqual(120, Enumerable.Range(1, 5).Product());

        // 6! will overflow for sbyte
    }

    [TestMethod]
    public void ProductOfDoublesShouldBeCorrect()
    {
        sbyte Double(int i) => (sbyte)(i * 2);

        Assert.AreEqual(0, Enumerable.Range(0, 10).Product(Double));
        Assert.AreEqual(2, Enumerable.Range(1, 1).Product(Double));
        Assert.AreEqual(8, Enumerable.Range(1, 2).Product(Double));
        Assert.AreEqual(48, Enumerable.Range(1, 3).Product(Double));

        // Π_(i=1)^(n(i*2)) will overflow at i=4 for sbyte
    }
}
