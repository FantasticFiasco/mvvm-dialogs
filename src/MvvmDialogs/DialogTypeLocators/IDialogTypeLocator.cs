using System;
using System.ComponentModel;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// Interface responsible for locating dialog types for specified view models.
    /// </summary>
    public interface IDialogTypeLocator
    {
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
        Type LocateDialogTypeFor(INotifyPropertyChanged viewModel);
    }
}