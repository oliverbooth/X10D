using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Core;

public partial class EnumerableTests
{
    [TestMethod]
    [DataRow(0, 1)]
    [DataRow(2, 3, 4)]
    [DataRow(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)] // 10!
    public void ProductInt32_Fixed(params int[] source)
    {
        var expected = 1;
        foreach (int item in source)
        {
            expected *= item;
        }

        int actual = source.Product();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0, 1)]
    [DataRow(2, 3, 4)]
    [DataRow(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)] // 10!
    public void ProductInt32_Transformed_Fixed(params int[] source)
    {
        var expected = 1;
        foreach (int item in source)
        {
            expected *= item * 2;
        }

        int actual = source.Product(n => n * 2);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ProductInt32_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new int[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = random.Next(1, 100);
            }

            var expected = 1;
            foreach (int item in source)
            {
                expected *= item;
            }

            int actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductInt32_Transformed_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new int[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = random.Next(1, 100);
            }

            var expected = 1;
            foreach (int item in source)
            {
                expected *= item * 2;
            }

            int actual = source.Product(n => n * 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
