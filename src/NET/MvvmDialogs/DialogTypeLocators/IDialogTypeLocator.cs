using System;
using System.ComponentModel;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// Interface responsible for finding a dialog type matching a view model.
    /// </summary>
    public interface IDialogTypeLocator
    {
        /// <summary>
        /// Locates a dialog type based on the specified view model.
        /// </summary>
        Type Locate(INotifyPropertyChanged viewModel);
    }
}
