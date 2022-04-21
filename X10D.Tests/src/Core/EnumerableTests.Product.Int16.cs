using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Core;

public partial class EnumerableTests
{
    [TestMethod]
    [DataRow((short)0, (short)1)]
    [DataRow((short)2, (short)3, (short)4)]
    [DataRow((short)1, (short)2, (short)3, (short)4, (short)5, (short)6, (short)7, (short)8, (short)9, (short)10)] // 10!
    public void ProductInt16_Fixed(params short[] source)
    {
        short expected = 1;
        foreach (short item in source)
        {
            expected *= item;
        }

        short actual = source.Product();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow((short)0, (short)1)]
    [DataRow((short)2, (short)3, (short)4)]
    [DataRow((short)1, (short)2, (short)3, (short)4, (short)5, (short)6, (short)7, (short)8, (short)9, (short)10)] // 10!
    public void ProductInt16_Transformed_Fixed(params short[] source)
    {
        short expected = 1;
        foreach (short item in source)
        {
            expected *= (short)(item * 2);
        }

        short actual = source.Product(n => (short)(n * 2));

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ProductInt16_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new short[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (short)random.Next(1, 100);
            }

            short expected = 1;
            foreach (short item in source)
            {
                expected *= item;
            }

            short actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductInt16_Transformed_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new short[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (short)random.Next(1, 100);
            }

            short expected = 1;
            foreach (short item in source)
            {
                expected *= (short)(item * 2);
            }

            short actual = source.Product(n => (short)(n * 2));

            Assert.AreEqual(expected, actual);
        }
    }
}
