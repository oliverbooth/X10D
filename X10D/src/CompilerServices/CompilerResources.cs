using System.Runtime.CompilerServices;

namespace X10D.CompilerServices;

internal static class CompilerResources
{
    public const MethodImplOptions MaxOptimization = MethodImplOptions.AggressiveInlining |
                                                     MethodImplOptions.AggressiveOptimization;
}
