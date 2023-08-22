using NUnit.Framework;
using X10D.Net;

namespace X10D.Tests.Net;

[TestFixture]
internal class Int32Tests
{
    [Test]
    public void HostToNetworkOrder_ReturnsCorrectValue()
    {
        const int hostOrder = 0x01020304;
        const int networkOrder = 0x04030201;

        Assert.That(hostOrder.HostToNetworkOrder(), Is.EqualTo(BitConverter.IsLittleEndian ? networkOrder : hostOrder));
    }

    [Test]
    public void NetworkToHostOrder_ReturnsCorrectValue()
    {
        const int hostOrder = 0x01020304;
        const int networkOrder = 0x04030201;

        Assert.That(networkOrder.NetworkToHostOrder(), Is.EqualTo(BitConverter.IsLittleEndian ? hostOrder : networkOrder));
    }
}
