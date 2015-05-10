using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    /// <summary>
    /// Interface of a view model describing the <see cref="OpenFileDialog"/>.
    /// </summary>
    public interface IOpenFileDialogViewModel : IFileDialogViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the dialog box allows multiple files to be
        /// selected.
        /// </summary>
        bool Multiselect { get; set; }
    }
}