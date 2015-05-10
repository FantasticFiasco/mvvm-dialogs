using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using DialogResult = System.Windows.Forms.DialogResult;
using FolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace MvvmDialogs
{
    /// <summary>
    /// Interface abstracting the interaction between view models and views when it comes to
    /// opening dialogs using the MVVM pattern in WPF.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Gets the registered views.
        /// </summary>
        ReadOnlyCollection<FrameworkElement> Views { get; }
        
        /// <summary>
        /// Registers a view.
        /// </summary>
        /// <param name="view">The view to register.</param>
        void Register(FrameworkElement view);
        
        /// <summary>
        /// Unregisters a view.
        /// </summary>
        /// <param name="view">The view to unregister.</param>
        void Unregister(FrameworkElement view);
        
        /// <summary>
        /// Shows a dialog of specified type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <typeparam name="T">The type of the dialog to show.</typeparam>
        /// <returns>
        /// A nullable value of type <see cref="bool"/> that signifies how a window was closed by
        /// the user.
        /// </returns>
        bool? ShowDialog<T>(
            INotifyPropertyChanged ownerViewModel,
            INotifyPropertyChanged viewModel)
            where T : Window;
        
        /// <summary>
        /// Shows a <see cref="MessageBox"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the message box.
        /// </param>
        /// <param name="messageBoxText">A string that specifies the text to display.</param>
        /// <param name="caption">A string that specifies the title bar caption to display.</param>
        /// <param name="button">
        /// A <see cref="MessageBoxButton"/> value that specifies which button or buttons to
        /// display.
        /// </param>
        /// <param name="icon">
        /// A <see cref="MessageBoxImage"/> value that specifies the icon to display.
        /// </param>
        /// <returns>
        /// A <see cref="MessageBoxResult"/> value that specifies which message box button is
        /// clicked by the user.
        /// </returns>
        MessageBoxResult ShowMessageBox(
            INotifyPropertyChanged ownerViewModel,
            string messageBoxText,
            string caption,
            MessageBoxButton button,
            MessageBoxImage icon);
        
        /// <summary>
        /// Shows the <see cref="OpenFileDialog"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="openFileDialogViewModel">The view model of a open file dialog.</param>
        /// <returns>
        /// <see cref="DialogResult.OK"/> if successful; otherwise
        /// <see cref="DialogResult.Cancel"/>.
        /// </returns>
        DialogResult ShowOpenFileDialog(
            INotifyPropertyChanged ownerViewModel,
            OpenFileDialogViewModel openFileDialogViewModel);

        /// <summary>
        /// Shows the <see cref="SaveFileDialog"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="saveFileDialogViewModel">The view model of a save file dialog.</param>
        /// <returns>
        /// <see cref="DialogResult.OK"/> if successful; otherwise
        /// <see cref="DialogResult.Cancel"/>.
        /// </returns>
        DialogResult ShowSaveFileDialog(
            INotifyPropertyChanged ownerViewModel,
            SaveFileDialogViewModel saveFileDialogViewModel);
        
        /// <summary>
        /// Shows the <see cref="FolderBrowserDialog"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="folderBrowserDialogViewModel">
        /// The view model of a folder browser dialog.
        /// </param>
        /// <returns>
        /// <see cref="DialogResult.OK"/> if successful; otherwise
        /// <see cref="DialogResult.Cancel"/>.
        /// </returns>
        DialogResult ShowFolderBrowserDialog(
            INotifyPropertyChanged ownerViewModel,
            FolderBrowserDialogViewModel folderBrowserDialogViewModel);
    }
}