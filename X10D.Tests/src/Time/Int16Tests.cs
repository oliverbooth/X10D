﻿using NUnit.Framework;
using X10D.Time;

namespace X10D.Tests.Time;

[TestFixture]
public class Int16Tests
{
    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenMultipleOf100()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((short)100).IsLeapYear(), Is.False);
            Assert.That(((short)-100).IsLeapYear(), Is.False);
            Assert.That(((short)1900).IsLeapYear(), Is.False);
            Assert.That(((short)2100).IsLeapYear(), Is.False);
        });
    }

    [Test]
    public void IsLeapYear_ShouldBeFalse_GivenOddNumber()
    {
        Assert.That(((short)1).IsLeapYear(), Is.False);
        Assert.That(((short)101).IsLeapYear(), Is.False);
        Assert.That(((short)-101).IsLeapYear(), Is.False);
    }

    [Test]
    public void IsLeapYear_ShouldBeTrue_GivenMultipleOf4Or400()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((short)-401).IsLeapYear());
            Assert.That(((short)-105).IsLeapYear());
            Assert.That(((short)4).IsLeapYear());
            Assert.That(((short)104).IsLeapYear());
            Assert.That(((short)400).IsLeapYear());
            Assert.That(((short)2000).IsLeapYear());
        });
    }

    [Test]
    public void IsLeapYear_ShouldThrow_GivenZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = ((short)0).IsLeapYear());
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeNegative_GivenMinusOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((short)-1).Weeks(), Is.LessThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBePositive_GivenOne()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((short)1).Weeks(), Is.GreaterThan(TimeSpan.Zero));
        });
    }

    [Test]
    public void TicksMillisecondsSecondsMinutesDaysHoursWeeks_ShouldBeZero_GivenZero()
    {
        Assert.Multiple(() =>
        {
            Assert.That(((short)0).Weeks(), Is.EqualTo(TimeSpan.Zero));
        });
    }
}
