using System.Runtime.CompilerServices;

namespace X10D.CompilerServices;

internal static class CompilerResources
{
    public const MethodImplOptions MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining |
                                                       System.Runtime.CompilerServices.MethodImplOptions.AggressiveOptimization;
}
