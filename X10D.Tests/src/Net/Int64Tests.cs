using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Net;

namespace X10D.Tests.Net;

[TestClass]
public class Int64Tests
{
    [TestMethod]
    public void HostToNetworkOrder_ReturnsCorrectValue()
    {
        const long hostOrder = 0x0102030405060708;
        const long networkOrder = 0x0807060504030201;

        Assert.AreEqual(BitConverter.IsLittleEndian ? networkOrder : hostOrder, hostOrder.HostToNetworkOrder());
    }

    [TestMethod]
    public void NetworkToHostOrder_ReturnsCorrectValue()
    {
        const long hostOrder = 0x0102030405060708;
        const long networkOrder = 0x0807060504030201;

        Assert.AreEqual(BitConverter.IsLittleEndian ? hostOrder : networkOrder, networkOrder.NetworkToHostOrder());
    }
}
