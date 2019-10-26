using System;
using System.Windows;
using Microsoft.Win32;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;

namespace Demo.CustomOpenFileDialog
{
    /// <remarks>
    /// This sample differs from the .NET Framework equivalent. The reason for that is that the
    /// dependency Ookii.Dialogs.Wpf currently doesn't support .NET Core 3.
    /// </remarks>
    public class CustomOpenFileDialog : IFrameworkDialog
    {
        private readonly OpenFileDialogSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomOpenFileDialog"/> class.
        /// </summary>
        /// <param name="settings">The settings for the open file dialog.</param>
        public CustomOpenFileDialog(OpenFileDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
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
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            var dialog = new OpenFileDialog
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

            var result = dialog.ShowDialog(owner);

            // Update settings
            settings.FileName = dialog.FileName;
            settings.FileNames = dialog.FileNames;
            settings.FilterIndex = dialog.FilterIndex;

            return result;
        }
    }
}
