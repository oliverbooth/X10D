using System.ComponentModel;

namespace X10D
{
    /// <summary>
    ///     Represents an enumeration of endianness values.
    /// </summary>
    public enum Endianness
    {
        /// <summary>
        ///     The value should be read as though it uses little endian encoding.
        /// </summary>
        [Description("The value should be read as though it uses little endian encoding.")]
        LittleEndian,

        /// <summary>
        ///     The value should be read as though it uses big endian encoding.
        /// </summary>
        [Description("The value should be read as though it uses big endian encoding.")]
        BigEndian
    }
}
