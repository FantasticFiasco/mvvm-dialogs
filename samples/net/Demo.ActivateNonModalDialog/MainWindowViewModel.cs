using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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

        public ICommand ShowCommand { get; }

        public ICommand ActivateCommand { get; }

        private void Show()
        {
            dialogViewModel = new CurrentTimeDialogViewModel();
            dialogService.Show(this, dialogViewModel);
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
