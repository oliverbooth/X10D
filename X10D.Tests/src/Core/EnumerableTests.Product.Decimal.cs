using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X10D.Tests.Core;

public partial class EnumerableTests
{
    // the Fixed methods in these tests can't use DataRow attribute because the use of a decimal literal compiles to an
    // instantiation of the decimal struct, which is not a compile-time constant expression.
    // thanks. I fucking hate it.
    
    [TestMethod]
    public void ProductDecimal_Fixed()
    {
        {
            var source = new[] {0m, 1m};
            var expected = 1m;
            foreach (decimal item in source)
            {
                expected *= item;
            }

            decimal actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
        {
            
            var source = new[] {2m, 3m, 4m};
            var expected = 1m;
            foreach (decimal item in source)
            {
                expected *= item;
            }

            decimal actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
        {
            
            var source = new[] {1m, 2m, 3m, 4m, 5m, 6m, 7m, 8m, 9m, 10m};
            var expected = 1m;
            foreach (decimal item in source)
            {
                expected *= item;
            }

            decimal actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductDecimal_Transformed_Fixed()
    {
        {
            var source = new[] {0m, 1m};
            var expected = 1m;
            foreach (decimal item in source)
            {
                expected *= item * 2;
            }

            decimal actual = source.Product(n => n * 2);

            Assert.AreEqual(expected, actual);
        }
        {
            var source = new[] {2m, 3m, 4m};
            var expected = 1m;
            foreach (decimal item in source)
            {
                expected *= item * 2;
            }

            decimal actual = source.Product(n => n * 2);

            Assert.AreEqual(expected, actual);
        }
        {
            var source = new[] {1m, 2m, 3m, 4m, 5m, 6m, 7m, 8m, 9m, 10m};
            var expected = 1m;
            foreach (decimal item in source)
            {
                expected *= item * 2;
            }

            decimal actual = source.Product(n => n * 2);

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductDecimal_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new decimal[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (decimal)random.NextDouble();
            }

            var expected = 1m;
            foreach (decimal item in source)
            {
                expected *= item;
            }

            decimal actual = source.Product();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestMethod]
    public void ProductDecimal_Transformed_Random1000()
    {
        var random = new Random();

        for (var i = 0; i < 1000; i++)
        {
            var source = new decimal[10];
            for (var j = 0; j < source.Length; j++)
            {
                source[j] = (decimal)random.NextDouble();
            }

            var expected = 1m;
            foreach (decimal item in source)
            {
                expected *= item * 2;
            }

            decimal actual = source.Product(n => n * 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
