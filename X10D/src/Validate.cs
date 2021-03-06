using System;

namespace X10D
{
    internal static class Validate
    {
        public static void IsDefined<T>(T value, string argumentName)
            where T : Enum
        {
            if (!Enum.IsDefined(typeof(T), value))
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }
        
        public static void IsNotNull<T>(T argument, string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
