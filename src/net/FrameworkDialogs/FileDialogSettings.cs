using System.Collections.Generic;
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
        /// <value>
        /// <c>true</c> if extensions are added; otherwise, <c>false</c>. The default is
        /// <c>true</c>.
        /// </value>
        public bool AddExtension { get; set; } = true;

        /// <summary>
        /// Gets or sets a value that specifies whether warnings are displayed if the user types
        /// invalid paths and file names.
        /// </summary>
        /// <value>
        /// <c>true</c> if warnings are displayed; otherwise, <c>false</c>. The default is
        /// <c>true</c>.
        /// </value>
        public bool CheckPathExists { get; set; } = true;

        /// <summary>
        /// Gets or sets the list of custom places for file dialog boxes.
        /// </summary>
        /// <value>
        /// The list of custom places.
        /// </value>
        /// <remarks>
        /// Starting in Windows Vista, open and save file dialog boxes have a <b>Favorite Links</b>
        /// panel on the left side of the dialog box that allows the user to quickly navigate to a
        /// different location. These links are called custom places. This property allows you to
        /// modify the list that appears when your application uses a file dialog box.
        /// </remarks>
        public IList<Microsoft.Win32.FileDialogCustomPlace> CustomPlaces { get; set; } = new List<Microsoft.Win32.FileDialogCustomPlace>();

        /// <summary>
        /// Gets or sets a value that specifies the default extension string to use to filter the
        /// list of files that are displayed.
        /// </summary>
        /// <value>
        /// The default extension string. The default is <see cref="string.Empty"/>.
        /// </value>
        /// <remarks>
        /// The extension string must contain the leading period. For example, set the
        /// <see cref="DefaultExt"/> property to ".txt" to select all text files.
        /// <para/>
        /// By default, the <see cref="AddExtension"/> property attempts to determine the extension
        /// to filter the displayed file list from the <see cref="Filter"/> property. If the
        /// extension cannot be determined from the <see cref="Filter"/> property,
        /// <see cref="DefaultExt"/> will be used instead.
        /// </remarks>
        public string DefaultExt { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether a file dialog returns either the location of
        /// the file referenced by a shortcut or the location of the shortcut file (.lnk).
        /// </summary>
        /// <value>
        /// <c>true</c> to return the location referenced; <c>false</c> to return the shortcut
        /// location. The default is <c>true</c>.
        /// </value>
        public bool DereferenceLinks { get; set; } = true;

        /// <summary>
        /// Gets or sets a string containing the full path of the file selected in a file dialog.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that is the full path of the file selected in the file dialog.
        /// The default is <see cref="string.Empty"/>.
        /// </value>
        /// <remarks>
        /// If more than one file name is selected (length of <see cref="FileNames"/> is greater
        /// than one) then <see cref="FileName"/> contains the first selected file name. If no file
        /// name is selected, this property contains <see cref="string.Empty"/> rather than
        /// <c>null</c>.
        /// </remarks>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets an array that contains one file name for each selected file.
        /// </summary>
        /// <value>
        /// An array of <see cref="string"/> that contains one file name for each selected file.
        /// The default is an array with a single item whose value is <see cref="string.Empty"/>.
        /// </value>
        public string[] FileNames { get; set; } = { string.Empty };

        /// <summary>
        /// Gets or sets the filter string that determines what types of files are displayed from
        /// either the open file dialog or the save file dialog.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that contains the filter. The default is
        /// <see cref="string.Empty"/>, which means that no filter is applied and all file types
        /// are displayed.
        /// </value>
        /// <remarks>
        /// If <see cref="Filter"/> is either <c>null</c> or <see cref="string.Empty"/>, all files
        /// are displayed, and folders are always displayed.
        /// <para/>
        /// You can specify a subset of file types to be displayed by setting the
        /// <see cref="Filter"/> property. Each file type can represent a specific type of file,
        /// such as the following:
        /// <list type="bullet">
        /// <item><description>Word Documents (*.doc)</description></item>
        /// <item><description>Excel Worksheets (*.xls)</description></item>
        /// <item><description>PowerPoint Presentations (*.ppt)</description></item>
        /// </list>
        /// Alternatively, a file type can represent a group of related file types, such as the
        /// following:
        /// <list type="bullet">
        /// <item><description>Office Files (*.doc, *.xls, *.ppt)</description></item>
        /// <item><description>All Files (*.*)</description></item>
        /// </list>
        /// To specify a subset of the types of files that are displayed, you set the
        /// <see cref="Filter"/> property with a string value (the <i>filter string</i>) that
        /// specifies one or more types of files to filter by. The following shows the expected
        /// format of the filter string:
        /// <code>
        /// FileType1[[|FileType2]...[|FileTypeN]]
        /// </code>
        /// You use the following format to describe each file type:
        /// <code>
        /// Label|Extension1[[;Extension2]...[;ExtensionN]]
        /// </code>
        /// The <i>Label</i> part is a human-readable string value that describes the file type,
        /// such as the following:
        /// <list type="bullet">
        /// <item><description>"Word Documents"</description></item>
        /// <item><description>"Excel Worksheets"</description></item>
        /// <item><description>"PowerPoint Presentations"</description></item>
        /// <item><description>"Office Files"</description></item>
        /// <item><description>"All Files"</description></item>
        /// </list>
        /// Each file type must be described by at least one <i>Extension</i>. If more than one
        /// <i>Extension</i> is used, each <i>Extension</i> must be separated by a semicolon (";").
        /// For example:
        /// <list type="bullet">
        /// <item><description>"*.doc"</description></item>
        /// <item><description>"*.xls;"</description></item>
        /// <item><description>"*.ppt"</description></item>
        /// <item><description>"*.doc;*.xls;*.ppt"</description></item>
        /// <item><description>"*.*"</description></item>
        /// </list>
        /// The following are complete examples of valid <see cref="Filter"/> string values:
        /// <list type="bullet">
        /// <item><description>Word Documents|*.doc</description></item>
        /// <item><description>Excel Worksheets|*.xls</description></item>
        /// <item><description>PowerPoint Presentations|*.ppt</description></item>
        /// <item><description>Office Files|*.doc;*.xls;*.ppt</description></item>
        /// <item><description>All Files|*.*</description></item>
        /// <item><description>Word Documents|*.doc|Excel Worksheets|*.xls|PowerPoint Presentations|*.ppt|Office Files|*.doc;*.xls;*.ppt|All Files|*.*</description></item>
        /// </list>
        /// Each file type that is included in the filter is added as a separate item to the
        /// <b>Files of type</b>: drop-down list in the open file dialog or the save file dialog.
        /// <para/>
        /// The user can choose a file type from this list to filter by. By default, the first item
        /// in the list (for example, the first file type) is selected when the open file dialog or
        /// save file dialog is displayed. To specify that another file type to be selected, you
        /// set the <see cref="FilterIndex"/> property before showing the open file dialog or the
        /// save file dialog.
        /// </remarks>
        public string Filter { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the index of the filter currently selected in a file dialog.
        /// </summary>
        /// <value>
        /// The <see cref="int" /> that is the index of the selected filter. The default is 1.
        /// </value>
        /// <remarks>
        /// This index is 1-based, not 0-based, due to compatibility requirements with the
        /// underlying Win32 API.
        /// </remarks>
        public int FilterIndex { get; set; } = 1;

        /// <summary>
        /// Gets or sets the initial directory that is displayed by a file dialog.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that contains the initial directory. The default is
        /// <see cref="string.Empty"/>.
        /// </value>
        /// <remarks>
        /// If there is no initial directory set, this property will contain
        /// <see cref="string.Empty"/> rather than a <c>null</c> string.
        /// </remarks>
        public string InitialDirectory { get; set; } = string.Empty;

        /// <summary>
        /// Gets a string that only contains the file name for the selected file.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that only contains the file name for the selected file. The
        /// default is <see cref="string.Empty"/>, which is also the value when either no file is
        /// selected or a directory is selected.
        /// </value>
        /// <remarks>
        /// This value is the <see cref="FileName"/> with all path information removed. Removing
        /// the paths makes the value appropriate for use in partial trust applications, since it
        /// prevents applications from discovering information about the local file system.
        /// <para/>
        /// If more than one file name is selected (length of <see cref="SafeFileNames"/> is
        /// greater than one) then this property contains only the first selected file name.
        /// </remarks>
        public string SafeFileName { internal set; get; } = string.Empty;

        /// <summary>
        /// Gets an array that contains one safe file name for each selected file.
        /// </summary>
        /// <value>
        /// An array of <see cref="string"/> that contains one safe file name for each selected
        /// file. The default is an array with a single item whose value is
        /// <see cref="string.Empty"/>.
        /// </value>
        /// <remarks>
        /// This value is the <see cref="FileNames"/> with all path information removed. Removing
        /// the paths makes the value appropriate for use in partial trust applications, since it
        /// prevents applications from discovering information about the local file system.
        /// </remarks>
        public string[] SafeFileNames { internal set; get; } = new string[0];

        /// <summary>
        /// Gets or sets the text that appears in the title bar of a file dialog.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that is the text that appears in the title bar of a file dialog.
        /// The default is <see cref="string.Empty"/>.
        /// </value>
        /// <remarks>
        /// If <see cref="Title"/> is <c>null</c> or <see cref="string.Empty"/>, a default,
        /// localized value is used, such as "Save As" or "Open".
        /// </remarks>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the dialog accepts only valid Win32 file names.
        /// </summary>
        /// <value>
        /// <c>true</c> if warnings will be shown when an invalid file name is provided; otherwise,
        /// <c>false</c>. The default is <c>true</c>.
        /// </value>
        public bool ValidateNames { get; set; } = true;
    }
}
