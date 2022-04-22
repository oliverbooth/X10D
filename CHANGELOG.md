# Changelog

## [3.0.0 (Unreleased)]

### Added

- Added `StringBuilderReader` (inheriting `TextReader`) which allows reading from a `StringBuilder` without consuming the underlying string
- Added extension methods for `System.Decimal`
- Added `All` and `Any` for `Span<T>` and `ReadOnlySpan<T>`, mimicking the corresponding methods in `System.Linq`
- Added time-related extension methods (`Ticks`, `Milliseconds`, `Seconds`, `Minutes`, `Hours`, `Days`, and `Weeks`) to all built-in numeric types
- Added `TimeSpan.Ago()` and `TimeSpan.FromNow()`
- Added `FileInfo.GetHash<T>()`
- Added `IEnumerable<TSource>.Product()` and `IEnumerable<TSource>.Product<TResult>(Func<TSource>, TResult)` for all built-in numeric types, computing the product of all (transformed) elements
- Added `IEnumerable<T>.Shuffled([Random])`, which wraps `IList<T>.Shuffle([Random])` and returns the result
- Added `T.AsArray()`
- Added `T.AsEnumerable()`
- Added `T.ToJson([JsonSerializerOptions])`
- Added `T[].AsReadOnly()`
- Added `T[].Clear([Range])` and `T[].Clear(int, int)`
- Added `T[].Fill(T)` and `T[].Fill(T, int, int)`
- Added `Random.Next<T>()`
- Added `Random.NextDouble(double)`
- Added `Random.NextDouble(double, double)`
- Added `Random.NextSingle()`
- Added `Random.NextSingle(float)`
- Added `Random.NextSingle(float, float)`
- Added `Random.NextInt64()`
- Added `Random.NextInt64(long)`
- Added `Random.NextInt64(long, long)`
- Added `Random.NextColor()`
- Added `Random.NextUnitVector2()`
- Added `Random.NextUnitVector3()`
- Added `Random.NextRotation()`
- Added `bool.GetBytes()`
- Added `byte.GetBytes()`
- Added `byte.IsEven()`
- Added `byte.IsOdd()`
- Added `byte.IsPrime()`
- Added `sbyte.IsEven()`
- Added `sbyte.IsOdd()`
- Added `sbyte.IsPrime()`
- Added `sbyte.Sign()`
- Added `decimal.Sign()`
- Added `double.Acos()`
- Added `double.Acosh()`
- Added `double.Asin()`
- Added `double.Asinh()`
- Added `double.Atan()`
- Added `double.Atanh()`
- Added `double.ComplexSqrt()`
- Added `double.Cos()`
- Added `double.Cosh()`
- Added `double.LerpFrom(double, double)`
- Added `double.LerpTo(double, double)`
- Added `double.LerpWith(double, double)`
- Added `double.Sign()`
- Added `double.Sin()`
- Added `double.Sinh()`
- Added `double.Sqrt()`
- Added `double.Tan()`
- Added `double.Tanh()`
- Added `float.Acos()`
- Added `float.Acosh()`
- Added `float.Asin()`
- Added `float.Asinh()`
- Added `float.Atan()`
- Added `float.Atanh()`
- Added `float.ComplexSqrt()`
- Added `float.Cos()`
- Added `float.Cosh()`
- Added `float.LerpFrom(float, float)`
- Added `float.LerpTo(float, float)`
- Added `float.LerpWith(float, float)`
- Added `float.Sign()`
- Added `float.Sin()`
- Added `float.Sinh()`
- Added `float.Sqrt()`
- Added `float.Tan()`
- Added `float.Tanh()`
- Added `short.ToHostOrder()`
- Added `short.LerpFrom(double, double)`
- Added `short.LerpTo(double, double)`
- Added `short.LerpWith(double, double)`
- Added `short.LerpFrom(float, float)`
- Added `short.LerpTo(float, float)`
- Added `short.LerpWith(float, float)`
- Added `short.Sign()`
- Added `short.ToNetworkOrder()`
- Added `short.To(short)` and `short.To(short, short)`
- Added `int.LerpFrom(double, double)`
- Added `int.LerpTo(double, double)`
- Added `int.LerpWith(double, double)`
- Added `int.LerpFrom(float, float)`
- Added `int.LerpTo(float, float)`
- Added `int.LerpWith(float, float)`
- Added `int.Mod(int)`
- Added `int.RotateLeft(int)`
- Added `int.RotateRight(int)`
- Added `int.Sign()`
- Added `int.ToHostOrder()`
- Added `int.ToNetworkOrder()`
- Added `int.To(int)` and `int.To(int, int)`
- Added `long.ToHostOrder()`
- Added `long.LerpFrom(double, double)`
- Added `long.LerpTo(double, double)`
- Added `long.LerpWith(double, double)`
- Added `long.LerpFrom(float, float)`
- Added `long.LerpTo(float, float)`
- Added `long.LerpWith(float, float)`
- Added `long.Sign()`
- Added `long.ToNetworkOrder()`
- Added `long.To(long)` and `long.To(long, long)`
- Added `IComparable<T>.Clamp(T, T)` which supersedes `short.Clamp(short, short)`, `int.Clamp(int, int)`,
  and `long.Clamp(long, long)`
