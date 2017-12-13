using System;
using System.Windows;
using Microsoft.Win32;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    /// <summary>
    /// Class wrapping <see cref="OpenFileDialog"/>.
    /// </summary>
    internal sealed class OpenFileDialogWrapper : IFrameworkDialog
    {
        private readonly OpenFileDialogSettings settings;
        private readonly OpenFileDialog openFileDialog;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFileDialogWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the open file dialog.</param>
        public OpenFileDialogWrapper(OpenFileDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

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
        /// Opens a open file dialog with specified owner.
        /// </summary>
        /// <param name="owner">
        /// Handle to the window that owns the dialog.
        /// </param>
        /// <returns>
        /// true if user clicks the OK button; otherwise false.
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