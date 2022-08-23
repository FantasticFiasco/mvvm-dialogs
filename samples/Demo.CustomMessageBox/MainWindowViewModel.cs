using System;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;

namespace Demo.CustomMessageBox
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;

        private string? confirmation;
        
        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            ShowMessageBoxWithMessageCommand = new RelayCommand(ShowMessageBoxWithMessage);
            ShowMessageBoxWithCaptionCommand = new RelayCommand(ShowMessageBoxWithCaption);
            ShowMessageBoxWithButtonCommand = new RelayCommand(ShowMessageBoxWithButton);
            ShowMessageBoxWithIconCommand = new RelayCommand(ShowMessageBoxWithIcon);
            ShowMessageBoxWithDefaultResultCommand = new RelayCommand(ShowMessageBoxWithDefaultResult);
        }

        public ICommand ShowMessageBoxWithMessageCommand { get; }

        public ICommand ShowMessageBoxWithCaptionCommand { get; }

        public ICommand ShowMessageBoxWithButtonCommand { get; }

        public ICommand ShowMessageBoxWithIconCommand { get; }

        public ICommand ShowMessageBoxWithDefaultResultCommand { get; }

        public string? Confirmation
        {
            get => confirmation;
            private set => SetProperty(ref confirmation, value);
        }

        private void ShowMessageBoxWithMessage()
        {
            MessageBoxResult result = dialogService.ShowMessageBox(
                this,
                "This is the text.");

            UpdateResult(result);
        }

        private void ShowMessageBoxWithCaption()
        {
            MessageBoxResult result = dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption");

            UpdateResult(result);
        }

        private void ShowMessageBoxWithButton()
        {
            MessageBoxResult result = dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OKCancel);

            UpdateResult(result);
        }

        private void ShowMessageBoxWithIcon()
        {
            MessageBoxResult result = dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Information);

            UpdateResult(result);
        }

        private void ShowMessageBoxWithDefaultResult()
        {
            MessageBoxResult result = dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Information,
                MessageBoxResult.Cancel);

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
}
