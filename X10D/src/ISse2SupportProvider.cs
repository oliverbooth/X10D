namespace X10D;

/// <summary>
///     Represents an object which provides the status of the support of SSE2 instructions.
/// </summary>
public interface ISse2SupportProvider
{
    /// <summary>
    ///     Gets a value indicating whether SSE2 instructions are supported on this platform.
    /// </summary>
    /// <value><see langword="true" /> if SSE2 instructions are supported; otherwise, <see langword="false" />.</value>
    bool IsSupported { get; }
}
