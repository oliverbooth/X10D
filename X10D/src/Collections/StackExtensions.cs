namespace X10D.Collections;

/// <summary>
///     Extension methods for <see cref="Stack{T}" />.
/// </summary>
public static class StackExtensions
{
    /// <summary>
    ///     Adds an enumerable collection of objects to the top of the <see cref="Stack{T}" />, in the order that they were
    ///     enumerated.
    /// </summary>
    /// <param name="stack">The stack to which the elements will be added.</param>
    /// <param name="values">An enumerable collection of elements to push.</param>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <exception cref="ArgumentNullException">
    ///     <para><paramref name="stack" /> is <see langword="null" />.</para>
    ///     -or-
    ///     <para><paramref name="values" /> is <see langword="null" />.</para>
    /// </exception>
    public static void PushAll<TElement>(this Stack<TElement> stack, IEnumerable<TElement> values)
    {
        if (stack is null)
        {
            throw new ArgumentNullException(nameof(stack));
        }

        if (values is null)
        {
            throw new ArgumentNullException(nameof(values));
        }

        foreach (TElement element in values)
        {
            stack.Push(element);
        }
    }

    /// <summary>
    ///     Removes and returns each element from the stack starting at the top, until the stack is empty.
    /// </summary>
    /// <param name="stack">The stack from which the elements will be removed.</param>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <exception cref="ArgumentNullException"><paramref name="stack" /> is <see langword="null" />.</exception>
    public static IEnumerable<TElement> PopAll<TElement>(this Stack<TElement> stack)
    {
        if (stack is null)
        {
            throw new ArgumentNullException(nameof(stack));
        }

        while (stack.Count > 0)
        {
            yield return stack.Pop();
        }
    }
}
