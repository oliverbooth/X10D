using System.Net;
using NUnit.Framework;
using X10D.Net;

namespace X10D.Tests.Net;

[TestFixture]
internal class IPAddressTests
{
    private IPAddress _ipv4Address = null!;
    private IPAddress _ipv6Address = null!;

    [SetUp]
    public void Initialize()
    {
        _ipv4Address = IPAddress.Parse("127.0.0.1");
        _ipv6Address = IPAddress.Parse("::1");
    }

    [Test]
    public void IsIPv4_ShouldBeTrue_GivenIPv4()
    {
        Assert.That(_ipv4Address.IsIPv4());
    }

    [Test]
    public void IsIPv4_ShouldBeFalse_GivenIPv6()
    {
        Assert.That(_ipv6Address.IsIPv4(), Is.False);
    }

    [Test]
    public void IsIPv4_ShouldThrowArgumentNullException_GivenNullAddress()
    {
        IPAddress address = null!;
        Assert.Throws<ArgumentNullException>(() => address.IsIPv4());
    }

    [Test]
    public void IsIPv6_ShouldBeFalse_GivenIPv4()
    {
        Assert.That(_ipv4Address.IsIPv6(), Is.False);
    }

    [Test]
    public void IsIPv6_ShouldBeTrue_GivenIPv6()
    {
        Assert.That(_ipv6Address.IsIPv6());
    }

    [Test]
    public void IsIPv6_ShouldThrowArgumentNullException_GivenNullAddress()
    {
        IPAddress address = null!;
        Assert.Throws<ArgumentNullException>(() => address.IsIPv6());
    }
}
