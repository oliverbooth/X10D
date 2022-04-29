using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Net;

namespace X10D.Tests.Net;

[TestClass]
public class Int32Tests
{
    [TestMethod]
    public void HostToNetworkOrder_ReturnsCorrectValue()
    {
        const int hostOrder = 0x01020304;
        const int networkOrder = 0x04030201;

        Assert.AreEqual(BitConverter.IsLittleEndian ? networkOrder : hostOrder, hostOrder.HostToNetworkOrder());
    }

    [TestMethod]
    public void NetworkToHostOrder_ReturnsCorrectValue()
    {
        const int hostOrder = 0x01020304;
        const int networkOrder = 0x04030201;

        Assert.AreEqual(BitConverter.IsLittleEndian ? hostOrder : networkOrder, networkOrder.NetworkToHostOrder());
    }
}
