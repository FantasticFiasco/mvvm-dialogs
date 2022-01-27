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
            string? viewModelTypeName = viewModelType.FullName;

            if (viewModelTypeName == null)
            {
                throw new Exception($"Type {viewModelType} has no full name");
            }

            // Get dialog type name by removing the 'VM' suffix
            string dialogTypeName = viewModelTypeName.Substring(
                0,
                viewModelTypeName.Length - "VM".Length);

            var type = viewModelType.Assembly.GetType(dialogTypeName);
            if (type == null)
            {
                throw new Exception($"Unable to find dialog type with name {dialogTypeName}");
            }

            return type;
        }
    }
}
