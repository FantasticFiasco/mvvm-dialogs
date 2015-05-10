using System;
using System.Diagnostics.Contracts;
using System.Windows.Forms;
using WinFormsOpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    /// <summary>
    /// Class wrapping System.Windows.Forms.OpenFileDialog, making it accept a IOpenFileDialog.
    /// </summary>
    public class OpenFileDialog : IDisposable
    {
        private readonly IOpenFileDialog openFileDialog;
        private WinFormsOpenFileDialog concreteOpenFileDialog;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFileDialog"/> class.
        /// </summary>
        /// <param name="openFileDialog">The interface of a open file dialog.</param>
        public OpenFileDialog(IOpenFileDialog openFileDialog)
        {
            Contract.Requires(openFileDialog != null);

            this.openFileDialog = openFileDialog;

            // Create concrete OpenFileDialog
            concreteOpenFileDialog = new WinFormsOpenFileDialog
            {
                AddExtension = openFileDialog.AddExtension,
                CheckFileExists = openFileDialog.CheckFileExists,
                CheckPathExists = openFileDialog.CheckPathExists,
                DefaultExt = openFileDialog.DefaultExt,
                FileName = openFileDialog.FileName,
                Filter = openFileDialog.Filter,
                InitialDirectory = openFileDialog.InitialDirectory,
                Multiselect = openFileDialog.Multiselect,
                Title = openFileDialog.Title
            };
        }

        /// <summary>
        /// Runs a common dialog box with the specified owner.
        /// </summary>
        /// <param name="owner">
        /// Any object that implements System.Windows.Forms.IWin32Window that represents the top-level
        /// window that will own the modal dialog box.
        /// </param>
        /// <returns>
        /// System.Windows.Forms.DialogResult.OK if the user clicks OK in the dialog box; otherwise,
        /// System.Windows.Forms.DialogResult.Cancel.
        /// </returns>
        public DialogResult ShowDialog(IWin32Window owner)
        {
            Contract.Requires(owner != null);

            DialogResult result = concreteOpenFileDialog.ShowDialog(owner);

            // Update view model
            openFileDialog.FileName = concreteOpenFileDialog.FileName;
            openFileDialog.FileNames = concreteOpenFileDialog.FileNames;

            return result;
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="OpenFileDialog"/> class.
        /// </summary>
        ~OpenFileDialog()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release
        /// only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (concreteOpenFileDialog != null)
                {
                    concreteOpenFileDialog.Dispose();
                    concreteOpenFileDialog = null;
                }
            }
        }

        #endregion
    }
}