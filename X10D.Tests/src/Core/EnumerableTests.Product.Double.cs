using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Linq;

namespace X10D.Tests.Core;

public partial class EnumerableTests
{
    [TestMethod]
    [DataRow(0.0, 1.0)]
    [DataRow(2.0, 3.0, 4.0)]
    [DataRow(1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0)] // 10!
    public void ProductDouble_Fixed(params double[] source)
    {
        var expected = 1.0;
        foreach (double item in source)
        {
            expected *= item;
        }

        double actual = source.Product();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(0.0, 1.0)]
    [DataRow(2.0, 3.0, 4.0)]
    [DataRow(1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0)] // 10!
    public void ProductDouble_Transformed_Fixed(params double[] source)
    {
        var expected = 1.0;
        foreach (double item in source)
        {
            expected *= item * 2;
        }

        double actual = source.Product(n => n * 2);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ProductDouble_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new double[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = random.NextDouble();
            }

            var expected = 1.0;
            foreach (double item in source)
            {
                expected *= item;
            }

            double actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductDouble_Transformed_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new double[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = random.NextDouble();
            }

            var expected = 1.0;
            foreach (double item in source)
            {
                expected *= item * 2;
            }

            double actual = source.Product(n => n * 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
