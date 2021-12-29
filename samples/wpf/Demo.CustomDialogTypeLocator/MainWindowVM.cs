using System.Windows.Input;
using Demo.CustomDialogTypeLocator.ComponentA;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;

namespace Demo.CustomDialogTypeLocator
{
    public class MainWindowVM : ObservableObject
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
