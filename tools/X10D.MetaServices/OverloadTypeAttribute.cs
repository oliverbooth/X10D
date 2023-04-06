namespace X10D.MetaServices;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
internal sealed class OverloadTypeAttribute : Attribute
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="OverloadTypeAttribute"/> class.
    /// </summary>
    /// <param name="types">The types to overload.</param>
    public OverloadTypeAttribute(params Type[] types)
    {
        Types = (Type[])types.Clone();
    }

    /// <summary>
    ///     Gets an array of types to overload.
    /// </summary>
    /// <value>An array of types to overload.</value>
    public Type[] Types { get; }
}
