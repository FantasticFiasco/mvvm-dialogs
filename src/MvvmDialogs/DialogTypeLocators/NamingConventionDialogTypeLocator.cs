using System;
using System.ComponentModel;
using MvvmDialogs.Properties;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// Class responsible for locating dialog types for specified view models based on a naming
    /// convention used in a multitude of articles and code samples regarding the MVVM pattern.
    /// 
    /// The convention states that if the name of the view model is
    /// 'MyNamespace.ViewModels.MyDialogViewModel' then the name of the dialog is
    /// 'MyNamespace.Views.MyDialog'.
    /// </summary>
    internal static class NamingConventionDialogTypeLocator
    {
        internal static readonly DialogTypeLocatorCache Cache = new DialogTypeLocatorCache();

        /// <summary>
        /// Locates the dialog type representing the specified view model in a user interface.
        /// </summary>
        /// <param name="viewModel">The view model to find the dialog type for.</param>
        /// <returns>
        /// The dialog type representing the specified view model in a user interface.
        /// </returns>
        internal static Type LocateDialogType(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("viewModel");

            Type viewModelType = viewModel.GetType();

            Type dialogType = Cache.Get(viewModelType);
            if (dialogType != null)
            {
                return dialogType;
            }

            string dialogName = GetDialogName(viewModelType);
            string dialogAssemblyName = GetAssemblyFullName(viewModelType);

            string dialogFullName = "{0}, {1}".InvariantFormat(
                dialogName,
                dialogAssemblyName);
            
            dialogType = Type.GetType(dialogFullName);
            if (dialogType == null)
                throw new Exception(Resources.DialogTypeMissing.CurrentFormat(dialogFullName));

            Cache.Add(viewModelType, dialogType);
            
            return dialogType;
        }

        private static string GetDialogName(Type viewModelType)
        {
            string dialogName = viewModelType.FullName.Replace(".ViewModels.", ".Views.");

            if (!dialogName.EndsWith("ViewModel", StringComparison.Ordinal))
                throw new Exception(Resources.ViewModelNameInvalid.CurrentFormat(viewModelType));

            return dialogName.Substring(
                0,
                dialogName.Length - "ViewModel".Length);
        }

        private static string GetAssemblyFullName(Type viewModelType)
        {
            return viewModelType.Assembly.FullName;
        }
    }
}