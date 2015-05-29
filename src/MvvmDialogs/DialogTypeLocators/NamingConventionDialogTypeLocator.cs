using System;
using System.ComponentModel;
using MvvmDialogs.Properties;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// Class responsible for locating dialog types for specified view models based on a naming
    /// convention used in a multitude of articles and code samples describing the MVVM pattern.
    /// 
    /// The convention states that if the name of the view model is
    /// 'MyNamespace.ViewModels.MyDialogViewModel' then the name of the dialog is
    /// 'MyNamespace.Views.MyDialog'.
    /// </summary>
    public class NamingConventionDialogTypeLocator : IDialogTypeLocator
    {
        private readonly DialogTypeLocatorCache cache;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="NamingConventionDialogTypeLocator"/> class.
        /// </summary>
        public NamingConventionDialogTypeLocator()
        {
            cache = new DialogTypeLocatorCache();
        }

        #region IDialogTypeLocator Members

        /// <summary>
        /// Locates the dialog type representing the specified view model in a user interface.
        /// </summary>
        /// <param name="viewModel">The view model to find the dialog type for.</param>
        /// <returns>
        /// The dialog type representing the specified view model in a user interface.
        /// </returns>
        /// <exception cref="DialogTypeException">
        /// Dialog type was not located for specified view model.
        /// </exception>
        public Type LocateDialogTypeFor(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("viewModel");

            Type viewModelType = viewModel.GetType();

            Type dialogType = cache.Get(viewModelType);
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
                throw new DialogTypeException(Resources.DialogTypeMissing.CurrentFormat(dialogFullName));

            cache.Add(viewModelType, dialogType);
            
            return dialogType;
        }

        #endregion
        
        private static string GetDialogName(Type viewModelType)
        {
            string dialogName = viewModelType.FullName.Replace(".ViewModels.", ".Views.");

            if (!dialogName.EndsWith("ViewModel", StringComparison.Ordinal))
                throw new DialogTypeException(Resources.ViewModelNameInvalid.CurrentFormat(viewModelType));

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