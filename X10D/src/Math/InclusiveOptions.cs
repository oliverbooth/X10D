namespace X10D.Math;

/// <summary>
///     Provides options for <see cref="ComparableExtensions.Between{T1,T2,T3}" /> clusivity.
/// </summary>
[Flags]
public enum InclusiveOptions : byte
{
    /// <summary>
    ///     Indicates that the comparison will be exclusive.
    /// </summary>
    None = 0,

    /// <summary>
    ///     Indicates that the comparison will treat the upper bound as exclusive.
    /// </summary>
    UpperInclusive = 1,

    /// <summary>
    ///     Indicates that the comparison will treat the lower bound as exclusive.
    /// </summary>
    LowerInclusive = 1 << 1,

    /// <summary>
    ///     Indicates that the comparison will treat both the upper and lower bound as exclusive.
    /// </summary>
    Inclusive = UpperInclusive | LowerInclusive
}
