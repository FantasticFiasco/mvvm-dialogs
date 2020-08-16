# Change Log

All notable changes to this project will be documented in this file.

This project adheres to [Semantic Versioning](http://semver.org/) and is following the [change log format](http://keepachangelog.com).

## Unreleased

NOTE: Features with breaking changes are found on branch [releases/v8](https://github.com/FantasticFiasco/mvvm-dialogs/tree/releases/v8) and will stay there until a new major version is released. Until then the features have been published to [www.nuget.org](https://www.nuget.org/packages/MvvmDialogs/) as pre-releases to v8.

### :syringe: Changed

- [#116](https://github.com/FantasticFiasco/mvvm-dialogs/issues/116) [BREAKING CHANGE] `IDialogService.Close` returns `false` instead of throwing an exception when failing to close a dialog. This behavior aligns with the behavior of `IDialogService.Activate`.

## 7.1.1 - 2020-08-27

### :syringe: Fixed

- Specify dependency groups in nuspec for each supported framework version
- [#122](https://github.com/FantasticFiasco/mvvm-dialogs/issues/122) Fix memory leak where `Window.Closed` events never where un-registered (discovered by [@peter-durrant](https://github.com/peter-durrant))

## 7.1.0 - 2020-06-07

### :zap: Added

- [#107](https://github.com/FantasticFiasco/mvvm-dialogs/issues/107) Support for closing a non-modal dialog using `IDialogService.Close` (proposed by [@metal450](https://github.com/metal450))

### :syringe: Fixed

- Typo in exception message thrown when view isn't registered

## 7.0.0 - 2020-01-28

### :zap: Added

- [#91](https://github.com/FantasticFiasco/mvvm-dialogs/issues/91) Added the following settings for parity with the native Windows dialogs (proposed by [@Kimmerest](https://github.com/Kimmerest))
    - `FolderBrowserDialogSettings`
        - `RootFolder` - The root folder where the browsing starts from
    - `MessageBoxSettings`
        - `Options` - A value object that specifies the options
    - `OpenFileDialogSettings`
        - `CustomPlaces` - The list of custom places for file dialog boxes
        - `DereferenceLinks` - A value indicating whether a file dialog returns either the location of the file referenced by a shortcut or the location of the shortcut file (.lnk)
        - `ReadOnlyChecked` - A value indicating whether the read-only check box displayed by the open file dialog is selected
        - `SafeFileName` - A string that only contains the file name for the selected file
        - `SafeFileNames` - An array that contains one safe file name for each selected file
        - `ShowReadOnly` - A value indicating whether the open file dialog contains a read-only check box
        - `ValidateNames` - A value indicating whether the dialog accepts only valid Win32 file names
    - `SaveFileDialogSettings`
        - `CustomPlaces` - The list of custom places for file dialog boxes
        - `DereferenceLinks` - A value indicating whether a file dialog returns either the location of the file referenced by a shortcut or the location of the shortcut file (.lnk)
        - `SafeFileName` - A string that only contains the file name for the selected file
        - `SafeFileNames` - An array that contains one safe file name for each selected file
        - `ValidateNames` - A value indicating whether the dialog accepts only valid Win32 file names

### :syringe: Changed

- [BREAKING CHANGE] The default value of `SaveFileDialogSettings.CheckFileExists` has changed from `true` to `false`, aligning it with the default value of the native Windows `SaveFileDialog`

## 6.0.0 - 2019-11-02

### :zap: Added

- [#55](https://github.com/FantasticFiasco/mvvm-dialogs/issues/55) Support for .NET Core 3.0 (proposed by [@virzak](https://github.com/virzak))
- [#55](https://github.com/FantasticFiasco/mvvm-dialogs/issues/55) NuGet package supporting .NET 4.5.2, .NET 4.6.2 and .NET 4.7.2

### :dizzy: Changed

- [BREAKING CHANGE] Adaptation to [nullable references in C# 8.0](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references) introduced breaking changes to the API

## 5.3.0 - 2019-04-29

### :zap: Added

- Support for activating non-modal dialogs using `IDialogService.Activate`

## 5.2.2 - 2019-03-13

### :syringe: Fixed

- `Logger.Writer` does not throw exception when being set to `null` (contributed by [@MathewSachin](https://github.com/MathewSachin))

## 5.2.1 - 2018-10-30

### :syringe: Fixed

- [#49](https://github.com/FantasticFiasco/mvvm-dialogs/issues/49) `FilterIndex` wasn't updated on closed Open/Save File dialog (discovered by [@ericdc66](https://github.com/ericdc66))

## 5.2.0 - 2018-10-11

### :zap: Added

- Overload `ShowMessageBox(INotifyPropertyChanged, MessageBoxSettings)` to `IDialogService`

## 5.1.0 - 2017-12-18

### :zap: Added

- Extended support for [MVVM Dialogs Contrib](https://github.com/FantasticFiasco/mvvm-dialogs-contrib)

## 5.0.0 - 2017-12-12

### :zap: Added

- [#30](https://github.com/FantasticFiasco/mvvm-dialogs/issues/30) Support for customizing the following Windows dialogs (contributed by [@pdinnissen](https://github.com/pdinnissen)):
    - Message box
    - Open file dialog
    - Save file dialog
    - Folder browser dialog

### :skull: Removed

- [BREAKING CHANGE] Reduce the constructors overloads in `DialogService` into:
    - `ctor()` - Default constructor that takes no arguments
    - `ctor(IDialogFactory?, IDialogTypeLocator?, IFrameworkDialogFactory?)` - Constructor that allows full customization

## 4.1.1 - 2017-09-07

### :zap: Added

- Option to set filter index when opening or saving a file (contributed by [@gigios](https://github.com/gigios))

## 4.0.10 - 2017-04-20

### :dizzy: Changed

- Improve exception message when dialog type locator fails

## 4.0.0 - 2016-11-27

### :zap: Added

- [#14](https://github.com/FantasticFiasco/mvvm-dialogs/issues/14) [BREAKING CHANGE] Support for showing custom WPF dialogs by implementing `IWindow` (proposed by [@wakuflair](https://github.com/wakuflair))
- Support for showing custom UWP content dialogs by implementing `IContentDialog`

## 3.0.0 - 2016-09-21

### :dizzy: Changed

- [BREAKING CHANGE] Updated the constructors of `DialogService`, making the class more friendly to IoC containers

## 2.0.1 - 2016-05-18

### :zap: Added

- [#8](https://github.com/FantasticFiasco/mvvm-dialogs/issues/8) Support for Universal Windows Platform (UWP) (proposed by [@MrWolfPST](https://github.com/MrWolfPST))
- Add `ViewNotRegisteredException` that is thrown by `IDialogService` when view is unregistered

## 1.2.16 - 2016-01-13

### :syringe: Fixed

- [#2](https://github.com/FantasticFiasco/mvvm-dialogs/issues/2) Fixed issue where exception was thrown when unregistering a view (discovered by [@Andy360](https://github.com/Andy360))

## 1.2.0 - 2015-12-14

### :zap: Added

- Support for exposing logs using class `MvvmDialogs.Logging.Logger`

## 1.1.4 - 2015-12-09

### :syringe: Fixed

- [#3](https://github.com/FantasticFiasco/mvvm-dialogs/issues/3) Fixed issue where exception no longer is thrown when the property changed event for `IModalDialogViewModel.DialogResult` is sent twice (discovered by [@igitur](https://github.com/igitur))

## 1.1.3 - 2015-07-07

### :syringe: Fixed

- NuGet icon URL

## 1.1.2 - 2015-06-12

### :dizzy: Changed

- Renamed `DialogServiceBehaviors` to `DialogServiceViews`

## 1.1.1 - 2015-06-11

### :zap: Added

- Apache license
- NuGet package supporting .NET 3.5, .NET 4.0 and .NET 4.5
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
