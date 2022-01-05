using System.Windows;

namespace MvvmDialogs.FrameworkDialogs.MessageBox
{
    /// <summary>
    /// Interface representing a message box.
    /// </summary>
    public interface IMessageBox
    {
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
        MessageBoxResult Show(Window owner);
    }
}
