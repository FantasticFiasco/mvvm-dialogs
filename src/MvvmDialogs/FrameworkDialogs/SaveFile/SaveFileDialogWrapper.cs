using System;
using System.Windows;
using Microsoft.Win32;

namespace MvvmDialogs.FrameworkDialogs.SaveFile
{
    /// <summary>
    /// Class wrapping <see cref="SaveFileDialog"/>, making it accept a view model.
    /// </summary>
    internal sealed class SaveFileDialogWrapper
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

            bool? result = saveFileDialog.ShowDialog(owner);

            // Update view model
            saveFileDialogViewModel.FileName = saveFileDialog.FileName;
            saveFileDialogViewModel.FileNames = saveFileDialog.FileNames;

            return result;
        }
    }
}