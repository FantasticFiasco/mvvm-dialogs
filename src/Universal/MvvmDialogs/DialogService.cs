using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MvvmDialogs.FrameworkPickers.FileOpen;
using MvvmDialogs.FrameworkPickers.FileSave;
using MvvmDialogs.FrameworkPickers.Folder;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using MvvmDialogs.ContentDialogFactories;
using MvvmDialogs.DialogTypeLocators;
using MvvmDialogs.Logging;

namespace MvvmDialogs
{
    /// <summary>
    /// Class abstracting the interaction between view models and views when it comes to
    /// opening dialogs using the MVVM pattern in UWP applications.
    /// </summary>
    public class DialogService : IDialogService
    {
        private readonly IContentDialogFactory contentDialogFactory;
        private readonly IDialogTypeLocator contentDialogTypeLocator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogService"/> class.
        /// </summary>
        /// <remarks>
        /// By default <see cref="ReflectionContentDialogFactory"/> is used as dialog factory and
        /// <see cref="NamingConventionDialogTypeLocator"/> is used as dialog type locator.
        /// </remarks>
        public DialogService()
            : this(new ReflectionContentDialogFactory(), new NamingConventionDialogTypeLocator())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogService"/> class.
        /// </summary>
        /// <param name="contentDialogFactory">
        /// Factory responsible for creating content dialogs.
        /// </param>
        /// <remarks>
        /// By default <see cref="NamingConventionDialogTypeLocator"/> is used as dialog type
        /// locator.
        /// </remarks>
        public DialogService(IContentDialogFactory contentDialogFactory)
            : this(contentDialogFactory, new NamingConventionDialogTypeLocator())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogService"/> class.
        /// </summary>
        /// <param name="contentDialogTypeLocator">
        /// Interface responsible for finding a content dialog type matching a view model.
        /// </param>
        /// <remarks>
        /// By default <see cref="ReflectionContentDialogFactory"/> is used as dialog factory.
        /// </remarks>
        public DialogService(IDialogTypeLocator contentDialogTypeLocator)
            : this(new ReflectionContentDialogFactory(), contentDialogTypeLocator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogService"/> class.
        /// </summary>
        /// <param name="contentDialogFactory">
        /// Factory responsible for creating content dialogs.
        /// </param>
        /// <param name="contentDialogTypeLocator">
        /// Interface responsible for finding a dialog type matching a view model.
        /// </param>
        public DialogService(
            IContentDialogFactory contentDialogFactory,
            IDialogTypeLocator contentDialogTypeLocator = null)
        {
            this.contentDialogFactory = contentDialogFactory ?? throw new ArgumentNullException(nameof(contentDialogFactory));
            this.contentDialogTypeLocator = contentDialogTypeLocator ?? throw new ArgumentNullException(nameof(contentDialogTypeLocator));
        }

        #region IDialogService Members

        /// <summary>
        /// Begins an asynchronous operation to show the <see cref="ContentDialog" /> of type
        /// <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of the content dialog to show.</typeparam>
        /// <param name="viewModel">The view model of the new content dialog.</param>
        /// <returns>
        /// An asynchronous operation showing the dialog. When complete, returns a
        /// <see cref="ContentDialogResult" />.
        /// </returns>
        public IAsyncOperation<ContentDialogResult> ShowContentDialogAsync<T>(INotifyPropertyChanged viewModel)
            where T : ContentDialog
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ShowContentDialogAsync(viewModel, typeof(T));
        }

        /// <summary>
        /// Begins an asynchronous operation to show the custom <see cref="IContentDialog" /> of
        /// type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of the custom content dialog to show.</typeparam>
        /// <param name="viewModel">The view model of the new custom content dialog.</param>
        /// <returns>
        /// An asynchronous operation showing the custom dialog. When complete, returns a
        /// <see cref="ContentDialogResult" />.
        /// </returns>
        public IAsyncOperation<ContentDialogResult> ShowCustomContentDialogAsync<T>(INotifyPropertyChanged viewModel)
            where T : IContentDialog
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ShowContentDialogAsync(viewModel, typeof(T));
        }

        /// <summary>
        /// Begins an asynchronous operation to show the <see cref="ContentDialog" /> of a type that
        /// is determined by the dialog type locator.
        /// </summary>
        /// <param name="viewModel">The view model of the new content dialog.</param>
        /// <returns>
        /// An asynchronous operation showing the dialog. When complete, returns a
        /// <see cref="ContentDialogResult" />.
        /// </returns>
        public IAsyncOperation<ContentDialogResult> ShowContentDialogAsync(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            Type contentDialogType = contentDialogTypeLocator.Locate(viewModel);
            return ShowContentDialogAsync(viewModel, contentDialogType);
        }

