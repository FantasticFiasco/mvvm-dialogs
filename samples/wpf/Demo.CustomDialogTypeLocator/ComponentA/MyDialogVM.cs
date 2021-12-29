using CommunityToolkit.Mvvm.ComponentModel;
using MvvmDialogs;

namespace Demo.CustomDialogTypeLocator.ComponentA
{
    public class MyDialogVM : ObservableObject, IModalDialogViewModel
    {
        private bool? dialogResult;

        public bool? DialogResult
        {
            get => dialogResult;
            private set => SetProperty(ref dialogResult, value);
        }
    }
}
