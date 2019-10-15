﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;

namespace Demo.ContentDialog
{
    public class MainPageViewModel : ViewModelBase
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
            ShowContentDialog(viewModel => dialogService.ShowContentDialogAsync<AddTextContentDialog>(viewModel));
        }

        private async void ShowContentDialog(Func<AddTextContentDialogViewModel, IAsyncOperation<ContentDialogResult>> showDialog)
        {
            var dialogViewModel = new AddTextContentDialogViewModel();

            ContentDialogResult result = await showDialog(dialogViewModel);
            if (result == ContentDialogResult.Primary)
            {
                Texts.Add(dialogViewModel.Text);
            }
        }
    }
}