using NSubstitute;
using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

public partial class EnumerableTests
{
    [TestFixture]
    public class DisposeAllTests
    {
        [Test]
        public void DisposeAll_ShouldDisposeAllItems_WhenCalledWithValidList()
        {
            var substitute1 = Substitute.For<IDisposable>();
            var substitute2 = Substitute.For<IDisposable>();
            var substitute3 = Substitute.For<IDisposable>();
            var list = new List<IDisposable> { substitute1, substitute2, null!, substitute3 };

            list.DisposeAll();

            substitute1.Received(1).Dispose();
            substitute2.Received(1).Dispose();
            substitute3.Received(1).Dispose();
        }

        [Test]
        public void DisposeAll_ShouldThrowArgumentNullException_WhenCalledWithNullList()
        {
            List<IDisposable> list = null!;
            Assert.Throws<ArgumentNullException>(() => list.DisposeAll());
        }
    }
}
