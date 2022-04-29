using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Net;

namespace X10D.Tests.Net;

[TestClass]
public class Int16Tests
{
    [TestMethod]
    public void HostToNetworkOrder_ReturnsCorrectValue()
    {
        const short hostOrder = 0x0102;
        const short networkOrder = 0x0201;

        Assert.AreEqual(BitConverter.IsLittleEndian ? networkOrder : hostOrder, hostOrder.HostToNetworkOrder());
    }

    [TestMethod]
    public void NetworkToHostOrder_ReturnsCorrectValue()
    {
        const short hostOrder = 0x0102;
        const short networkOrder = 0x0201;

        Assert.AreEqual(BitConverter.IsLittleEndian ? hostOrder : networkOrder, networkOrder.NetworkToHostOrder());
    }
}
