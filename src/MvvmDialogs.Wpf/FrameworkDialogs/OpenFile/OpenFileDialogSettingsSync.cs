using System;
using Microsoft.Win32;

namespace MvvmDialogs.FrameworkDialogs.OpenFile
{
    /// <summary>
    /// Class responsible for synchronizing settings between <see cref="OpenFileDialogSettings" />
    /// and <see cref="OpenFileDialog" />.
    /// </summary>
    internal class OpenFileDialogSettingsSync
    {
        private readonly OpenFileDialog dialog;
        private readonly OpenFileDialogSettings settings;

        public OpenFileDialogSettingsSync(OpenFileDialog dialog, OpenFileDialogSettings settings)
        {
            this.dialog = dialog ?? throw new ArgumentNullException(nameof(dialog));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public void ToDialog()
        {
            dialog.AddExtension = settings.AddExtension;
            dialog.CheckFileExists = settings.CheckFileExists;
            dialog.CheckPathExists = settings.CheckPathExists;
            dialog.CustomPlaces = settings.CustomPlaces;
            dialog.DefaultExt = settings.DefaultExt;
            dialog.DereferenceLinks = settings.DereferenceLinks;
            dialog.FileName = settings.FileName;
            dialog.Filter = settings.Filter;
            dialog.FilterIndex = settings.FilterIndex;
            dialog.InitialDirectory = settings.InitialDirectory;
            dialog.Multiselect = settings.Multiselect;
            dialog.ReadOnlyChecked = settings.ReadOnlyChecked;
            dialog.ShowReadOnly = settings.ShowReadOnly;
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
