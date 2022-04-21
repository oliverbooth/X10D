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
    public void DnsEndPointGetHostLocalhost()
    {
        var endPoint = new DnsEndPoint("localhost", 1234);
        Assert.AreEqual("localhost", endPoint.GetHost());
    }

    [TestMethod]
    public void DnsEndPointGetPort1234()
    {
        var endPoint = new DnsEndPoint("localhost", 1234);
        Assert.AreEqual(1234, endPoint.GetPort());
    }

    [TestMethod]
    public void IPEndPointIPv4LoopbackGetHost127001()
    {
        var endPoint = new IPEndPoint(IPAddress.Loopback, 1234);
        Assert.AreEqual("127.0.0.1", endPoint.GetHost());
    }

    [TestMethod]
    public void IPEndPointIPv6LoopbackGetHostColonColon1()
    {
        var endPoint = new IPEndPoint(IPAddress.IPv6Loopback, 1234);
        Assert.AreEqual("::1", endPoint.GetHost());
    }

    [TestMethod]
    public void IPEndPointGetPort1234()
    {
        var endPoint = new IPEndPoint(IPAddress.Loopback, 1234);
        Assert.AreEqual(1234, endPoint.GetPort());
    }
}
