using System;

namespace X10D
{
    internal static class Util
    {
        public static void SwapIfNeeded(ref byte[] buffer, Endianness endianness)
        {
            if (buffer is null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            var swapNeeded = BitConverter.IsLittleEndian == (endianness == Endianness.BigEndian);
            if (swapNeeded)
            {
                Array.Reverse(buffer);
            }
        }
    }
}
