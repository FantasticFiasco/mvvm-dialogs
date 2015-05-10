namespace MvvmDialogs.FrameworkDialogs.FolderBrowse
{
    /// <summary>
    /// Interface describing the FolderBrowserDialog.
    /// </summary>
    public interface IFolderBrowserDialog
    {
        /// <summary>
        /// Gets or sets the descriptive text displayed above the tree view control in the dialog box.
        /// </summary>
        string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the path selected by the user.
        /// </summary>
        string SelectedPath { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether the New Folder button appears in the folder browser
        /// dialog box.
        /// </summary>
        bool ShowNewFolderButton { get; set; }
    }
}