# Change Log

All notable changes to this project will be documented in this file.

This project adheres to [Semantic Versioning](http://semver.org/) and is following the [change log format](http://keepachangelog.com).

## Unreleased

### :syringe: Fixed

- `Logger.Writer` does not throw exception when being set to `null` (contribution by [@MathewSachin](https://github.com/MathewSachin))

## 5.2.1 - 2018-10-30

### :syringe: Fixed

- [#49](https://github.com/FantasticFiasco/mvvm-dialogs/issues/49) - `FilterIndex` wasn't updated on closed Open/Save File dialog

## 5.2.0 - 2018-10-11

### :zap: Added

- Overload `ShowMessageBox(INotifyPropertyChanged, MessageBoxSettings)` to `IDialogService`

## 5.1.0 - 2017-12-18

### :zap: Added

- Extended support for [MVVM Dialogs Contrib](https://github.com/FantasticFiasco/mvvm-dialogs-contrib)

## 5.0.0 - 2017-12-12

### :zap: Added

- [#30](https://github.com/FantasticFiasco/mvvm-dialogs/issues/30) Support for customizing the following Windows dialogs (contribution by [@pdinnissen](https://github.com/pdinnissen)):
    - Message box
    - Open file dialog
    - Save file dialog
    - Folder browser dialog

### :skull: Removed

- Reduce the constructors overloads in `DialogService` into:
    - `ctor()` - Default constructor that takes no arguments
    - `ctor(IDialogFactory?, IDialogTypeLocator?, IFrameworkDialogFactory?)` - Constructor that allows full customization

## 4.1.1 - 2017-09-07

### :zap: Added

- Option to set filter index when opening or saving a file (contribution by [@gigios](https://github.com/gigios))

## 4.0.10 - 2017-04-20

### :dizzy: Changed

- Improve exception message when dialog type locator fails

## 4.0.0 - 2016-11-27

### :zap: Added

- [#14](https://github.com/FantasticFiasco/mvvm-dialogs/issues/14) - Support for showing custom WPF dialogs by implementing `IWindow`
- Support for showing custom UWP content dialogs by implementing `IContentDialog`

## 3.0.0 - 2016-09-21

### :dizzy: Changed

- Updated the constructors of `DialogService`, making the class more friendly to IoC containers

## 2.0.1 - 2016-05-18

### :zap: Added

- [#8](https://github.com/FantasticFiasco/mvvm-dialogs/issues/8) - Support for Universal Windows Platform (UWP)
- Add `ViewNotRegisteredException` that is thrown by `IDialogService` when view is unregistered

## 1.2.16 - 2016-01-13

### :syringe: Fixed

- [#2](https://github.com/FantasticFiasco/mvvm-dialogs/issues/2) - Fixed issue where exception was thrown when unregistering a view

## 1.2.0 - 2015-12-14

### :zap: Added

- Support for exposing logs using class `MvvmDialogs.Logging.Logger`

## 1.1.4 - 2015-12-09

### :syringe: Fixed

- [#3](https://github.com/FantasticFiasco/mvvm-dialogs/issues/3) - Fixed issue where exception no longer is thrown when the property changed event for `IModalDialogViewModel.DialogResult` is sent twice

## 1.1.3 - 2015-07-07

### :syringe: Fixed

- NuGet icon URL

## 1.1.2 - 2015-06-12

### :dizzy: Changed

- Renamed `DialogServiceBehaviors` to `DialogServiceViews`

## 1.1.1 - 2015-06-11

### :zap: Added

- Apache license
- NuGet package supporting .NET3.5, .NET4.0 and .NET4.5
- Support for specifying a dialog factory used by `DialogService`, enabling inversion of control integration
- Support for specifying a dialog type locator used by `DialogService`, enabling implementation of custom dialogs type locators
- `DialogService` is referencing registered views using weak references, thus never preventing a view from being garbage collected
- Pruning of view references that no longer are alive
- XML namespace prefix
- Strong name

### :syringe: Fixed

- Issue where exception was thrown when the same view was registered twice, and one hadn't been garbage collected yet

## 1.1.0 - 2015-06-11 [YANKED]

## 1.0.0 - 2009-05-25

Initial version
