using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.SaveFile
{
    /// <summary>
    /// Interface of a view model describing the <see cref="SaveFileDialog"/>.
    /// </summary>
    public interface ISaveFileDialogViewModel : IFileDialogViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the dialog box prompts the user for permission
        /// to create a file if the user specifies a file that does not exist.
        /// </summary>
        bool CreatePrompt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <b>Save As</b> dialog box displays a
        /// warning if the user specifies a file name that already exists.
        /// </summary>
        bool OverwritePrompt { get; set; }
    }
}