- Added `IComparable<T>.GreaterThan(T)`
- Added `IComparable<T>.GreaterOrEqualTo(T)`
- Added `IComparable<T>.LessThan(T)`
- Added `IComparable<T>.LessThanOrEqualTo(T)`
- Added `IComparable<T>.Max(T)`
- Added `IComparable<T>.Min(T)`
- Added `IReadOnlyCollection<T>.Split(int)`
  - Yields the same results as `IEnumerable<T>.Split(int)`, except is able to avoid a hidden allocation with the benefit of knowing the collection size ahead of time
- Added `Type.HasCustomAttribute<T>()` and `Type.HasCustomAttribute(Type)`
- Added `Type.Implements<T>()` and `Type.Implements(Type)`
- Added `Type.Inherits<T>()` and `Type.Inherits(Type)`
- Added `Type.SelectFromCustomAttribute<TAttribute, TReturn>()`
- Added `DateTimeOffset` extensions which supersede `DateTime` extensions
- Added `Endianness` enum
- Added `Stream.ReadInt16([Endian])`
- Added `Stream.ReadInt32([Endian])`
- Added `Stream.ReadInt64([Endian])`
- Added `Stream.ReadUInt16([Endian])`
- Added `Stream.ReadUInt32([Endian])`
- Added `Stream.ReadUInt64([Endian])`
- Added `Stream.Write(short, [Endian])`
- Added `Stream.Write(int, [Endian])`
- Added `Stream.Write(long, [Endian])`
- Added `Stream.Write(ushort, [Endian])`
- Added `Stream.Write(uint, [Endian])`
- Added `Stream.Write(ulong, [Endian])`
- Added `string.IsPalindrome()`
- Added `string.FromJson([JsonSerializerOptions])`
- Added `TimeSpanParser.TryParse` which supersedes `TimeSpanParser.Parse`

### Changed

- Update to .NET 6
- Methods defined to accept `byte[]` have been changed accept `IReadOnlyList<byte>`
- `Enum.Next([bool])` and `Enum.Previous([bool])` have been separated. Non-wrapped overloads now use the `Unchecked` prefix (`NextUnchecked` and `PreviousUnchecked`)
- Improve performance for:
    - `string.IsLower()`
    - `string.IsUpper()`
    - `string.Reverse()`
- `IEnumerable<T>.Split(int)` now lazily enumerates, rather than consuming in full before yielding
- Separated `short.FromUnixTimestamp(bool)` into `short.FromUnixTimeMilliseconds` and `short.FromUnixTimeSeconds`
- Separated `int.FromUnixTimestamp(bool)` into `int.FromUnixTimeMilliseconds` and `int.FromUnixTimeSeconds`
- Separated `long.FromUnixTimestamp(bool)` into `long.FromUnixTimeMilliseconds` and `long.FromUnixTimeSeconds`
- Seperated `string.WithAlternative(string, [bool])` to `string.WithEmptyAlternative(string)` and `string.WithWhiteSpaceAlternative(string)`
- `IComparable.Between` now accepts an `InclusiveOptions` parameter to specify whether checks shall be inclusive or exclusive
- Renamed `Random.CoinToss()` to `Random.NextBoolean()` to fall into consistency with `Random.Next()`, `Random.NextBytes()`
  and `Random.NextDouble()`
