using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MvvmDialogs.Properties;

namespace MvvmDialogs.DialogLocators
{
    /// <summary>
    /// Class responsible for locating dialog types for specified view models based on a naming
    /// convention used in a multitude of articles and code samples describing the MVVM pattern.
    /// 
    /// The convention states that if the full name of the view model is
    /// 'MyNamespace.ViewModel.MyDialogViewModel' then the full name of the dialog is
    /// 'MyNamespace.View.MyDialog'.
    /// </summary>
    public class NameConventionDialogTypeLocator : IDialogTypeLocator
    {
        private const string View = "View";
        private const string ViewModel = "ViewModel";

        /// <summary>
        /// A cache holding the known mappings between view model types and dialog types.
        /// </summary>
        internal static readonly Dictionary<Type, Type> Cache = new Dictionary<Type, Type>(); 

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

            Type dialogType = GetFromCache(viewModelType);
            if (dialogType != null)
            {
                return dialogType;
            }

            string dialogNamespace = GetDialogNamespace(viewModelType);
            string dialogClassName = GetDialogClassName(viewModelType);
            string dialogAssemblyFullName = GetAssemblyFullName(viewModelType);

            string dialogFullName = "{0}.{1}, {2}".InvariantFormat(
                dialogNamespace,
                dialogClassName,
                dialogAssemblyFullName);

            dialogType = Type.GetType(dialogFullName);
            if (dialogType == null)
                throw new DialogTypeException(Resources.DialogTypeMissing.CurrentFormat(dialogFullName));

            AddToCache(viewModelType, dialogType);
            
            return dialogType;
        }

        private static string GetDialogNamespace(Type viewModelType)
        {
            if (viewModelType.Namespace == null)
                throw new DialogTypeException(Resources.ViewModelNamespaceMissing.CurrentFormat(viewModelType));

            string[] parts = viewModelType.Namespace.Split('.');

            if (parts.Last() != ViewModel)
                throw new DialogTypeException(Resources.ViewModelNamespaceInvalid.CurrentFormat(viewModelType, ViewModel));

            parts[parts.Length - 1] = View;

            return string.Join(".", parts);
        }

        private static string GetDialogClassName(Type viewModelType)
        {
            if (!viewModelType.Name.EndsWith(ViewModel, StringComparison.Ordinal))
                throw new DialogTypeException(Resources.ViewModelNameInvalid.CurrentFormat(viewModelType, ViewModel));

            return viewModelType.Name.Substring(
                0,
                viewModelType.Name.Length - ViewModel.Length);
        }

        private static string GetAssemblyFullName(Type viewModelType)
        {
            return viewModelType.Assembly.FullName;
        }

        private static Type GetFromCache(Type viewModelType)
        {
            Type dialogType;
            
            return Cache.TryGetValue(viewModelType, out dialogType) ?
                dialogType :
                null;
        }

        private static void AddToCache(Type viewModelType, Type dialogType)
        {
            Cache.Add(viewModelType, dialogType);
        }
    }
}
