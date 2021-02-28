using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Demo.CustomDialogTypeLocator.Core.ComponentA;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;

namespace Demo.CustomDialogTypeLocator.Core
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly IDialogService dialogService;

        public MainWindowVM()
        {
            dialogService = new DialogService();

            ShowDialogCommand = new RelayCommand(ShowDialog);
        }

        public ICommand ShowDialogCommand { get; }

        private void ShowDialog()
        {
            var dialogViewModel = new MyDialogVM();
            dialogService.ShowDialog(this, dialogViewModel);
        }
    }
}
