using System;
using System.Windows;
using System.Windows.Input;
using MvvmDialogs;
using ReactiveUI;

namespace DemoApplication.Features.MessageBox.ViewModels
{
    public class MessageBoxTabContentViewModel : ReactiveObject
    {
        private readonly IDialogService dialogService;
        private readonly ReactiveCommand<object> showMessageBoxWithMessageCommand;
        private readonly ReactiveCommand<object> showMessageBoxWithCaptionCommand;
        private readonly ReactiveCommand<object> showMessageBoxWithButtonCommand;
        private readonly ReactiveCommand<object> showMessageBoxWithIconCommand;
        private readonly ReactiveCommand<object> showMessageBoxWithDefaultResultCommand;

        public MessageBoxTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            showMessageBoxWithMessageCommand = ReactiveCommand.Create();
            showMessageBoxWithMessageCommand.Subscribe(_ => ShowMessageBoxWithMessage());

            showMessageBoxWithCaptionCommand = ReactiveCommand.Create();
            showMessageBoxWithCaptionCommand.Subscribe(_ => ShowMessageBoxWithCaption());

            showMessageBoxWithButtonCommand = ReactiveCommand.Create();
            showMessageBoxWithButtonCommand.Subscribe(_ => ShowMessageBoxWithButton());

            showMessageBoxWithIconCommand = ReactiveCommand.Create();
            showMessageBoxWithIconCommand.Subscribe(_ => ShowMessageBoxWithIcon());

            showMessageBoxWithDefaultResultCommand = ReactiveCommand.Create();
            showMessageBoxWithDefaultResultCommand.Subscribe(_ => ShowMessageBoxWithDefaultResult());
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