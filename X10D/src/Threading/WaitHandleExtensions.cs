namespace X10D.Threading;

/// <summary>
///     Threading-related extension methods for <see cref="WaitHandle" />.
/// </summary>
public static class WaitHandleExtensions
{
    /// <summary>
    ///     Returns a <see cref="Task" /> which can be awaited until the current <see cref="WaitHandle" /> receives a signal.
    /// </summary>
    /// <param name="handle">The <see cref="WaitHandle" /> instance.</param>
    /// <returns>
    ///     <see langword="true" /> if the current instance receives a signal. If the current instance is never signaled,
    ///     <see cref="WaitOneAsync" /> never returns.
    /// </returns>
    /// <remarks>
    ///     It is heavily recommended that the use of this method is minimal, or non-existent. For suspension of execution when
    ///     performing an asynchronous operation, use <see cref="TaskCompletionSource" /> or
    ///     <see cref="TaskCompletionSource{TResult}" />.
    /// </remarks>
    [Obsolete("Consider using a TaskCompletionSource instead.")]
    public static Task<bool> WaitOneAsync(this WaitHandle handle)
    {
        if (handle is null)
        {
            throw new ArgumentNullException(nameof(handle));
        }

        return Task.Run(handle.WaitOne);
    }
}
