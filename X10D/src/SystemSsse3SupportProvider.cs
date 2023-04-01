#if NETCOREAPP3_0_OR_GREATER
using System.Runtime.Intrinsics.X86;
#endif

namespace X10D;

internal struct SystemSsse3SupportProvider : ISsse3SupportProvider
{
    /// <inheritdoc />
    public bool IsSupported
    {
#if NETCOREAPP3_0_OR_GREATER
        get => Sse3.IsSupported;
#else
        get => false;
#endif
    }
}
