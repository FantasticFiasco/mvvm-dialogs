using System.Windows.Input;
using Demo.CustomDialogTypeLocator.ComponentA;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;

namespace Demo.CustomDialogTypeLocator
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly IDialogService dialogService;

        public MainWindowVM()
        {
            dialogService = new DialogService(dialogTypeLocator: new MyCustomDialogTypeLocator());

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
