namespace X10D;

/// <summary>
///     Represents an object which provides the status of the support of SSSE3 instructions.
/// </summary>
public interface ISsse3SupportProvider
{
    /// <summary>
    ///     Gets a value indicating whether SSSE3 instructions are supported on this platform.
    /// </summary>
    /// <value><see langword="true" /> if SSSE3 instructions are supported; otherwise, <see langword="false" />.</value>
    bool IsSupported { get; }
}
