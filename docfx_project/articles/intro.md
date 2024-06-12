## X10D
X10D (pronounced *extend*), is a .NET package that provides extension methods for numerous types. The purpose of this library is to simplify a codebase by reducing the need for repeated code when performing common operations. Simplify your codebase. Take advantage of .NET. Use extension methods.

*(I'm also [dogfooding](https://www.pcmag.com/encyclopedia/term/dogfooding) this library, so there's that.)*

### What are extension methods?

Extension methods are a clever .NET feature that augment existing types with new functionality. They are defined as
static methods in a static class, and are called as if they were instance methods on the type they are extending. Take,
for example, the following code:

```csharp
public static class Program
{
    public static void Main()
    {
        string str = "Hello, world!";
        Console.WriteLine(str.Reverse());
    }
}

public static class StringExtensions
{
    public static string Reverse(this string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}
```

This will print `!dlrow ,olleH` to the console. The `Reverse` method is defined in the `StringExtensions` class, yet is
called as if it were an instance method on the `str` variable, even though it's not.

### Why use extension methods?

Extension methods were introduced when LINQ was added to .NET. LINQ is a set of extension methods that provide a way to
query, filter, and transform data. If you were to access LINQ's methods statically, you would have to write code like
this:

```csharp
public static class Program
{
    public static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        IEnumerable<int> evenNumbers = Enumerable.Where(numbers, x => x % 2 == 0);
        IEnumerable<int> doubledNumbers = Enumerable.Select(evenNumbers, x => x * 2);
        int sum = Enumerable.Sum(doubledNumbers);
        Console.WriteLine(sum);
    }
}
```

And if you wanted to one-line this, you'd have to write this:

```csharp
public static class Program
{
    public static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        Console.WriteLine(Enumerable.Sum(Enumerable.Select(Enumerable.Where(numbers, x => x % 2 == 0), x => x * 2)));
    }
}
```

This is a lot of code to write, and it's not very readable. The nested method calls make it incredibly difficult to
follow. However, because LINQ is implemented as extension methods, you can write the following code instead:

```csharp
public static class Program
{
    public static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        Console.WriteLine(numbers.Where(x => x % 2 == 0).Select(x => x * 2).Sum());
    }
}
```

Because the methods are called as if they were instance methods on `IEnumerable<T>`, they can be chained together,
making the code much more readable.

X10D aims to provide these same benefits as LINQ, but for dozens of other types and for countless other use cases.