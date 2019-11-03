using System.ComponentModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;

namespace Demo.ActivateNonModalDialog
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        private INotifyPropertyChanged dialogViewModel;

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            ShowCommand = new RelayCommand(Show, CanShow);
            ActivateCommand = new RelayCommand(Activate, CanActivate);
        }

        public RelayCommand ShowCommand { get; }

        public RelayCommand ActivateCommand { get; }

        private void Show()
        {
            dialogViewModel = new CurrentTimeDialogViewModel();
            dialogService.Show(this, dialogViewModel);

            ShowCommand.RaiseCanExecuteChanged();
            ActivateCommand.RaiseCanExecuteChanged();
        }

        private bool CanShow()
        {
            return dialogViewModel == null;
        }

        private void Activate()
        {
            dialogService.Activate(dialogViewModel);
        }

        private bool CanActivate()
        {
            return dialogViewModel != null;
        }
    }
}
