using System.Text;

namespace X10D.Text;

// NOTE: the overriden async overloads simply wrap the result of their sync counterparts because StringBuilder isn't inherently
// async. calling Task.FromResult (or creating a new ValueTask) is sufficient enough in this case, because there is simply no
// other way to have native async reading of a StringBuilder

/// <summary>
///     Represents a <see cref="TextReader"/> reads from a <see cref="StringBuilder" />.
/// </summary>
public class StringBuilderReader : TextReader
{
    private readonly StringBuilder _stringBuilder;
    private int _index;

    /// <summary>
    ///     Initializes a new instance of the <see cref="StringBuilderReader" /> class.
    /// </summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder" /> to wrap.</param>
    /// <exception cref="ArgumentNullException"><paramref name="stringBuilder" /> is <see langword="null" />.</exception>
    public StringBuilderReader(StringBuilder stringBuilder)
    {
        _stringBuilder = stringBuilder ?? throw new ArgumentNullException(nameof(stringBuilder));
    }

    /// <inheritdoc />
    public override void Close()
    {
        _index = _stringBuilder.Length;
    }

    /// <inheritdoc />
    public override int Peek()
    {
        if (_index >= _stringBuilder.Length)
        {
            return -1;
        }

        return _stringBuilder[_index];
    }

    /// <inheritdoc />
    public override int Read()
    {
        if (_index >= _stringBuilder.Length)
        {
            return -1;
        }

        return _stringBuilder[_index++];
    }

    /// <inheritdoc />
    public override int Read(char[] buffer, int index, int count)
    {
        if (buffer is null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }

        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        if (buffer.Length - index < count)
        {
            throw new ArgumentException(ExceptionMessages.BufferTooSmall, nameof(buffer));
        }

        if (_index >= _stringBuilder.Length)
        {
            return -1;
        }

        int length = System.Math.Min(_stringBuilder.Length - _index, count);
        _stringBuilder.CopyTo(_index, buffer, index, length);
        _index += length;
        return length;
    }

    /// <inheritdoc />
    public override int Read(Span<char> buffer)
    {
        int count = System.Math.Min(buffer.Length, _stringBuilder.Length - _index);
        for (var index = 0; index < count; index++)
        {
            buffer[index] = _stringBuilder[index + _index];
        }

        _index += count;
        return count;
    }

    /// <inheritdoc />
    public override Task<int> ReadAsync(char[] buffer, int index, int count)
    {
        return Task.FromResult(Read(buffer, index, count));
    }

    // except not really 🔽
    /// <summary>
    ///     Asynchronously reads the characters from the current stream into a memory block.
    /// </summary>
    /// <param name="buffer">
    ///     When this method returns, contains the specified memory block of characters replaced by the characters read from the
    ///     current source.
    /// </param>
    /// <param name="cancellationToken">Ignored.</param>
    /// <returns>
    ///     A value task that represents the asynchronous read operation. The value of the type parameter contains the number of
    ///     characters that have been read, or 0 if at the end of the stream and no data was read. The number will be less than or
    ///     equal to the buffer length, depending on whether the data is available within the stream.
    /// </returns>
    public override ValueTask<int> ReadAsync(Memory<char> buffer, CancellationToken cancellationToken = default)
    {
        return new ValueTask<int>(Read(buffer.Span));
    }

    /// <inheritdoc />
    public override int ReadBlock(Span<char> buffer)
    {
        return Read(buffer);
    }

    /// <inheritdoc />
    public override int ReadBlock(char[] buffer, int index, int count)
    {
        if (_index >= _stringBuilder.Length)
        {
            return -1;
        }

        int length = System.Math.Min(count, _stringBuilder.Length - _index);
        _stringBuilder.CopyTo(_index, buffer, index, length);
        _index += length;
        return length;
    }

    /// <inheritdoc />
    public override Task<int> ReadBlockAsync(char[] buffer, int index, int count)
    {
        return Task.FromResult(ReadBlock(buffer, index, count));
    }

    // except not really 🔽
    /// <summary>
    ///     Asynchronously reads the characters from the current stream and writes the data to a buffer.
    /// </summary>
    /// <param name="buffer">
    ///     When this method returns, contains the specified memory block of characters replaced by the characters read from the
    ///     current source.
    /// </param>
    /// <param name="cancellationToken">Ignored.</param>
    /// <returns>
    ///     A value task that represents the asynchronous read operation. The value of the type parameter contains the total
    ///     number of characters read into the buffer. The result value can be less than the number of characters requested if the
    ///     number of characters currently available is less than the requested number, or it can be 0 (zero) if the end of the
    ///     stream has been reached.
    /// </returns>
    public override ValueTask<int> ReadBlockAsync(Memory<char> buffer, CancellationToken cancellationToken = default)
    {
        return new ValueTask<int>(ReadBlock(buffer.Span));
    }

    /// <inheritdoc />
    public override string? ReadLine()
    {
        if (_index >= _stringBuilder.Length)
        {
            return null;
        }

        int start = _index;
        while (_index < _stringBuilder.Length && _stringBuilder[_index] != '\n')
        {
            _index++;
        }

        if (_index < _stringBuilder.Length)
        {
            _index++;
        }

        var result = _stringBuilder.ToString(start, _index - start);

        if (result.Length > 0 && (result[^1] == '\n' || result[^1] == '\r'))
        {
            result = result[..^1];
        }

        return result;
    }

    /// <inheritdoc />
    public override Task<string?> ReadLineAsync()
    {
        return Task.FromResult(ReadLine());
    }

    /// <inheritdoc />
    public override string ReadToEnd()
    {
        var value = _stringBuilder.ToString(_index, _stringBuilder.Length - _index);
        _index = _stringBuilder.Length;
        return value;
    }

    /// <inheritdoc />
    public override Task<string> ReadToEndAsync()
    {
        return Task.FromResult(ReadToEnd());
    }
}
