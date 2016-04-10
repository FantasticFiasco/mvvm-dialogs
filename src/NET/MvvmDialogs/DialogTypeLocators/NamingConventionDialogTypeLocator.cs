using System;
using System.ComponentModel;
#if NETFX_CORE
using System.Reflection;
#endif

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
                throw new ArgumentNullException(nameof(viewModel));

            Type viewModelType = viewModel.GetType();

            Type dialogType = Cache.Get(viewModelType);
            if (dialogType != null)
            {
                return dialogType;
            }

            string dialogName = GetDialogName(viewModelType);
            string dialogAssemblyName = GetAssemblyFullName(viewModelType);

            string dialogFullName = $"{dialogName}, {dialogAssemblyName}";
            
            dialogType = Type.GetType(dialogFullName);
            if (dialogType == null)
                throw new TypeLoadException($"Dialog with full name '{dialogFullName}' is missing.");

            Cache.Add(viewModelType, dialogType);
            
            return dialogType;
        }

        private static string GetDialogName(Type viewModelType)
        {
            string dialogName = viewModelType.FullName.Replace(".ViewModels.", ".Views.");

            if (!dialogName.EndsWith("ViewModel", StringComparison.Ordinal))
                throw new TypeLoadException($"View model of type '{viewModelType}' doesn't follow naming convention since it isn't suffixed with 'ViewModel'.");

            return dialogName.Substring(
                0,
                dialogName.Length - "ViewModel".Length);
        }

        private static string GetAssemblyFullName(Type viewModelType)
        {
#if NETFX_CORE
            return viewModelType.GetTypeInfo().Assembly.FullName;
#else
            return viewModelType.Assembly.FullName;
#endif
        }
    }
}