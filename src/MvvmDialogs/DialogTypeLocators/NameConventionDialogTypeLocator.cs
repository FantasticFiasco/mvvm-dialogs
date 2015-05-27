using System;
using System.Collections.Generic;
using System.ComponentModel;
using MvvmDialogs.Properties;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// Class responsible for locating dialog types for specified view models based on a naming
    /// convention used in a multitude of articles and code samples describing the MVVM pattern.
    /// 
    /// The convention states that if the full name of the view model is
    /// 'MyNamespace.Module.ViewModel.MyDialogViewModel' then the full name of the dialog is
    /// 'MyNamespace.Module.View.MyDialog'.
    /// </summary>
    public class NameConventionDialogTypeLocator : IDialogTypeLocator
    {
        private const string ViewModel = "ViewModel";

        private readonly DialogTypeLocatorCache cache;
        private readonly IDictionary<string, string> namespaceReplacements;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="NameConventionDialogTypeLocator"/> class.
        /// </summary>
        public NameConventionDialogTypeLocator()
        {
            cache = new DialogTypeLocatorCache();
            namespaceReplacements = new Dictionary<string, string>
            {
                { "ViewModel", "View" },
                { "ViewModels", "Views" }
            };
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

            cache.Add(viewModelType, dialogType);
            
            return dialogType;
        }

        #endregion

        private string GetDialogNamespace(Type viewModelType)
        {
            if (viewModelType.Namespace == null)
                throw new DialogTypeException(Resources.ViewModelNamespaceMissing.CurrentFormat(viewModelType));

            string[] parts = viewModelType.Namespace.Split('.');

            int index = -1;
            string foundNamespaceReplacement = null;
            
            foreach (KeyValuePair<string, string> namespaceReplacement in namespaceReplacements)
            {
                index = Array.IndexOf(parts, namespaceReplacement.Key);
                if (index != -1)
                {
                    foundNamespaceReplacement = namespaceReplacement.Value;
                    break;
                }
            }

            if (index == -1)
            {
                throw new DialogTypeException(
                    Resources.ViewModelNamespaceInvalid.CurrentFormat(
                        viewModelType,
                        string.Join(", ", namespaceReplacements.Keys)));
            }

            parts[index] = foundNamespaceReplacement;

            return string.Join(".", parts);
        }

        private static string GetDialogClassName(Type viewModelType)
        {
            if (!viewModelType.Name.EndsWith(ViewModel, StringComparison.Ordinal))
                throw new DialogTypeException(Resources.ViewModelNameInvalid.CurrentFormat(viewModelType));

            return viewModelType.Name.Substring(
                0,
                viewModelType.Name.Length - ViewModel.Length);
        }

        private static string GetAssemblyFullName(Type viewModelType)
        {
            return viewModelType.Assembly.FullName;
        }
    }
}