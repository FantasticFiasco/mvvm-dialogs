using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    /// <summary>
    /// View model describing the <see cref="OpenFileDialog"/>.
    /// </summary>
    public class OpenFileDialogViewModel : FileDialogViewModel, IOpenFileDialogViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the dialog box allows multiple files to be
        /// selected.
        /// </summary>
        public bool Multiselect { get; set; }
    }
}