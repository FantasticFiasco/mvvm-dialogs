using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// Dialog type locator responsible for locating dialog types for specified view models based
    /// on a naming convention used in a multitude of articles and code samples regarding the MVVM
    /// pattern.
    /// <para/>
    /// The convention states that if the name of the view model is
    /// 'MyNamespace.ViewModels.MyDialogViewModel' then the name of the dialog is
    /// 'MyNamespace.Views.MyDialog'.
    /// </summary>
    public class NamingConventionDialogTypeLocator : IDialogTypeLocator
    {
        internal static readonly DialogTypeLocatorCache Cache = new DialogTypeLocatorCache();

        /// <summary>
        /// Locates the dialog type representing the specified view model in a user interface.
        /// </summary>
        /// <param name="viewModel">The view model to find the dialog type for.</param>
        /// <returns>
        /// The dialog type representing the specified view model in a user interface.
        /// </returns>
        public Type Locate(INotifyPropertyChanged viewModel)
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

            dialogType = GetAssemblyFromType(viewModelType).GetType(dialogName);

            // if view name ends with "View"
            if(dialogType == null)
                dialogType = GetAssemblyFromType(viewModelType).GetType(dialogName + "View");

            if (dialogType == null)
                throw new TypeLoadException($"Dialog with name '{dialogName}' is missing.");

            Cache.Add(viewModelType, dialogType);
            
            return dialogType;
        }

        private static string GetDialogName(Type viewModelType)
        {
            string dialogName;

            if(viewModelType.FullName.Contains("ViewModel"))
                dialogName = viewModelType.FullName.Replace(".ViewModel.", ".View.");
            else
                dialogName = viewModelType.FullName.Replace(".ViewModels.", ".Views.");

            if (!dialogName.EndsWith("ViewModel", StringComparison.Ordinal))
                throw new TypeLoadException($"View model of type '{viewModelType}' doesn't follow naming convention since it isn't suffixed with 'ViewModel'.");

            return dialogName.Substring(
                0,
                dialogName.Length - "ViewModel".Length);
        }

        private static Assembly GetAssemblyFromType(Type type)
        {
#if NETFX_CORE
            // GetTypeInfo is supported on UWP
            return type.GetTypeInfo().Assembly;
#else
            // Assembly is supported on all .NET versions
            return type.Assembly;
#endif
        }
    }
}