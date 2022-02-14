namespace X10D
{
    public static partial class StreamExtensions
    {
        private static unsafe byte[] ReadInternal<T>(this Stream stream, Endianness endianness)
            where T : unmanaged
        {
            var buffer = new byte[sizeof(T)];
            stream.Read(buffer, 0, buffer.Length);
            SwapIfNeeded(ref buffer, endianness);
            return buffer;
        }

        private static void SwapIfNeeded(ref byte[] buffer, Endianness endianness)
        {
            var swapNeeded = BitConverter.IsLittleEndian == (endianness == Endianness.BigEndian);
            if (swapNeeded)
            {
                Array.Reverse(buffer);
            }
        }

        private static int WriteInternal(this Stream stream, byte[] value, Endianness endianness)
        {
            var clone = (byte[])value.Clone();
            SwapIfNeeded(ref clone, endianness);
            var preWritePosition = stream.Position;
            stream.Write(clone, 0, clone.Length);
            return (int)(stream.Position - preWritePosition);
        }

        private static int WriteInternal(this Stream stream, Span<byte> value)
        {
            var preWritePosition = stream.Position;
            stream.Write(value);
            return (int)(stream.Position - preWritePosition);
        }
    }
}
