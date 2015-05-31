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
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the path selected by the user.
        /// </summary>
        public string SelectedPath { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether the New Folder button appears in the folder
        /// browser dialog box.
        /// </summary>
        public bool ShowNewFolderButton { get; set; }
    }
}