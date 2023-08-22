using NUnit.Framework;
using X10D.Core;

namespace X10D.Tests.Core;

[TestFixture]
internal class NullableTests
{
    [Test]
    public void TryGetValue_ShouldBeTrue_GivenValue()
    {
        int? value = 42;
        Assert.Multiple(() =>
        {
            Assert.That(value.TryGetValue(out int returnedValue));
            Assert.That(returnedValue, Is.EqualTo(value.Value));
        });
    }

    [Test]
    public void TryGetValue_ShouldBeFalse_GivenNull()
    {
        int? value = null;
        Assert.Multiple(() =>
        {
            Assert.That(value.TryGetValue(out int returnedValue), Is.False);
            Assert.That(returnedValue, Is.Zero);
        });
    }
}
