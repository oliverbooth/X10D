namespace X10D.Reactive;

/// <summary>
///     Represents a disposable that removes an observer from a collection of observers.
/// </summary>
internal readonly struct ObservableDisposer<T> : IDisposable
{
    private readonly HashSet<IObserver<T>> _observers;
    private readonly IObserver<T> _observer;
    private readonly Action? _additionalAction;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableDisposer{T}" /> struct.
    /// </summary>
    /// <param name="observers">A collection of observers from which to remove the specified observer.</param>
    /// <param name="observer">The observer to remove from the collection.</param>
    /// <param name="additionalAction">The additional action to run on dispose.</param>
    public ObservableDisposer(HashSet<IObserver<T>> observers, IObserver<T> observer, Action? additionalAction)
    {
        _observers = observers ?? throw new ArgumentNullException(nameof(observers));
        _observer = observer ?? throw new ArgumentNullException(nameof(observer));
        _additionalAction = additionalAction;
    }

    /// <summary>
    ///     Removes the observer from the collection of observers.
    /// </summary>
    public void Dispose()
    {
        _observers.Remove(_observer);
        _additionalAction?.Invoke();
    }
}
