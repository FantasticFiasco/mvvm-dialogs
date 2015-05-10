using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Windows;
using System.Windows.Forms;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using MvvmDialogs.FrameworkDialogs.OpenFile;

namespace MvvmDialogs
{
    [ContractClassFor(typeof(IDialogService))]
    internal abstract class IDialogServiceContract : IDialogService
    {
        /// <summary>
        /// Gets the registered views.
        /// </summary>
        public ReadOnlyCollection<FrameworkElement> Views
        {
            get { return default(ReadOnlyCollection<FrameworkElement>); }
        }
        
        /// <summary>
        /// Registers a View.
        /// </summary>
        /// <param name="view">The registered View.</param>
        public void Register(FrameworkElement view)
        {
            Contract.Requires(view != null);
            Contract.Requires(!Views.Contains(view));
        }
        
        /// <summary>
        /// Unregisters a View.
        /// </summary>
        /// <param name="view">The unregistered View.</param>
        public void Unregister(FrameworkElement view)
        {
            Contract.Requires(Views.Contains(view));
        }

        /// <summary>
        /// Shows a dialog.
        /// </summary>
        /// <remarks>
        /// The dialog used to represent the view model is retrieved from the registered mappings.
        /// </remarks>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <returns>
        /// A nullable value of type bool that signifies how a window was closed by the user.
        /// </returns>
        public bool? ShowDialog(object ownerViewModel, object viewModel)
        {
            Contract.Requires(ownerViewModel != null);
            Contract.Requires(viewModel != null);

            return default(bool?);
        }

        /// <summary>
        /// Shows a dialog.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <typeparam name="T">The type of the dialog to show.</typeparam>
        /// <returns>
        /// A nullable value of type bool that signifies how a window was closed by the user.
        /// </returns>
        public bool? ShowDialog<T>(object ownerViewModel, object viewModel) where T : Window
        {
            Contract.Requires(ownerViewModel != null);
            Contract.Requires(viewModel != null);

            return default(bool?);
        }
        
        /// <summary>
        /// Shows a message box.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the message box.
        /// </param>
        /// <param name="messageBoxText">A string that specifies the text to display.</param>
        /// <param name="caption">A string that specifies the title bar caption to display.</param>
        /// <param name="button">
        /// A MessageBoxButton value that specifies which button or buttons to display.
        /// </param>
        /// <param name="icon">A MessageBoxImage value that specifies the icon to display.</param>
        /// <returns>
        /// A MessageBoxResult value that specifies which message box button is clicked by the user.
        /// </returns>
        public MessageBoxResult ShowMessageBox(
            object ownerViewModel,
            string messageBoxText,
            string caption,
            MessageBoxButton button,
            MessageBoxImage icon)
        {
            Contract.Requires(ownerViewModel != null);
            Contract.Requires(!string.IsNullOrWhiteSpace(messageBoxText));
            Contract.Requires(!string.IsNullOrWhiteSpace(caption));

            return default(MessageBoxResult);
        }
        
        /// <summary>
        /// Shows the OpenFileDialog.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="openFileDialogViewModel">The interface of a open file dialog.</param>
        /// <returns>
        /// DialogResult.OK if successful; otherwise DialogResult.Cancel.
        /// </returns>
        public DialogResult ShowOpenFileDialog(object ownerViewModel, IOpenFileDialogViewModel openFileDialogViewModel)
        {
            Contract.Requires(ownerViewModel != null);
            Contract.Requires(openFileDialogViewModel != null);

            return default(DialogResult);
        }
        
        /// <summary>
        /// Shows the FolderBrowserDialog.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="folderBrowserDialogViewModel">The interface of a folder browser dialog.</param>
        /// <returns>
        /// The DialogResult.OK if successful; otherwise DialogResult.Cancel.
        /// </returns>
        public DialogResult ShowFolderBrowserDialog(object ownerViewModel, IFolderBrowserDialogViewModel folderBrowserDialogViewModel)
        {
            Contract.Requires(ownerViewModel != null);
            Contract.Requires(folderBrowserDialogViewModel != null);

            return default(DialogResult);
        }
    }
}