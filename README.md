# X10D
## Extension methods on crack

[![GitHub Workflow Status](https://img.shields.io/github/workflow/status/oliverbooth/X10D/.NET%20Core?style=for-the-badge)](https://github.com/oliverbooth/X10D/actions?query=workflow%3A%22.NET+Core%22)
[![GitHub issues](https://img.shields.io/github/issues/oliverbooth/X10D?style=for-the-badge)](https://github.com/oliverbooth/X10D/issues)
[![Nuget](https://img.shields.io/nuget/dt/X10D?style=for-the-badge)](https://www.nuget.org/packages/X10D/)
[![Nuget](https://img.shields.io/nuget/v/X10D?style=for-the-badge)](https://www.nuget.org/packages/X10D/)
[![GitHub](https://img.shields.io/github/license/oliverbooth/X10D?style=for-the-badge)](https://github.com/oliverbooth/X10D/blob/master/LICENSE.md)

### About
X10D (pronounced *extend*), is a class library that provides extension methods for numerous .NET types. The purpose of this library is to simplify a codebase by reducing the need for repeated code when performing common operations. Simplify your codebase. Take advantage of .NET. Use extension methods.

*(I'm also [dogfooding](https://www.pcmag.com/encyclopedia/term/dogfooding) this library, so there's that.)*

### Table of contents
- [Installation](#installation)
    - [Unity installation](#unity-installation)
    - [NuGet installation](#nuget-installation)
    - [Manual installation](#manual-installation)
- [Features](#features)
    - [Numeric](#numeric)
    - [String](#string)
    - [DateTime](#datetime)
    - [Enumerable](#enumerable)
    - [Enum](#enum)
    - [Conversion](#conversion)
    - [Random](#random)
- [Contributing](#contributing)
- [License](#license)

You can find the list of classes that have extension methods by viewing the `README.md` file in any of the respective library folders.

## Installation
### Unity installation
1. Open the package manager, open the `+` menu and select `Add package from git URL...`.
   
   ![](https://user-images.githubusercontent.com/1129769/109844969-8ec7a100-7c44-11eb-9729-9a03be703d1b.png)

2) Enter the URL below and press Add.
    ```cs
    https://github.com/oliverbooth/X10D.git#upm
    ```

### NuGet installation
```ps
Install-Package X10D -Version 2.6.0
```

### Manual installation
Download the [latest release](https://github.com/oliverbooth/X10D/releases/latest) from this repository and adding a direct assembly reference for your chosen platform.

## Features
### Numeric extensions
> 👍 ProTip: *Most* of the extensions available for `int` will also exist for `short`, `long`, and their unsigned counterparts!

#### `bool` &lt;-&gt; `int`
Convert a `bool` to an `int` by using `ToInt32`. The value returned is 1 if the input is `true`, and 0 if it's `false`.
```cs
bool b = true;

int i = b.ToInt32(); // 1
```
The same also works in reverse. Using `ToBoolean` on an `int` will return `false` if the input is 0, and `true`if the input is anything else.
```cs
int zero = 0;
long nonZero = 1;

bool b1 = zero.ToBoolean(); // false
bool b2 = nonZero.ToBoolean(); // true
```

#### Between
Determine if a value is between other values using `Between` like so:
```cs
int i = 3;

if (i.Between(2, 4))
{
    // i is between 2 and 4!
}
```
Since the signature of this method is defined with a generic constraint of `IComparable<T>`, this will also work for any object that is `IComparable<T>` - not just numeric types!
```cs
bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
```

#### IsEven (*and IsOdd*)
As the names suggest, this method determines if the input value is evenly divisible by 2.
```cs
int i = 5;
bool b = i.IsEven(); // false
```
There is also an `IsOdd` extension method, which will return the opposite of that returned by `IsEven`.

#### IsPrime
Determine if an integral is a prime number by using `IsPrime`.
```cs
bool b = 43.IsPrime(); // true
```

#### Clamp
Clamp a value between an upper and lower bound
```cs
int i = 5.Clamp(0, 3); // 3
```

#### Convert degrees &lt;-&gt; radians
Easily convert between radians and degrees
```cs
double rad = 2 * Math.PI;
double deg = rad.RadiansToDegrees(); // 360

rad = deg.DegreesToRadians();        // back to 2*pi
```

#### Round
Round a value to the nearest whole number:
```cs
var d = 2.75;
var rounded = d.Round(); // 3
```
Or specify a value to have it round to the nearest multiple of `x`:
```cs
double a = 8.0.Round(10); // 10
double b = 2.0.Round(10); // 0
```

### String
#### Repeat value
Repeat a string or a char a specific number of times using `Repeat`
```cs
var c   = '-';
var str = "foo";

string repeatedC   = c.Repeat(10);  // ----------
string repeatedStr = str.Repeat(5); // foofoofoofoofoo
```

#### Base-64 encode/decode
```cs
var base64 = "Hello World".Base64Encode();      // SGVsbG8gV29ybGQ=
var str    = "SGVsbG8gV29ybGQ=".Base64Decode(); // Hello World
```

### DateTime

#### Age
Get a rounded integer representing the number of years since a given date. i.e. easily calculate someone's age:
```cs
var dateOfBirth = new DateTime(1960, 7, 16);
int age = dateOfBirth.Age(); // the age as of today
```
You can also specify a date at which to stop counting the years, by passing an `asOf` date:
```cs
var dateOfBirth = new DateTime(1960, 7, 16);
int age = dateOfBirth.Age(new DateTime(1970, 7, 16)); // 10, the age as of 1970
```

#### To/From Unix Timestamp
Convert to/from a Unix timestamp represented in seconds using `FromUnixTimestamp` on a numeric type, and `ToUnixTimestamp` on a `DateTime`.
```cs
long sec = 1587223415;
DateTime time = sec.FromUnixTimestamp(); // 2020-04-18 15:23:35
long unix = time.ToUnixTimestamp();
```
or represent it with milliseconds by passing `true` for the `isMillis` argument:
```cs
long millis = 1587223415500;
DateTime time = millis.FromUnixTimestamp(true); // 2020-04-18 15:23:35.50
long unix = time.ToUnixTimestamp(true);
```

#### Get first/last day of month
Get the first or last day of the month by using `FirstDayOfMonth` and `LastDayOfMonth`
```cs
var dt = new DateTime(2016, 2, 4);

DateTime first = dt.FirstDayOfMonth(); // 2016-02-01
DateTime last = dt.LastDayOfMonth();   // 2016-02-29 (2016 is a leap year)
```
You can also use `First` or `Last` to get the first or final occurrence of a specific day of the week in a given month:
```cs
var dt = new DateTime(2019, 4, 14);

DateTime theLastFriday   = dt.Last(DayOfWeek.Friday);   // 2019-04-24
DateTime theLastThursday = dt.Last(DayOfWeek.Thursday); // 2019-04-40
```

### Enumerable
#### Split into chunks
Split an `IEnumerable<T>` into an `IEnumerable<IEnumerable<T>>`, essentially "chunking" the original IEnumerable into a specific size
```cs
var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
var chunks = arr.Split(2); // split into chunks of 2

foreach (var chunk in chunks)
{
    Console.WriteLine(string.Join(", ", chunk));
}

// Output:
// 1, 2
// 3, 4
// 5, 6
// 7, 8
```
This also works for `string`:
```cs
var str = "Hello World";
var chunks = str.Split(2); // split string into chunks of 2

foreach (var chunk in chunks)
{
    Console.WriteLine(string.Join(string.Empty, chunk));
}

// Output:
// He
// ll
// o        <-- space is included
// Wo
// rl
// d        <-- no space! end of string
```

### Enum
#### Parse string into enum
You can use the `EnumParse` method to convert a string into a value from an enum, while optionally ignoring case:
```cs
enum Number
{
    Zero,
    One,
    Two,
    Three,
}

Number num = "two".EnumParse<Number>(true); // num == Number.Two
```

#### `Next` / `Previous` enum cycling
Cycle through the values in an enum with `Next` and `Previous`:
```cs
Number two = Number.Two;

Number one = two.Previous();
Number three = two.Next();
```

### Conversion
Easily convert between types using `To`, `ToOrNull`, `ToOrDefault`, or `ToOrOther`, thereby shortening the call to `Convert.ChangeType` or `Convert.ToX`:
```CS
int i = "43".To<int>();
int j = "a".ToOrDefault<int>(); // 0
int k = "a".ToOrOther<int>(100); // 100
```

### Random
Do more with Random including flip a coin, randomly select an element in an array, or shuffle the array entirely.
```cs
var random = new Random();

// flip a coin
bool heads = random.CoinToss();

// randomly choose an item
var arr = new int[] { 1, 2, 3, 4 };
var item = random.OneOf(arr);

// shuffle an array or list
var shuffled = arr.Shuffle(random);
```

## Contributing
Contributions are welcome. See [CONTRIBUTING.md](CONTRIBUTING.md).

## License
X10D is released under the MIT License. See [here](https://github.com/oliverbooth/X10D/blob/master/LICENSE.md) for more details.
