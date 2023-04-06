using NUnit.Framework;
using X10D.Net;

namespace X10D.Tests.Net;

[TestFixture]
public class Int64Tests
{
    [Test]
    public void HostToNetworkOrder_ReturnsCorrectValue()
    {
        const long hostOrder = 0x0102030405060708;
        const long networkOrder = 0x0807060504030201;

        Assert.That(hostOrder.HostToNetworkOrder(), Is.EqualTo(BitConverter.IsLittleEndian ? networkOrder : hostOrder));
    }

    [Test]
    public void NetworkToHostOrder_ReturnsCorrectValue()
    {
        const long hostOrder = 0x0102030405060708;
        const long networkOrder = 0x0807060504030201;

        Assert.That(networkOrder.NetworkToHostOrder(), Is.EqualTo(BitConverter.IsLittleEndian ? hostOrder : networkOrder));
    }
}
