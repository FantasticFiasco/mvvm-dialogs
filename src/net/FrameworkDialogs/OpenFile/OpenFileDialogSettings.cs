using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    /// <summary>
    /// Settings for <see cref="OpenFileDialog"/>.
    /// </summary>
    public class OpenFileDialogSettings : FileDialogSettings
    {
        /// <summary>
        /// Gets or sets an option indicating whether the dialog box allows users to select
        /// multiple files.
        /// </summary>
        /// <value>
        /// <c>true</c> if multiple selections are allowed; otherwise, <c>false</c>. The default is
        /// <c>false</c>.
        /// </value>
        public bool Multiselect { get; set; }
    }
}
