using System;
using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    /// <summary>
    /// Class wrapping <see cref="FolderBrowserDialog"/>.
    /// </summary>
    internal sealed class FolderBrowserDialogWrapper : IDisposable
    {
        private readonly FolderBrowserDialogSettings settings;
        private readonly FolderBrowserDialog folderBrowserDialog;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderBrowserDialogWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public FolderBrowserDialogWrapper(FolderBrowserDialogSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            this.settings = settings;

            folderBrowserDialog = new FolderBrowserDialog
            {
                Description = settings.Description,
                SelectedPath = settings.SelectedPath,
                ShowNewFolderButton = settings.ShowNewFolderButton
            };
        }

        /// <summary>
        /// Runs a common dialog box with the specified owner.
        /// </summary>
        /// <param name="owner">
        /// Any object that implements <see cref="IWin32Window"/> that represents the top-level
        /// window that will own the modal dialog box.
        /// </param>
        /// <returns>
        /// <see cref="DialogResult.OK"/> if the user clicks OK in the dialog box; otherwise,
        /// <see cref="DialogResult.Cancel"/>.
        /// </returns>
        public DialogResult ShowDialog(IWin32Window owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            DialogResult result = folderBrowserDialog.ShowDialog(owner);

            // Update settings
            settings.SelectedPath = folderBrowserDialog.SelectedPath;

            return result;
        }
        
        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            folderBrowserDialog?.Dispose();
        }

        #endregion
    }
}