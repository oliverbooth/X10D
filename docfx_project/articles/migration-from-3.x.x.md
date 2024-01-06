# Migration from 3.x.x

X10D 4.0.0 is a major release that introduces breaking changes. This document will help you migrate your code from 3.x.x
to 4.0.0.

## Removed APIs

### X10D.DSharpPlus library

The `X10D.DSharpPlus` library has been removed. This library was used to provide extension methods for the DSharpPlus
wrapper library. However, I have since moved to using a different library, and as such, I feel it is no longer in the
scope of X10D or in my best interest to maintain it. The library will remain available on NuGet until DSharpPlus release
5.0.0 as stable, and X10D.DSharpPlus will NOT be part of X10D 4.0.0. I'm sorry for any inconvenience this may cause.

### `Endianness` enum

The `Endianness` enum was used to specify the endianness of data when reading or writing to a stream. This was causing
some clutter, and makes it harder to develop X10D, so it was removed. In its stead, any method which accepted an
`Endianness` parameter now has two overloads: one for big-endian, and one for little-endian. For example, the following
code:

```csharp
someStream.Write(12345, Endianness.BigEndian);

// or

Span<byte> buffer = stackalloc byte[4];
12345.TryWriteBytes(buffer, Endianness.BigEndian);
```

would now be written as:

```csharp
someStream.WriteBigEndian(12345);

// or

Span<byte> buffer = stackalloc byte[4];
12345.TryWriteLittleEndianBytes(buffer);
```

### `IEnumerable<T>.ConcatOne(T)` extension method

The `IEnumerable<T>.ConcatOne` extension method was used to concatenate a single item to an enumerable. At the time, I
was unaware of the `Enumerable.Append` method, which does the same thing. As such, `ConcatOne` has been removed. There
is no migration path for this, as the built in `Append` method from LINQ is a drop-in replacement.

## Exception Changes

If you were previously catching TypeInitializationException when calling `Stream.GetHash<>` or `Stream.TryWriteHash<>`,
you will now need to catch a ArgumentException instead. The justification for this change is that ArgumentException is
more general, and more easily understood by developers.