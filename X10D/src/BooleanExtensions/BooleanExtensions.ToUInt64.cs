namespace X10D.BooleanExtensions
{
    public static partial class BooleanExtensions
    {
        /// <summary>
        ///     Converts the current <see cref="bool" /> to an 8-byte unsigned integer representing its truthiness.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>
        ///     <c>1</c> if <paramref name="value" /> is <see langword="true"/>
        ///     -or-
        ///     <c>0</c> otherwise.
        /// </returns>
        public static ulong ToUInt64(this bool value)
        {
            return value.ToByte();
        }
    }
}
