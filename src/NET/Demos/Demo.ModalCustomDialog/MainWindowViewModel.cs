using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace Demo.ModalCustomDialog
{
    public class MainWindowViewModel : ViewModelBase
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
            ShowDialog(viewModel => dialogService.ShowCustomDialog<AddTextCustomDialog>(this, viewModel));
        }

        private void ShowDialog(Func<AddTextCustomDialogViewModel, bool?> showDialog)
        {
            var dialogViewModel = new AddTextCustomDialogViewModel();

            bool? success = showDialog(dialogViewModel);
            if (success == true)
            {
                Texts.Add(dialogViewModel.Text);
            }
        }
    }
}