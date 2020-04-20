# Changelog

## [Unreleased]
### Added
- Add `string.ChangeEncoding(Encoding, Encoding)`
    - Converts this string from one encoding to another
- Add `string.IsLower`
    - Determines if all alpha characters in this string are considered lowercase
- Add `string.IsUpper`
    - Determines if all alpha characters in this string are considered uppercase

### Changed
- n/a

### Removed
- n/a

## [2.1.0] - 2020-04-18
### Added
- `bool bool.And(bool)`
    - Performs logical AND
- `bool bool.Or(bool)` 
    - Performs logical OR
- `bool bool.Not(bool)`
    - Performs logical NOT
- `bool bool.XOr(bool)`
    - Performs Logical XOR
- `bool bool.NAnd(bool)`
    - Performs logical NAND
- `bool bool.NOr(bool)`
    - Performs logical NOR
- `bool bool.XNOr(bool)`
    - Performs logical XNOR
- `byte bool.ToByte()`
    - 1 if `true`, 0 otherwise
- `short bool.ToInt16()`
    - 1 if `true`, 0 otherwise
- `long bool.ToInt64()`
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
[2.1.0]: https://github.com/oliverbooth/X10D/releases/tag/2.1.0
[2.0.0]: https://github.com/oliverbooth/X10D/releases/tag/2.0.0