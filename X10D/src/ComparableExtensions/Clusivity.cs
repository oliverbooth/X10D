namespace X10D;

/// <summary>
///     Provides options for <see cref="ComparableExtensions.Between{T1, T2, T3}" /> clusivity.
/// </summary>
[Flags]
public enum Clusivity : byte
{
    /// <summary>
    ///     Indicates that the comparison will be exclusive. 
    /// </summary>
    Exclusive,
    
    /// <summary>
    ///     Indicates that the comparison will treat the upper bound as exclusive. 
    /// </summary>
    UpperInclusive,
    
    /// <summary>
    ///     Indicates that the comparison will treat the lower bound as exclusive. 
    /// </summary>
    LowerInclusive,
    
    /// <summary>
    ///     Indicates that the comparison will treat both the upper and lower bound as exclusive. 
    /// </summary>
    Inclusive
}
