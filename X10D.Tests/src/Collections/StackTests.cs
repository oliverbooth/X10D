using NUnit.Framework;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestFixture]
internal class StackTests
{
    [Test]
    public void PushAll_ShouldThrowArgumentNullException_GivenNullStack()
    {
        Stack<int> stack = null!;
        Assert.Throws<ArgumentNullException>(() => stack.PushAll([]));
    }

    [Test]
    public void PushAll_ShouldThrowArgumentNullException_GivenNullElements()
    {
        var stack = new Stack<int>();
        Assert.Throws<ArgumentNullException>(() => stack.PushAll(null!));
    }

    [Test]
    public void PopAll_ShouldThrowArgumentNullException_GivenNullStack()
    {
        Stack<int> stack = null!;
        Assert.Throws<ArgumentNullException>(() => _ = stack.PopAll().ToArray());
    }

    [Test]
    public void PushAll_ShouldAddElementsToStack_GivenValidEnumerable()
    {
        var stack = new Stack<int>();
        int[] elements = [1, 2, 3, 4, 5];

        Assert.That(stack, Is.Empty);

        stack.PushAll(elements);

        Assert.That(stack, Is.Not.Empty);
        Assert.That(stack, Has.Count.EqualTo(5));

        var index = 4;
        foreach (int i in stack)
        {
            Assert.That(i, Is.EqualTo(elements[index]));
            index--;
        }
    }

    [Test]
    public void PopAll_ShouldRemoveElementsFromStack()
    {
        var stack = new Stack<int>([1, 2, 3, 4, 5]);

        Assert.That(stack, Is.Not.Empty);
        Assert.That(stack, Has.Count.EqualTo(5));

        var index = 5;
        foreach (int i in stack.PopAll())
        {
            Assert.That(i, Is.EqualTo(index));
            index--;
        }

        Assert.That(stack, Is.Empty);
    }
}
