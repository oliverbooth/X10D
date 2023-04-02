using System.Diagnostics.CodeAnalysis;
#if NETCOREAPP3_0_OR_GREATER
using System.Runtime.Intrinsics.X86;
#endif

namespace X10D;

[ExcludeFromCodeCoverage]
internal struct SystemAvx2SupportProvider : IAvx2SupportProvider
{
    /// <inheritdoc />
    public bool IsSupported
    {
#if NETCOREAPP3_0_OR_GREATER
        get => Avx2.IsSupported;
#else
        get => false;
#endif
    }
}
