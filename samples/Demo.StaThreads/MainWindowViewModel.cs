using System;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;

namespace Demo.StaThreads;

public class MainWindowViewModel : ObservableObject
{
    private readonly IDialogService dialogService;

    private string? confirmation;
        
    public MainWindowViewModel(IDialogService dialogService)
    {
        this.dialogService = dialogService;

        ShowMessageBoxCommand = new RelayCommand(ShowMessageBox);
    }

    public ICommand ShowMessageBoxCommand { get; }

    public string? Confirmation
    {
        get => confirmation;
        private set => SetProperty(ref confirmation, value);
    }

    private void ShowMessageBox()
    {
        MessageBoxResult result = dialogService.ShowMessageBox(
            this,
            "This is the text.");

        UpdateResult(result);
    }

    private void UpdateResult(MessageBoxResult result)
    {
        switch (result)
        {
            case MessageBoxResult.OK:
                Confirmation = "We got confirmation to continue!";
                break;

            case MessageBoxResult.Cancel:
                Confirmation = string.Empty;
                break;

            default:
                throw new NotSupportedException($"{confirmation} is not supported.");
        }
    }
}