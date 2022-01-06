using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;

namespace Sample.CustomFolderBrowserDialog
{
    public class CustomFrameworkDialogFactory : DefaultFrameworkDialogFactory
    {
        public override IFrameworkDialog CreateFolderBrowserDialog(FolderBrowserDialogSettings settings)
        {
            return new CustomFolderBrowserDialog(settings);
        }
    }
}
