<h1 align="center"><img src="https://raw.githubusercontent.com/oliverbooth/X10D/develop/banner.png"></h1>
<p align="center">
<a href="https://github.com/oliverbooth/X10D/actions?query=workflow%3A%22.NET%22"><img src="https://img.shields.io/github/actions/workflow/status/oliverbooth/X10D/dotnet.yml" alt="GitHub Workflow Status" title="GitHub Workflow Status"></a>
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

## Installation
### NuGet installation
```ps
Install-Package X10D -Version 3.1.0
```

### Manual installation
Download the [latest release](https://github.com/oliverbooth/X10D/releases/latest) from this repository and adding a direct assembly reference for your chosen platform.

### Unity installation
Starting with Unity 2021.2, support for .NET Standard 2.1 has been added. With this change, I am confident providing support for this version for the time being, with only minimal feature-loss.
To add X10D into your Unity project, goto the [Package Manager window](https://docs.unity3d.com/Manual/upm-ui.html), and choose to install from a Git URL, and use the URL https://github.com/oliverbooth/X10D.git#upm

Parity with the main branch of X10D, and full .NET 6 feature support, is planned - but a timeline is not yet available. Unity plan to add .NET 6 support in the near future.
For more information, see [this forum post](https://forum.unity.com/threads/unity-future-net-development-status.1092205/).

## Features
I'm planning on writing complete and extensive documentation in the near future. As of this time, feel free to browse the source or the API using your favourite IDE.
For those familiar with the 2.6.0 API, please read [CHANGELOG.md](CHANGELOG.md) for a complete list of changes. **3.0.0 is a major release and introduces many breaking changes.**

## Contributing
Contributions are welcome. See [CONTRIBUTING.md](CONTRIBUTING.md).

## License
X10D is released under the MIT License. See [here](https://github.com/oliverbooth/X10D/blob/master/LICENSE.md) for more details.
