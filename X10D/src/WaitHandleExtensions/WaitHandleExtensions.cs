namespace X10D
{
    /// <summary>
    ///     Extension methods for <see cref="WaitHandle" />.
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
        public static Task<bool> WaitOneAsync(this WaitHandle handle)
        {
            if (handle is null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            return Task.Run(handle.WaitOne);
        }
    }
}
