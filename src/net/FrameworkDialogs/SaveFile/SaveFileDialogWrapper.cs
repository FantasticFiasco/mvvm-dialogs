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
        private readonly SaveFileDialog dialog;
        private readonly SaveFileDialogSettingsSync sync;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveFileDialogWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the save file dialog.</param>
        public SaveFileDialogWrapper(SaveFileDialogSettings settings)
        {
            dialog = new SaveFileDialog();
            sync = new SaveFileDialogSettingsSync(dialog, settings);

            // Update dialog
            sync.ToDialog();
        }

        /// <inheritdoc />
        public bool? ShowDialog(Window owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            bool? result = dialog.ShowDialog(owner);

            // Update settings
            sync.ToSettings();

            return result;
        }
    }
}
