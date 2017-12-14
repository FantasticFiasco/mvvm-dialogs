using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace Demo.MessageBox
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        private string confirmation;
        
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

        public string Confirmation
        {
            get => confirmation;
            private set { Set(() => Confirmation, ref confirmation, value); }
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