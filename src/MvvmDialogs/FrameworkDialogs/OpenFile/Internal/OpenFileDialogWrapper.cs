using System;
using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.OpenFile.Internal
{
    /// <summary>
    /// Class wrapping <see cref="OpenFileDialog"/>, making it accept a view model.
    /// </summary>
    internal sealed class OpenFileDialogWrapper : IDisposable
    {
        private readonly IOpenFileDialogViewModel openFileDialogViewModel;
        private readonly OpenFileDialog openFileDialog;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFileDialogWrapper"/> class.
        /// </summary>
        /// <param name="openFileDialogViewModel">
        /// The open file dialog view model.
        /// </param>
        public OpenFileDialogWrapper(IOpenFileDialogViewModel openFileDialogViewModel)
        {
            if (openFileDialogViewModel == null)
                throw new ArgumentNullException("openFileDialogViewModel");

            this.openFileDialogViewModel = openFileDialogViewModel;

            openFileDialog = new OpenFileDialog
            {
                AddExtension = openFileDialogViewModel.AddExtension,
                CheckFileExists = openFileDialogViewModel.CheckFileExists,
                CheckPathExists = openFileDialogViewModel.CheckPathExists,
                DefaultExt = openFileDialogViewModel.DefaultExt,
                FileName = openFileDialogViewModel.FileName,
                Filter = openFileDialogViewModel.Filter,
                InitialDirectory = openFileDialogViewModel.InitialDirectory,
                Multiselect = openFileDialogViewModel.Multiselect,
                Title = openFileDialogViewModel.Title
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

            DialogResult result = openFileDialog.ShowDialog(owner);

            // Update view model
            openFileDialogViewModel.FileName = openFileDialog.FileName;
            openFileDialogViewModel.FileNames = openFileDialog.FileNames;

            return result;
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (openFileDialog != null)
            {
                openFileDialog.Dispose();
            }
        }

        #endregion
    }
}