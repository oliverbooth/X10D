namespace X10D.Reactive;

/// <summary>
///     Provides extension methods for <see cref="Progress{T}" />.
/// </summary>
public static class ProgressExtensions
{
    /// <summary>
    ///     Wraps the <see cref="Progress{T}.ProgressChanged" /> event of the current <see cref="Progress{T}" /> in an
    ///     <see cref="IObservable{T}" /> object.
    /// </summary>
    /// <param name="progress">The progress whose <see cref="Progress{T}.ProgressChanged" /> event to wrap.</param>
    /// <typeparam name="T">The type of progress update value.</typeparam>
    /// <returns>
    ///     An <see cref="IObservable{T}" /> object that wraps the <see cref="Progress{T}.ProgressChanged" /> event of the current
    ///     <see cref="Progress{T}" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="progress" /> is <see langword="null" />.</exception>
    public static IObservable<T> OnProgressChanged<T>(this Progress<T> progress)
    {
        if (progress is null)
        {
            throw new ArgumentNullException(nameof(progress));
        }

        var progressObservable = new ProgressObservable<T>();

        void ProgressChangedHandler(object? sender, T args)
        {
            IObserver<T>[] observers = progressObservable.Observers;

            for (var index = 0; index < observers.Length; index++)
            {
                observers[index].OnNext(args);
            }
        }

        progress.ProgressChanged += ProgressChangedHandler;
        progressObservable.OnDispose = () => progress.ProgressChanged -= ProgressChangedHandler;

        return progressObservable;
    }

    /// <summary>
    ///     Wraps the <see cref="Progress{T}.ProgressChanged" /> event of the current <see cref="Progress{T}" /> in an
    ///     <see cref="IObservable{T}" /> object, and completes the observable when the progress reaches the specified value.
    /// </summary>
    /// <param name="progress">The progress whose <see cref="Progress{T}.ProgressChanged" /> event to wrap.</param>
    /// <param name="completeValue">The value that indicates completion.</param>
    /// <typeparam name="T">The type of progress update value.</typeparam>
    /// <returns>
    ///     An <see cref="IObservable{T}" /> object that wraps the <see cref="Progress{T}.ProgressChanged" /> event of the current
    ///     <see cref="Progress{T}" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="progress" /> is <see langword="null" />.</exception>
    public static IObservable<T> OnProgressChanged<T>(this Progress<T> progress, T completeValue)
    {
        if (progress is null)
        {
            throw new ArgumentNullException(nameof(progress));
        }

        var progressObservable = new ProgressObservable<T>();
        var comparer = EqualityComparer<T>.Default;

        void ProgressChangedHandler(object? sender, T args)
        {
            IObserver<T>[] observers = progressObservable.Observers;

            for (var index = 0; index < observers.Length; index++)
            {
                observers[index].OnNext(args);
            }

            if (comparer.Equals(args, completeValue))
            {
                for (var index = 0; index < observers.Length; index++)
                {
                    observers[index].OnCompleted();
                }
            }
        }

        progress.ProgressChanged += ProgressChangedHandler;
        progressObservable.OnDispose = () => progress.ProgressChanged -= ProgressChangedHandler;

        return progressObservable;
    }
}
