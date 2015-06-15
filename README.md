# MVVM Dialogs

![MVVM Dialogs logo](design/Icon_128x128.png)

### Introduction

MVVM Dialogs is a framework simplifying the concept of opening dialogs from a view model when using MVVM in WPF. It enables the developer to write unit tests for the view models in the same way unit tests are written for other classes.

### Usage

Decorate the XAML with the following attached property:

```xaml
<UserControl
  x:Class="DemoApplication.Features.Dialog.Modal.Views.ModalDialogTabContent"
  ...
  xmlns:md="https://github.com/fantasticfiasco/mvvm-dialogs"
  md:DialogServiceViews.IsRegistered="True">
  ...
</UserControl>
```

and then the view model can open dialogs using the following code:

```C#
public class ModalDialogTabContentViewModel : ReactiveObject
{
  private readonly IDialogService dialogService;

  public ModalDialogTabContentViewModel(IDialogService dialogService)
  {
    this.dialogService = dialogService;
  }

  ...

  private void ImplicitShowDialog()
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

### Install MVVM Dialogs via NuGet

If you want to include MVVM Dialogs in your project, you can [install it directly from NuGet](https://www.nuget.org/packages/MvvmDialogs/)

To install MVVM Dialogs, run the following command in the Package Manager Console

```
PM> Install-Package MvvmDialogs
```