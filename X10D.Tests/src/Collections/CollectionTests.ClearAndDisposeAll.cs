using System.Collections.ObjectModel;
using Moq;
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
            var mock1 = new Mock<IDisposable>();
            var mock2 = new Mock<IDisposable>();
            var mock3 = new Mock<IDisposable>();
            var list = new List<IDisposable> {mock1.Object, mock2.Object, mock3.Object};

            list.ClearAndDisposeAll();

            mock1.Verify(i => i.Dispose(), Times.Once);
            mock2.Verify(i => i.Dispose(), Times.Once);
            mock3.Verify(i => i.Dispose(), Times.Once);
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
            var mock = new Mock<IDisposable>();
            var list = new ReadOnlyCollection<IDisposable>(new List<IDisposable> {mock.Object});

            Assert.Throws<InvalidOperationException>(() => list.ClearAndDisposeAll());
        }
    }
}
