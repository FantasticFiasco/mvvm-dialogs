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
        public FolderBrowserDialogWrapper(FolderBrowserDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <inheritdoc />
        public bool? ShowDialog(Window owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = settings.Description;
                folderBrowserDialog.SelectedPath = settings.SelectedPath;
                folderBrowserDialog.ShowNewFolderButton = settings.ShowNewFolderButton;

                DialogResult result = folderBrowserDialog.ShowDialog(new Win32Window(owner));

                // Update settings
                settings.SelectedPath = folderBrowserDialog.SelectedPath;

                switch (result)
                {
                    case DialogResult.OK:
                    case DialogResult.Yes:
                        return true;

                    case DialogResult.No:
                    case DialogResult.Abort:
                        return false;
                    
                    default:
                        return null;
                }
            }
        }
    }
}
