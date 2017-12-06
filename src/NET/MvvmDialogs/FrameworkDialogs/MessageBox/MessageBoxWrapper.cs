using System;
using System.Windows;
using WinMessageBox = System.Windows.MessageBox;

namespace MvvmDialogs.FrameworkDialogs.MessageBox
{
    /// <summary>
    /// Class wrapping <see cref="WinMessageBox"/>.
    /// </summary>
    internal sealed class MessageBoxWrapper : IMessageBox
    {
        private readonly MessageBoxSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public MessageBoxWrapper(MessageBoxSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <summary>
        /// Opens a message box with specified owner.
        /// </summary>
        /// <param name="owner">
        /// Handle to the window that owns the dialog.
        /// </param>
        /// <returns>
        /// A <see cref="MessageBoxResult"/> value that specifies which message box button is
        /// clicked by the user.
        /// </returns>
        public MessageBoxResult Show(Window owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            return WinMessageBox.Show(
                owner,
                settings.MessageBoxText,
                settings.Caption,
                settings.Button,
                settings.Icon,
                settings.DefaultResult);
        }
    }
}