using System;

namespace X10D
{
    internal static class ExceptionMessages
    {
        public static readonly string TypeDoesNotInheritAttribute = $"{{0}} does not inherit {typeof(Attribute)}";
        public static readonly string TypeIsNotClass = $"{{0}} is not a class";
        public static readonly string TypeIsNotInterface = $"{{0}} is not an interface";
    }
}
