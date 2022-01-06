using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;

namespace Sample.CustomOpenFileDialog
{
    public class CustomFrameworkDialogFactory : DefaultFrameworkDialogFactory
    {
        public override IFrameworkDialog CreateOpenFileDialog(OpenFileDialogSettings settings)
        {
            return new CustomOpenFileDialog(settings);
        }
    }
}
