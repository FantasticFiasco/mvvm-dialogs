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
            Show(viewModel => dialogService.Show(this, viewModel));
        }

        private void ExplicitShow()
        {
            Show(viewModel => dialogService.Show<CurrentTimeDialog>(this, viewModel));
        }

        private static void Show(Action<CurrentTimeDialogViewModel> show)
        {
            var dialogViewModel = new CurrentTimeDialogViewModel();
            show(dialogViewModel);
        }
    }
}