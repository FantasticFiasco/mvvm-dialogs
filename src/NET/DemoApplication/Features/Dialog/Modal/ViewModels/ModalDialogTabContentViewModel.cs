using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DemoApplication.Features.Dialog.Modal.Views;
using MvvmDialogs;
using ReactiveUI;

namespace DemoApplication.Features.Dialog.Modal.ViewModels
{
    public class ModalDialogTabContentViewModel : ReactiveObject
    {
        private readonly IDialogService dialogService;
        private readonly ObservableCollection<string> texts; 
        private readonly ReactiveCommand<object> implicitShowDialogCommand;
        private readonly ReactiveCommand<object> explicitShowDialogCommand;

        public ModalDialogTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            texts = new ObservableCollection<string>();

            implicitShowDialogCommand = ReactiveCommand.Create();
            implicitShowDialogCommand.Subscribe(_ => ImplicitShowDialog());

            explicitShowDialogCommand = ReactiveCommand.Create();
            explicitShowDialogCommand.Subscribe(_ => ExplicitShowDialog());
        }

        public ObservableCollection<string> Texts
        {
            get { return texts; }
        }

        public ICommand ImplicitShowDialogCommand
        {
            get { return implicitShowDialogCommand; }
        }

        public ICommand ExplicitShowDialogCommand
        {
            get { return explicitShowDialogCommand; }
        }

        private void ImplicitShowDialog()
        {
            ShowDialog(viewModel => dialogService.ShowDialog(this, viewModel));
        }

        private void ExplicitShowDialog()
        {
            ShowDialog(viewModel => dialogService.ShowDialog<AddTextDialog>(this, viewModel));
        }

        private void ShowDialog(Func<AddTextDialogViewModel, bool?> showDialog)
        {
            var dialogViewModel = new AddTextDialogViewModel();

            bool? success = showDialog(dialogViewModel);
            if (success == true)
            {
                Texts.Add(dialogViewModel.Text);
            }
        }
    }
}