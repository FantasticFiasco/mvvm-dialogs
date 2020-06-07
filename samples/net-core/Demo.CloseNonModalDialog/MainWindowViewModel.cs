using System.ComponentModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;

namespace Demo.CloseNonModalDialog
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        private INotifyPropertyChanged dialogViewModel;

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            ShowCommand = new RelayCommand(Show, CanShow);
            CloseCommand = new RelayCommand(Close, CanClose);
        }

        public RelayCommand ShowCommand { get; }

        public RelayCommand CloseCommand { get; }

        private void Show()
        {
            dialogViewModel = new CurrentTimeDialogViewModel();
            dialogService.Show(this, dialogViewModel);

            ShowCommand.RaiseCanExecuteChanged();
            CloseCommand.RaiseCanExecuteChanged();
        }

        private bool CanShow()
        {
            return dialogViewModel == null;
        }

        private void Close()
        {
            dialogService.Close(dialogViewModel);
            dialogViewModel = null;

            ShowCommand.RaiseCanExecuteChanged();
            CloseCommand.RaiseCanExecuteChanged();
        }

        private bool CanClose()
        {
            return dialogViewModel != null;
        }
    }
}
