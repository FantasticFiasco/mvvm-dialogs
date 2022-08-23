using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;

namespace Demo.CloseNonModalDialog
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;

        private INotifyPropertyChanged? dialogViewModel;

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

            ShowCommand.NotifyCanExecuteChanged();
            CloseCommand.NotifyCanExecuteChanged();
        }

        private bool CanShow()
        {
            return dialogViewModel == null;
        }

        private void Close()
        {
            dialogService.Close(dialogViewModel!);
            dialogViewModel = null;

            ShowCommand.NotifyCanExecuteChanged();
            CloseCommand.NotifyCanExecuteChanged();
        }

        private bool CanClose()
        {
            return dialogViewModel != null;
        }
    }
}
