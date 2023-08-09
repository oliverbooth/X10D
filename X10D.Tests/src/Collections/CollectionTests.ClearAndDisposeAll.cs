using System.Collections.ObjectModel;
using NSubstitute;
using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

public partial class CollectionTests
{
    [TestFixture]
    public class ClearAndDisposeAllTests
    {
        [Test]
        public void ClearAndDisposeAll_ShouldClearAndDisposeAllItems_WhenCalledWithValidList()
        {
            var substitute1 = Substitute.For<IDisposable>();
            var substitute2 = Substitute.For<IDisposable>();
            var substitute3 = Substitute.For<IDisposable>();
            var list = new List<IDisposable> {substitute1, substitute2, substitute3};

            list.ClearAndDisposeAll();

            substitute1.Received(1).Dispose();
            substitute2.Received(1).Dispose();
            substitute3.Received(1).Dispose();

            Assert.That(list, Is.Empty);
        }

        [Test]
        public void ClearAndDisposeAll_ShouldThrowArgumentNullException_WhenCalledWithNullList()
        {
            List<IDisposable>? list = null;
            Assert.Throws<ArgumentNullException>(() => list!.ClearAndDisposeAll());
        }

        [Test]
        public void ClearAndDisposeAll_ShouldThrowInvalidOperationException_WhenCalledWithReadOnlyList()
        {
            var substitute = Substitute.For<IDisposable>();
            var list = new ReadOnlyCollection<IDisposable>(new List<IDisposable> {substitute});

            Assert.Throws<InvalidOperationException>(() => list.ClearAndDisposeAll());
        }
    }
}
