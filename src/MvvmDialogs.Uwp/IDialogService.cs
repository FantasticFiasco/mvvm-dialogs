using System.Collections.Generic;
using System.ComponentModel;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using MvvmDialogs.FrameworkPickers.FileOpen;
using MvvmDialogs.FrameworkPickers.FileSave;
using MvvmDialogs.FrameworkPickers.Folder;

namespace MvvmDialogs
{
    /// <summary>
    /// Interface abstracting the interaction between view models and views when it comes to
    /// opening dialogs using the MVVM pattern in UWP applications.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Begins an asynchronous operation to show the <see cref="ContentDialog"/> of type
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the content dialog to show.</typeparam>
        /// <param name="viewModel">The view model of the new content dialog.</param>
        /// <returns>
        /// An asynchronous operation showing the dialog. When complete, returns a
        /// <see cref="ContentDialogResult"/>.
        /// </returns>
        IAsyncOperation<ContentDialogResult> ShowContentDialogAsync<T>(INotifyPropertyChanged viewModel)
            where T : ContentDialog;

        /// <summary>
        /// Begins an asynchronous operation to show the custom <see cref="IContentDialog"/> of
        /// type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the custom content dialog to show.</typeparam>
        /// <param name="viewModel">The view model of the new custom content dialog.</param>
        /// <returns>
        /// An asynchronous operation showing the custom dialog. When complete, returns a
        /// <see cref="ContentDialogResult"/>.
        /// </returns>
        IAsyncOperation<ContentDialogResult> ShowCustomContentDialogAsync<T>(INotifyPropertyChanged viewModel)
            where T : IContentDialog;

        /// <summary>
        /// Begins an asynchronous operation to show the <see cref="ContentDialog"/> of a type that
        /// is determined by the dialog type locator.
        /// </summary>
        /// <param name="viewModel">The view model of the new content dialog.</param>
        /// <returns>
        /// An asynchronous operation showing the dialog. When complete, returns a
        /// <see cref="ContentDialogResult"/>.
        /// </returns>
        IAsyncOperation<ContentDialogResult> ShowContentDialogAsync(INotifyPropertyChanged viewModel);

        /// <summary>
        /// Begins an asynchronous operation showing a <see cref="MessageDialog"/>.
        /// </summary>
        /// <param name="content">The message displayed to the user.</param>
        /// <param name="title">The title you want displayed on the dialog.</param>
        /// <param name="commands">
        /// The array of commands that appear in the command bar of the message dialog. These
        /// commands makes the dialog actionable.
        /// </param>
        /// <param name="defaultCommandIndex">
        /// The index of the command you want to use as the default. This is the command that fires
        /// by default when users press the ENTER key.
        /// </param>
        /// <param name="cancelCommandIndex">
        /// The index of the command you want to use as the cancel command. This is the command
        /// that fires when users press the ESC key.
        /// </param>
        /// <param name="options">The options for the dialog.</param>
        /// <returns>
        /// An object that represents the asynchronous operation. For more on the async pattern, see
        /// <see href="https://msdn.microsoft.com/en-us/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps">Asynchronous programming</see>.
        /// </returns>
        IAsyncOperation<IUICommand> ShowMessageDialogAsync(
            string content,
            string title = null,
            IEnumerable<IUICommand> commands = null,
            uint? defaultCommandIndex = null,
            uint? cancelCommandIndex = null,
            MessageDialogOptions options = MessageDialogOptions.None);

        /// <summary>
        /// Shows the file picker so that the user can pick one file.
        /// </summary>
        /// <param name="settings">The settings for the file open picker.</param>
        /// <returns>
        /// When the call to this method completes successfully, it returns a
        /// <see cref="StorageFile"/> object that represents the file that the user picked.
        /// </returns>
        IAsyncOperation<StorageFile> PickSingleFileAsync(FileOpenPickerSettings settings);

        /// <summary>
        /// Shows the file picker so that the user can pick multiple files.
        /// </summary>
        /// <param name="settings">The settings for the file open picker.</param>
        /// <returns>
        /// When the call to this method completes successfully, it returns a
        /// <see cref="IReadOnlyList{StorageFile}"/> object that contains all the files that were
        /// picked by the user. Picked files in this array are represented by
        /// <see cref="StorageFile"/> objects.
        /// </returns>
        IAsyncOperation<IReadOnlyList<StorageFile>> PickMultipleFilesAsync(FileOpenPickerSettings settings);

        /// <summary>
        /// Shows the file picker so that the user can save a file and set the file name,
        /// extension, and location of the file to be saved.
        /// </summary>
        /// <param name="settings">The settings for the file save picker.</param>
        /// <returns>
        /// When the call to this method completes successfully, it returns a
        /// <see cref="StorageFile"/> object that was created to represent the saved file. The file
        /// name, extension, and location of this <see cref="StorageFile"/> match those specified
        /// by the user, but the file has no content.
        /// </returns>
        IAsyncOperation<StorageFile> PickSaveFileAsync(FileSavePickerSettings settings);

        /// <summary>
        /// Shows the folder picker so that the user can pick a folder. 
        /// </summary>
        /// <param name="settings">The settings for the folder picker.</param>
        /// <returns>
        /// When the call to this method completes successfully, it returns a
        /// <see cref="StorageFolder"/> object that represents the folder that the user picked.
        /// </returns>
        IAsyncOperation<StorageFolder> PickSingleFolderAsync(FolderPickerSettings settings);
    }
}
