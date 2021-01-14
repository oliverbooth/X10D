# Changelog

## [2.6.0] - 2020-10-20
# Added
- Add `string.AsNullIfEmpty()`
  - Returns the current string, or `null` if the current string is null or empty.
- Add `string.AsNullIfWhiteSpace()`
  - Returns the current string, or `null` if the current string is null, empty, or consists of only whitespace.
- Add `string.Reverse()`
  - Reverses the current string
- Add `string.WithAlternative()`
  - Returns the current string, or an alternative value if the current string is null or empty, or optionally if the current string consists of only whitespace.

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
    - `SelectFromCustomAttribute<T1, T2>` - Internally calls `GetCustomAttribute<T1>` and passes it to a `Func<T1, T2>` so that specific members may be selected

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

[Unreleased]: https://github.com/oliverbooth/X10D/tree/HEAD
[2.5.0]: https://github.com/oliverbooth/X10D/releases/tag/2.5.0
[2.2.0]: https://github.com/oliverbooth/X10D/releases/tag/2.2.0
[2.1.0]: https://github.com/oliverbooth/X10D/releases/tag/2.1.0
[2.0.0]: https://github.com/oliverbooth/X10D/releases/tag/2.0.0