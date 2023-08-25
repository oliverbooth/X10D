using System.Drawing;
using NUnit.Framework;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestFixture]
internal class RandomTests
{
    [Test]
    public void NextColorArgb_ShouldReturn331515e5_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextColorArgb(), Is.EqualTo(Color.FromArgb(51, 21, 21, 229)));
    }

    [Test]
    public void NextColorArgb_ShouldThrow_GivenNull()
    {
        Random random = null!;
        Assert.Throws<ArgumentNullException>(() => random.NextColorArgb());
    }

    [Test]
    public void NextColorRgb_ShouldReturn1515e5_GivenSeed1234()
    {
        var random = new Random(1234);
        Assert.That(random.NextColorRgb(), Is.EqualTo(Color.FromArgb(255, 21, 21, 229)));
    }

    [Test]
    public void NextColorRgb_ShouldThrow_GivenNull()
    {
        Random random = null!;
        Assert.Throws<ArgumentNullException>(() => random.NextColorRgb());
    }
}
