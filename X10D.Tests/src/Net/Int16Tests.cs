using NUnit.Framework;
using X10D.Net;

namespace X10D.Tests.Net;

[TestFixture]
public class Int16Tests
{
    [Test]
    public void HostToNetworkOrder_ReturnsCorrectValue()
    {
        const short hostOrder = 0x0102;
        const short networkOrder = 0x0201;

        Assert.That(hostOrder.HostToNetworkOrder(), Is.EqualTo(BitConverter.IsLittleEndian ? networkOrder : hostOrder));
    }

    [Test]
    public void NetworkToHostOrder_ReturnsCorrectValue()
    {
        const short hostOrder = 0x0102;
        const short networkOrder = 0x0201;

        Assert.That(networkOrder.NetworkToHostOrder(), Is.EqualTo(BitConverter.IsLittleEndian ? hostOrder : networkOrder));
    }
}
