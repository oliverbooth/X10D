namespace X10D;

/// <summary>
///     Represents an object which provides the status of the support of AVX2 instructions.
/// </summary>
public interface IAvx2SupportProvider
{
    /// <summary>
    ///     Gets a value indicating whether AVX2 instructions are supported on this platform.
    /// </summary>
    /// <value><see langword="true" /> if AVX2 instructions are supported; otherwise, <see langword="false" />.</value>
    bool IsSupported { get; }
}
