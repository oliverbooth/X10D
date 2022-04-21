using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Core;

public partial class EnumerableTests
{
    [TestMethod]
    [DataRow(0L, 1L)]
    [DataRow(2L, 3L, 4L)]
    [DataRow(1L, 2L, 3L, 4L, 5L, 6L, 7L, 8L, 9L, 10L)] // 10!
    public void ProductInt64_Fixed(params long[] source)
    {
        var expected = 1L;
        foreach (long item in source)
        {
            expected *= item;
        }

        long actual = source.Product();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0L, 1L)]
    [DataRow(2L, 3L, 4L)]
    [DataRow(1L, 2L, 3L, 4L, 5L, 6L, 7L, 8L, 9L, 10L)] // 10!
    public void ProductInt64_Transformed_Fixed(params long[] source)
    {
        var expected = 1L;
        foreach (long item in source)
        {
            expected *= item * 2;
        }

        long actual = source.Product(n => n * 2);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ProductInt64_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new long[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = random.NextInt64(1, 100);
            }

            var expected = 1L;
            foreach (long item in source)
            {
                expected *= item;
            }

            long actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductInt64_Transformed_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new long[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = random.NextInt64(1, 100);
            }

            var expected = 1L;
            foreach (long item in source)
            {
                expected *= item * 2;
            }

            long actual = source.Product(n => n * 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
