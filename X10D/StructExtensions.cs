namespace X10D
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// A set of extension methods for <see langword="struct"/> types.
    /// </summary>
    public static class StructExtensions
    {
        public static T Next<T>(this T src, bool wrap = true) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");
            }

            T[] arr = (T[])Enum.GetValues(src.GetType());
            int j   = Array.IndexOf(arr, src) + 1;
            return arr.Length == j ? arr[wrap ? 0 : j - 1] : arr[j];
        }

        public static T Previous<T>(this T src, bool wrap = true) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");
            }

            T[] arr = (T[])Enum.GetValues(src.GetType());
            int j   = Array.IndexOf(arr, src) - 1;
            return j < 0 ? arr[wrap ? arr.Length - 1 : 0] : arr[j];
        }
    }
}
