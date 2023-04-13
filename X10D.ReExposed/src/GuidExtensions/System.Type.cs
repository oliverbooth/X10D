﻿namespace X10D.ReExposed.GuidExtensions;

/// <summary>
///     Extension methods for <see cref="Guid"/>.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public static class GuidExtensions
{
    /// <inheritdoc cref="Type.GetTypeFromCLSID(Guid,string,bool)"/>
    [SupportedOSPlatform("windows")]
    public static Type? GetTypeFromCLSID(this Guid clsid, string? server, bool throwOnError)
    {
        return Type.GetTypeFromCLSID(clsid, server, throwOnError);
    }
}