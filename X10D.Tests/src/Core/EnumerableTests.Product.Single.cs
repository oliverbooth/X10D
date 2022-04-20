using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

public partial class EnumerableTests
{
    [TestMethod]
    [DataRow(0f, 1f)]
    [DataRow(2f, 3f, 4f)]
    [DataRow(1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f)] // 10!
    public void ProductSingle_Fixed(params float[] source)
    {
        var expected = 1f;
        foreach (float item in source)
        {
            expected *= item;
        }

        float actual = source.Product();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0f, 1f)]
    [DataRow(2f, 3f, 4f)]
    [DataRow(1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f)] // 10!
    public void ProductSingle_Transformed_Fixed(params float[] source)
    {
        var expected = 1f;
        foreach (float item in source)
        {
            expected *= item * 2;
        }

        float actual = source.Product(n => n * 2);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ProductSingle_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new float[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (float)random.NextDouble();
            }

            var expected = 1f;
            foreach (float item in source)
            {
                expected *= item;
            }

            float actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductSingle_Transformed_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new float[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (float)random.NextDouble();
            }

            var expected = 1f;
            foreach (float item in source)
            {
                expected *= item * 2;
            }

            float actual = source.Product(n => n * 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
