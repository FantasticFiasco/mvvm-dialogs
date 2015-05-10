using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.SaveFile
{
    /// <summary>
    /// View model describing the <see cref="SaveFileDialog"/>.
    /// </summary>
    public class SaveFileDialogViewModel : FileDialogViewModel, ISaveFileDialogViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the dialog box prompts the user for permission
        /// to create a file if the user specifies a file that does not exist.
        /// </summary>
        public bool CreatePrompt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <b>Save As</b> dialog box displays a
        /// warning if the user specifies a file name that already exists.
        /// </summary>
        public bool OverwritePrompt { get; set; }
    }
}