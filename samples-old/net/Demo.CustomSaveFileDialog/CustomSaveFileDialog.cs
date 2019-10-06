using System;
using System.Windows;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomSaveFileDialog
{
    public class CustomSaveFileDialog : IFrameworkDialog
    {
        private readonly SaveFileDialogSettings settings;
        private readonly VistaSaveFileDialog saveFileDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSaveFileDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the save file dialog.</param>
        public CustomSaveFileDialog(SaveFileDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

            saveFileDialog = new VistaSaveFileDialog
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

        /// <summary>
        /// Opens a save file dialog with specified owner.
        /// </summary>
        /// <param name="owner">
        /// Handle to the window that owns the dialog.
        /// </param>
        /// <returns>
        /// true if user clicks the OK button; otherwise false.
        /// </returns>
        public bool? ShowDialog(Window owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            var result = saveFileDialog.ShowDialog(owner);

            // Update settings
            settings.FileName = saveFileDialog.FileName;
            settings.FileNames = saveFileDialog.FileNames;
            settings.FilterIndex = saveFileDialog.FilterIndex;

            return result;
        }
    }
}
