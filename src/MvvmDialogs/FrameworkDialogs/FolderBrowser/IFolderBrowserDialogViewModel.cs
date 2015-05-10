using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    /// <summary>
    /// Interface of a view model describing the <see cref="FolderBrowserDialog"/>.
    /// </summary>
    public interface IFolderBrowserDialogViewModel
    {
        /// <summary>
        /// Gets or sets the descriptive text displayed above the tree view control in the dialog
        /// box.
        /// </summary>
        string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the path selected by the user.
        /// </summary>
        string SelectedPath { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether the New Folder button appears in the folder
        /// browser dialog box.
        /// </summary>
        bool ShowNewFolderButton { get; set; }
    }
}