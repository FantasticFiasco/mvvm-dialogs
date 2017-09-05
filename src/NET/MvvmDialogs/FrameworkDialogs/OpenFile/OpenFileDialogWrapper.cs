using System;
using System.Windows;
using Microsoft.Win32;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    /// <summary>
    /// Class wrapping <see cref="OpenFileDialog"/>.
    /// </summary>
    internal sealed class OpenFileDialogWrapper
    {
        private readonly OpenFileDialogSettings settings;
        private readonly OpenFileDialog openFileDialog;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFileDialogWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the open file dialog.</param>
        public OpenFileDialogWrapper(OpenFileDialogSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            this.settings = settings;

            openFileDialog = new OpenFileDialog
            {
                AddExtension = settings.AddExtension,
                CheckFileExists = settings.CheckFileExists,
                CheckPathExists = settings.CheckPathExists,
                DefaultExt = settings.DefaultExt,
                FileName = settings.FileName,
                Filter = settings.Filter,
                FilterIndex = settings.FilterIndex,
                InitialDirectory = settings.InitialDirectory,
                Multiselect = settings.Multiselect,
                Title = settings.Title
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
                throw new ArgumentNullException(nameof(owner));

            bool? result = openFileDialog.ShowDialog(owner);

            // Update settings
            settings.FileName = openFileDialog.FileName;
            settings.FileNames = openFileDialog.FileNames;

            return result;
        }
    }
}