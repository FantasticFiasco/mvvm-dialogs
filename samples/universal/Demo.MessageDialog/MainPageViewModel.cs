using System;
using System.Windows.Input;
using Windows.UI.Popups;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;

namespace Demo.MessageDialog
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;

        private string confirmation;

        public MainPageViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            ShowMessageDialogWithContentCommand = new RelayCommand(ShowMessageDialogWithContent);
            ShowMessageDialogWithTitleCommand = new RelayCommand(ShowMessageDialogWithTitle);
            ShowMessageDialogWithCommandsCommand = new RelayCommand(ShowMessageDialogWithCommands);
            ShowMessageDialogWithDefaultCommandCommand = new RelayCommand(ShowMessageDialogWithDefaultCommand);
        }

        public ICommand ShowMessageDialogWithContentCommand { get; }

        public ICommand ShowMessageDialogWithTitleCommand { get; }

        public ICommand ShowMessageDialogWithCommandsCommand { get; }

        public ICommand ShowMessageDialogWithDefaultCommandCommand { get; }

        public string Confirmation
        {
            get => confirmation;
            private set => SetProperty(ref confirmation, value);
        }

        private async void ShowMessageDialogWithContent()
        {
            await dialogService.ShowMessageDialogAsync("This is the text.");
            Confirmation = string.Empty;
        }

        private async void ShowMessageDialogWithTitle()
        {
            await dialogService.ShowMessageDialogAsync(
                "This is the text.",
                "This Is The Title");

            Confirmation = string.Empty;
        }

        private async void ShowMessageDialogWithCommands()
        {
            IUICommand command = await dialogService.ShowMessageDialogAsync(
                "This is the text.",
                "This Is The Title",
                new[]
                {
                    new UICommand { Id = 0, Label = "OK" },
                    new UICommand { Id = 1, Label = "Close" }
                });

            Confirmation = (int)command.Id == 0 ?
                "We got confirmation to continue!" :
                string.Empty;
        }

        private async void ShowMessageDialogWithDefaultCommand()
        {
            IUICommand command = await dialogService.ShowMessageDialogAsync(
                "This is the text.",
                "This Is The Title",
                new[]
                {
                    new UICommand { Id = 0, Label = "OK" },
                    new UICommand { Id = 1, Label = "Close" }
                },
                1);

            Confirmation = (int)command.Id == 0 ?
                "We got confirmation to continue!" :
                string.Empty;
        }
    }
}