- Renamed `Random.OneOf()` to `Random.NextFrom()` (same reasoning)
- Renamed `List.OneOf()` to `List.Random()`
- Renamed `string.Random(int[, Random])` to `string.Randomize(int[, Random])`
- Renamed `char[].Random(int)`, `char[].Random(int, Random)`, `IEnumerable<char>.Random(int)`,
  and `IEnumerable<char>.Random(int, Random)`, in favour of `Random.NextString(IReadOnlyList<char>, int)`
- `IList<T>.Shuffle([Random])` now uses a Fisher-Yates shuffle implementation
- `IList<T>.Shuffle([Random])` now returns `void`, as it will reorganize the elements in-place on the current `IList<T>`
- `Dictionary`, `IDictionary`, and `IReadOnlyDictionary` extension methods have been consolidated
  to `IEnumerable<KeyValuePair<K,V>>`
- Fixed a bug where `IEnumerable<KeyValuePair<K,V>>.ToConnectionString()` would not sanitize types with custom `ToString()`
  implementation (#20)
- `DateTime` extensions now wrap `DateTimeOffset` extensions
- `DateTime.ToUnixTimestamp([bool])` has been split into `DateTime.ToUnixTimeMilliseconds()` and `DateTime.ToUnixTimeSeconds()`
- `IEnumerable<byte>.GetString([Encoding])` has been renamed to `IReadOnlyList<byte>.ToString` and its `Encoding` parameter has
  been made non-optional
- `WaitHandle.WaitOneAsync` now returns `Task<bool>` as a result of calling `Task.Run`, rather than returning a
  typeless `new Task()`
- `string.AsNullIfEmpty()` and `string.AsNullIfWhiteSpace()` now accept a nullable `string`
- `string.WithAlternative` is now `string.WithEmptyAlternative` and `string.WithWhiteSpaceAlternative`

### Removed

- Removed `bool.And(bool)`
- Removed `bool.NAnd(bool)`
- Removed `bool.NOr(bool)`
- Removed `bool.Not()`
- Removed `bool.Or(bool)`
- Removed `bool.XNOr(bool)`
- Removed `bool.XOr(bool)`
- Removed `float.ToBoolean()`
- Removed `double.ToBoolean()`
- Removed `int.ToBoolean()`
- Removed `long.ToBoolean()`
- Removed `IConvertible.To<T>([IFormatProvider])`
- Removed `IConvertible.ToOrDefault<T>([IFormatProvider])`
- Removed `IConvertible.ToOrDefault<T>(out T, [IFormatProvider])`
- Removed `IConvertible.ToOrNull<T>([IFormatProvider])`
- Removed `IConvertible.ToOrNull<T>(out T, [IFormatProvider])`
- Removed `IConvertible.ToOrOther<T>(T, [IFormatProvider])`
- Removed `IConvertible.ToOrOther<T>(T, out T, [IFormatProvider])`
- Removed `IEnumerable<T>.Split(int)` and `IReadOnlyCollection<T>.Split` (this functionality is now provided by LINQ in the form of the [`Chunk`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.chunk?view=net-6.0) method)
- Removed `MemberInfo.GetDefaultValue()` (use `SelectFromCustomAttribute()` instead)
- Removed `MemberInfo.GetDescription()` (use `SelectFromCustomAttribute()` instead)
- Removed `Random.NextInt64()` and its overloads. This functionality is built in starting with .NET 6
- Removed `TimeSpanParser.Parse`

## [2.6.0] - 2020-10-20

### Added

- Add `string.AsNullIfEmpty()`
    - Returns the current string, or `null` if the current string is null or empty.
- Add `string.AsNullIfWhiteSpace()`
    - Returns the current string, or `null` if the current string is null, empty, or consists of only whitespace.
- Add `string.Reverse()`
    - Reverses the current string
- Add `string.WithAlternative()`
    - Returns the current string, or an alternative value if the current string is null or empty, or optionally if the current
      string consists of only whitespace.

### Changed

- n/a

### Removed

- n/a

## [2.5.0] - 2020-07-15

### Added

- `WaitHandle.WaitOneAsync()`
    - Wraps `WaitHandle.WaitOne` as a `Task`
- Add support for Unity 2019.4.3f1
    - Add `GameObject.LookAt(GameObject)`
        - Rotates the Transform on the current GameObject so that it faces the Transform on another GameObject
    - Add `GameObject.LookAt(Transform)`
        - Rotates the Transform on the current GameObject so that it faces another transform
    - Add `Transform.LookAt(GameObject)`
        - Rotates the current Transform so that it faces the Transform on another GameObject
    - Add `Vector3.Round([float])`
        - Returns a rounded Vector3 by calling `float.Round()` on each component
    - Add `Vector3.WithX(float)`
        - Returns a Vector3 with a new X component value
    - Add `Vector3.WithY(float)`
        - Returns a Vector3 with a new Y component value
    - Add `Vector3.WithZ(float)`
        - Returns a Vector3 with a new Z component value
    - Add `Vector3.WithXY(float, float)`
        - Returns a Vector3 with new X and Y component values
    - Add `Vector3.WithXZ(float, float)`
        - Returns a Vector3 with new X and Z component values
    - Add `Vector3.WithYZ(float, float)`
        - Returns a Vector3 with new Y and Z component values
    - Add `BetterBehavior` (experimental wrapper over `MonoBehaviour`)

### Changed

- n/a

### Removed

- n/a

## [2.2.0] - 2020-04-21

### Added

- Add `string.ChangeEncoding(Encoding, Encoding)`
    - Converts this string from one encoding to another
- Add `string.IsLower()`
    - Determines if all alpha characters in this string are considered lowercase
- Add `string.IsUpper()`
    - Determines if all alpha characters in this string are considered uppercase

- Various extension methods with regards to reflection:
    - `GetDefaultValue` and `GetDefaultValue<T>` - gets the value stored in the member's `DefaultValue` attribute
    - `GetDescription`- gets the value stored in the member's `Description` attribute
    - `SelectFromCustomAttribute<T1, T2>` - Internally calls `GetCustomAttribute<T1>` and passes it to a `Func<T1, T2>` so that
      specific members may be selected

### Changed

- n/a

### Removed

- n/a

## [2.1.0] - 2020-04-18

### Added

- Add `bool bool.And(bool)`
    - Performs logical AND
- Add `bool bool.Or(bool)`
    - Performs logical OR
- Add `bool bool.Not(bool)`
    - Performs logical NOT
- Add `bool bool.XOr(bool)`
    - Performs Logical XOR
- Add `bool bool.NAnd(bool)`
    - Performs logical NAND
- Add `bool bool.NOr(bool)`
    - Performs logical NOR
- Add `bool bool.XNOr(bool)`
    - Performs logical XNOR
- Add `byte bool.ToByte()`
    - 1 if `true`, 0 otherwise
- Add `short bool.ToInt16()`
    - 1 if `true`, 0 otherwise
- Add `long bool.ToInt64()`
    - 1 if `true`, 0 otherwise

### Changed

- n/a

### Removed

- n/a

## [2.0.0] - 2020-04-18

### Added

- Add `IEnumerable<T>.Split(int)`
    - Performs the same operation as the previously defined `IEnumerable<byte>.Chunkify(int)`, except now accepts any type `T`

### Changed

- Fix `DateTime.Last(DayOfWeek)` implementation
    - Now returns the correct date/time for a given day of the week

### Removed

- Remove `IEnumerable<byte>.Chunkify(int)`
    - Replaced by a method of the same behaviour `IEnumerable<T>.Split(int)`

## Earlier versions

### ***Not documented***

[3.0.0 (Unreleased)]: https://github.com/oliverbooth/X10D/tree/develop
[2.6.0]: https://github.com/oliverbooth/X10D/releases/tag/2.6.0
[2.5.0]: https://github.com/oliverbooth/X10D/releases/tag/2.5.0
[2.2.0]: https://github.com/oliverbooth/X10D/releases/tag/2.2.0
[2.1.0]: https://github.com/oliverbooth/X10D/releases/tag/2.1.0
[2.0.0]: https://github.com/oliverbooth/X10D/releases/tag/2.0.0