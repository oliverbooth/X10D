using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Core;

public partial class EnumerableTests
{
    [TestMethod]
    [DataRow((ushort)0, (ushort)1)]
    [DataRow((ushort)2, (ushort)3, (ushort)4)]
    [DataRow((ushort)1, (ushort)2, (ushort)3, (ushort)4, (ushort)5, (ushort)6, (ushort)7, (ushort)8, (ushort)9, (ushort)10)] // 10!
    public void ProductUInt16_Fixed(params ushort[] source)
    {
        ushort expected = 1;
        foreach (ushort item in source)
        {
            expected *= item;
        }

        ushort actual = source.Product();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow((ushort)0, (ushort)1)]
    [DataRow((ushort)2, (ushort)3, (ushort)4)]
    [DataRow((ushort)1, (ushort)2, (ushort)3, (ushort)4, (ushort)5, (ushort)6, (ushort)7, (ushort)8, (ushort)9, (ushort)10)] // 10!
    public void ProductUInt16_Transformed_Fixed(params ushort[] source)
    {
        ushort expected = 1;
        foreach (ushort item in source)
        {
            expected *= (ushort)(item * 2);
        }

        ushort actual = source.Product(n => (ushort)(n * 2));

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ProductUInt16_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new ushort[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (ushort)random.Next(1, 100);
            }

            ushort expected = 1;
            foreach (ushort item in source)
            {
                expected *= item;
            }

            ushort actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductUInt16_Transformed_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new ushort[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (ushort)random.Next(1, 100);
            }

            ushort expected = 1;
            foreach (ushort item in source)
            {
                expected *= (ushort)(item * 2);
            }

            ushort actual = source.Product(n => (ushort)(n * 2));

            Assert.AreEqual(expected, actual);
        }
    }
}
