using System.ComponentModel;

namespace X10D
{
    /// <summary>
    ///     Represents an enumeration of endianness values.
    /// </summary>
    public enum Endianness
    {
        [Description("The value should be read as though it uses little endian encoding.")]
        LittleEndian,

        [Description("The value should be read as though it uses big endian encoding.")]
        BigEndian
    }
}
