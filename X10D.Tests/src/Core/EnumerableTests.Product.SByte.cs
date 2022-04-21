using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Core;

public partial class EnumerableTests
{
    [TestMethod]
    [DataRow((sbyte)0, (sbyte)1)]
    [DataRow((sbyte)2, (sbyte)3, (sbyte)4)]
    [DataRow((sbyte)1, (sbyte)2, (sbyte)3, (sbyte)4, (sbyte)5, (sbyte)6, (sbyte)7, (sbyte)8, (sbyte)9, (sbyte)10)] // 10!
    public void ProductSByte_Fixed(params sbyte[] source)
    {
        sbyte expected = 1;
        foreach (sbyte item in source)
        {
            expected *= item;
        }

        sbyte actual = source.Product();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow((sbyte)0, (sbyte)1)]
    [DataRow((sbyte)2, (sbyte)3, (sbyte)4)]
    [DataRow((sbyte)1, (sbyte)2, (sbyte)3, (sbyte)4, (sbyte)5, (sbyte)6, (sbyte)7, (sbyte)8, (sbyte)9, (sbyte)10)] // 10!
    public void ProductSByte_Transformed_Fixed(params sbyte[] source)
    {
        sbyte expected = 1;
        foreach (sbyte item in source)
        {
            expected *= (sbyte)(item * 2);
        }

        sbyte actual = source.Product(n => (sbyte)(n * 2));

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ProductSByte_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new sbyte[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (sbyte)random.Next(1, 100);
            }

            sbyte expected = 1;
            foreach (sbyte item in source)
            {
                expected *= item;
            }

            sbyte actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductSByte_Transformed_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new sbyte[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (sbyte)random.Next(1, 100);
            }

            sbyte expected = 1;
            foreach (sbyte item in source)
            {
                expected *= (sbyte)(item * 2);
            }

            sbyte actual = source.Product(n => (sbyte)(n * 2));

            Assert.AreEqual(expected, actual);
        }
    }
}
