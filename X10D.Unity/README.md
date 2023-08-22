<h1 align="center"><img src="https://raw.githubusercontent.com/oliverbooth/X10D/main/X10D.Unity/branding_Unity.png"></h1>
<p align="center">
<a href="https://github.com/oliverbooth/X10D/actions/workflows/unity.yml"><img src="https://img.shields.io/github/actions/workflow/status/oliverbooth/X10D/unity.yml?style=flat-square" alt="GitHub Workflow Status" title="GitHub Workflow Status"></a>
<a href="https://github.com/oliverbooth/X10D/tree/upm"><img src="https://img.shields.io/github/package-json/v/oliverbooth/X10D/upm?label=upm&style=flat-square" title="UPM Version"></a>
<a href="https://github.com/oliverbooth/X10D/blob/master/LICENSE.md"><img src="https://img.shields.io/github/license/oliverbooth/X10D?style=flat-square" alt="MIT License" title="MIT License"></a>
</p>

### About
X10D (pronounced *extend*), is a .NET package that provides extension methods for numerous types. The purpose of this library is to simplify a codebase by reducing the need for repeated code when performing common operations. Simplify your codebase. Take advantage of .NET. Use extension methods.

*(I'm also [dogfooding](https://www.pcmag.com/encyclopedia/term/dogfooding) this library, so there's that.)*


### Preface
Parity with the main branch of X10D, and full .NET feature support, is planned. Unity plan to add CoreCLR and native NuGet support in the future, but no timeline is available.
For more information, see [this forum post](https://forum.unity.com/threads/unity-future-net-development-status.1092205/).

## Installation
You must be using Unity 2021.3 LTS or later to add this package.
### Using the Unity Package Manager (UPM)
To install X10D in Unity, follow the steps blow:
1. Navigate to the [Package Manager window](https://docs.unity3d.com/Manual/upm-ui.html), under `Window > Package Manager`
2. Hit the `+` icon and select `Add package from git URL...`
3. Enter the following URL: https://github.com/oliverbooth/X10D.git#upm and hit the Add button
4. Profit!

The [upm](https://github.com/oliverbooth/X10D/tree/upm) branch contains the latest nightly - that is the bleeding edge version of X10D.
If you'd like to remain on a stable release, specify a commit hash after the `#` instead of `upm`.
The latest current stable is 3.3.1, which is commit [0bb35bb565fff170a3848acdffbb5d53087de64b](https://github.com/oliverbooth/X10D/commit/0bb35bb565fff170a3848acdffbb5d53087de64b).
Keep in mind that referencing a specific commit rather than the `upm` branch will prevent the auto-updater in Unity from detecting new versions. 

## Contributing
Contributions are welcome. See [CONTRIBUTING.md](../CONTRIBUTING.md).

## License
X10D is released under the MIT License. See [here](https://github.com/oliverbooth/X10D/blob/main/LICENSE.md) for more details.
