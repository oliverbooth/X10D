# Changelog

## 3.2.0
### Added
- X10D: Added `MathUtility.InverseLerp(float, float, float)` and `MathUtility.InverseLerp(double, double, double)`
- X10D: Added `Circle`, `CircleF`, `Cuboid`, `Ellipse`, `EllipseF`, `Line3D`, `Line`, `LineF`, `Polygon`, `PolygonF`, `Polyhedron`, and `Sphere`, to complement System.Drawing structs such as `Point` and `Rectangle`
- X10D: Added `Color.GetClosestConsoleColor()`
- X10D: Added `DateTime.GetIso8601WeekOfYear()` and `DateTimeOffset.GetIso8601WeekOfYear()`
- X10D: Added `DirectoryInfo.Clear([bool])`
- X10D: Added `IList<T>.RemoveRange(Range)`
- X10D: Added `Point.IsOnLine(LineF)`, `Point.IsOnLine(PointF, PointF)`, and `Point.IsOnLine(Vector2, Vector2)`
- X10D: Added `PointF.IsOnLine(LineF)`, `PointF.IsOnLine(PointF, PointF)`, and `PointF.IsOnLine(Vector2, Vector2)`
- X10D: Added `Point.ToSize()`
- X10D: Added `Point.ToSizeF()`
- X10D: Added `Point.ToVector2()`
- X10D: Added `PointF.Round([float])`
- X10D: Added `PointF.ToSizeF()`
- X10D: Added `PointF.ToVector2()` for .NET < 6
- X10D: Added `PopCount()` for built-in integer types
- X10D: Added `RoundUpToPowerOf2()` for built-in integer types
- X10D: Added `Size.ToPoint()`
- X10D: Added `Size.ToPointF()`
- X10D: Added `Size.ToVector2()`
- X10D: Added `Quaternion.Multiply(Vector3)` - this functions as an equivalent to Unity's `Quaternion * Vector3` operator
- X10D: Added `Vector2.Deconstruct()`
- X10D: Added `Vector2.IsOnLine(LineF)`, `Vector2.IsOnLine(PointF, PointF)`, and `Vector2.IsOnLine(Vector2, Vector2)`
- X10D: Added `Vector2.Round([float])`
- X10D: Added `Vector2.ToPointF()`
- X10D: Added `Vector2.ToSizeF()`
- X10D: Added `Vector3.Deconstruct()`
- X10D: Added `Vector3.Round([float])`
- X10D: Added `Vector4.Deconstruct()`
- X10D: Added `Vector4.Round([float])`
- X10D.Unity: Added `DebugEx`, which mimics `UnityEngine.Debug` while offering more useful primitive drawing methods
- X10D.Unity: Added `System.Drawing.Color.ToUnityColor()`
- X10D.Unity: Added `System.Drawing.Color.ToUnityColor32()`
- X10D.Unity: Added `Color.GetClosestConsoleColor()`
- X10D.Unity: Added `Color.ToSystemDrawingColor()`
- X10D.Unity: Added `Color32.GetClosestConsoleColor()`
- X10D.Unity: Added `Color32.ToSystemDrawingColor()`
- X10D.Unity: Added `Point.ToUnityVector2()`
- X10D.Unity: Added `Point.ToUnityVector2Int()`
- X10D.Unity: Added `PointF.ToUnityVector2()`
- X10D.Unity: Added `Rect.ToSystemRectangleF()`
- X10D.Unity: Added `RectInt.ToSystemRectangle()`
- X10D.Unity: Added `RectInt.ToSystemRectangleF()`
- X10D.Unity: Added `Rectangle.ToUnityRect()`
- X10D.Unity: Added `Rectangle.ToUnityRectInt()`
- X10D.Unity: Added `RectangleF.ToUnityRect()`
- X10D.Unity: Added `Size.ToUnityVector2()`
- X10D.Unity: Added `Size.ToUnityVector2Int()`
- X10D.Unity: Added `SizeF.ToUnityVector2()`
- X10D.Unity: Added `Vector2.Deconstruct()`
- X10D.Unity: Added `Vector2.IsOnLine(LineF)`, `Vector2.IsOnLine(PointF, PointF)`, and `Vector2.IsOnLine(Vector2, Vector2)`
- X10D.Unity: Added `Vector2Int.IsOnLine(LineF)`, `Vector2Int.IsOnLine(PointF, PointF)`, `Vector2Int.IsOnLine(Vector2, Vector2)`, and `Vector2Int.IsOnLine(Vector2Int, Vector2Int)`
- X10D.Unity: Added `Vector2.Round([float])`
- X10D.Unity: Added `Vector2.ToSystemPointF()`
- X10D.Unity: Added `Vector2.ToSystemSizeF()`
- X10D.Unity: Added `Vector2Int.Deconstruct()`
- X10D.Unity: Added `Vector2Int.ToSystemPoint()`
- X10D.Unity: Added `Vector2Int.ToSystemSize()`
- X10D.Unity: Added `Vector2Int.ToSystemVector()`
- X10D.Unity: Added `Vector2Int.WithX()`
- X10D.Unity: Added `Vector2Int.WithY()`
- X10D.Unity: Added `Vector3.Deconstruct()`
- X10D.Unity: Added `Vector3.Round([float])`
- X10D.Unity: Added `Vector3Int.Deconstruct()`
- X10D.Unity: Added `Vector3Int.ToSystemVector()`
- X10D.Unity: Added `Vector3Int.WithX()`
- X10D.Unity: Added `Vector3Int.WithY()`
- X10D.Unity: Added `Vector3Int.WithZ()`
- X10D.Unity: Added `Vector4.Deconstruct()`
- X10D.Unity: Added `Vector4.Round([float])`

