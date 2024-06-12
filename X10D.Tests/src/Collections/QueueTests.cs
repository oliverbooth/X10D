using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestFixture]
internal class QueueTests
{
    [Test]
    public void EnqueueAll_ShouldThrowArgumentNullException_GivenNullQueue()
    {
        Queue<int> queue = null!;
        Assert.Throws<ArgumentNullException>(() => queue.EnqueueAll([]));
    }

    [Test]
    public void EnqueueAll_ShouldThrowArgumentNullException_GivenNullElements()
    {
        var queue = new Queue<int>();
        Assert.Throws<ArgumentNullException>(() => queue.EnqueueAll(null!));
    }

    [Test]
    public void DequeueAll_ShouldThrowArgumentNullException_GivenNullQueue()
    {
        Queue<int> queue = null!;
        Assert.Throws<ArgumentNullException>(() => _ = queue.DequeueAll().ToArray());
    }

    [Test]
    public void EnqueueAll_ShouldAddElementsToQueue_GivenValidEnumerable()
    {
        var queue = new Queue<int>();
        int[] elements = [1, 2, 3, 4, 5];

        Assert.That(queue, Is.Empty);

        queue.EnqueueAll(elements);

        Assert.That(queue, Is.Not.Empty);
        Assert.That(queue, Has.Count.EqualTo(5));

        var index = 0;
        foreach (int i in queue)
        {
            Assert.That(i, Is.EqualTo(elements[index]));
            index++;
        }
    }

    [Test]
    public void DequeueAll_ShouldRemoveElementsFromQueue()
    {
        var queue = new Queue<int>([1, 2, 3, 4, 5]);

        Assert.That(queue, Is.Not.Empty);
        Assert.That(queue, Has.Count.EqualTo(5));

        var index = 1;
        foreach (int i in queue.DequeueAll())
        {
            Assert.That(i, Is.EqualTo(index));
            index++;
        }

        Assert.That(queue, Is.Empty);
    }
}
