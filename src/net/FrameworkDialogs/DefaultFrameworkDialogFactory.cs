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
        /// <inheritdoc />
        public virtual IMessageBox CreateMessageBox(MessageBoxSettings settings) => new MessageBoxWrapper(settings);

        /// <inheritdoc />
        public virtual IFrameworkDialog CreateOpenFileDialog(OpenFileDialogSettings settings) => new OpenFileDialogWrapper(settings);

        /// <inheritdoc />
        public virtual IFrameworkDialog CreateSaveFileDialog(SaveFileDialogSettings settings) => new SaveFileDialogWrapper(settings);

        /// <inheritdoc />
        public virtual IFrameworkDialog CreateFolderBrowserDialog(FolderBrowserDialogSettings settings) => new FolderBrowserDialogWrapper(settings);
    }
}
