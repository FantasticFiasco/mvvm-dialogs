using System;
using System.Windows.Input;
using MvvmDialogs;
using ReactiveUI;

namespace DemoApplication.Features.Dialog.Modal.ViewModels
{
    public class AddTextDialogViewModel : ReactiveObject, IModalDialogViewModel
    {
        private readonly ReactiveCommand<object> okCommand;

        private string text;
        private bool? dialogResult;

        public AddTextDialogViewModel()
        {
            okCommand = ReactiveCommand.Create();
            okCommand.Subscribe(_ => Ok());
        }

        public string Text
        {
            get { return text; }
            set { this.RaiseAndSetIfChanged(ref text, value); }
        }

        public ICommand OkCommand
        {
            get { return okCommand; }
        }

        public bool? DialogResult
        {
            get { return dialogResult; }
            private set { this.RaiseAndSetIfChanged(ref dialogResult, value); }
        }

        private void Ok()
        {
            if (!string.IsNullOrEmpty(Text))
            {
                DialogResult = true;
            }
        }
    }
}