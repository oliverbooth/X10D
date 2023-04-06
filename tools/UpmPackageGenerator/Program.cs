using System.Reflection;
using System.Text.Json;

string version;

string? githubSha = Environment.GetEnvironmentVariable("GITHUB_SHA");
Console.WriteLine(string.IsNullOrWhiteSpace(githubSha)
    ? "GITHUB_SHA environment variable not found. This is not a CI run."
    : $"Building from commit {githubSha}.");

if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
{
    Console.WriteLine("No input file specified. Attempting to use GITHUB_SHA.");
    version = githubSha ?? "0.0.0";
}
else
{
    string path = args[0];
    var assembly = Assembly.LoadFrom(path);
    var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
    if (attribute is null || string.IsNullOrWhiteSpace(attribute.InformationalVersion))
    {
        Console.WriteLine("AssemblyInformationalVersionAttribute not found. Attempting to use GITHUB_SHA.");
        version = githubSha ?? "0.0.0";
    }
    else
    {
        Console.WriteLine("AssemblyInformationalVersionAttribute found.");
        version = attribute.InformationalVersion;
    }
}

Console.WriteLine($"Building for version {version}.");

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

using FileStream stream = File.Open("package.json", FileMode.Create, FileAccess.ReadWrite);
Console.WriteLine("Serializing package.json.");
JsonSerializer.Serialize(stream, package, new JsonSerializerOptions {WriteIndented = true});
stream.Position = 0;
stream.CopyTo(Console.OpenStandardOutput());
