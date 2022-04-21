using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Core;

public partial class EnumerableTests
{
    [TestMethod]
    [DataRow(0u, 1u)]
    [DataRow(2u, 3u, 4u)]
    [DataRow(1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 10u)] // 10!
    public void ProductUInt32_Fixed(params uint[] source)
    {
        var expected = 1u;
        foreach (uint item in source)
        {
            expected *= item;
        }

        uint actual = source.Product();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0u, 1u)]
    [DataRow(2u, 3u, 4u)]
    [DataRow(1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 10u)] // 10!
    public void ProductUInt32_Transformed_Fixed(params uint[] source)
    {
        var expected = 1u;
        foreach (uint item in source)
        {
            expected *= item * 2;
        }

        uint actual = source.Product(n => n * 2);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ProductUInt32_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new uint[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (uint) random.Next(1, 100);
            }

            var expected = 1u;
            foreach (uint item in source)
            {
                expected *= item;
            }

            uint actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductUInt32_Transformed_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new uint[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (uint) random.Next(1, 100);
            }

            var expected = 1u;
            foreach (uint item in source)
            {
                expected *= item * 2;
            }

            uint actual = source.Product(n => n * 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
