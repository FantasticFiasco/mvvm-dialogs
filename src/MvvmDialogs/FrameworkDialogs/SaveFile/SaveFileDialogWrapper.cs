using System;
using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.SaveFile
{
    /// <summary>
    /// Class wrapping <see cref="SaveFileDialog"/>, making it accept a view model.
    /// </summary>
    internal sealed class SaveFileDialogWrapper : IDisposable
    {
        private readonly SaveFileDialogViewModel saveFileDialogViewModel;
        private readonly SaveFileDialog saveFileDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveFileDialogWrapper"/> class.
        /// </summary>
        /// <param name="saveFileDialogViewModel">The save file dialog view model.</param>
        public SaveFileDialogWrapper(SaveFileDialogViewModel saveFileDialogViewModel)
        {
            if (saveFileDialogViewModel == null)
                throw new ArgumentNullException("saveFileDialogViewModel");

            this.saveFileDialogViewModel = saveFileDialogViewModel;

            saveFileDialog = new SaveFileDialog
            {
                AddExtension = saveFileDialogViewModel.AddExtension,
                CheckFileExists = saveFileDialogViewModel.CheckFileExists,
                CheckPathExists = saveFileDialogViewModel.CheckPathExists,
                CreatePrompt = saveFileDialogViewModel.CreatePrompt,
                DefaultExt = saveFileDialogViewModel.DefaultExt,
                FileName = saveFileDialogViewModel.FileName,
                Filter = saveFileDialogViewModel.Filter,
                InitialDirectory = saveFileDialogViewModel.InitialDirectory,
                OverwritePrompt = saveFileDialogViewModel.OverwritePrompt,
                Title = saveFileDialogViewModel.Title
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

            DialogResult result = saveFileDialog.ShowDialog(owner);

            // Update view model
            saveFileDialogViewModel.FileName = saveFileDialog.FileName;
            saveFileDialogViewModel.FileNames = saveFileDialog.FileNames;

            return result;
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (saveFileDialog != null)
            {
                saveFileDialog.Dispose();
            }
        }

        #endregion
    }
}