using System.Collections.Generic;
using Windows.Storage.Pickers;

namespace MvvmDialogs.FrameworkPickers.FileOpen
{
    /// <summary>
    /// Settings for <see cref="FileOpenPicker"/>.
    /// </summary>
    public class FileOpenPickerSettings
    {
        /// <summary>
        /// Gets or sets the label text of the file open picker's commit button.
        /// </summary>
        /// <remarks>
        /// By default, the label text of the commit button is <b>Open</b>.
        /// </remarks>
        public string CommitButtonText { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of file types that the file open picker displays.
        /// </summary>
        /// <value>
        /// A <see cref="IList{String}"/> object that contains a collection of file types
        /// (file name extensions) , such as ".doc" and ".png". File name extensions are stored in
        /// this sequence as string objects.
        /// </value>
        public IEnumerable<string> FileTypeFilter { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the settings identifier associated with the state of the file open picker.
        /// </summary>
        /// <remarks>
        /// If your application uses multiple instances of the file open picker, you can use this
        /// property to identify the individual instances.
        /// </remarks>
        public string SettingsIdentifier { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the initial location where the file open picker looks for files to present
        /// to the user.
        /// </summary>
        /// <remarks>
        /// The <b>SuggestedStartLocation</b> is not always used as the start location for the
        /// file picker. To give the user a sense of consistency, the file picker remembers the
        /// last location that the user navigated to and will generally start at that location.
        /// </remarks>
        public PickerLocationId SuggestedStartLocation { get; set; } = PickerLocationId.DocumentsLibrary;

        /// <summary>
        /// Gets or sets the view mode that the file open picker uses to display items.
        /// </summary>
        public PickerViewMode ViewMode { get; set; } = PickerViewMode.List;
    }
}
