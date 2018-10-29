using System;
using System.Windows;
using Microsoft.Win32;

namespace MvvmDialogs.FrameworkDialogs.SaveFile
{
    /// <summary>
    /// Class wrapping <see cref="SaveFileDialog"/>.
    /// </summary>
    internal sealed class SaveFileDialogWrapper : IFrameworkDialog
    {
        private readonly SaveFileDialogSettings settings;
        private readonly SaveFileDialog saveFileDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveFileDialogWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the save file dialog.</param>
        public SaveFileDialogWrapper(SaveFileDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

            saveFileDialog = new SaveFileDialog
            {
                AddExtension = settings.AddExtension,
                CheckFileExists = settings.CheckFileExists,
                CheckPathExists = settings.CheckPathExists,
                CreatePrompt = settings.CreatePrompt,
                DefaultExt = settings.DefaultExt,
                FileName = settings.FileName,
                Filter = settings.Filter,
                FilterIndex = settings.FilterIndex,
                InitialDirectory = settings.InitialDirectory,
                OverwritePrompt = settings.OverwritePrompt,
                Title = settings.Title
            };
        }

        /// <inheritdoc />
        public bool? ShowDialog(Window owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            bool? result = saveFileDialog.ShowDialog(owner);

            // Update settings
            settings.FileName = saveFileDialog.FileName;
            settings.FileNames = saveFileDialog.FileNames;

            return result;
        }
    }
}
