using System.Collections.Generic;
using Windows.Storage.Pickers;

namespace MvvmDialogs.FrameworkPickers.Folder
{
    /// <summary>
    /// Settings for <see cref="FolderPicker"/>.
    /// </summary>
    public class FolderPickerSettings
    {
        /// <summary>
        /// Gets or sets the label text of the folder picker's commit button.
        /// </summary>
        /// <remarks>
        /// By default, the label text of the commit button is <b>Pick Folder</b>.
        /// </remarks>
        public string CommitButtonText { get; set; } = string.Empty;

        /// <summary>
        /// Gets the collection of file types that the folder picker displays.
        /// </summary>
        /// <value>
        /// A <see cref="IEnumerable{String}"/> object that contains a collection of file types
        /// (file name extensions) , such as ".doc" and ".png". File name extensions are stored in
        /// this array as string objects.
        /// </value>
        public IEnumerable<string> FileTypeFilter { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the settings identifier associated with the with the current
        /// <see cref="FolderPicker"/> instance.
        /// </summary>
        /// <remarks>
        /// If your application uses multiple instances of the folder picker, you can use this
        /// property to identify the individual instances.
        /// </remarks>
        public string SettingsIdentifier { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the initial location where the folder picker looks for folders to present
        /// to the user.
        /// </summary>
        /// <remarks>
        /// The <see cref="SuggestedStartLocation"/> is not always used as the start location for
        /// the file picker. To give the user a sense of consistency, the file picker remembers the
        /// last location that the user navigated to and will generally start at that location.
        /// </remarks>
        public PickerLocationId SuggestedStartLocation { get; set; } = PickerLocationId.DocumentsLibrary;

        /// <summary>
        /// Gets or sets the view mode that the folder picker uses to display items.
        /// </summary>
        public PickerViewMode ViewMode { get; set; } = PickerViewMode.List;
    }
}
