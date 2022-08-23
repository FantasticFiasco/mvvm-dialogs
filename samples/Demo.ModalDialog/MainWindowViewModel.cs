using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;

namespace Demo.ModalDialog
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;

        public MainWindowViewModel(IDialogService dialogService)
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
            ShowDialog(viewModel => dialogService.ShowDialog(this, viewModel));
        }

        private void ExplicitShowDialog()
        {
            ShowDialog(viewModel => dialogService.ShowDialog<Demo.ModalDialog.AddTextDialog>(this, viewModel));
        }

        private void ShowDialog(Func<AddTextDialogViewModel, bool?> showDialog)
        {
            var dialogViewModel = new AddTextDialogViewModel();

            bool? success = showDialog(dialogViewModel);
            if (success == true)
            {
                Texts.Add(dialogViewModel.Text!);
            }
        }
    }
}
