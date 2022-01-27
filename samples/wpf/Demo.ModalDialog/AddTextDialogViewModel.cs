using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;

namespace Demo.ModalDialog
{
    public class AddTextDialogViewModel : ObservableObject, IModalDialogViewModel
    {
        private string? text;
        private bool? dialogResult;

        public AddTextDialogViewModel()
        {
            OkCommand = new RelayCommand(Ok);
        }

        public string? Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public ICommand OkCommand { get; }

        public bool? DialogResult
        {
            get => dialogResult;
            private set => SetProperty(ref dialogResult, value);
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
