using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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

        public ICommand ShowCommand { get; }

        public ICommand CloseCommand { get; }

        private void Show()
        {
            dialogViewModel = new CurrentTimeDialogViewModel();
            dialogService.Show(this, dialogViewModel);
        }

        private bool CanShow()
        {
            return dialogViewModel == null;
        }

        private void Close()
        {
            dialogService.Close(dialogViewModel);
            dialogViewModel = null;
        }

        private bool CanClose()
        {
            return dialogViewModel != null;
        }
    }
}
