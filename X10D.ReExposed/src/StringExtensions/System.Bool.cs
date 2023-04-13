namespace X10D.ReExposed.StringExtensions;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static partial class StringExtensions
{
    /// <inheritdoc cref="bool.Parse(string)"/>
    public static bool ToBool(this string value)
    {
        switch (value)
        {
            case "TRUE":
            case "True":
            case "true":
            case "T":
            case "t":
            case "YES":
            case "Yes":
            case "yes":
            case "Y":
            case "y":
            case "1": return true;
            default: return false;
        }
    }

    /// <inheritdoc cref="bool.TryParse(string,out bool)"/>
    public static bool TryToBool(this string value, out bool result)
    {
        switch (value)
        {
            case "TRUE":
            case "True":
            case "true":
            case "T":
            case "t":
            case "YES":
            case "Yes":
            case "yes":
            case "Y":
            case "y":
            case "1":
                result = true;

                return true;
            case "FALSE":
            case "False":
            case "false":
            case "F":
            case "f":
            case "NO":
            case "No":
            case "no":
            case "N":
            case "n":
            case "0":
                result = false;

                return true;
            default:
                result = false;

                return false;
        }
    }
}