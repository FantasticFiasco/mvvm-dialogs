using System;
using System.Windows;
using Microsoft.Win32;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;

namespace Demo.CustomSaveFileDialog
{
    /// <remarks>
    /// This sample differs from the .NET Framework equivalent. The reason for that is that the
    /// dependency Ookii.Dialogs.Wpf currently doesn't support .NET Core 3.
    /// </remarks>
    public class CustomSaveFileDialog : IFrameworkDialog
    {
        private readonly SaveFileDialogSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSaveFileDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the save file dialog.</param>
        public CustomSaveFileDialog(SaveFileDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
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

            var dialog = new SaveFileDialog
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
            
            var result = dialog.ShowDialog(owner);

            // Update settings
            settings.FileName = dialog.FileName;
            settings.FileNames = dialog.FileNames;
            settings.FilterIndex = dialog.FilterIndex;

            return result;
        }
    }
}
