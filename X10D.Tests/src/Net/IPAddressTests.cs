using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Net;

namespace X10D.Tests.Net;

[TestClass]
public class IPAddressTests
{
    private IPAddress _ipv4Address = null!;
    private IPAddress _ipv6Address = null!;

    [TestInitialize]
    public void Initialize()
    {
        _ipv4Address = IPAddress.Parse("127.0.0.1");
        _ipv6Address = IPAddress.Parse("::1");
    }

    [TestMethod]
    public void IsIPv4_ShouldBeTrue_GivenIPv4()
    {
        Assert.IsTrue(_ipv4Address.IsIPv4());
    }

    [TestMethod]
    public void IsIPv4_ShouldBeFalse_GivenIPv6()
    {
        Assert.IsFalse(_ipv6Address.IsIPv4());
    }

    [TestMethod]
    public void IsIPv6_ShouldBeFalse_GivenIPv4()
    {
        Assert.IsFalse(_ipv4Address.IsIPv6());
    }

    [TestMethod]
    public void IsIPv6_ShouldBeTrue_GivenIPv6()
    {
        Assert.IsTrue(_ipv6Address.IsIPv6());
    }
}
