using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

public partial class EnumerableTests
{
    [TestMethod]
    [DataRow(0UL, 1UL)]
    [DataRow(2UL, 3UL, 4UL)]
    [DataRow(1UL, 2UL, 3UL, 4UL, 5UL, 6UL, 7UL, 8UL, 9UL, 10UL)] // 10!
    public void ProductUInt64_Fixed(params ulong[] source)
    {
        var expected = 1UL;
        foreach (ulong item in source)
        {
            expected *= item;
        }

        ulong actual = source.Product();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0UL, 1UL)]
    [DataRow(2UL, 3UL, 4UL)]
    [DataRow(1UL, 2UL, 3UL, 4UL, 5UL, 6UL, 7UL, 8UL, 9UL, 10UL)] // 10!
    public void ProductUInt64_Transformed_Fixed(params ulong[] source)
    {
        var expected = 1UL;
        foreach (ulong item in source)
        {
            expected *= item * 2;
        }

        ulong actual = source.Product(n => n * 2);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ProductUInt64_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new ulong[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (ulong) random.NextInt64(1, 100);
            }

            var expected = 1UL;
            foreach (ulong item in source)
            {
                expected *= item;
            }

            ulong actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductUInt64_Transformed_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new ulong[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (ulong) random.NextInt64(1, 100);
            }

            var expected = 1UL;
            foreach (ulong item in source)
            {
                expected *= item * 2;
            }

            ulong actual = source.Product(n => n * 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
