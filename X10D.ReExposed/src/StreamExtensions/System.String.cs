namespace X10D.ReExposed.StreamExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StreamExtensions
{
    /// <inheritdoc cref="Stream.Synchronized(Stream)"/>
    public static Stream Synchronized(this Stream stream)
    {
        return Stream.Synchronized(stream);
    }
}