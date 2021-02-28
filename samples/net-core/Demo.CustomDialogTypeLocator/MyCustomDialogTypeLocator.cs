using System;
using System.ComponentModel;
using MvvmDialogs.DialogTypeLocators;

namespace Demo.CustomDialogTypeLocator
{
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
