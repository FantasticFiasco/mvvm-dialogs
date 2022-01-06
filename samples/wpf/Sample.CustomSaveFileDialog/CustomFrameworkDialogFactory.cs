using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;

namespace Sample.CustomSaveFileDialog
{
    public class CustomFrameworkDialogFactory : DefaultFrameworkDialogFactory
    {
        public override IFrameworkDialog CreateSaveFileDialog(SaveFileDialogSettings settings)
        {
            return new CustomSaveFileDialog(settings);
        }
    }
}