### Changed
- X10D.Unity: Obsolesced `Singleton<T>`

## [3.1.0]
### Added
- Reintroduced Unity support
- X10D: Added `Color.Inverted()` (#54)
- X10D: Added `Color.WithA()` (#55)
- X10D: Added `Color.WithB()` (#55)
- X10D: Added `Color.WithG()` (#55)
- X10D: Added `Color.WithR()` (#55)
- X10D: Added `ICollection<T>.ClearAndDisposeAll()`
- X10D: Added `ICollection<T>.ClearAndDisposeAllAsync()`
- X10D: Added `IEnumerable<T>.For()` (#50)
- X10D: Added `IEnumerable<T>.ForEach()` (#50)
- X10D: Added `IEnumerable<T>.DisposeAll()`
- X10D: Added `IEnumerable<T>.DisposeAllAsync()`
- X10D: Added `char.IsEmoji`
- X10D: Added `ReadOnlySpan<T>.Count(Predicate<T>)`
- X10D: Added `Rune.IsEmoji`
- X10D: Added `Span<T>.Count(Predicate<T>)`
- X10D: Added `string.IsEmoji`
- X10D: Added `Vector2.WithX()` (#56)
- X10D: Added `Vector2.WithY()` (#56)
- X10D: Added `Vector3.WithX()` (#56)
- X10D: Added `Vector3.WithY()` (#56)
- X10D: Added `Vector3.WithZ()` (#56)
- X10D: Added `Vector4.WithX()` (#56)
- X10D: Added `Vector4.WithY()` (#56)
- X10D: Added `Vector4.WithZ()` (#56)
- X10D: Added `Vector4.WithW()` (#56)
- X10D.Unity: Added `Singleton<T>` class
- X10D.Unity: Added `Color.Inverted()` (#54)
- X10D.Unity: Added `Color.WithA()` (#55)
- X10D.Unity: Added `Color.WithB()` (#55)
- X10D.Unity: Added `Color.WithG()` (#55)
- X10D.Unity: Added `Color.WithR()` (#55)
- X10D.Unity: Added `Color32.Inverted()` (#54)
- X10D.Unity: Added `Color32.WithA()` (#55)
- X10D.Unity: Added `Color32.WithB()` (#55)
- X10D.Unity: Added `Color32.WithG()` (#55)
- X10D.Unity: Added `Color32.WithR()` (#55)
- X10D.Unity: Added `Component.GetComponentsInChildrenOnly<T>()`
- X10D.Unity: Added `GameObject.GetComponentsInChildrenOnly<T>()`
- X10D.Unity: Added `GameObject.LookAt(GameObject[, Vector3])`
- X10D.Unity: Added `GameObject.LookAt(Transform[, Vector3])`
- X10D.Unity: Added `GameObject.LookAt(Vector3[, Vector3])`
- X10D.Unity: Added `GameObject.SetLayerRecursively(int)` (#57)
- X10D.Unity: Added `GameObject.SetParent(GameObject[, bool])`
- X10D.Unity: Added `GameObject.SetParent(Transform[, bool])`
- X10D.Unity: Added `System.Numerics.Quaternion.ToUnityQuaternion()`
- X10D.Unity: Added `Quaternion.ToSystemQuaternion()`
- X10D.Unity: Added `Random.NextColorArgb()`
- X10D.Unity: Added `Random.NextColor32Argb()`
- X10D.Unity: Added `Random.NextColorRgb()`
- X10D.Unity: Added `Random.NextColor32Rgb()`
- X10D.Unity: Added `Random.NextRotation()`
- X10D.Unity: Added `Random.NextRotationUniform()`
- X10D.Unity: Added `Random.NextUnitVector2()`
- X10D.Unity: Added `Random.NextUnitVector3()`
- X10D.Unity: Added `Transform.LookAt(GameObject[, Vector3])`
- X10D.Unity: Added `Transform.SetParent(GameObject[, bool])`
- X10D.Unity: Added `System.Numerics.Vector2.ToUnityVector()`
- X10D.Unity: Added `System.Numerics.Vector3.ToUnityVector()`
- X10D.Unity: Added `System.Numerics.Vector4.ToUnityVector()`
- X10D.Unity: Added `Vector2.ToSystemVector()`
- X10D.Unity: Added `Vector3.ToSystemVector()`
- X10D.Unity: Added `Vector4.ToSystemVector()`
- X10D.Unity: Added `Vector2.WithX()` (#56)
- X10D.Unity: Added `Vector2.WithY()` (#56)
- X10D.Unity: Added `Vector3.WithX()` (#56)
- X10D.Unity: Added `Vector3.WithY()` (#56)
- X10D.Unity: Added `Vector3.WithZ()` (#56)
- X10D.Unity: Added `Vector4.WithX()` (#56)
- X10D.Unity: Added `Vector4.WithY()` (#56)
- X10D.Unity: Added `Vector4.WithZ()` (#56)
- X10D.Unity: Added `Vector4.WithW()` (#56)

## [3.0.0]

In the midst of writing these release notes, I may have missed some important changes. If you notice an API change that is not documented here,
please [open an issue](https://github.com/oliverbooth/X10D/issues)!

### Added
- Added `T.AsArrayValue()`
- Added `T.AsEnumerableValue()`
- Added `T.RepeatValue(int)`
- Added `T.ToJson([JsonSerializerOptions])`
- Added `string.FromJson([JsonSerializerOptions])`
- Added `T[].AsReadOnly()`
- Added `T[].Clear([Range])` and `T[].Clear(int, int)`
- Added `DateTime.IsLeapYear()`
- Added `DateTimeOffset.IsLeapYear()`
- Added `Endianness` enum
- Added `FileInfo.GetHash<T>()`
- Added `FileInfo.TryWriteHash<T>(Span<byte>, out int)`
- Added `IComparable<T>.Clamp(T, T)` - this supersedes `Clamp` defined for hard-coded numeric types (#24)
- Added `IComparable<T1>.GreaterThan(T2)` (#22)
- Added `IComparable<T1>.GreaterThanOrEqualTo(T2)` (#22)
- Added `IComparable<T1>.LessThan(T2)` (#22)
- Added `IComparable<T1>.LessThanOrEqualTo(T2)` (#22)
- Added `IComparable<T1>.Max(T)` (#23)
- Added `IComparable<T1>.Min(T)` (#23)
- Added `IDictionary<TKey, TValue>.AddOrUpdate()`
- Added `IEnumerable<TSource>.Product()` and `IEnumerable<TSource>.Product<TResult>(Func<TSource>, TResult)` for all built-in numeric types, computing the product of all (optionally transformed) elements
- Added `IList<T>.Fill(T)` and `IList<T>.Fill(T, int, int)`
- Added `IPAddress.IsIPv4()` and `IPAddress.IsIPv6()`
- Added `IReadOnlyList<byte>.Pack8Bit()`
- Added `IReadOnlyList<byte>.Pack16Bit()`
- Added `IReadOnlyList<byte>.Pack32Bit()`
- Added `IReadOnlyList<byte>.Pack64Bit()`
- Added `MemberInfo.HasCustomAttribute<T>()` and `MemberInfo.HasCustomAttribute(Type)`
- Added `defaultValue` overload for `MemberInfo.SelectFromCustomAttribute<TAttr, TReturn>()`
- Added `Random.Next<T>()` (returns a random field from a specified enum type)
- Added `Random.NextByte([byte[, byte]])`
- Added `Random.NextColorArgb()`, returning a random color in RGB space, including random alpha
- Added `Random.NextColorRgb()`, returning a random color in RGB space with alpha 255
- Added `Random.NextDouble(double[, double])`
- Added `Random.NextInt16([short[, short]])`
- Added `Random.NextSingle(float[, float])` (#34)
- Added `Random.NextUnitVector2()`
- Added `Random.NextUnitVector3()`
- Added `Random.NextRotation()`
- Added `Rune.Repeat(int)`
- Added `byte.IsEven()`
- Added `byte.IsOdd()`
- Added `byte.IsPrime()`
- Added `byte.UnpackBits()`
- Added `byte.RangeTo(byte)`, `byte.RangeTo(short)`, `byte.RangeTo(int)`, and `byte.RangeTo(long)`
- Added `int.Mod(int)`
- Added `int.RangeTo(int)`, and `int.RangeTo(long)`
- Added `int.UnpackBits()`
- Added `long.Mod(long)`
- Added `long.RangeTo(long)`
- Added `long.UnpackBits()`
- Added `sbyte.IsEven()`
- Added `sbyte.IsOdd()`
- Added `sbyte.IsPrime()`
- Added `sbyte.Mod(sbyte)`
- Added `short.IsEven()`
- Added `short.IsOdd()`
- Added `short.Mod(short)`
- Added `short.RangeTo(short)`, `short.RangeTo(int)`, and `short.RangeTo(long)`
- Added `short.UnpackBits()`
- Added `string.IsPalindrome()`
- Added `Stream.GetHash<T>()`
- Added `Stream.TryWriteHash<T>(Span<byte>, out int)`
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
- Added `TimeSpan.Ago()`
- Added `TimeSpan.FromNow()`
- Added `TimeSpanParser.TryParse` which supersedes `TimeSpanParser.Parse`
- Added `Sqrt()` and `ComplexSqrt()` for all built-in decimal types
- Added `All()` and `Any()` for `Span<T>` and `ReadOnlySpan<T>`, mimicking the corresponding methods in `System.Linq`
- Added `Sign()` for built-in numeric types. For unsigned types, this never returns -1
- Added `Type.Implements<T>()` and `Type.Implements(Type)` (#25)
- Added `Type.Inherits<T>()` and `Type.Inherits(Type)` (#25)
- Added `DigitalRoot` function for built-in integer types
- Added `Factorial` function for built-in integer types
- Added `HostToNetworkOrder` and `NetworkToHostOrder` for `short`, `int`, and `long`
- Added `IsLeapYear` function for `DateTime` and `DateTimeOffset`, as well as built-in numeric types
- Added `MultiplicativePersistence` function for built-in integer types
- Added `RotateLeft` and `RotateRight` for built-in integer types
- Added trigonometric functions for built-in numeric types, including `Acos()`, `Asin()`, `Atan()`, `Atan2()`, `Cos()`, `Sin()`, `Tan()` (#49)
- Added time-related extension methods for built-in numeric types, including `Milliseconds()`, `Seconds()`, `Minutes()`, `Hours()`, `Days()`, and `Weeks()`. `Ticks()` is also available, but only for integers; not floating point
- Added `StringBuilderReader` (inheriting `TextReader`) which allows reading from a `StringBuilder` without consuming the underlying string
- Added extension methods for `System.Decimal`

### Changed
- Updated to .NET 6 (#45)
- Methods defined to accept `byte[]` have been changed accept `IReadOnlyList<byte>`
- Extension methods are now defined in appropriate child namespaces to reduce the risk of name collisions (#7)
- `char[].Random(int)`, `char[].Random(int, int)`, `IEnumerable<char>.Random(int)`, and `IEnumerable<char>.Random(int, int)` have been redefined as `Random.NextString(IReadOnlyList<char>, int)`
- `IComparable<T>.Between(T, T)` has been redefined as `IComparable<T1>.Between(T2, T3, [InclusiveOptions])` to allow comparison of disparate yet comparable types, and also offers inclusivity options
- `DateTime` extensions now wrap `DateTimeOffset` extensions
- `DateTime.ToUnixTimestamp([bool])` has been redefined as `DateTime.ToUnixTimeMilliseconds()` and `DateTime.ToUnixTimeSeconds()`
- `Dictionary<T1, T2>.ToGetParameters()`, `IDictionary<T1, T2>.ToGetParameters()`, and `IReadOnlyDictionary<T1, T2>.ToGetParameters()`, has been redefined as `IEnumerable<KeyValuePair<T1, T2>>.ToGetParameters()`
- `Dictionary<T1, T2>.ToConnectionString()`, `IDictionary<T1, T2>.ToConnectionString()`, and `IReadOnlyDictionary<T1, T2>.ToConnectionString()`, has been redefined as `IEnumerable<KeyValuePair<T1, T2>>.ToConnectionString()`
- `IList<T>.OneOf([Random])` and `IEnumerable<T>.OneOf([Random])` have been redefined as `Random.NextFrom<T>(IEnumerable<T>)` to fall in line with the naming convention of `System.Random` (#21)
- `IList<T>.Shuffle([Random])` now uses a Fisher-Yates shuffle implementation
- `IList<T>.Shuffle([Random])` has been repurposed to shuffle the list in place, rather than returning a new enumerable
  - `IEnumerable<T>.Shuffle([Random])` has been renamed to `IEnumerable<T>.Shuffled([Random])` to avoid confusion with `IList<T>.Shuffle([Random])`
- `Random.CoinToss()` has been redefined as `Random.NextBoolean()` to fall in line with the naming convention of `System.Random`
- `Random.OneOf<T>(T[])` and `Random.OneOf<T>(IList<T>)` have been redefined as `Random.NextFrom<T>(IEnumerable<T>)` to fall in line with the naming convention of `System.Random`
- `Enum.Next([bool])` and `Enum.Previous([bool])` have been redefined as `Enum.Next()`, `Enum.Previous()`, `Enum.NextUnchecked()`, `Enum.PreviousUnchecked()`. The `Unchecked` variants of these methods do not perform index validation, and will throw `IndexOutOfRangeException` when attempting to access an invalid index. The checked variants will perform a modulo to wrap the index
- Seperated `string.WithAlternative(string, [bool])` to `string.WithEmptyAlternative(string)` and `string.WithWhiteSpaceAlternative(string)`
- `string.AsNullIfEmpty()` and `string.AsNullIfWhiteSpace()` now accept a nullable `string`
- `IEnumerable<byte>.GetString([Encoding])` has been renamed to `IReadOnlyList<byte>.ToString` and its `Encoding` parameter has
  been made non-optional
- Fixed a bug where `IEnumerable<KeyValuePair<K,V>>.ToConnectionString()` would not sanitize types with custom `ToString()`
  implementation (#20)
  Renamed `string.Random(int[, Random])` to `string.Randomize(int[, Random])`
- Redefined `char[].Random(int)`, `char[].Random(int, Random)`, `IEnumerable<char>.Random(int)`, and `IEnumerable<char>.Random(int, Random)`, as `Random.NextString(IReadOnlyList<char>, int)`
- Improved performance for:
    - `string.IsLower()`
    - `string.IsUpper()`
    - `string.Reverse()`
    - `TimeSpanParser`

### Removed
- Indefinitely suspended Unity support, until such a time that Unity can be updated to a newer version of .NET. See: https://forum.unity.com/threads/unity-future-net-development-status.1092205/
- Removed `bool.And(bool)`
- Removed `bool.NAnd(bool)`
- Removed `bool.NOr(bool)`
- Removed `bool.Not(bool)`
- Removed `bool.Or(bool)`
- Removed `bool.ToByte()`
- Removed `bool.ToInt16()`
- Removed `bool.ToInt64()`
- Removed `bool.XNOr()`
- Removed `bool.XOr()`
- Removed `IConvertible.To<T>([IFormatProvider])` (#13)
- Removed `IConvertible.ToOrDefault<T>([IFormatProvider])` (#13)
- Removed `IConvertible.ToOrDefault<T>(out T, [IFormatProvider])` (#13)
- Removed `IConvertible.ToOrNull<T>([IFormatProvider])` (#13)
- Removed `IConvertible.ToOrNull<T>(out T, [IFormatProvider])` (#13)
- Removed `IConvertible.ToOrOther<T>(T, [IFormatProvider])` (#13)
- Removed `IConvertible.ToOrOther<T>(out T, T, [IFormatProvider])` (#13)
- Removed `IEnumerable<T>.Split(int)` - this functionality is now provided by .NET in the form of the `Chunk` method. See: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.chunk?view=net-6.0
- Removed `MemberInfo.GetDefaultValue()` (use `SelectFromCustomAttribute()` instead)
- Removed `MemberInfo.GetDescription()` (use `SelectFromCustomAttribute()` instead)
- Removed `int.ToBoolean()`
- Removed `long.ToBoolean()`
- Removed `short.ToBoolean()`
- Removed `uint.ToBoolean()`
- Removed `ushort.ToBoolean()`
- Removed `ulong.ToBoolean()`
- Removed `WaitHandle.WaitOneAsync()`. For suspensions of execution during asynchronous operations, favour `TaskCompletionSource` or `TaskCompletionSource<T>`. See: https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskcompletionsource?view=net-6.0 and https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskcompletionsource-1?view=net-6.0 

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

[3.1.0]: https://github.com/oliverbooth/X10D/releases/tag/v3.1.0
[3.0.0]: https://github.com/oliverbooth/X10D/releases/tag/v3.0.0
[2.6.0]: https://github.com/oliverbooth/X10D/releases/tag/2.6.0
[2.5.0]: https://github.com/oliverbooth/X10D/releases/tag/2.5.0
[2.2.0]: https://github.com/oliverbooth/X10D/releases/tag/2.2.0
[2.1.0]: https://github.com/oliverbooth/X10D/releases/tag/2.1.0
[2.0.0]: https://github.com/oliverbooth/X10D/releases/tag/2.0.0