namespace X10D.Reactive;

/// <summary>
///     Represents a concrete implementation of <see cref="IObservable{T}" /> that tracks progress of a <see cref="Progress{T}"/>.
/// </summary>
internal sealed class ProgressObservable<T> : IObservable<T>
{
    private readonly HashSet<IObserver<T>> _observers = new();

    /// <summary>
    ///     Gets the observers.
    /// </summary>
    /// <value>The observers.</value>
    public IObserver<T>[] Observers
    {
        get => _observers.ToArray();
    }

    internal Action? OnDispose { get; set; }

    /// <summary>
    ///     Subscribes the specified observer to the progress tracker.
    /// </summary>
    /// <param name="observer">The observer.</param>
    /// <returns>An object which can be disposed to unsubscribe from progress tracking.</returns>
    public IDisposable Subscribe(IObserver<T> observer)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(observer);
#else
        if (observer is null)
        {
            throw new ArgumentNullException(nameof(observer));
        }
#endif

        _observers.Add(observer);
        return new ObservableDisposer<T>(_observers, observer, OnDispose);
    }
}
