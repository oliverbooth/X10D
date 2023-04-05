using System.Net;
using NUnit.Framework;
using X10D.Net;

namespace X10D.Tests.Net;

[TestFixture]
public class EndPointTests
{
    [Test]
    public void GetHost_ShouldBeLocalhost_GivenLocalhostDnsEndPoint()
    {
        var endPoint = new DnsEndPoint("localhost", 1234);
        Assert.That(endPoint.GetHost(), Is.EqualTo("localhost"));
    }

    [Test]
    public void GetHost_ShouldBe127001_GivenLoopbackIPEndPoint()
    {
        var endPoint = new IPEndPoint(IPAddress.Loopback, 1234);
        Assert.That(endPoint.GetHost(), Is.EqualTo("127.0.0.1"));
    }

    [Test]
    public void GetHost_ShouldBeColonColon1_GivenIPv6LoopBackIPEndPoint()
    {
        var endPoint = new IPEndPoint(IPAddress.IPv6Loopback, 1234);
        Assert.That(endPoint.GetHost(), Is.EqualTo("::1"));
    }

    [Test]
    public void GetHost_ShouldThrow_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((IPEndPoint?)null)!.GetHost());
        Assert.Throws<ArgumentNullException>(() => ((DnsEndPoint?)null)!.GetHost());
    }

    [Test]
    public void GetPort_ShouldBe1234_Given1234IPEndPoint()
    {
        var endPoint = new IPEndPoint(IPAddress.Loopback, 1234);
        Assert.That(endPoint.GetPort(), Is.EqualTo(1234));
    }

    [Test]
    public void GetPort_ShouldBe1234_Given1234DnsEndPoint()
    {
        var endPoint = new DnsEndPoint("localhost", 1234);
        Assert.That(endPoint.GetPort(), Is.EqualTo(1234));
    }

    [Test]
    public void GetPort_ShouldThrow_GivenNull()
    {
        Assert.Throws<ArgumentNullException>(() => ((IPEndPoint?)null)!.GetPort());
        Assert.Throws<ArgumentNullException>(() => ((DnsEndPoint?)null)!.GetPort());
    }

    [Test]
    public void GetHost_ShouldBeEmpty_GivenInvalidEndPoint()
    {
        var endPoint = new DummyEndPoint();
        Assert.That(endPoint.GetHost(), Is.EqualTo(string.Empty));
    }

    [Test]
    public void GetPort_ShouldBe0_GivenInvalidEndPoint()
    {
        var endPoint = new DummyEndPoint();
        Assert.That(endPoint.GetPort(), Is.Zero);
    }

    private class DummyEndPoint : EndPoint
    {
    }
}
