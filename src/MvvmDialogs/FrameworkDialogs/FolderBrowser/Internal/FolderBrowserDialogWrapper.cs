using System;
using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser.Internal
{
    /// <summary>
    /// Class wrapping <see cref="FolderBrowserDialog"/>, making it accept a
    /// view model.
    /// </summary>
    internal sealed class FolderBrowserDialogWrapper : IDisposable
    {
        private readonly IFolderBrowserDialogViewModel folderBrowserDialogViewModel;
        private readonly FolderBrowserDialog folderBrowserDialog;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderBrowserDialogWrapper"/> class.
        /// </summary>
        /// <param name="folderBrowserDialogViewModel">
        /// The folder browser dialog view model.
        /// </param>
        public FolderBrowserDialogWrapper(IFolderBrowserDialogViewModel folderBrowserDialogViewModel)
        {
            if (folderBrowserDialogViewModel == null)
                throw new ArgumentNullException("folderBrowserDialogViewModel");

            this.folderBrowserDialogViewModel = folderBrowserDialogViewModel;

            folderBrowserDialog = new FolderBrowserDialog
            {
                Description = folderBrowserDialogViewModel.Description,
                SelectedPath = folderBrowserDialogViewModel.SelectedPath,
                ShowNewFolderButton = folderBrowserDialogViewModel.ShowNewFolderButton
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
                throw new ArgumentNullException("owner");

            DialogResult result = folderBrowserDialog.ShowDialog(owner);

            // Update view model
            folderBrowserDialogViewModel.SelectedPath = folderBrowserDialog.SelectedPath;

            return result;
        }
        
        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (folderBrowserDialog != null)
            {
                folderBrowserDialog.Dispose();
            }
        }

        #endregion
    }
}