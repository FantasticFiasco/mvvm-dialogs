using System;
using System.ComponentModel;
using MvvmDialogs.Properties;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// Class responsible for locating dialog types for specified view models based on configured
    /// mappings.
    /// </summary>
    public class MappedDialogTypeLocator : IDialogTypeLocator
    {
        private readonly DialogTypeLocatorCache cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="MappedDialogTypeLocator"/> class.
        /// </summary>
        public MappedDialogTypeLocator()
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
            if (dialogType == null)
                throw new DialogTypeException(Resources.ViewModelNotMapped.CurrentFormat(viewModelType));

            return dialogType;
        }

        #endregion

        /// <summary>
        /// Maps the specified view model type to its corresponding dialog type.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <param name="dialogType">Type of the dialog.</param>
        public void Map(Type viewModelType, Type dialogType)
        {
            if (viewModelType == null)
                throw new ArgumentNullException("viewModelType");
            if (dialogType == null)
                throw new ArgumentNullException("dialogType");

            cache.Add(viewModelType, dialogType);
        }
    }
}