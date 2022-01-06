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

        /// <inheritdoc />
        public IAsyncOperation<ContentDialogResult> ShowContentDialogAsync<T>(INotifyPropertyChanged viewModel)
            where T : ContentDialog
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            return ShowContentDialogAsync(viewModel, typeof(T));
        }

        /// <inheritdoc />
        public IAsyncOperation<ContentDialogResult> ShowCustomContentDialogAsync<T>(INotifyPropertyChanged viewModel)
            where T : IContentDialog
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            return ShowContentDialogAsync(viewModel, typeof(T));
        }

        /// <inheritdoc />
        public IAsyncOperation<ContentDialogResult> ShowContentDialogAsync(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            Type contentDialogType = contentDialogTypeLocator.Locate(viewModel);
            return ShowContentDialogAsync(viewModel, contentDialogType);
        }

        /// <inheritdoc />
        public IAsyncOperation<IUICommand> ShowMessageDialogAsync(
            string content,
            string title = null,
            IEnumerable<IUICommand> commands = null,
            uint? defaultCommandIndex = default(uint?),
            uint? cancelCommandIndex = default(uint?),
            MessageDialogOptions options = MessageDialogOptions.None)
        {
            if (content == null) throw new ArgumentNullException(nameof(content));

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

        /// <inheritdoc />
        public IAsyncOperation<StorageFile> PickSingleFileAsync(FileOpenPickerSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Commit button text: {settings.CommitButtonText}");

            var dialog = new FileOpenPickerWrapper(settings);
            return dialog.PickSingleFileAsync();
        }

        /// <inheritdoc />
        public IAsyncOperation<IReadOnlyList<StorageFile>> PickMultipleFilesAsync(FileOpenPickerSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Commit button text: {settings.CommitButtonText}");

            var dialog = new FileOpenPickerWrapper(settings);
            return dialog.PickMultipleFilesAsync();
        }

        /// <inheritdoc />
        public IAsyncOperation<StorageFile> PickSaveFileAsync(FileSavePickerSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Commit button text: {settings.CommitButtonText}");

            var dialog = new FileSavePickerWrapper(settings);
            return dialog.PickSaveFileAsync();
        }

        /// <inheritdoc />
        public IAsyncOperation<StorageFolder> PickSingleFolderAsync(FolderPickerSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

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
