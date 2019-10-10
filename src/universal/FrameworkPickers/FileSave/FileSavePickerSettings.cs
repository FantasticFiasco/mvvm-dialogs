using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace MvvmDialogs.FrameworkPickers.FileSave
{
    /// <summary>
    /// Settings for <see cref="FileSavePicker"/>.
    /// </summary>
    public class FileSavePickerSettings
    {
        /// <summary>
        /// Gets or sets the label text of the commit button in the file picker UI.
        /// </summary>
        /// <remarks>
        /// By default, the label text of the commit button is <b>Save</b>.
        /// </remarks>
        public string CommitButtonText { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the default file name extension that the <see cref="FileSavePicker"/>
        /// gives to files to be saved.
        /// </summary>
        public string DefaultFileExtension { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets an ID that specifies the enterprise that owns the file.
        /// </summary>
        public string EnterpriseId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of valid file types that the user can choose to assign to a
        /// file.
        /// </summary>
        /// <value>
        /// A <see cref="IDictionary{String, IList}"/> object that contains a collection of
        /// valid file types (extensions) that the user can use to save a file. Each element in
        /// this collection maps a display name to a corresponding collection of file name
        /// extensions. The key is a single string, the value is a list of strings representing one
        /// or more extension choices.
        /// </value>
        /// <remarks>
        /// Some apps do not need to understand a file format in order to process it - such as a
        /// cloud storage provider. Therefore, using the file wildcard character - "*" - is
        /// supported for the <see cref="FileOpenPicker.FileTypeFilter"/> collection. However,
        /// writing a file requires knowledge of its format. As a result, the wildcard is not
        /// supported for <see cref="FileSavePicker.FileTypeChoices"/>.
        /// <para />
        /// One display name as a classification of file types might have multiple file types that
        /// support it. For example, a display name of "HTML page" could be saved either with
        /// ".htm" or ".html" extension. That is why the value of each entry in a
        /// <see cref="IDictionary{String, IList}"/> is an ordered list (vector) of strings,
        /// displayed in the UI in the order that you place the extensions in the vector.
        /// </remarks>
        public IDictionary<string, IList<string>> FileTypeChoices { get; set; } = new Dictionary<string, IList<string>>();

        /// <summary>
        /// Gets or sets the settings identifier associated with the current
        /// <see cref="FileSavePicker"/> instance.
        /// </summary>
        /// <remarks>
        /// If your application uses multiple instances of the file save picker, you can use this
        /// property to identify the individual instances.
        /// </remarks>
        public string SettingsIdentifier { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the file name that the file save picker suggests to the user.
        /// </summary>
        public string SuggestedFileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the <see cref="StorageFile"/> that the file picker suggests to the user
        /// for saving a file.
        /// </summary>
        public StorageFile SuggestedSaveFile { get; set; } = null;

        /// <summary>
        /// Gets or sets the location that the file save picker suggests to the user as the
        /// location to save a file.
        /// </summary>
        /// <remarks>
        /// The <see cref="SuggestedStartLocation"/> is not always used as the start location for
        /// the file picker. To give the user a sense of consistency, the file picker remembers the
        /// last location that the user navigated to and will generally start at that location.
        /// </remarks>
        public PickerLocationId SuggestedStartLocation { get; set; } = PickerLocationId.DocumentsLibrary;
    }
}
