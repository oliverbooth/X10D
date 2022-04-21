using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Net;

namespace X10D.Tests.Net;

[TestClass]
public class IpAddressTests
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
    public void IsIPv4()
    {
        Assert.IsTrue(_ipv4Address.IsIpV4());
        Assert.IsFalse(_ipv6Address.IsIpV4());
    }

    [TestMethod]
    public void IsIPv6()
    {
        Assert.IsTrue(_ipv6Address.IsIpV6());
        Assert.IsFalse(_ipv4Address.IsIpV6());
    }
}
