using GalaSoft.MvvmLight;
using MvvmDialogs;

namespace Demo.CustomDialogTypeLocator.Core.ComponentA
{
    public class MyDialogVM : ViewModelBase, IModalDialogViewModel
    {
        private bool? dialogResult;

        public bool? DialogResult
        {
            get => dialogResult;
            private set => Set(nameof(DialogResult), ref dialogResult, value);
        }
    }
}
