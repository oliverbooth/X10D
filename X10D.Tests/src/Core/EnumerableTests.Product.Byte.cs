using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Core;

public partial class EnumerableTests
{
    [TestMethod]
    [DataRow((byte)0, (byte)1)]
    [DataRow((byte)2, (byte)3, (byte)4)]
    [DataRow((byte)1, (byte)2, (byte)3, (byte)4, (byte)5, (byte)6, (byte)7, (byte)8, (byte)9, (byte)10)] // 10!
    public void ProductByte_Fixed(params byte[] source)
    {
        byte expected = 1;
        foreach (byte item in source)
        {
            expected *= item;
        }

        byte actual = source.Product();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow((byte)0, (byte)1)]
    [DataRow((byte)2, (byte)3, (byte)4)]
    [DataRow((byte)1, (byte)2, (byte)3, (byte)4, (byte)5, (byte)6, (byte)7, (byte)8, (byte)9, (byte)10)] // 10!
    public void ProductByte_Transformed_Fixed(params byte[] source)
    {
        byte expected = 1;
        foreach (byte item in source)
        {
            expected *= (byte)(item * 2);
        }

        byte actual = source.Product(n => (byte)(n * 2));

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ProductByte_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new byte[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (byte)random.Next(1, 100);
            }

            byte expected = 1;
            foreach (byte item in source)
            {
                expected *= item;
            }

            byte actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductByte_Transformed_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new byte[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (byte)random.Next(1, 100);
            }

            byte expected = 1;
            foreach (byte item in source)
            {
                expected *= (byte)(item * 2);
            }

            byte actual = source.Product(n => (byte)(n * 2));

            Assert.AreEqual(expected, actual);
        }
    }
}
