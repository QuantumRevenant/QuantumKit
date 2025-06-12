# QuantumKit.Tools ⚙️

**QuantumKit.Tools** is a utility library written in **C# (.NET 8.0)**, designed for personal and professional projects that require reusable, modular, and practical tools. It provides components for common tasks such as string manipulation, file handling, validation, console utilities, and more.

The goal is to offer a robust toolkit that can be included as a Git submodule or distributed through NuGet in future versions.

---

## Requirements 📦

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

---

## Installation ⚙️

Add this library to your repository as a submodule:

```
git submodule add https://github.com/QuantumRevenant/QuantumKit.Tools.git
```

Or simply clone it:

```
git clone https://github.com/QuantumRevenant/QuantumKit.Tools.git
```

---

## Usage 🚀

Reference the project in your solution (`.sln`) or add it to your project directly.

Build the library:

```
dotnet build QuantumKit.Tools/QuantumKit.Tools.csproj
```

Example usage:

```csharp
using QuantumKit.Tools.Strings;
using QuantumKit.Tools.IO;
using QuantumKit.Tools.ConsoleUtils;
// etc.
```

> NuGet support is planned for future releases.

---

## Key Features 🧩

- Interactive console utilities
- Advanced string manipulation
- Regex and path validation
- File utilities (including Excel generation)
- Modular design for easy maintenance
- Cross-platform (.NET 8.0)

---

## Third-party dependencies

This library uses the following third-party components:

- [ClosedXML](https://github.com/ClosedXML/ClosedXML) (MIT License)
- [SixLabors.Fonts](https://github.com/SixLabors/Fonts) (Apache-2.0 License), indirectly via ClosedXML

---

## License 📝

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.

---

## Contact ✉️

[![X (Twitter)](https://img.shields.io/badge/X_(Twitter)%09--%40QuantumRevenant-%23000000.svg?logo=X&logoColor=white)](https://twitter.com/QuantumRevenant)  
[![GitHub](https://img.shields.io/badge/GitHub%09--%40QuantumRevenant-%23121011.svg?logo=github&logoColor=white)](https://github.com/QuantumRevenant)

---

## Contributing 🤝

See the [CONTRIBUTING](CONTRIBUTING.md) file for contribution guidelines.

---

## Authors 👥

- [QuantumRevenant](https://github.com/QuantumRevenant)

---

## Notice ⚠️

This library is under active development and may undergo structural changes. It is not yet intended for production use.

---

## Changelog 📘

See [CHANGELOG](CHANGELOG.md) for the list of updates.
