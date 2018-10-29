using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace MvvmDialogs.FrameworkPickers.FileSave
{
    /// <summary>
    /// Class wrapping <see cref="FileSavePicker"/>.
    /// </summary>
    internal sealed class FileSavePickerWrapper
    {
        private readonly FileSavePicker picker;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSavePickerWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the file save picker.</param>
        internal FileSavePickerWrapper(FileSavePickerSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            picker = new FileSavePicker
            {
                CommitButtonText = settings.CommitButtonText,
                DefaultFileExtension = settings.DefaultFileExtension,
                EnterpriseId = settings.EnterpriseId,
                SettingsIdentifier = settings.SettingsIdentifier,
                SuggestedFileName = settings.SuggestedFileName,
                SuggestedSaveFile = settings.SuggestedSaveFile,
                SuggestedStartLocation = settings.SuggestedStartLocation
            };

            foreach (KeyValuePair<string, IList<string>> fileTypeChoice in settings.FileTypeChoices)
            {
                picker.FileTypeChoices.Add(fileTypeChoice);
            }
        }

        /// <summary>
        /// Shows the file picker so that the user can save a file and set the file name,
        /// extension, and location of the file to be saved.
        /// </summary>
        /// <returns>
        /// When the call to this method completes successfully, it returns a
        /// <see cref="StorageFile"/> object that was created to represent the saved file. The file
        /// name, extension, and location of this <see cref="StorageFile"/> match those specified
        /// by the user, but the file has no content.
        /// </returns>
        internal IAsyncOperation<StorageFile> PickSaveFileAsync() => picker.PickSaveFileAsync();
    }
}
