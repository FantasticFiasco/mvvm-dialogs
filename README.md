<h1 align="center">
    <br>
    <img src="https://raw.githubusercontent.com/FantasticFiasco/mvvm-dialogs/master/doc/resources/Icon_200x200.png" alt="MVVM Dialogs" width="200">
    <br>
    MVVM Dialogs
    <br>
</h1>

<h4 align="center">Library simplifying the concept of opening dialogs from a view model when using MVVM in WPF or UWP.</h4>

<p align="center">
    <a href="https://ci.appveyor.com/project/FantasticFiasco/mvvm-dialogs/branch/master"><img src="https://ci.appveyor.com/api/projects/status/9eyvxv5jr9bybant/branch/master?svg=true"></a>
    <a href="https://www.nuget.org/packages/MvvmDialogs/"><img src="https://img.shields.io/nuget/v/MvvmDialogs.svg"></a>
    <a href="https://semver.org/"><img src="https://img.shields.io/badge/%E2%9C%85-SemVer%20compatible-blue"></a>
    <a href="https://www.nuget.org/packages/MvvmDialogs/"><img src="https://img.shields.io/nuget/dt/MvvmDialogs.svg"></a>
</p>

## Table of contents

- [Introduction](#introduction)
- [WPF usage](#wpf-usage)
- [UWP usage](#uwp-usage)
- [Custom windows](#custom-windows)
- [Custom framework dialogs](#custom-framework-dialogs)
- [More in the wiki](#more-in-the-wiki)
- [Integration into other MVVM frameworks](#integration-into-other-mvvm-frameworks)
- [MVVM Dialogs Contrib](#mvvm-dialogs-contrib)
- [Install MVVM Dialogs via NuGet](#install-mvvm-dialogs-via-nuget)
- [History](#history)
- [Reputation](#reputation)
- [Credit](#credit)

---

## Introduction

MVVM Dialogs is a library simplifying the concept of opening dialogs from a view model when using MVVM in WPF (Windows Presentation Framework) or UWP (Universal Windows Platform). It enables the developer to easily write unit tests for view models in the same manner unit tests are written for other classes.

The library has built in support for the following dialogs in WPF:

- Modal window
- Non-modal window
- Message box
- Open file dialog
- Save file dialog
- Folder browser dialog

The library has built in support for the following dialogs in UWP:

- Content dialog
- Message dialog
- Single file picker
- Multiple files picker
- Save file picker
- Single folder picker

## WPF usage

To open a modal window, decorate the view with the attached property `DialogServiceViews.IsRegistered`:

```xaml
<UserControl
    x:Class="DemoApplication.Features.Dialog.Modal.Views.ModalDialogTabContent"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:md="https://github.com/fantasticfiasco/mvvm-dialogs"
    md:DialogServiceViews.IsRegistered="True">

  ...

</UserControl>
```

With the view registered the view model is now capable of opening a dialog using the interface `IDialogService`:

```c#
public class ModalDialogTabContentViewModel : INotifyPropertyChanged
{
    private readonly IDialogService dialogService;

    public ModalDialogTabContentViewModel(IDialogService dialogService)
    {
        this.dialogService = dialogService;
    }

    ...

    private void ShowDialog()
    {
        var dialogViewModel = new AddTextDialogViewModel();

        bool? success = dialogService.ShowDialog(this, dialogViewModel);
        if (success == true)
        {
            Texts.Add(dialogViewModel.Text);
        }
    }
}
```

## UWP usage

With UWP you don't need to register the view, simply open the dialog using the interface `IDialogService`:

```c#
public class MainPageViewModel : INotifyPropertyChanged
{
    private readonly IDialogService dialogService;

    public MainPageViewModel(IDialogService dialogService)
    {
        this.dialogService = dialogService;
    }

    ...

    private async void ShowContentDialog()
    {
        var dialogViewModel = new AddTextContentDialogViewModel();

        ContentDialogResult result = await dialogService.ShowContentDialogAsync(dialogViewModel);
        if (result == ContentDialogResult.Primary)
        {
            Texts.Add(dialogViewModel.Text);
        }
    }
}
```

## Custom windows

Dialogs in WPF that doesn't inherit from `Window`, or content dialogs in UWP that doesn't inherit from `ContentDialog`, are called custom dialogs. These custom dialogs are supported, but in order for `DialogService` to know how to interact with them, you will have to implement the `IWindow` interface in WPF or `IContentDialog` in UWP.

## Custom framework dialogs

MVVM Dialogs is by default opening the standard Windows message box or the open file dialog when asked to. This can however be changed by providing your own implementation of `IFrameworkDialogFactory` to `DialogService`.

## More in the wiki

For more information regarding the concepts of MVVM Dialogs and extended samples on the subjects, please see the [wiki](https://github.com/FantasticFiasco/mvvm-dialogs/wiki).

## Integration into other MVVM frameworks

For the benefit of all we aim to play nice with existing MVVM frameworks. Creating a new application can be daunting. Lots of decisions have to be made, and some mistakes are harder to correct than others. To help you on your way we've created a sample application using some of the popular MVVM frameworks existing today, to show you how you'd integrate MVVM Dialogs into that framework.

Currently the sample application is implemented using the following frameworks.

- [Caliburn.Micro](https://github.com/FantasticFiasco/mvvm-dialogs-integrated-into-caliburn-micro)
- [MVVM Light Toolkit](https://github.com/FantasticFiasco/mvvm-dialogs-integrated-into-mvvm-light-toolkit)
- [Windows Community Toolkit](https://github.com/FantasticFiasco/mvvm-dialogs-integrated-into-windows-community-toolkit)

If your specific framework isn't among the listed, please create a new pull request and let us know.

## MVVM Dialogs Contrib

The world is full of snowflakes and all applications are unique in some way. MVVM Dialogs takes no claim to solve all issues regarding dialogs, but is a fantastic solution for most applications. The rest, the applications deviating from the common path, may require specific changes to the behavior of MVVM Dialog. For those there is [MVVM Dialogs Contrib](https://github.com/FantasticFiasco/mvvm-dialogs-contrib). A repository with features and functionality developed by the open source community, solving very specific needs.

If MVVM Dialogs for some reason doesn't fit your application, raise an issue in [MVVM Dialogs Contrib](https://github.com/FantasticFiasco/mvvm-dialogs-contrib) and we'll see what we can do. These features are always implemented by the community, but shepherded by the maintainers of MVVM Dialogs.

## Install MVVM Dialogs via NuGet

If you want to include MVVM Dialogs in your project, you can [install it directly from NuGet](https://www.nuget.org/packages/MvvmDialogs/).

To install MVVM Dialogs, run the following command in the Package Manager Console:

```powershell
PM> Install-Package MvvmDialogs
```

## History

MVVM Dialogs started out as an [article on CodeProject](https://www.codeproject.com/Articles/36745/Showing-Dialogs-When-Using-the-MVVM-Pattern-in-WPF) with its first revision published in May 2009. At that time MVVM was still new and fresh, and the now deprecated [MVVM Light](http://www.mvvmlight.net/) had yet not been published. In fact, none of the MVVM libraries commonly used today existed back then. MVVM Dialogs came about out of necessity to work with dialogs from the view model, a reaction to the fact that although MVVM was a popular pattern, the support to implement it was rather limited.

So, the initial publication was over 10 years ago. Give that a thought. An open source project that after 10 years still is maintained and extremely relevant with the release of .NET Core 3. Take that all you out there claiming open source code is volatile!

![MVVM Dialogs anniversary](doc/resources/cake.png)

Hip hip hooray!

## Reputation

MVVM Dialogs has earned enough reputation to be listed on [Awesome .NET!](https://github.com/quozd/awesome-dotnet), in company with other awesome MVVM libraries.

## Credit

Thank you [JetBrains](https://www.jetbrains.com/) for your important initiative to support the open source community with free licenses to your products.

![JetBrains](./doc/resources/jetbrains.png)
