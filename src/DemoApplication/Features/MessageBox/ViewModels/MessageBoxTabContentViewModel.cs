using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace DemoApplication.Features.MessageBox.ViewModels
{
    [Export]
    public class MessageBoxTabContentViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;
        private readonly ICommand showMessageBoxWithMessageCommand;
        private readonly ICommand showMessageBoxWithCaptionCommand;
        private readonly ICommand showMessageBoxWithButtonCommand;
        private readonly ICommand showMessageBoxWithIconCommand;
        private readonly ICommand showMessageBoxWithDefaultResultCommand;

        [ImportingConstructor]
        public MessageBoxTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            showMessageBoxWithMessageCommand = new RelayCommand(ShowMessageBoxWithMessage);
            showMessageBoxWithCaptionCommand = new RelayCommand(ShowMessageBoxWithCaption);
            showMessageBoxWithButtonCommand = new RelayCommand(ShowMessageBoxWithButton);
            showMessageBoxWithIconCommand = new RelayCommand(ShowMessageBoxWithIcon);
            showMessageBoxWithDefaultResultCommand = new RelayCommand(ShowMessageBoxWithDefaultResult);
        }

        public ICommand ShowMessageBoxWithMessageCommand
        {
            get { return showMessageBoxWithMessageCommand; }
        }

        public ICommand ShowMessageBoxWithCaptionCommand
        {
            get { return showMessageBoxWithCaptionCommand; }
        }

        public ICommand ShowMessageBoxWithButtonCommand
        {
            get { return showMessageBoxWithButtonCommand; }
        }

        public ICommand ShowMessageBoxWithIconCommand
        {
            get { return showMessageBoxWithIconCommand; }
        }

        public ICommand ShowMessageBoxWithDefaultResultCommand
        {
            get { return showMessageBoxWithDefaultResultCommand; }
        }

        private void ShowMessageBoxWithMessage()
        {
            dialogService.ShowMessageBox(
                this,
                "This is the text.");
        }

        private void ShowMessageBoxWithCaption()
        {
            dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption");
        }

        private void ShowMessageBoxWithButton()
        {
            dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OKCancel);
        }

        private void ShowMessageBoxWithIcon()
        {
            dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Information);
        }

        private void ShowMessageBoxWithDefaultResult()
        {
            dialogService.ShowMessageBox(
                this,
                "This is the text.",
                "This Is The Caption",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Information,
                MessageBoxResult.Cancel);
        }
    }
}