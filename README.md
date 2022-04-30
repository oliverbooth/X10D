<h1 align="center"><img src="https://raw.githubusercontent.com/oliverbooth/X10D/develop/banner.png"></h1>
<p align="center">
<a href="https://github.com/oliverbooth/X10D/actions?query=workflow%3A%22.NET+Core%22"><img src="https://img.shields.io/github/workflow/status/oliverbooth/X10D/.NET%20Core" alt="GitHub Workflow Status" title="GitHub Workflow Status"></a>
<a href="https://github.com/oliverbooth/X10D/issues"><img src="https://img.shields.io/github/issues/oliverbooth/X10D" alt="GitHub Issues" title="GitHub Issues"></a>
<a href="https://sonarcloud.io/dashboard?id=oliverbooth_X10D"><img src="https://img.shields.io/sonar/coverage/oliverbooth_X10D?server=https%3A%2F%2Fsonarcloud.io" alt="Coverage"></a>
<a href="https://www.nuget.org/packages/X10D/"><img src="https://img.shields.io/nuget/dt/X10D" alt="NuGet Downloads" title="NuGet Downloads"></a>
<a href="https://www.nuget.org/packages/X10D/"><img src="https://img.shields.io/nuget/v/X10D?label=stable" alt="Stable Version" title="Stable Version"></a>
<a href="https://www.nuget.org/packages/X10D/"><img src="https://img.shields.io/nuget/vpre/X10D?label=nightly" alt="Nightly Version" title="Nightly Version"></a>
<a href="https://github.com/oliverbooth/X10D/blob/master/LICENSE.md"><img src="https://img.shields.io/github/license/oliverbooth/X10D" alt="MIT License" title="MIT License"></a>
</p>

### About
X10D (pronounced *extend*), is a .NET package that provides extension methods for numerous types. The purpose of this library is to simplify a codebase by reducing the need for repeated code when performing common operations. Simplify your codebase. Take advantage of .NET. Use extension methods.

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
### NuGet installation
```ps
Install-Package X10D -Version 3.0.0
```

### Manual installation
Download the [latest release](https://github.com/oliverbooth/X10D/releases/latest) from this repository and adding a direct assembly reference for your chosen platform.

### What happened to X10D.Unity?
I decided it was time for X10D to be migrated to .NET 6. Unity currently supports .NET Framework 4.x / .NET Standard 2.1, and as such is not compatible with X10D at this time.
Unity have announced official support for .NET 6 in the future (see [this forum post](https://forum.unity.com/threads/unity-future-net-development-status.1092205/) for more details),
but until such a time that Unity supports .NET 6, X10D.Unity will not be maintained or innovated upon.

## Features
I'm planning on writing complete and extensive documentation in the near future. As of this time, feel free to browse the source or the API using your favourite IDE.
For those familiar with the 2.6.0 API, please read [CHANGELOG.md](CHANGELOG.md) for a complete list of changes. **3.0.0 is a major release and introduces many breaking changes.**

## Contributing
Contributions are welcome. See [CONTRIBUTING.md](CONTRIBUTING.md).

## License
X10D is released under the MIT License. See [here](https://github.com/oliverbooth/X10D/blob/master/LICENSE.md) for more details.
