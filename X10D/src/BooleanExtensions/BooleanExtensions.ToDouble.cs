namespace X10D.BooleanExtensions
{
    public static partial class BooleanExtensions
    {
        /// <summary>
        ///     Converts the current <see cref="bool" /> to a double-precision floating-point number representing its truthiness.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>
        ///     <c>1</c> if <paramref name="value" /> is <see langword="true"/>
        ///     -or-
        ///     <c>0</c> otherwise.
        /// </returns>
        public static long ToDouble(this bool value)
        {
            return value.ToByte();
        }
    }
}
