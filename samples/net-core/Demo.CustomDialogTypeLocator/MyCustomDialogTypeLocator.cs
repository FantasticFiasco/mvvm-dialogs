using System;
using System.ComponentModel;
using MvvmDialogs.DialogTypeLocators;

namespace Demo.CustomDialogTypeLocator
{
    // This class is used as an example in the wiki. For more information see
    // https://github.com/FantasticFiasco/mvvm-dialogs/wiki/Custom-dialog-type-locators.
    public class MyCustomDialogTypeLocator : IDialogTypeLocator
    {
        public Type Locate(INotifyPropertyChanged viewModel)
        {
            Type viewModelType = viewModel.GetType();
            string viewModelTypeName = viewModelType.FullName;

            // Get dialog type name by removing the 'VM' suffix
            string dialogTypeName = viewModelTypeName.Substring(
                0,
                viewModelTypeName.Length - "VM".Length);

            return viewModelType.Assembly.GetType(dialogTypeName);
        }
    }
}
