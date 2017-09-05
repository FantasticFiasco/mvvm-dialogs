using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Settings for <see cref="FileDialog"/>.
    /// </summary>
    public abstract class FileDialogSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the dialog box automatically adds an extension
        /// to a file name if the user omits the extension.
        /// </summary>
        public bool AddExtension { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box displays a warning if the user
        /// specifies a file name that does not exist.
        /// </summary>
        public bool CheckFileExists { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box displays a warning if the user
        /// specifies a path that does not exist.
        /// </summary>
        public bool CheckPathExists { get; set; } = true;
        
        /// <summary>
        /// Gets or sets the default file name extension.
        /// </summary>
        public string DefaultExt { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a string containing the file name selected in the file dialog box.
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets the file names of all selected files in the dialog box.
        /// </summary>
        public string[] FileNames { get; set; } = { string.Empty };
        
        /// <summary>
        /// Gets or sets the current file name filter string, which determines the choices that
        /// appear in the "Save as file type" or "Files of type" box in the dialog box.
        /// </summary>
        public string Filter { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the index of the filter currently selected in a file dialog.
        /// </summary>
        /// <returns>
        /// The <see cref="int" /> that is the index of the selected filter. The default is 1.
        /// </returns>
        public int FilterIndex { get; set; } = 1;

        /// <summary>
        /// Gets or sets the initial directory displayed by the file dialog box.
        /// </summary>
        public string InitialDirectory { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the file dialog box title.
        /// </summary>
        public string Title { get; set; } = string.Empty;
    }
}