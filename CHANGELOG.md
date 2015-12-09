# Change Log

All notable changes to this project will be documented in this file.

This project adheres to [Semantic Versioning](http://semver.org/) and is following the [change log format](https://github.com/olivierlacan/keep-a-changelog).

## [Unreleased]

## [1.1.3] - 2015-07-07

### Fixed

- NuGet icon URL

## [1.1.2] - 2015-06-12

### Changed

- Renamed `DialogServiceBehaviors` to `DialogServiceViews`

## [1.1.1] - 2015-06-11

### Added

- Apache license
- NuGet package supporting .NET3.5, .NET4.0 and .NET4.5
- Support for specifying a dialog factory used by `DialogService`, enabling inversion of control integration
- Support for specifying a dialog type locator used by `DialogService`, enabling implementation of custom dialogs type locators
- `DialogService` is referencing registered views using weak references, thus never preventing a view from being garbage collected
- Pruning of view references that no longer are alive
- XML namespace prefix
- Strong name

### Fixed

- Issue where exception was thrown when the same view was registered twice, and one hadn't been garbage collected yet

## [1.1.0] - 2015-06-11 [YANKED]

## [1.0.0] - 2009-05-25

Initial version