using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using MvvmDialogs.FrameworkDialogs.MessageBox;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.FrameworkDialogs.SaveFile;

namespace MvvmDialogs.FrameworkDialogs
{
    /// <summary>
    /// Default framework dialog factory that will create instances of standard Windows dialogs.
    /// </summary>
    public class DefaultFrameworkDialogFactory : IFrameworkDialogFactory
    {
        /// <summary>
        /// Create an instance of the Windows message box.
        /// </summary>
        /// <param name="settings">The settings for the message box.</param>
        public virtual IMessageBox CreateMessageBox(MessageBoxSettings settings)
        {
            return new MessageBoxWrapper(settings);
        }

        /// <summary>
        /// Create an instance of the Windows open file dialog.
        /// </summary>
        /// <param name="settings">The settings for the open file dialog.</param>
        public virtual IFrameworkDialog CreateOpenFileDialog(OpenFileDialogSettings settings)
        {
            return new OpenFileDialogWrapper(settings);
        }

        /// <summary>
        /// Create an instance of the Windows save file dialog.
        /// </summary>
        /// <param name="settings">The settings for the save file dialog.</param>
        public virtual IFrameworkDialog CreateSaveFileDialog(SaveFileDialogSettings settings)
        {
            return new SaveFileDialogWrapper(settings);
        }

        /// <summary>
        /// Create an instance of the Windows folder browser dialog.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public virtual IFrameworkDialog CreateFolderBrowserDialog(FolderBrowserDialogSettings settings)
        {
            return new FolderBrowserDialogWrapper(settings);
        }
    }
}
