using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;

namespace Demo.ModalCustomDialog
{
    public class AddTextCustomDialogViewModel : ViewModelBase, IModalDialogViewModel
    {
        private string text;
        private bool? dialogResult;

        public AddTextCustomDialogViewModel()
        {
            OkCommand = new RelayCommand(Ok);
        }

        public string Text
        {
            get => text;
            set => Set(nameof(Text), ref text, value);
        }

        public ICommand OkCommand { get; }

        public bool? DialogResult
        {
            get => dialogResult;
            private set => Set(nameof(DialogResult), ref dialogResult, value);
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