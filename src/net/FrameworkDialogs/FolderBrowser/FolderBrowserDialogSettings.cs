using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    /// <summary>
    /// Settings for <see cref="FolderBrowserDialog"/>.
    /// </summary>
    public class FolderBrowserDialogSettings
    {
        /// <summary>
        /// Gets or sets the descriptive text displayed above the tree view control in the dialog
        /// box.
        /// </summary>
        /// <remarks>
        /// The description to display. The default is an empty string ("").
        /// </remarks>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the root folder where the browsing starts from.
        /// </summary>
        /// <remarks>
        /// One of the <see cref="Environment.SpecialFolder"/> values. The default is
        /// <c>Desktop</c>.
        /// </remarks>
        public Environment.SpecialFolder RootFolder { get; set; } = Environment.SpecialFolder.Desktop;

        /// <summary>
        /// Gets or sets the path selected by the user.
        /// </summary>
        /// <remarks>
        /// The path of the folder first selected in the dialog box or the last folder selected by
        /// the user. The default is an empty string ("").
        /// </remarks>
        public string SelectedPath { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the <b>New Folder</b> button appears in the
        /// folder browser dialog box.
        /// </summary>
        /// <remarks>
        /// <c>true</c> if the <b>New Folder</b> button is shown in the dialog box; otherwise,
        /// <c>false</c>. The default is <c>true</c>.
        /// </remarks>
        public bool ShowNewFolderButton { get; set; }
    }
}
