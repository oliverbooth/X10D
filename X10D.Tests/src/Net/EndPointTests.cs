using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Net;

namespace X10D.Tests.Net;

[TestClass]
public class EndPointTests
{
    [TestMethod]
    public void DnsEndPoint_GetHost_Localhost()
    {
        var endPoint = new DnsEndPoint("localhost", 1234);
        Assert.AreEqual("localhost", endPoint.GetHost());
    }
    
    [TestMethod]
    public void DnsEndPoint_GetPort_1234()
    {
        var endPoint = new DnsEndPoint("localhost", 1234);
        Assert.AreEqual(1234, endPoint.GetPort());
    }
    
    [TestMethod]
    public void IPEndPoint_IPv4_Loopback_GetHost_127_0_0_1()
    {
        var endPoint = new IPEndPoint(IPAddress.Loopback, 1234);
        Assert.AreEqual("127.0.0.1", endPoint.GetHost());
    }
    
    [TestMethod]
    public void IPEndPoint_IPv6_Loopback_GetHost_ColonColon1()
    {
        var endPoint = new IPEndPoint(IPAddress.IPv6Loopback, 1234);
        Assert.AreEqual("::1", endPoint.GetHost());
    }
    
    [TestMethod]
    public void IPEndPoint_GetPort_1234()
    {
        var endPoint = new IPEndPoint(IPAddress.Loopback, 1234);
        Assert.AreEqual("127.0.0.1", endPoint.GetHost());
    }
}
