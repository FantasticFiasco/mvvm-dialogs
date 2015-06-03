using System;
using System.Windows.Input;
using DemoApplication.Features.Dialog.NonModal.Views;
using MvvmDialogs;
using ReactiveUI;

namespace DemoApplication.Features.Dialog.NonModal.ViewModels
{
    public class NonModalDialogTabContentViewModel : ReactiveObject
    {
        private readonly IDialogService dialogService;
        private readonly ReactiveCommand<object> implicitShowCommand;
        private readonly ReactiveCommand<object> explicitShowCommand;

        public NonModalDialogTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            implicitShowCommand = ReactiveCommand.Create();
            implicitShowCommand.Subscribe(_ => ImplicitShow());

            explicitShowCommand = ReactiveCommand.Create();
            explicitShowCommand.Subscribe(_ => ExplicitShow());
        }

        public ICommand ImplicitShowCommand
        {
            get { return implicitShowCommand; }
        }

        public ICommand ExplicitShowCommand
        {
            get { return explicitShowCommand; }
        }

        private void ImplicitShow()
        {
            var dialogViewModel = new CurrentTimeDialogViewModel();
            dialogService.Show(this, dialogViewModel);
        }

        private void ExplicitShow()
        {
            var dialogViewModel = new CurrentTimeDialogViewModel();
            dialogService.Show<CurrentTimeDialog>(this, dialogViewModel);
        }
    }
}