using System;
using System.Threading;
using System.Threading.Tasks;

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
        /// <returns>A task which encapsulates <see cref="WaitHandle.WaitOne()" />.</returns>
        public static Task WaitOneAsync(this WaitHandle handle)
        {
            if (handle is null)
            {
                throw new ArgumentNullException(nameof(handle));
            }

            return new Task(() => handle.WaitOne());
        }
    }
}
