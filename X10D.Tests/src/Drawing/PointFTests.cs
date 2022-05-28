using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Core;
using X10D.Drawing;

namespace X10D.Tests.Drawing;

[TestClass]
public class PointFTests
{
    [TestMethod]
    public void ToSizeF_ShouldReturnSize_WithEquivalentMembers()
    {
        var random = new Random();
        var point = new PointF(random.NextSingle(), random.NextSingle());
        var size = point.ToSizeF();

        Assert.AreEqual(point.X, size.Width, 1e-6f);
        Assert.AreEqual(point.Y, size.Height, 1e-6f);
    }
}
