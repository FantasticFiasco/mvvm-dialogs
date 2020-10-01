using System;
using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    /// <summary>
    /// Class responsible for synchronizing settings between
    /// <see cref="FolderBrowserDialogSettings" /> and <see cref="FolderBrowserDialog" />.
    /// </summary>
    internal class FolderBrowserDialogSettingsSync
    {
        private readonly FolderBrowserDialog dialog;
        private readonly FolderBrowserDialogSettings settings;

        public FolderBrowserDialogSettingsSync(FolderBrowserDialog dialog, FolderBrowserDialogSettings settings)
        {
            this.dialog = dialog ?? throw new ArgumentNullException(nameof(dialog));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public void ToDialog()
        {
            dialog.Description = settings.Description;
            dialog.RootFolder = settings.RootFolder;
            dialog.SelectedPath = settings.SelectedPath;
            dialog.ShowNewFolderButton = settings.ShowNewFolderButton;
        }

        public void ToSettings() => settings.SelectedPath = dialog.SelectedPath;
    }
}
