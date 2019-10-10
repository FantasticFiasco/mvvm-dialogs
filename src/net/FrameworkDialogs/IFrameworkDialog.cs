using System.Windows;

namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Interface representing a framework dialog.
    /// </summary>
    public interface IFrameworkDialog
    {
        /// <summary>
        /// Opens a framework dialog with specified owner.
        /// </summary>
        /// <param name="owner">
        /// Handle to the window that owns the dialog.
        /// </param>
        /// <returns>
        /// true if user clicks the OK button; otherwise false.
        /// </returns>
        bool? ShowDialog(Window owner);
    }
}