        /// <summary>
        /// Begins an asynchronous operation showing a <see cref="MessageDialog" />.
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
        public IAsyncOperation<IUICommand> ShowMessageDialogAsync(
            string content,
            string title = null,
            IEnumerable<IUICommand> commands = null,
            uint? defaultCommandIndex = default(uint?),
            uint? cancelCommandIndex = default(uint?),
            MessageDialogOptions options = MessageDialogOptions.None)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            Logger.Write($"Title: {title}; Content: {content}");

            var messageDialog = new MessageDialog(content)
            {
                Options = options
            };

            DoIf(title != null, () => messageDialog.Title = title);
            DoIf(defaultCommandIndex != null, () => messageDialog.DefaultCommandIndex = defaultCommandIndex.Value);
            DoIf(cancelCommandIndex != null, () => messageDialog.CancelCommandIndex = cancelCommandIndex.Value);

            foreach (IUICommand uiCommand in commands ?? Enumerable.Empty<IUICommand>())
            {
                messageDialog.Commands.Add(uiCommand);
            }

            return messageDialog.ShowAsync();
        }

        /// <summary>
        /// Shows the file picker so that the user can pick one file.
        /// </summary>
        /// <param name="settings">The settings for the file open picker.</param>
        /// <returns>
        /// When the call to this method completes successfully, it returns a
        /// <see cref="StorageFile" /> object that represents the file that the user picked.
        /// </returns>
        public IAsyncOperation<StorageFile> PickSingleFileAsync(FileOpenPickerSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Commit button text: {settings.CommitButtonText}");

            var dialog = new FileOpenPickerWrapper(settings);
            return dialog.PickSingleFileAsync();
        }

        /// <summary>
        /// Shows the file picker so that the user can pick multiple files.
        /// </summary>
        /// <param name="settings">The settings for the file open picker.</param>
        /// <returns>
        /// When the call to this method completes successfully, it returns a
        /// <see cref="IReadOnlyList{StorageFile}" /> object that contains all the files that were
        /// picked by the user. Picked files in this array are represented by
        /// <see cref="StorageFile" /> objects.
        /// </returns>
        public IAsyncOperation<IReadOnlyList<StorageFile>> PickMultipleFilesAsync(FileOpenPickerSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Commit button text: {settings.CommitButtonText}");

            var dialog = new FileOpenPickerWrapper(settings);
            return dialog.PickMultipleFilesAsync();
        }

        /// <summary>
        /// Shows the file picker so that the user can save a file and set the file name,
        /// extension, and location of the file to be saved.
        /// </summary>
        /// <param name="settings">The settings for the file save picker.</param>
        /// <returns>
        /// When the call to this method completes successfully, it returns a
        /// <see cref="StorageFile" /> object that was created to represent the saved file. The file
        /// name, extension, and location of this <see cref="StorageFile" /> match those specified
        /// by the user, but the file has no content.
        /// </returns>
        public IAsyncOperation<StorageFile> PickSaveFileAsync(FileSavePickerSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Commit button text: {settings.CommitButtonText}");

            var dialog = new FileSavePickerWrapper(settings);
            return dialog.PickSaveFileAsync();
        }

        /// <summary>
        /// Shows the folder picker so that the user can pick a folder.
        /// </summary>
        /// <param name="settings">The settings for the folder picker.</param>
        /// <returns>
        /// When the call to this method completes successfully, it returns a
        /// <see cref="StorageFolder" /> object that represents the folder that the user picked.
        /// </returns>
        public IAsyncOperation<StorageFolder> PickSingleFolderAsync(FolderPickerSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            var dialog = new FolderPickerWrapper(settings);
            return dialog.PickSingleFolderAsync();
        }

        #endregion

        private IAsyncOperation<ContentDialogResult> ShowContentDialogAsync(
            INotifyPropertyChanged viewModel,
            Type contentDialogType)
        {
            Logger.Write($"Content dialog: {contentDialogType}; View model: {viewModel.GetType()}");

            IContentDialog dialog = CreateContentDialog(contentDialogType, viewModel);
            return dialog.ShowAsync();
        }

        private IContentDialog CreateContentDialog(
            Type dialogType,
            INotifyPropertyChanged viewModel)
        {
            var dialog = contentDialogFactory.Create(dialogType);
            dialog.DataContext = viewModel;

            return dialog;
        }

        private static void DoIf(bool condition, Action action)
        {
            if (condition)
            {
                action();
            }
        }
    }
}