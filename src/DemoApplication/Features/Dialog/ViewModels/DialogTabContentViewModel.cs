using System;
using System.Collections.ObjectModel;
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
        private readonly ObservableCollection<string> texts; 
        private readonly ReactiveCommand<object> showImplicitDialogCommand;
        private readonly ReactiveCommand<object> showExplicitDialogCommand;

        [ImportingConstructor]
        public DialogTabContentViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            texts = new ObservableCollection<string>();

            showImplicitDialogCommand = ReactiveCommand.Create();
            showImplicitDialogCommand.Subscribe(_ => ShowImplicitDialog());

            showExplicitDialogCommand = ReactiveCommand.Create();
            showExplicitDialogCommand.Subscribe(_ => ShowExplicitDialog());
        }

        public ObservableCollection<string> Texts
        {
            get { return texts; }
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
            var dialogViewModel = new AddTextDialogViewModel();
            
            bool? success = dialogService.ShowDialog(this, dialogViewModel);
            if (success == true)
            {
                Texts.Add(dialogViewModel.Text);
            }
        }

        private void ShowExplicitDialog()
        {
            var dialogViewModel = new AddTextDialogViewModel();

            bool? success = dialogService.ShowDialog<AddTextDialog>(this, dialogViewModel);
            if (success == true)
            {
                Texts.Add(dialogViewModel.Text);
            }
        }
    }
}