using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Settings for <see cref="FileDialog"/>.
    /// </summary>
    public abstract class FileDialogSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether a file dialog automatically adds an extension
        /// to a file name if the user omits an extension.
        /// </summary>
        /// <remarks>
        /// <c>true</c> if extensions are added; otherwise, <c>false</c>. The default is
        /// <c>true</c>.
        /// </remarks>
        public bool AddExtension { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog displays a warning if the user
        /// specifies a file name that does not exist.
        /// </summary>
        /// <remarks>
        /// <c>true</c> if warnings are displayed; otherwise, <c>false</c>. The default in this
        /// base class is <c>false</c>.
        /// </remarks>
        public bool CheckFileExists { get; set; } = true;

        /// <summary>
        /// Gets or sets a value that specifies whether warnings are displayed if the user types
        /// invalid paths and file names.
        /// </summary>
        /// <remarks>
        /// <c>true</c> if warnings are displayed; otherwise, <c>false</c>. The default is
        /// <c>true</c>.
        /// </remarks>
        public bool CheckPathExists { get; set; } = true;

        /// <summary>
        /// Gets or sets a value that specifies the default extension string to use to filter the
        /// list of files that are displayed.
        /// </summary>
        /// <remarks>
        /// The default extension string. The default is <see cref="string.Empty"/>.
        /// </remarks>
        public string DefaultExt { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a string containing the full path of the file selected in a file dialog.
        /// </summary>
        /// <remarks>
        /// A <see cref="string"/> that is the full path of the file selected in the file dialog.
        /// The default is <see cref="string.Empty"/>.
        /// </remarks>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets an array that contains one file name for each selected file.
        /// </summary>
        /// <remarks>
        /// An array of <see cref="string"/> that contains one file name for each selected file.
        /// The default is an array with a single item whose value is <see cref="string.Empty"/>.
        /// </remarks>
        public string[] FileNames { get; set; } = { string.Empty };

        /// <summary>
        /// Gets or sets the filter string that determines what types of files are displayed from
        /// either the open file dialog or the save file dialog.
        /// </summary>
        /// <remarks>
        /// A <see cref="string"/> that contains the filter. The default is
        /// <see cref="string.Empty"/>, which means that no filter is applied and all file types
        /// are displayed.
        /// </remarks>
        public string Filter { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the index of the filter currently selected in a file dialog.
        /// </summary>
        /// <returns>
        /// The <see cref="int" /> that is the index of the selected filter. The default is 1.
        /// </returns>
        public int FilterIndex { get; set; } = 1;

        /// <summary>
        /// Gets or sets the initial directory that is displayed by a file dialog.
        /// </summary>
        /// <remarks>
        /// A <see cref="string"/> that contains the initial directory. The default is
        /// <see cref="string.Empty"/>.
        /// </remarks>
        public string InitialDirectory { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the text that appears in the title bar of a file dialog.
        /// </summary>
        /// <remarks>
        /// A <see cref="string"/> that is the text that appears in the title bar of a file dialog.
        /// The default is <see cref="string.Empty"/>.
        /// </remarks>
        public string Title { get; set; } = string.Empty;
    }
}
