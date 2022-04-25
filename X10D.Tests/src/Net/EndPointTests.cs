using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Net;

namespace X10D.Tests.Net;

[TestClass]
public class EndPointTests
{
    [TestMethod]
    public void GetHost_ShouldBeLocalhost_GivenLocalhostDnsEndPoint()
    {
        var endPoint = new DnsEndPoint("localhost", 1234);
        Assert.AreEqual("localhost", endPoint.GetHost());
    }

    [TestMethod]
    public void GetHost_ShouldBe127001_GivenLoopbackIPEndPoint()
    {
        var endPoint = new IPEndPoint(IPAddress.Loopback, 1234);
        Assert.AreEqual("127.0.0.1", endPoint.GetHost());
    }

    [TestMethod]
    public void GetHost_ShouldBeColonColon1_GivenIPv6LoopBackIPEndPoint()
    {
        var endPoint = new IPEndPoint(IPAddress.IPv6Loopback, 1234);
        Assert.AreEqual("::1", endPoint.GetHost());
    }

    [TestMethod]
    public void GetHost_ShouldThrow_GivenNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((IPEndPoint?)null)!.GetHost());
        Assert.ThrowsException<ArgumentNullException>(() => ((DnsEndPoint?)null)!.GetHost());
    }

    [TestMethod]
    public void GetPort_ShouldBe1234_Given1234IPEndPoint()
    {
        var endPoint = new IPEndPoint(IPAddress.Loopback, 1234);
        Assert.AreEqual(1234, endPoint.GetPort());
    }

    [TestMethod]
    public void GetPort_ShouldBe1234_Given1234DnsEndPoint()
    {
        var endPoint = new DnsEndPoint("localhost", 1234);
        Assert.AreEqual(1234, endPoint.GetPort());
    }

    [TestMethod]
    public void GetPort_ShouldThrow_GivenNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((IPEndPoint?)null)!.GetPort());
        Assert.ThrowsException<ArgumentNullException>(() => ((DnsEndPoint?)null)!.GetPort());
    }

    [TestMethod]
    public void GetHost_ShouldBeEmpty_GivenInvalidEndPoint()
    {
        var endPoint = new DummyEndPoint();
        Assert.AreEqual(string.Empty, endPoint.GetHost());
    }

    [TestMethod]
    public void GetPort_ShouldBe0_GivenInvalidEndPoint()
    {
        var endPoint = new DummyEndPoint();
        Assert.AreEqual(0, endPoint.GetPort());
    }

    private class DummyEndPoint : EndPoint
    {
    }
}
