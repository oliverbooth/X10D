using System.Reflection;
using System.Text.Json;

string version;

if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
{
    version = Environment.GetEnvironmentVariable("GITHUB_SHA") ?? "0.0.0";
}
else
{
    string path = args[0];
    var assembly = Assembly.LoadFrom(path);
    var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
    if (attribute is null || string.IsNullOrWhiteSpace(attribute.InformationalVersion))
    {
        version = Environment.GetEnvironmentVariable("GITHUB_SHA") ?? "0.0.0";
    }
    else
    {
        version = attribute.InformationalVersion;
    }
}

var package = new
{
    name = "me.olivr.x10d",
    author = new {name = "Oliver Booth", email = "me@olivr.me", url = "https://oliverbooth.dev"},
    displayName = "X10D",
    version,
    unity = "2021.3",
    description = "Extension methods on crack",
    keywords = new[] {"dotnet", "extension-methods"},
    changelogUrl = "https://github.com/oliverbooth/X10D/blob/main/CHANGELOG.md",
    licensesUrl = "https://github.com/oliverbooth/X10D/blob/main/LICENSE.md"
};

using FileStream outputStream = File.Create("package.json");
JsonSerializer.Serialize(outputStream, package, new JsonSerializerOptions {WriteIndented = true});
