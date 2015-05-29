using System;
using System.Windows.Input;
using ReactiveUI;

namespace DemoApplication.Features.Dialog.ViewModels
{
    public class AddTextDialogViewModel : ReactiveObject
    {
        private readonly ReactiveCommand<object> okCommand;

        private string text;

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

        private void Ok()
        {
            throw new NotImplementedException();
        }
    }
}