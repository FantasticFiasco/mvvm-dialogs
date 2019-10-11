using System;
using System.ComponentModel;
using System.Reflection;

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

        /// <inheritdoc />
        public Type Locate(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            Type viewModelType = viewModel.GetType();
#if NETFX_CORE
            Type dialogType = Cache.Get(viewModelType);
#else
            Type? dialogType = Cache.Get(viewModelType);
#endif
            if (dialogType != null)
            {
                return dialogType;
            }

            string dialogName = GetDialogName(viewModelType);

            dialogType = GetAssemblyFromType(viewModelType).GetType(dialogName);
            if (dialogType == null) throw new TypeLoadException(AppendInfoAboutDialogTypeLocators($"Dialog with name '{dialogName}' is missing."));

            Cache.Add(viewModelType, dialogType);

            return dialogType;
        }

        private static string GetDialogName(Type viewModelType)
        {
            if (viewModelType.FullName != null)
            {
                string dialogName = viewModelType.FullName.Replace(".ViewModels.", ".Views.");

                if (dialogName.EndsWith("ViewModel", StringComparison.Ordinal))
                {
                    return dialogName.Substring(
                        0,
                        dialogName.Length - "ViewModel".Length);
                }
            }

            throw new TypeLoadException(AppendInfoAboutDialogTypeLocators($"View model of type '{viewModelType}' doesn't follow naming convention since it isn't suffixed with 'ViewModel'."));
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

        private static string AppendInfoAboutDialogTypeLocators(string errorMessage)
        {
            return
                errorMessage + Environment.NewLine +
                "If your project structure doesn't conform to the default convention of MVVM " +
                "Dialogs you can always define a new convention by implementing your own dialog " +
                "type locator. For more information on how to do that, please read the GitHub " +
                "wiki or ask the author.";
        }
    }
}
