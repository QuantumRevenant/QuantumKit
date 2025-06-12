# Changelog

All notable changes to this project will be documented in this file.

The format follows [Keep a Changelog](https://keepachangelog.com/en/1.0.0/)  
and the project uses [Semantic Versioning](https://semver.org/).

## [v1.0.1] - 2025-06-12
### Fixed
- 🐛 Fixed embedded resource loading issue by allowing `JsonFromEmbeddedResource` to receive an `Assembly` parameter. This enables loading resources from the main executable.
- 🔧 Renamed the project folder from `QuantumKit.Tools` to `QuantumKit` for naming consistency.

## [1.0.0] - 2025-06-11

### Added
- Initial implementation of the project.
- `ConsoleMenuBuilder` for interactive console menus, with:
  - Support for main and submenus.
  - Input validation for numbers, paths, filenames, and strings.
  - Customizable confirmation prompts and binary choices.
  - Error handling and user-friendly messages.
- `ExcelBuilder` for generating Excel `.xlsx` files from CSV-like input:
  - Automatic detection of dates (dd/MM/yyyy), percentages, numbers, and text.
  - Proper cell formatting for each data type.
  - Row-by-row building and file export support.
