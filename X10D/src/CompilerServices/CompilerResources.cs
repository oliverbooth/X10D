using System.Runtime.CompilerServices;

namespace X10D.CompilerServices;

internal static class CompilerResources
{
#if NETCOREAPP3_0_OR_GREATER
    public const MethodImplOptions MaxOptimization = System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining | 
                                                     System.Runtime.CompilerServices.MethodImplOptions.AggressiveOptimization;
#else
    public const MethodImplOptions MaxOptimization = System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining;
#endif
}
