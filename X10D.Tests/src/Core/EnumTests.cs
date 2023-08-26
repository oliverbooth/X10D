using NUnit.Framework;
using X10D.Core;

namespace X10D.Tests.Core;

[TestFixture]
internal class EnumTests
{
    // Microsoft wrongfully decided to have Sunday be 0, Monday be 1, etc.
    // I personally hate this, Sunday is not the first day of the week.
    // it's clearly Monday as defined by ISO 8601.
    // but Microsoft can't fix this without breaking compatibility.
    // I have feelings...

    [Test]
    public void Next()
    {
        Assert.Multiple(() =>
        {
            Assert.That(DayOfWeek.Sunday.Next(), Is.EqualTo(DayOfWeek.Monday));
            Assert.That(DayOfWeek.Monday.Next(), Is.EqualTo(DayOfWeek.Tuesday));
            Assert.That(DayOfWeek.Tuesday.Next(), Is.EqualTo(DayOfWeek.Wednesday));
            Assert.That(DayOfWeek.Wednesday.Next(), Is.EqualTo(DayOfWeek.Thursday));
            Assert.That(DayOfWeek.Thursday.Next(), Is.EqualTo(DayOfWeek.Friday));
            Assert.That(DayOfWeek.Friday.Next(), Is.EqualTo(DayOfWeek.Saturday));
            Assert.That(DayOfWeek.Saturday.Next(), Is.EqualTo(DayOfWeek.Sunday)); // Saturday is the "last" day. wrap to "first"
        });
    }

    [Test]
    public void NextUnchecked()
    {
        Assert.Multiple(() =>
        {
            Assert.That(DayOfWeek.Sunday.NextUnchecked(), Is.EqualTo(DayOfWeek.Monday));
            Assert.That(DayOfWeek.Monday.NextUnchecked(), Is.EqualTo(DayOfWeek.Tuesday));
            Assert.That(DayOfWeek.Tuesday.NextUnchecked(), Is.EqualTo(DayOfWeek.Wednesday));
            Assert.That(DayOfWeek.Wednesday.NextUnchecked(), Is.EqualTo(DayOfWeek.Thursday));
            Assert.That(DayOfWeek.Thursday.NextUnchecked(), Is.EqualTo(DayOfWeek.Friday));
            Assert.That(DayOfWeek.Friday.NextUnchecked(), Is.EqualTo(DayOfWeek.Saturday));
        });
        Assert.Throws<IndexOutOfRangeException>(() => _ = DayOfWeek.Saturday.NextUnchecked());
    }

    [Test]
    public void Previous()
    {
        Assert.Multiple(() =>
        {
            Assert.That(DayOfWeek.Sunday.Previous(), Is.EqualTo(DayOfWeek.Saturday)); // Sunday is the "first" day. wrap to "last"
            Assert.That(DayOfWeek.Monday.Previous(), Is.EqualTo(DayOfWeek.Sunday));
            Assert.That(DayOfWeek.Tuesday.Previous(), Is.EqualTo(DayOfWeek.Monday));
            Assert.That(DayOfWeek.Wednesday.Previous(), Is.EqualTo(DayOfWeek.Tuesday));
            Assert.That(DayOfWeek.Thursday.Previous(), Is.EqualTo(DayOfWeek.Wednesday));
            Assert.That(DayOfWeek.Friday.Previous(), Is.EqualTo(DayOfWeek.Thursday));
            Assert.That(DayOfWeek.Saturday.Previous(), Is.EqualTo(DayOfWeek.Friday));
        });
    }

    [Test]
    public void PreviousUnchecked()
    {
        Assert.Multiple(() =>
        {
            Assert.That(DayOfWeek.Monday.PreviousUnchecked(), Is.EqualTo(DayOfWeek.Sunday));
            Assert.That(DayOfWeek.Tuesday.PreviousUnchecked(), Is.EqualTo(DayOfWeek.Monday));
            Assert.That(DayOfWeek.Wednesday.PreviousUnchecked(), Is.EqualTo(DayOfWeek.Tuesday));
            Assert.That(DayOfWeek.Thursday.PreviousUnchecked(), Is.EqualTo(DayOfWeek.Wednesday));
            Assert.That(DayOfWeek.Friday.PreviousUnchecked(), Is.EqualTo(DayOfWeek.Thursday));
            Assert.That(DayOfWeek.Saturday.PreviousUnchecked(), Is.EqualTo(DayOfWeek.Friday));
        });
        Assert.Throws<IndexOutOfRangeException>(() => _ = DayOfWeek.Sunday.PreviousUnchecked());
    }
}
