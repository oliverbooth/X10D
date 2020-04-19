---
name: Extension method request
about: Make a request for an extension method you believe should be implemented
title: ''
labels: ''
assignees: ''

---

**Type**
Provide the fully-qualified type name of the extension method you wish to have here. Example:
```cs
System.String
```

**Extension method signature**
Provide the full method signature here, without parameter names, but do not include the leading `this T x` parameter. Example:
```cs
string Random(int, System.Random)
```

**Parameters**
Document each of the parameters here, with their name and description - i.e. this would be equivalent to the entry in the XMLDoc. Use a table layout like in the following example:
| Parameter | Type | Description |
|- |- |- |
|length|`int`|The length of the string to generate.|
|random|`System.Random`|The instance of `System.Random` to use for the operation|

**Description**
Briefly but concisely document the method's purpose here. i.e. This would be the `<summary>` entry in the XMLDoc.

**Benefits**
Give a reason as to why this method should be added. Does it add a need not satisified by any other X10D method? Does .NET not offer similar operations? Why should this method exist?

**Drawbacks**
Give a reason as to why this method should *not* be added. Is it an expensive operation? Does it defy .NET guidelines? If you cannot think of any, leave this blank.

**(Optional) Implementation example**
If you prefer, you can give an example of how this method might be implemented using a C# codeblock.
Do not include the method signature here - just the body.
```cs
{
    // code
}
```
