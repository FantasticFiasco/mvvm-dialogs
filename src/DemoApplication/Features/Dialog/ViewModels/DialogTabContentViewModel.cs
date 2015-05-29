using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using DemoApplication.Features.Dialog.Views;
using MvvmDialogs;
using ReactiveUI;

namespace DemoApplication.Features.Dialog.ViewModels
{
    [Export]
    public class DialogTabContentViewModel : ReactiveObject
    {
        private readonly IDialogService dialogService;
        private readonly ReactiveCommand<object> showImplicitDialogCommand;
        private readonly ReactiveCommand<object> showExplicitDialogCommand;

        [ImportingConstructor]
        public DialogTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            showImplicitDialogCommand = ReactiveCommand.Create();
            showImplicitDialogCommand.Subscribe(_ => ShowImplicitDialog());

            showExplicitDialogCommand = ReactiveCommand.Create();
            showExplicitDialogCommand.Subscribe(_ => ShowExplicitDialog());
        }

        public ICommand ShowImplicitDialogCommand
        {
            get { return showImplicitDialogCommand; }
        }

        public ICommand ShowExplicitDialogCommand
        {
            get { return showExplicitDialogCommand; }
        }

        private void ShowImplicitDialog()
        {
            var dialogViewModel = new CurrentTimeDialogViewModel();
            dialogService.ShowDialog(this, dialogViewModel);
        }

        private void ShowExplicitDialog()
        {
            var dialogViewModel = new CurrentTimeDialogViewModel();
            dialogService.ShowDialog<CurrentTimeDialog>(this, dialogViewModel);
        }
    }
}