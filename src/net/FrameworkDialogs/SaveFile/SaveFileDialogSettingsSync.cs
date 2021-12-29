using System;
using Microsoft.Win32;

namespace MvvmDialogs.FrameworkDialogs.SaveFile
{
    /// <summary>
    /// Class responsible for synchronizing settings between <see cref="SaveFileDialogSettings" />
    /// and <see cref="SaveFileDialog" />.
    /// </summary>
    internal class SaveFileDialogSettingsSync
    {
        private readonly SaveFileDialog dialog;
        private readonly SaveFileDialogSettings settings;

        public SaveFileDialogSettingsSync(SaveFileDialog dialog, SaveFileDialogSettings settings)
        {
            this.dialog = dialog ?? throw new ArgumentNullException(nameof(dialog));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public void ToDialog()
        {
            dialog.AddExtension = settings.AddExtension;
            dialog.CheckFileExists = settings.CheckFileExists;
            dialog.CheckPathExists = settings.CheckPathExists;
            dialog.CreatePrompt = settings.CreatePrompt;
            dialog.CustomPlaces = settings.CustomPlaces;
            dialog.DefaultExt = settings.DefaultExt;
            dialog.DereferenceLinks = settings.DereferenceLinks;
            dialog.FileName = settings.FileName;
            dialog.Filter = settings.Filter;
            dialog.FilterIndex = settings.FilterIndex;
            dialog.InitialDirectory = settings.InitialDirectory;
            dialog.OverwritePrompt = settings.OverwritePrompt;
            dialog.Title = settings.Title;
            dialog.ValidateNames = settings.ValidateNames;
        }

        public void ToSettings()
        {
            settings.FileName = dialog.FileName;
            settings.FileNames = dialog.FileNames;
            settings.FilterIndex = dialog.FilterIndex;
            settings.SafeFileName = dialog.SafeFileName;
            settings.SafeFileNames = dialog.SafeFileNames;
        }
    }
}
