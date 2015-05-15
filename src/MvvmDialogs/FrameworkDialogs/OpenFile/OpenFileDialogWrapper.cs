using System;
using System.Windows;
using Microsoft.Win32;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    /// <summary>
    /// Class wrapping <see cref="OpenFileDialog"/>, making it accept a view model.
    /// </summary>
    internal sealed class OpenFileDialogWrapper
    {
        private readonly OpenFileDialogViewModel openFileDialogViewModel;
        private readonly OpenFileDialog openFileDialog;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFileDialogWrapper"/> class.
        /// </summary>
        /// <param name="openFileDialogViewModel">
        /// The open file dialog view model.
        /// </param>
        public OpenFileDialogWrapper(OpenFileDialogViewModel openFileDialogViewModel)
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
        /// Handle to the window that owns the dialog.
        /// </param>
        /// <returns>
        /// If the user clicks the OK button of the dialog that is displayed, true is returned;
        /// otherwise false.
        /// </returns>
        public bool? ShowDialog(Window owner)
        {
            if (owner == null)
                throw new ArgumentNullException("owner");

            bool? result = openFileDialog.ShowDialog(owner);

            // Update view model
            openFileDialogViewModel.FileName = openFileDialog.FileName;
            openFileDialogViewModel.FileNames = openFileDialog.FileNames;

            return result;
        }
    }
}