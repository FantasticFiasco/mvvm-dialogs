using System;
using System.Windows;
using System.Windows.Forms;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;

namespace Demo.CustomFolderBrowserDialog
{
    /// <remarks>
    /// This sample differs from the .NET Framework equivalent. The reason for that is that the
    /// dependency Ookii.Dialogs.Wpf currently doesn't support .NET Core 3.
    /// </remarks>
    public class CustomFolderBrowserDialog : IFrameworkDialog
    {
        private readonly FolderBrowserDialogSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderBrowserDialogWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public CustomFolderBrowserDialog(FolderBrowserDialogSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
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

            using (var dialog = new FolderBrowserDialog())
            {
                // Update dialog
                dialog.Description = settings.Description;
                dialog.SelectedPath = settings.SelectedPath;
                dialog.ShowNewFolderButton = settings.ShowNewFolderButton;

                // Show dialog
                var result = dialog.ShowDialog(new Win32Window(owner));

                // Update settings
                settings.SelectedPath = dialog.SelectedPath;

                switch (result)
                {
                    case DialogResult.OK:
                    case DialogResult.Yes:
                        return true;

                    case DialogResult.No:
                    case DialogResult.Abort:
                        return false;

                    default:
                        return null;
                }
            }
        }
    }
}
