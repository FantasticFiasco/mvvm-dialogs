using System;
using System.Windows;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomFolderBrowserDialog
{
    public class CustomFolderBrowserDialog : IFrameworkDialog
    {
        private readonly FolderBrowserDialogSettings settings;
        private readonly VistaFolderBrowserDialog folderBrowserDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderBrowserDialogWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public CustomFolderBrowserDialog(FolderBrowserDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

            folderBrowserDialog = new VistaFolderBrowserDialog
            {
                Description = settings.Description,
                SelectedPath = settings.SelectedPath,
                ShowNewFolderButton = settings.ShowNewFolderButton
            };
        }

        /// <summary>
        /// Opens a folder browser dialog with specified owner.
        /// </summary>
        /// <param name="owner">
        /// Handle to the window that owns the dialog.
        /// </param>
        /// <returns>
        /// true if user clicks the OK or YES button; otherwise false.
        /// </returns>
        public bool? ShowDialog(Window owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            var result = folderBrowserDialog.ShowDialog(owner);

            // Update settings
            settings.SelectedPath = folderBrowserDialog.SelectedPath;

            return result;
        }
    }
}
