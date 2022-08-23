using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    /// <summary>
    /// Settings for <see cref="OpenFileDialog"/>.
    /// </summary>
    public class OpenFileDialogSettings : FileDialogSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether a file dialog displays a warning if the user
        /// specifies a file name that does not exist.
        /// </summary>
        /// <value>
        /// <c>true</c> if warnings are displayed; otherwise, <c>false</c>. The default in this
        /// class is <c>true</c>.
        /// </value>
        public bool CheckFileExists { get; set; } = true;

        /// <summary>
        /// Gets or sets an option indicating whether the dialog box allows users to select
        /// multiple files.
        /// </summary>
        /// <value>
        /// <c>true</c> if multiple selections are allowed; otherwise, <c>false</c>. The default is
        /// <c>false</c>.
        /// </value>
        public bool Multiselect { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the read-only check box displayed by the open
        /// file dialog is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if the checkbox is selected; otherwise, <c>false</c>. The default is
        /// <c>false</c>.
        /// </value>
        public bool ReadOnlyChecked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the open file dialog contains a read-only check
        /// box.
        /// </summary>
        /// <value>
        /// <c>true</c> if the checkbox is displayed; otherwise, <c>false</c>. The default is
        /// <c>false</c>.
        /// </value>
        public bool ShowReadOnly { get; set; }
    }
}
