using System;
using System.Windows;
using Microsoft.Win32;

namespace MvvmDialogs.FrameworkDialogs.OpenFile;

/// <summary>
/// Class wrapping <see cref="OpenFileDialog"/>.
/// </summary>
internal sealed class OpenFileDialogWrapper : IFrameworkDialog
{
    private readonly OpenFileDialog dialog;
    private readonly OpenFileDialogSettingsSync sync;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenFileDialogWrapper"/> class.
    /// </summary>
    /// <param name="settings">The settings for the open file dialog.</param>
    public OpenFileDialogWrapper(OpenFileDialogSettings settings)
    {
        dialog = new OpenFileDialog();
        sync = new OpenFileDialogSettingsSync(dialog, settings);

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