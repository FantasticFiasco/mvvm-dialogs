using System;
using System.Windows;
using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    /// <summary>
    /// Class wrapping <see cref="FolderBrowserDialog"/>.
    /// </summary>
    internal sealed class FolderBrowserDialogWrapper : IFrameworkDialog
    {
        private readonly FolderBrowserDialogSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderBrowserDialogWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public FolderBrowserDialogWrapper(FolderBrowserDialogSettings settings) => this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

        /// <inheritdoc />
        public bool? ShowDialog(Window owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            using var dialog = new FolderBrowserDialog();
            var sync = new FolderBrowserDialogSettingsSync(dialog, settings);

            // Update dialog
            sync.ToDialog();

            DialogResult result = dialog.ShowDialog(new Win32Window(owner));

            // Update settings
            sync.ToSettings();

            return result switch
            {
                DialogResult.OK => true,
                DialogResult.Yes => true,
                DialogResult.No => false,
                DialogResult.Abort => false,
                _ => null
            };
        }
    }
}
