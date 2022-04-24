using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Net;

namespace X10D.Tests.Net;

[TestClass]
public class EndPointTests
{
    [TestMethod]
    public void GetHostNullShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((IPEndPoint?)null)!.GetHost());
        Assert.ThrowsException<ArgumentNullException>(() => ((DnsEndPoint?)null)!.GetHost());
    }

    [TestMethod]
    public void GetPortNullShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((IPEndPoint?)null)!.GetPort());
        Assert.ThrowsException<ArgumentNullException>(() => ((DnsEndPoint?)null)!.GetPort());
    }

    [TestMethod]
    public void DnsEndPointGetHostShouldBeLocalhost()
    {
        var endPoint = new DnsEndPoint("localhost", 1234);
        Assert.AreEqual("localhost", endPoint.GetHost());
    }

    [TestMethod]
    public void DnsEndPointGetPortShouldBe1234()
    {
        var endPoint = new DnsEndPoint("localhost", 1234);
        Assert.AreEqual(1234, endPoint.GetPort());
    }

    [TestMethod]
    public void IPEndPointIPv4LoopbackGetHostShouldBe127_0_0_1()
    {
        var endPoint = new IPEndPoint(IPAddress.Loopback, 1234);
        Assert.AreEqual("127.0.0.1", endPoint.GetHost());
    }

    [TestMethod]
    public void IPEndPointIPv6LoopbackGetHostShouldBeColonColon1()
    {
        var endPoint = new IPEndPoint(IPAddress.IPv6Loopback, 1234);
        Assert.AreEqual("::1", endPoint.GetHost());
    }

    [TestMethod]
    public void IPEndPointGetPortShouldBe1234()
    {
        var endPoint = new IPEndPoint(IPAddress.Loopback, 1234);
        Assert.AreEqual(1234, endPoint.GetPort());
    }

    [TestMethod]
    public void DummyEndPointGetHostShouldBeEmptyString()
    {
        var endPoint = new DummyEndPoint();
        Assert.AreEqual(string.Empty, endPoint.GetHost());
    }

    [TestMethod]
    public void DummyEndPointGetPortShouldBe0()
    {
        var endPoint = new DummyEndPoint();
        Assert.AreEqual(0, endPoint.GetPort());
    }

    private class DummyEndPoint : EndPoint
    {
    }
}
