using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;

namespace Demo.CustomContentDialog
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;

        public MainPageViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            ImplicitShowDialogCommand = new RelayCommand(ImplicitShowDialog);
            ExplicitShowDialogCommand = new RelayCommand(ExplicitShowDialog);
        }

        public ObservableCollection<string> Texts { get; } = new ObservableCollection<string>();

        public ICommand ImplicitShowDialogCommand { get; }

        public ICommand ExplicitShowDialogCommand { get; }

        private void ImplicitShowDialog()
        {
            ShowContentDialog(viewModel => dialogService.ShowContentDialogAsync(viewModel));
        }

        private void ExplicitShowDialog()
        {
            ShowContentDialog(viewModel => dialogService.ShowCustomContentDialogAsync<AddTextCustomContentDialog>(viewModel));
        }

        private async void ShowContentDialog(Func<AddTextCustomContentDialogViewModel, IAsyncOperation<ContentDialogResult>> showDialog)
        {
            var dialogViewModel = new AddTextCustomContentDialogViewModel();

            ContentDialogResult result = await showDialog(dialogViewModel);
            if (result == ContentDialogResult.Primary)
            {
                Texts.Add(dialogViewModel.Text);
            }
        }
    }
}
